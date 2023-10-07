using System;
using System.Collections.Generic;
using System.Text;

namespace Everyone
{
    public class JSONTokenizer : IteratorBase<JSONToken, JSONTokenizer>
    {
        private readonly Iterator<char> characters;
        private JSONToken? current;
        private bool disposed;
        private bool started;

        private JSONTokenizer(Iterator<char> characters)
        {
            Pre.Condition.AssertNotNull(characters, nameof(characters));

            this.characters = characters;
        }

        public static JSONTokenizer Create(IEnumerable<char> characters)
        {
            Pre.Condition.AssertNotNull(characters, nameof(characters));

            return JSONTokenizer.Create(characters.Iterate());
        }

        public static JSONTokenizer Create(Iterator<char> characters)
        {
            Pre.Condition.AssertNotNull(characters, nameof(characters));

            return new JSONTokenizer(characters);
        }

        public override bool Dispose()
        {
            bool result = !this.Disposed;
            if (result)
            {
                this.disposed = true;
                
                this.current = null;
                this.characters.Dispose();
            }
            return result;
        }

        public override JSONToken Current
        {
            get
            {
                Pre.Condition.AssertTrue(this.HasCurrent(), "this.HasCurrent()");

                return this.current!;
            }
        }

        private char CurrentCharacter
        {
            get { return this.characters.Current; }
        }

        public override bool Disposed => this.disposed;

        public override bool HasCurrent()
        {
            return this.current != null;
        }

        public override bool HasStarted()
        {
            return this.started;
        }

        private bool HasCurrentCharacter()
        {
            return this.characters.HasCurrent();
        }

        private bool NextCharacter()
        {
            return this.characters.Next();
        }

        private char TakeCurrentCharacter()
        {
            return this.characters.TakeCurrent();
        }

        public override bool Next()
        {
            this.started = true;

            this.characters.Start();

            if (!this.HasCurrentCharacter())
            {
                this.current = null;
            }
            else
            {
                switch (this.CurrentCharacter)
                {
                    case '{':
                        this.current = JSONToken.LeftCurlyBracket;
                        this.NextCharacter();
                        break;

                    case '}':
                        this.current = JSONToken.RightCurlyBracket;
                        this.NextCharacter();
                        break;

                    case '[':
                        this.current = JSONToken.LeftSquareBracket;
                        this.NextCharacter();
                        break;

                    case ']':
                        this.current = JSONToken.RightSquareBracket;
                        this.NextCharacter();
                        break;

                    case ':':
                        this.current = JSONToken.Colon;
                        this.NextCharacter();
                        break;

                    case ',':
                        this.current = JSONToken.Comma;
                        this.NextCharacter();
                        break;

                    case '\'':
                    case '"':
                        this.current = this.ParseQuotedString();
                        break;

                    case '-':
                    case '+':
                    case '.':
                        this.current = this.ParseNumber();
                        break;

                    default:
                        if (JSON.IsWhitespace(this.CurrentCharacter))
                        {
                            this.current = JSONToken.Whitespace(this.ReadWhile(JSON.IsWhitespace));
                        }
                        else if (JSON.IsLetter(this.CurrentCharacter))
                        {
                            string letters = this.ReadWhile(JSON.IsLetter);
                            if (letters.Equals("null"))
                            {
                                this.current = JSONToken.Null;
                            }
                            else if (letters.Equals("false"))
                            {
                                this.current = JSONBoolean.False;
                            }
                            else if (letters.Equals("true"))
                            {
                                this.current = JSONBoolean.True;
                            }
                            else
                            {
                                this.current = JSONToken.Unknown(letters);
                            }
                        }
                        else if (JSON.IsDigit(this.CurrentCharacter))
                        {
                            this.current = this.ParseNumber();
                        }
                        else
                        {
                            this.current = JSONToken.Unknown(this.TakeCurrentCharacter().ToString());
                        }
                        break;
                }
            }
            return this.HasCurrent();
        }

        private JSONString ParseQuotedString()
        {
            Pre.Condition.AssertTrue(this.HasCurrentCharacter(), "this.HasCurrentCharacter()");
            Pre.Condition.AssertOneOf(this.CurrentCharacter, new[] { '\'', '"' }, "this.CurrentCharacter");

            StringBuilder builder = new StringBuilder();
            char startQuote = this.TakeCurrentCharacter();

            builder.Append(startQuote);

            char? endQuote = null;
            bool escaped = false;
            while (this.HasCurrentCharacter())
            {
                switch (this.CurrentCharacter)
                {
                    case '\\':
                        builder.Append(this.TakeCurrentCharacter());
                        escaped = !escaped;
                        break;

                    default:
                        builder.Append(this.CurrentCharacter);
                        if (!escaped && this.CurrentCharacter == startQuote)
                        {
                            endQuote = this.TakeCurrentCharacter();
                            goto quotedStringDone;
                        }
                        this.NextCharacter();
                        break;
                }
            }
            quotedStringDone:

            JSONString result = JSONString.Create(builder.ToString(), endQuote);

            Post.Condition.AssertNotNull(result, nameof(result));

            return result;
        }

        private JSONToken ParseNumber()
        {
            Pre.Condition.AssertTrue(this.HasCurrentCharacter(), "this.HasCurrentCharacter()");
            
            JSONToken result;

            StringBuilder builder = new StringBuilder();

            // Sign
            switch (this.CurrentCharacter)
            {
                case '-':
                case '+':
                    builder.Append(this.TakeCurrentCharacter());
                    break;
            }

            if (!this.HasCurrentCharacter())
            {
                result = JSONToken.Unknown(builder.ToString());
            }
            else
            {
                bool hasIntegerPart = false;
                if (JSON.IsDigit(this.CurrentCharacter))
                {
                    // Integer Part
                    builder.Append(this.ReadWhile(JSON.IsDigit));
                    hasIntegerPart = true;
                }

                bool hasFractionalPart = false;
                if (this.HasCurrentCharacter() && this.CurrentCharacter == '.')
                {
                    // Decimal Point
                    builder.Append(this.TakeCurrentCharacter());

                    if (this.HasCurrentCharacter() && JSON.IsDigit(this.CurrentCharacter))
                    {
                        // Fractional Part
                        builder.Append(this.ReadWhile(JSON.IsDigit));
                        hasFractionalPart = true;
                    }
                }

                if (!hasIntegerPart && !hasFractionalPart)
                {
                    result = JSONToken.Unknown(builder.ToString());
                }
                else
                {
                    if (this.HasCurrentCharacter())
                    {
                        switch (this.CurrentCharacter)
                        {
                            case 'e':
                            case 'E':
                                // Exponent Letter
                                builder.Append(this.TakeCurrentCharacter());

                                if (this.HasCurrentCharacter())
                                {
                                    switch (this.CurrentCharacter)
                                    {
                                        case '-':
                                        case '+':
                                            // Exponent Sign
                                            builder.Append(this.TakeCurrentCharacter());
                                            break;
                                    }
                                }

                                if (this.HasCurrentCharacter() && JSON.IsDigit(this.CurrentCharacter))
                                {
                                    builder.Append(this.ReadWhile(JSON.IsDigit));
                                }
                                break;
                        }
                    }
                    result = JSONNumber.Create(builder.ToString());
                }
            }

            Post.Condition.AssertNotNull(result, nameof(result));

            return result;
        }

        private string ReadWhile(Func<char,bool> condition)
        {
            Pre.Condition.AssertNotNull(condition, nameof(condition));
            Pre.Condition.AssertTrue(condition(this.CurrentCharacter), $"{nameof(condition)}(this.CurrentCharacter)");

            StringBuilder builder = new StringBuilder();
            builder.Append(this.TakeCurrentCharacter());

            while (this.HasCurrentCharacter() && condition(this.CurrentCharacter))
            {
                builder.Append(this.TakeCurrentCharacter());
            }
            string result = builder.ToString();

            Post.Condition.AssertNotNullAndNotEmpty(result, nameof(result));

            return result;
        }
    }
}

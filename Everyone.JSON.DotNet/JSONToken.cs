namespace Everyone
{
    public class JSONToken
    {
        protected JSONToken(string text, JSONTokenType type)
        {
            Pre.Condition.AssertNotNullAndNotEmpty(text, nameof(text));

            this.Text = text;
            this.Type = type;
        }

        public static JSONToken Create(string text, JSONTokenType type)
        {
            return new JSONToken(text, type);
        }

        public string Text { get; }

        public JSONTokenType Type { get; }

        public override string ToString()
        {
            return $"{{\"Type\":\"{this.Type},\"Text\":{this.Text.EscapeAndQuote()}}}";
        }

        public override bool Equals(object? obj)
        {
            return this.Equals(obj as JSONToken);
        }

        public virtual bool Equals(JSONToken? rhs)
        {
            return rhs != null &&
                this.Text == rhs.Text &&
                this.Type == rhs.Type;
        }

        public override int GetHashCode()
        {
            return HashCode.Get(this.Text, this.Type);
        }

        /// <summary>
        /// A left curly bracket ('{') <see cref="JSONToken"/>.
        /// </summary>
        public static readonly JSONToken LeftCurlyBracket = JSONToken.Create("{", JSONTokenType.LeftCurlyBracket);

        /// <summary>
        /// A right curly bracket ('}') <see cref="JSONToken"/>.
        /// </summary>
        public static readonly JSONToken RightCurlyBracket = JSONToken.Create("}", JSONTokenType.RightCurlyBracket);

        /// <summary>
        /// A left square bracket ('[') <see cref="JSONToken"/>.
        /// </summary>
        public static readonly JSONToken LeftSquareBracket = JSONToken.Create("[", JSONTokenType.LeftSquareBracket);

        /// <summary>
        /// A right square bracket (']') <see cref="JSONToken"/>.
        /// </summary>
        public static readonly JSONToken RightSquareBracket = JSONToken.Create("]", JSONTokenType.RightSquareBracket);

        /// <summary>
        /// A colon (':') <see cref="JSONToken"/>.
        /// </summary>
        public static readonly JSONToken Colon = JSONToken.Create(":", JSONTokenType.Colon);

        /// <summary>
        /// A comma (',') <see cref="JSONToken"/>.
        /// </summary>
        public static readonly JSONToken Comma = JSONToken.Create(",", JSONTokenType.Comma);

        /// <summary>
        /// A null ("null") <see cref="JSONToken"/>.
        /// </summary>
        public static readonly JSONToken Null = JSONToken.Create("null", JSONTokenType.Null);
        
        /// <summary>
        /// A whitespace <see cref="JSONToken"/>. This token will not contain carriage returns or
        /// newline characters.
        /// </summary>
        /// <param name="text">The text of the whitespace.</param>
        public static JSONToken Whitespace(string text)
        {
            return JSONToken.Create(text, JSONTokenType.Whitespace);
        }

        /// <summary>
        /// A quoted-string ("\"hello\"") <see cref="JSONString"/>.
        /// </summary>
        /// <param name="quotedText">The text of the quoted string (including the quotes).</param>
        public static JSONString QuotedString(string quotedText, char? endQuote)
        {
            return JSONString.Create(quotedText, endQuote);
        }

        /// <summary>
        /// A boolean ("true" or "false") <see cref="JSONToken"/>.
        /// </summary>
        /// <param name="text">The text of the boolean.</param>
        public static JSONBoolean Boolean(string text)
        {
            return JSONBoolean.Create(text);
        }

        /// <summary>
        /// A boolean ("true" or "false") <see cref="JSONToken"/>.
        /// </summary>
        /// <param name="value">The value of the boolean.</param>
        public static JSONBoolean Boolean(bool value)
        {
            return value ? JSONBoolean.True : JSONBoolean.False;
        }

        /// <summary>
        /// A false ("false") <see cref="JSONToken"/>.
        /// </summary>
        public static readonly JSONBoolean False = JSONBoolean.Create("false");

        /// <summary>
        /// A true ("true") <see cref="JSONToken"/>.
        /// </summary>
        public static readonly JSONBoolean True = JSONBoolean.Create("true");

        /// <summary>
        /// A number ("12.345") <see cref="JSONNumber"/>.
        /// </summary>
        /// <param name="text">The text of the number.</param>
        public static JSONNumber Number(string text)
        {
            return JSONNumber.Create(text);
        }

        /// <summary>
        /// A number ("12.345") <see cref="JSONNumber"/>.
        /// </summary>
        /// <param name="value">The value of the number.</param>
        public static JSONNumber Number(long value)
        {
            return JSONNumber.Create(value);
        }

        /// <summary>
        /// A number ("12.345") <see cref="JSONNumber"/>.
        /// </summary>
        /// <param name="value">The value of the number.</param>
        public static JSONNumber Number(double value)
        {
            return JSONNumber.Create(value);
        }

        /// <summary>
        /// A line comment (// comment text) <see cref="JSONToken"/>.
        /// </summary>
        /// <param name="text">The text of the line comment (not including the terminating newline
        /// or carriage return characters).</param>
        public static JSONToken LineComment(string text)
        {
            return JSONToken.Create(text, JSONTokenType.LineComment);
        }

        /// <summary>
        /// A block comment (/* comment text */) <see cref="JSONToken"/>.
        /// </summary>
        /// <param name="text">The text of the block comment.</param>
        public static JSONToken BlockComment(string text)
        {
            return JSONToken.Create(text, JSONTokenType.BlockComment);
        }

        public static JSONToken Unknown(string text)
        {
            return JSONToken.Create(text, JSONTokenType.Unknown);
        }
    }
}

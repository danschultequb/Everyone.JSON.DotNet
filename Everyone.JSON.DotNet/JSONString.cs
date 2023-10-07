using System.Linq;

namespace Everyone
{
    public class JSONString : JSONToken, JSONValue
    {
        private static readonly char[] quotes = new[] { '\'', '\"' };
        
        protected JSONString(string text, char? endQuote)
            : base(text, JSONTokenType.QuotedString)
        {
            Pre.Condition.AssertOneOf(text.First(), JSONString.quotes, "text.First()");
            Pre.Condition.AssertOneOf(endQuote, new char?[] { null, text.First() }, nameof(endQuote));

            this.EndQuote = endQuote;
            this.Value = text.Substring(1, text.Length - 1 - (endQuote == null ? 0 : 1));
        }

        public static JSONString Create(string text, char? endQuote)
        {
            return new JSONString(text, endQuote);
        }

        /// <summary>
        /// Get the quote character that begins this <see cref="JSONString"/>.
        /// </summary>
        public char StartQuote => this.Text[0];

        /// <summary>
        /// Get the quote character that ends this <see cref="JSONString"/>. This will be null if
        /// this <see cref="JSONString"/> is missing its end quote.
        /// </summary>
        public char? EndQuote { get; }

        /// <summary>
        /// Get the text between this <see cref="JSONString"/>'s quotes.
        /// </summary>
        public string Value { get; }

        public override bool Equals(object? obj)
        {
            return this.Equals(obj as JSONString);
        }

        public override bool Equals(JSONToken? rhs)
        {
            return this.Equals(rhs as JSONString);
        }

        public virtual bool Equals(JSONString? rhs)
        {
            return base.Equals(rhs) &&
                this.EndQuote == rhs?.EndQuote;
        }

        public override int GetHashCode()
        {
            return HashCode.Get(base.GetHashCode(), this.EndQuote);
        }
    }
}

namespace Everyone
{
    public class JSONNumber : JSONToken, JSONValue
    {
        protected JSONNumber(string text)
            : base(text, JSONTokenType.Number)
        {
        }

        public static JSONNumber Create(string text)
        {
            return new JSONNumber(text);
        }

        public static JSONNumber Create(long value)
        {
            return JSONNumber.Create(value.ToString());
        }

        public static JSONNumber Create(double value)
        {
            return JSONNumber.Create(value.ToString());
        }

        public override bool Equals(object? obj)
        {
            return this.Equals(obj as JSONNumber);
        }

        public override bool Equals(JSONToken? rhs)
        {
            return this.Equals(rhs as JSONNumber);
        }

        public virtual bool Equals(JSONNumber? rhs)
        {
            return rhs != null &&
                base.Equals(rhs);
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }
    }
}

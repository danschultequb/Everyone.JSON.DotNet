namespace Everyone
{
    public class JSONBoolean : JSONToken
    {
        protected JSONBoolean(string text)
            : base(text, JSONTokenType.Boolean)
        {
        }

        public static JSONBoolean Create(string text)
        {
            return new JSONBoolean(text);
        }

        public static JSONBoolean Create(bool value)
        {
            return JSONBoolean.Create(value.ToString().ToLower());
        }

        public override bool Equals(object? obj)
        {
            return this.Equals(obj as JSONBoolean);
        }

        public override bool Equals(JSONToken? rhs)
        {
            return this.Equals(rhs as JSONBoolean);
        }

        public virtual bool Equals(JSONBoolean? rhs)
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

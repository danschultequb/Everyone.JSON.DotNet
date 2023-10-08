namespace Everyone
{
    public class JSONNull : JSONValue
    {
        private static readonly JSONNull instance = new JSONNull();

        protected JSONNull()
        {
        }

        public static JSONNull Create()
        {
            return JSONNull.instance;
        }

        public override string ToString()
        {
            return "null";
        }

        public override bool Equals(object? rhs)
        {
            return rhs is JSONNull;
        }

        public override int GetHashCode()
        {
            return HashCode.Get(this.GetType());
        }
    }
}

namespace Everyone
{
    public class JSONNull : JSONValue
    {
        protected JSONNull()
        {
        }

        public static JSONNull Create()
        {
            return new JSONNull();
        }

        public static readonly JSONNull Null = JSONNull.Create();
    }
}

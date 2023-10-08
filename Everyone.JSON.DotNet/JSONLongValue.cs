namespace Everyone
{
    public class JSONLongValue : JSONNumberValue
    {
        private readonly long value;

        protected JSONLongValue(long value)
        {
            this.value = value;
        }

        public static JSONLongValue Create(long value)
        {
            return new JSONLongValue(value);
        }

        public long GetValue()
        {
            return this.value;
        }

        public override string ToString()
        {
            return this.value.ToString();
        }

        public override bool Equals(object? obj)
        {
            return obj is JSONLongValue rhsJson &&
                this.value == rhsJson.value;
        }

        public override int GetHashCode()
        {
            return HashCode.Get(this.GetType(), this.value);
        }
    }
}

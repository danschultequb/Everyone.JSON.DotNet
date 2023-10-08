namespace Everyone
{
    public class JSONDoubleValue : JSONNumberValue
    {
        private readonly double value;

        protected JSONDoubleValue(double value)
        {
            this.value = value;
        }

        public static JSONDoubleValue Create(double value)
        {
            return new JSONDoubleValue(value);
        }

        public double GetValue()
        {
            return this.value;
        }

        public override string ToString()
        {
            return this.value.ToString();
        }

        public override bool Equals(object? rhs)
        {
            return rhs is JSONDoubleValue rhsJson &&
                this.value == rhsJson.value;
        }

        public override int GetHashCode()
        {
            return HashCode.Get(this.GetType(), this.value);
        }
    }
}

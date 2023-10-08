namespace Everyone
{
    /// <summary>
    /// A JSON boolean value.
    /// </summary>
    public class JSONBooleanValue : JSONValue
    {
        private readonly bool value;

        protected JSONBooleanValue(bool value)
        {
            this.value = value;
        }

        public static JSONBooleanValue Create(bool value)
        {
            return value ? JSONBooleanValue.True : JSONBooleanValue.False;
        }

        public static readonly JSONBooleanValue True = new JSONBooleanValue(true);
        public static readonly JSONBooleanValue False = new JSONBooleanValue(false);

        /// <summary>
        /// Get the <see cref="bool"/> value of this <see cref="JSONBooleanValue"/>.
        /// </summary>
        public bool GetValue()
        {
            return this.value;
        }

        public override string ToString()
        {
            return this.value ? "true" : "false";
        }

        public override bool Equals(object? rhs)
        {
            return rhs is JSONBooleanValue rhsJson &&
                this.value == rhsJson.value;
        }

        public override int GetHashCode()
        {
            return HashCode.Get(this.GetType(), this.value);
        }
    }
}

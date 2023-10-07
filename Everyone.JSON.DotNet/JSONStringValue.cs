namespace Everyone
{
    /// <summary>
    /// A JSON string value.
    /// </summary>
    public class JSONStringValue : JSONValue
    {
        private readonly string value;

        protected JSONStringValue(string value)
        {
            Pre.Condition.AssertNotNull(value, nameof(value));

            this.value = value;
        }

        public static JSONStringValue Create(string value)
        {
            return new JSONStringValue(value);
        }

        /// <summary>
        /// Get the <see cref="string"/> value of this <see cref="JSONStringValue"/>.
        /// </summary>
        public string GetValue()
        {
            return this.value;
        }
    }
}

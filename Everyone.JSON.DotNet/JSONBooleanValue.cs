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
            return new JSONBooleanValue(value);
        }

        public static readonly JSONBooleanValue True = JSONBooleanValue.Create(true);
        public static readonly JSONBooleanValue False = JSONBooleanValue.Create(false);

        /// <summary>
        /// Get the <see cref="bool"/> value of this <see cref="JSONBooleanValue"/>.
        /// </summary>
        public bool GetValue()
        {
            return this.value;
        }
    }
}

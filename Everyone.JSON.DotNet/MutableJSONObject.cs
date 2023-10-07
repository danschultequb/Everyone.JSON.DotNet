namespace Everyone
{
    /// <summary>
    /// A <see cref="JSONObject"/> that can change its properties.
    /// </summary>
    public class MutableJSONObject : JSONObject
    {
        private readonly MutableMap<string, JSONValue> properties;

        protected MutableJSONObject()
        {
            this.properties = Map.Create<string, JSONValue>();
        }

        public static MutableJSONObject Create()
        {
            return new MutableJSONObject();
        }

        public virtual Result<JSONValue> Get(string propertyName)
        {
            Pre.Condition.AssertNotNullAndNotEmpty(propertyName, nameof(propertyName));

            return this.properties.Get(propertyName);
        }

        /// <summary>
        /// Set the property in this <see cref="MutableJSONObject"/> with the provided name and
        /// value.
        /// </summary>
        /// <param name="propertyName">The name of the property.</param>
        /// <param name="propertyValue">The value of the property.</param>
        /// <returns>This object for method chaining.</returns>
        public virtual MutableJSONObject Set(string propertyName, JSONValue propertyValue)
        {
            Pre.Condition.AssertNotNullAndNotEmpty(propertyName, nameof(propertyName));
            Pre.Condition.AssertNotNull(propertyValue, nameof(propertyValue));

            this.properties.Set(propertyName, propertyValue);

            return this;
        }

        /// <summary>
        /// Set the property in this <see cref="MutableJSONObject"/> with the provided name and
        /// value.
        /// </summary>
        /// <param name="propertyName">The name of the property.</param>
        /// <param name="propertyValue">The value of the property.</param>
        /// <returns>This object for method chaining.</returns>
        public virtual MutableJSONObject Set(string propertyName, bool propertyValue)
        {
            return this.Set(propertyName, JSONBooleanValue.Create(propertyValue));
        }

        /// <summary>
        /// Set the property in this <see cref="MutableJSONObject"/> with the provided name and
        /// value.
        /// </summary>
        /// <param name="propertyName">The name of the property.</param>
        /// <param name="propertyValue">The value of the property.</param>
        /// <returns>This object for method chaining.</returns>
        public virtual MutableJSONObject Set(string propertyName, string propertyValue)
        {
            return this.Set(propertyName, JSONStringValue.Create(propertyValue));
        }

        /// <summary>
        /// Set the property in this <see cref="MutableJSONObject"/> with the provided name and
        /// null value.
        /// </summary>
        /// <param name="propertyName">The name of the property.</param>
        /// <returns>This object for method chaining.</returns>
        public virtual MutableJSONObject SetNull(string propertyName)
        {
            return this.Set(propertyName, JSONNull.Null);
        }
    }
}

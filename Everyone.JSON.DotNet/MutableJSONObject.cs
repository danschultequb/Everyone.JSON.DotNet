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
            return this.Set(propertyName, JSONNull.Create());
        }
    }

    /// <summary>
    /// A collection of extension methods for <see cref="MutableJSONObject"/>s.
    /// </summary>
    public static class MutableJSONObjects
    {
        /// <summary>
        /// Get the <see cref="MutableJSONObject"/> value of the property with the provided name.
        /// </summary>
        /// <param name="jsonObject">The <see cref="MutableJSONObject"/> to get the property value from.</param>
        /// <param name="propertyName">The name of the property to get the
        /// <see cref="MutableJSONObject"/> value of.</param>
        public static Result<MutableJSONObject> GetObject(this MutableJSONObject jsonObject, string propertyName)
        {
            return jsonObject.Get<MutableJSONObject>(propertyName);
        }

        /// <summary>
        /// Get the <see cref="MutableJSONObject"/> value of the property with the provided name.
        /// </summary>
        /// <param name="jsonObject">The <see cref="MutableJSONObject"/> to get the property value from.</param>
        /// <param name="propertyName">The name of the property to get the
        /// <see cref="MutableJSONObject"/> value of.</param>
        public static Result<MutableJSONObject?> GetAsObject(this MutableJSONObject jsonObject, string propertyName)
        {
            return jsonObject.GetAs<MutableJSONObject>(propertyName);
        }

        /// <summary>
        /// Get the <see cref="MutableJSONArray"/> value of the property with the provided name.
        /// </summary>
        /// <param name="jsonObject">The <see cref="MutableJSONObject"/> to get the property value from.</param>
        /// <param name="propertyName">The name of the property to get the
        /// <see cref="MutableJSONArray"/> value of.</param>
        public static Result<MutableJSONArray> GetArray(this MutableJSONObject jsonObject, string propertyName)
        {
            return jsonObject.Get<MutableJSONArray>(propertyName);
        }

        /// <summary>
        /// Get the <see cref="MutableJSONArray"/> value of the property with the provided name.
        /// </summary>
        /// <param name="jsonObject">The <see cref="MutableJSONObject"/> to get the property value from.</param>
        /// <param name="propertyName">The name of the property to get the
        /// <see cref="MutableJSONArray"/> value of.</param>
        public static Result<MutableJSONArray?> GetAsArray(this MutableJSONObject jsonObject, string propertyName)
        {
            return jsonObject.GetAs<MutableJSONArray>(propertyName);
        }
    }
}

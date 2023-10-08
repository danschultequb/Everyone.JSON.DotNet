namespace Everyone
{
    /// <summary>
    /// A read-only JSON object.
    /// </summary>
    public interface JSONObject : JSONValue
    {
        /// <summary>
        /// Create a new <see cref="MutableJSONObject"/>.
        /// </summary>
        public static MutableJSONObject Create()
        {
            return MutableJSONObject.Create();
        }

        /// <summary>
        /// Get the value of the property with the provided name.
        /// </summary>
        /// <param name="propertyName">The name of the property to get the value of.</param>
        public Result<JSONValue> Get(string propertyName);
    }

    /// <summary>
    /// A collection of extension methods for <see cref="JSONObject"/>s.
    /// </summary>
    public static class JSONObjects
    {
        /// <summary>
        /// Get the value of the property with the provided name.
        /// </summary>
        /// <typeparam name="T">The type of <see cref="JSONValue"/> to cast the value to.</typeparam>
        /// <param name="jsonObject">The <see cref="JSONObject"/> to get the property value from.</param>
        /// <param name="propertyName">The name of the property to get the value of.</param>
        public static Result<T> Get<T>(this JSONObject jsonObject, string propertyName)
            where T : JSONValue
        {
            Pre.Condition.AssertNotNull(jsonObject, nameof(jsonObject));
            Pre.Condition.AssertNotNullAndNotEmpty(propertyName, nameof(propertyName));

            return jsonObject.Get(propertyName)
                .Then((JSONValue value) =>
                {
                    return (T)value;
                });
        }

        /// <summary>
        /// Get the value of the property with the provided name.
        /// </summary>
        /// <typeparam name="T">The type of <see cref="JSONValue"/> to try to convert the value to.</typeparam>
        /// <param name="jsonObject">The <see cref="JSONObject"/> to get the property value from.</param>
        /// <param name="propertyName">The name of the property to get the value of.</param>
        public static Result<T?> GetAs<T>(this JSONObject jsonObject, string propertyName)
            where T : class, JSONValue
        {
            Pre.Condition.AssertNotNull(jsonObject, nameof(jsonObject));
            Pre.Condition.AssertNotNullAndNotEmpty(propertyName, nameof(propertyName));

            return jsonObject.Get(propertyName)
                .Then((JSONValue value) =>
                {
                    return value as T;
                });
        }

        /// <summary>
        /// Get the <see cref="JSONObject"/> value of the property with the provided name.
        /// </summary>
        /// <param name="jsonObject">The <see cref="JSONObject"/> to get the property value from.</param>
        /// <param name="propertyName">The name of the property to get the
        /// <see cref="JSONObject"/> value of.</param>
        public static Result<JSONObject> GetObject(this JSONObject jsonObject, string propertyName)
        {
            return jsonObject.Get<JSONObject>(propertyName);
        }

        /// <summary>
        /// Get the <see cref="JSONObject"/> value of the property with the provided name.
        /// </summary>
        /// <param name="jsonObject">The <see cref="JSONObject"/> to get the property value from.</param>
        /// <param name="propertyName">The name of the property to get the
        /// <see cref="JSONObject"/> value of.</param>
        public static Result<JSONObject?> GetAsObject(this JSONObject jsonObject, string propertyName)
        {
            return jsonObject.GetAs<JSONObject>(propertyName);
        }

        /// <summary>
        /// Get the <see cref="JSONArray"/> value of the property with the provided name.
        /// </summary>
        /// <param name="jsonObject">The <see cref="JSONObject"/> to get the property value from.</param>
        /// <param name="propertyName">The name of the property to get the
        /// <see cref="JSONArray"/> value of.</param>
        public static Result<JSONArray> GetArray(this JSONObject jsonObject, string propertyName)
        {
            return jsonObject.Get<JSONArray>(propertyName);
        }

        /// <summary>
        /// Get the <see cref="JSONArray"/> value of the property with the provided name.
        /// </summary>
        /// <param name="jsonObject">The <see cref="JSONObject"/> to get the property value from.</param>
        /// <param name="propertyName">The name of the property to get the
        /// <see cref="JSONArray"/> value of.</param>
        public static Result<JSONArray?> GetAsArray(this JSONObject jsonObject, string propertyName)
        {
            return jsonObject.GetAs<JSONArray>(propertyName);
        }

        /// <summary>
        /// Get the <see cref="bool"/> value of the property with the provided name.
        /// </summary>
        /// <param name="jsonObject">The <see cref="JSONObject"/> to get the property value from.</param>
        /// <param name="propertyName">The name of the property to get the <see cref="bool"/> value
        /// of.</param>
        public static Result<bool> GetBoolean(this JSONObject jsonObject, string propertyName)
        {
            return jsonObject.Get<JSONBooleanValue>(propertyName)
                .Then(jsonValue => jsonValue.GetValue());
        }

        /// <summary>
        /// Get the <see cref="bool"/> value of the property with the provided name.
        /// </summary>
        /// <param name="jsonObject">The <see cref="JSONObject"/> to get the property value from.</param>
        /// <param name="propertyName">The name of the property to get the <see cref="bool"/> value
        /// of.</param>
        public static Result<bool?> GetAsBoolean(this JSONObject jsonObject, string propertyName)
        {
            return jsonObject.GetAs<JSONBooleanValue>(propertyName)
                .Then(jsonValue => jsonValue?.GetValue()); ;
        }

        /// <summary>
        /// Get the <see cref="string"/> value of the property with the provided name.
        /// </summary>
        /// <param name="jsonObject">The <see cref="JSONObject"/> to get the property value from.</param>
        /// <param name="propertyName">The name of the property to get the <see cref="string"/>
        /// value of.</param>
        public static Result<string> GetString(this JSONObject jsonObject, string propertyName)
        {
            return jsonObject.Get<JSONStringValue>(propertyName)
                .Then(jsonValue => jsonValue.GetValue());
        }

        /// <summary>
        /// Get the <see cref="string"/> value of the property with the provided name.
        /// </summary>
        /// <param name="jsonObject">The <see cref="JSONObject"/> to get the property value from.</param>
        /// <param name="propertyName">The name of the property to get the <see cref="string"/>
        /// value of.</param>
        public static Result<string?> GetAsString(this JSONObject jsonObject, string propertyName)
        {
            return jsonObject.GetAs<JSONStringValue>(propertyName)
                .Then(jsonValue => jsonValue?.GetValue()); ;
        }

        /// <summary>
        /// Get the <see cref="JSONNull"/> value of the property with the provided name.
        /// </summary>
        /// <param name="jsonObject">The <see cref="JSONObject"/> to get the property value from.</param>
        /// <param name="propertyName">The name of the property to get the <see cref="JSONNull"/>
        /// value of.</param>
        public static Result<JSONNull> GetNull(this JSONObject jsonObject, string propertyName)
        {
            return jsonObject.Get<JSONNull>(propertyName);
        }

        /// <summary>
        /// Get the <see cref="long"/> value of the property with the provided name.
        /// </summary>
        /// <param name="jsonObject">The <see cref="JSONObject"/> to get the property value from.</param>
        /// <param name="propertyName">The name of the property to get the <see cref="long"/> value
        /// of.</param>
        public static Result<long> GetLong(this JSONObject jsonObject, string propertyName)
        {
            return jsonObject.Get<JSONLongValue>(propertyName)
                .Then(jsonValue => jsonValue.GetValue());
        }

        /// <summary>
        /// Get the <see cref="long"/> value of the property with the provided name.
        /// </summary>
        /// <param name="jsonObject">The <see cref="JSONObject"/> to get the property value from.</param>
        /// <param name="propertyName">The name of the property to get the <see cref="long"/> value
        /// of.</param>
        public static Result<long?> GetAsLong(this JSONObject jsonObject, string propertyName)
        {
            return jsonObject.GetAs<JSONLongValue>(propertyName)
                .Then(jsonValue => jsonValue?.GetValue()); ;
        }

        /// <summary>
        /// Get the <see cref="double"/> value of the property with the provided name.
        /// </summary>
        /// <param name="jsonObject">The <see cref="JSONObject"/> to get the property value from.</param>
        /// <param name="propertyName">The name of the property to get the <see cref="long"/> value
        /// of.</param>
        public static Result<double> GetDouble(this JSONObject jsonObject, string propertyName)
        {
            return jsonObject.Get<JSONDoubleValue>(propertyName)
                .Then(jsonValue => jsonValue.GetValue());
        }

        /// <summary>
        /// Get the <see cref="long"/> value of the property with the provided name.
        /// </summary>
        /// <param name="jsonObject">The <see cref="JSONObject"/> to get the property value from.</param>
        /// <param name="propertyName">The name of the property to get the <see cref="long"/> value
        /// of.</param>
        public static Result<double?> GetAsDouble(this JSONObject jsonObject, string propertyName)
        {
            return jsonObject.GetAs<JSONDoubleValue>(propertyName)
                .Then(jsonValue => jsonValue?.GetValue()); ;
        }
    }
}

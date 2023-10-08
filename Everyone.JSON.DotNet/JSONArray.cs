namespace Everyone
{
    /// <summary>
    /// An array of <see cref="JSONValue"/>s.
    /// </summary>
    public interface JSONArray : Indexable<JSONValue>, JSONValue
    {
        public static MutableJSONArray Create(params JSONValue[] elements)
        {
            return MutableJSONArray.Create(elements);
        }
    }

    /// <summary>
    /// A collection of extension methods for <see cref="JSONArray"/>s.
    /// </summary>
    public static class JSONArrays
    {
        /// <summary>
        /// Get the value at the provided <paramref name="index"/>.
        /// </summary>
        /// <typeparam name="T">The type of <see cref="JSONValue"/> to cast the value to.</typeparam>
        /// <param name="jsonArray">The <see cref="JSONArray"/> to get the value from.</param>
        /// <param name="index">The index of the value to get.</param>
        public static Result<T> Get<T>(this JSONArray jsonArray, int index)
            where T : JSONValue
        {
            Pre.Condition.AssertNotNull(jsonArray, nameof(jsonArray));
            Pre.Condition.AssertAccessIndex(index, jsonArray, nameof(index));

            return Result.Create(() =>
            {
                return (T)jsonArray.Get(index);
            });
        }

        /// <summary>
        /// Get the value at the provided <paramref name="index"/>.
        /// </summary>
        /// <typeparam name="T">The type of <see cref="JSONValue"/> to cast the value to.</typeparam>
        /// <param name="jsonArray">The <see cref="JSONArray"/> to get the value from.</param>
        /// <param name="index">The index of the value to get.</param>
        public static Result<T?> GetAs<T>(this JSONArray jsonArray, int index)
            where T : class, JSONValue
        {
            Pre.Condition.AssertNotNull(jsonArray, nameof(jsonArray));
            Pre.Condition.AssertAccessIndex(index, jsonArray, nameof(index));

            return Result.Create(jsonArray.Get(index) as T);
        }

        /// <summary>
        /// Get the <see cref="JSONObject"/> value at the provided <paramref name="index"/>.
        /// </summary>
        /// <param name="jsonArray">The <see cref="JSONArray"/> to get the value from.</param>
        /// <param name="index">The index of the value to get.</param>
        public static Result<JSONObject> GetObject(this JSONArray jsonArray, int index)
        {
            return jsonArray.Get<JSONObject>(index);
        }

        /// <summary>
        /// Get the <see cref="JSONObject"/> value at the provided <paramref name="index"/>.
        /// </summary>
        /// <param name="jsonArray">The <see cref="JSONArray"/> to get the value from.</param>
        /// <param name="index">The index of the value to get.</param>
        public static Result<JSONObject?> GetAsObject(this JSONArray jsonArray, int index)
        {
            return jsonArray.GetAs<JSONObject>(index);
        }

        /// <summary>
        /// Get the <see cref="JSONArray"/> value at the provided <paramref name="index"/>.
        /// </summary>
        /// <param name="jsonArray">The <see cref="JSONArray"/> to get the value from.</param>
        /// <param name="index">The index of the value to get.</param>
        public static Result<JSONArray> GetArray(this JSONArray jsonArray, int index)
        {
            return jsonArray.Get<JSONArray>(index);
        }

        /// <summary>
        /// Get the <see cref="JSONArray"/> value at the provided <paramref name="index"/>.
        /// </summary>
        /// <param name="jsonArray">The <see cref="JSONArray"/> to get the value from.</param>
        /// <param name="index">The index of the value to get.</param>
        public static Result<JSONArray?> GetAsArray(this JSONArray jsonArray, int index)
        {
            return jsonArray.GetAs<JSONArray>(index);
        }

        /// <summary>
        /// Get the <see cref="bool"/> value at the provided <paramref name="index"/>.
        /// </summary>
        /// <param name="jsonArray">The <see cref="JSONArray"/> to get the value from.</param>
        /// <param name="index">The index of the value to get.</param>
        public static Result<bool> GetBoolean(this JSONArray jsonArray, int index)
        {
            return jsonArray.Get<JSONBooleanValue>(index)
                .Then(json => json.GetValue());
        }

        /// <summary>
        /// Get the <see cref="bool"/> value at the provided <paramref name="index"/>.
        /// </summary>
        /// <param name="jsonArray">The <see cref="JSONArray"/> to get the value from.</param>
        /// <param name="index">The index of the value to get.</param>
        public static Result<bool?> GetAsBoolean(this JSONArray jsonArray, int index)
        {
            return jsonArray.GetAs<JSONBooleanValue>(index)
                .Then(json => json?.GetValue());
        }

        /// <summary>
        /// Get the <see cref="string"/> value at the provided <paramref name="index"/>.
        /// </summary>
        /// <param name="jsonArray">The <see cref="JSONArray"/> to get the value from.</param>
        /// <param name="index">The index of the value to get.</param>
        public static Result<string> GetString(this JSONArray jsonArray, int index)
        {
            return jsonArray.Get<JSONStringValue>(index)
                .Then(json => json.GetValue());
        }

        /// <summary>
        /// Get the <see cref="string"/> value at the provided <paramref name="index"/>.
        /// </summary>
        /// <param name="jsonArray">The <see cref="JSONArray"/> to get the value from.</param>
        /// <param name="index">The index of the value to get.</param>
        public static Result<string?> GetAsString(this JSONArray jsonArray, int index)
        {
            return jsonArray.GetAs<JSONStringValue>(index)
                .Then(json => json?.GetValue());
        }

        /// <summary>
        /// Get the <see cref="JSONNull"/> value at the provided <paramref name="index"/>.
        /// </summary>
        /// <param name="jsonArray">The <see cref="JSONArray"/> to get the value from.</param>
        /// <param name="index">The index of the value to get.</param>
        public static Result<JSONNull> GetNull(this JSONArray jsonArray, int index)
        {
            return jsonArray.Get<JSONNull>(index);
        }

        /// <summary>
        /// Get the <see cref="JSONNull"/> value at the provided <paramref name="index"/>.
        /// </summary>
        /// <param name="jsonArray">The <see cref="JSONArray"/> to get the value from.</param>
        /// <param name="index">The index of the value to get.</param>
        public static Result<JSONNull?> GetAsNull(this JSONArray jsonArray, int index)
        {
            return jsonArray.GetAs<JSONNull>(index);
        }

        /// <summary>
        /// Get the <see cref="long"/> value at the provided <paramref name="index"/>.
        /// </summary>
        /// <param name="jsonArray">The <see cref="JSONArray"/> to get the value from.</param>
        /// <param name="index">The index of the value to get.</param>
        public static Result<long> GetLong(this JSONArray jsonArray, int index)
        {
            return jsonArray.Get<JSONLongValue>(index)
                .Then(json => json.GetValue());
        }

        /// <summary>
        /// Get the <see cref="long"/> value at the provided <paramref name="index"/>.
        /// </summary>
        /// <param name="jsonArray">The <see cref="JSONArray"/> to get the value from.</param>
        /// <param name="index">The index of the value to get.</param>
        public static Result<long?> GetAsLong(this JSONArray jsonArray, int index)
        {
            return jsonArray.GetAs<JSONLongValue>(index)
                .Then(json => json?.GetValue());
        }

        /// <summary>
        /// Get the <see cref="double"/> value at the provided <paramref name="index"/>.
        /// </summary>
        /// <param name="jsonArray">The <see cref="JSONArray"/> to get the value from.</param>
        /// <param name="index">The index of the value to get.</param>
        public static Result<double> GetDouble(this JSONArray jsonArray, int index)
        {
            return jsonArray.Get<JSONDoubleValue>(index)
                .Then(json => json.GetValue());
        }

        /// <summary>
        /// Get the <see cref="double"/> value at the provided <paramref name="index"/>.
        /// </summary>
        /// <param name="jsonArray">The <see cref="JSONArray"/> to get the value from.</param>
        /// <param name="index">The index of the value to get.</param>
        public static Result<double?> GetAsDouble(this JSONArray jsonArray, int index)
        {
            return jsonArray.GetAs<JSONDoubleValue>(index)
                .Then(json => json?.GetValue());
        }
    }
}

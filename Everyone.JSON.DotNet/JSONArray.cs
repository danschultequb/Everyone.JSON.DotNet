using System;

namespace Everyone
{
    /// <summary>
    /// An array of <see cref="JSONValue"/>s.
    /// </summary>
    public interface JSONArray : Indexable<JSONValue>
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
        /// Get the <see cref="JSONBooleanValue"/> value at the provided <paramref name="index"/>.
        /// </summary>
        /// <param name="jsonArray">The <see cref="JSONArray"/> to get the value from.</param>
        /// <param name="index">The index of the value to get.</param>
        public static Result<bool> GetBoolean(this JSONArray jsonArray, int index)
        {
            return jsonArray.Get<JSONBooleanValue>(index)
                .Then(json => json.GetValue());
        }

        /// <summary>
        /// Get the <see cref="JSONBooleanValue"/> value at the provided <paramref name="index"/>.
        /// </summary>
        /// <param name="jsonArray">The <see cref="JSONArray"/> to get the value from.</param>
        /// <param name="index">The index of the value to get.</param>
        public static Result<bool?> GetAsBoolean(this JSONArray jsonArray, int index)
        {
            return jsonArray.GetAs<JSONBooleanValue>(index)
                .Then(json => json?.GetValue());
        }

        /// <summary>
        /// Get the <see cref="JSONStringValue"/> value at the provided <paramref name="index"/>.
        /// </summary>
        /// <param name="jsonArray">The <see cref="JSONArray"/> to get the value from.</param>
        /// <param name="index">The index of the value to get.</param>
        public static Result<string> GetString(this JSONArray jsonArray, int index)
        {
            return jsonArray.Get<JSONStringValue>(index)
                .Then(json => json.GetValue());
        }

        /// <summary>
        /// Get the <see cref="JSONStringValue"/> value at the provided <paramref name="index"/>.
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
    }
}

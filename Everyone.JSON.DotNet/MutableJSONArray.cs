using System.Collections.Generic;
using System.Linq;

namespace Everyone
{
    public class MutableJSONArray : ListDecorator<JSONValue,MutableJSONArray>, JSONArray
    {
        protected MutableJSONArray(IEnumerable<JSONValue> values)
            : base(List.Create(values))
        {
        }

        public static MutableJSONArray Create(params JSONValue[] values)
        {
            Pre.Condition.AssertNotNull(values, nameof(values));

            return MutableJSONArray.Create(values.ToList());
        }

        public static MutableJSONArray Create(IEnumerable<JSONValue> elements)
        {
            return new MutableJSONArray(elements);
        }

        public override MutableJSONArray Set(int index, JSONValue value)
        {
            Pre.Condition.AssertNotNull(value, nameof(value));

            return base.Set(index, value);
        }
    }

    /// <summary>
    /// A collection of extension methods for <see cref="MutableJSONArray"/>s.
    /// </summary>
    public static class MutableJSONArrays
    {
        /// <summary>
        /// Get the <see cref="MutableJSONObject"/> value at the provided <paramref name="index"/>.
        /// </summary>
        /// <param name="jsonArray">The <see cref="MutableJSONArray"/> to get the value from.</param>
        /// <param name="index">The index of the value to get.</param>
        public static Result<MutableJSONObject> GetObject(this MutableJSONArray jsonArray, int index)
        {
            return jsonArray.Get<MutableJSONObject>(index);
        }

        /// <summary>
        /// Get the <see cref="MutableJSONObject"/> value at the provided <paramref name="index"/>.
        /// </summary>
        /// <param name="jsonArray">The <see cref="MutableJSONArray"/> to get the value from.</param>
        /// <param name="index">The index of the value to get.</param>
        public static Result<MutableJSONObject?> GetAsObject(this MutableJSONArray jsonArray, int index)
        {
            return jsonArray.GetAs<MutableJSONObject>(index);
        }

        /// <summary>
        /// Get the <see cref="JSONArray"/> value at the provided <paramref name="index"/>.
        /// </summary>
        /// <param name="jsonArray">The <see cref="JSONArray"/> to get the value from.</param>
        /// <param name="index">The index of the value to get.</param>
        public static Result<MutableJSONArray> GetArray(this MutableJSONArray jsonArray, int index)
        {
            return jsonArray.Get<MutableJSONArray>(index);
        }

        /// <summary>
        /// Get the <see cref="JSONArray"/> value at the provided <paramref name="index"/>.
        /// </summary>
        /// <param name="jsonArray">The <see cref="MutableJSONArray"/> to get the value from.</param>
        /// <param name="index">The index of the value to get.</param>
        public static Result<MutableJSONArray?> GetAsArray(this MutableJSONArray jsonArray, int index)
        {
            return jsonArray.GetAs<MutableJSONArray>(index);
        }

        public static MutableJSONArray Add(this MutableJSONArray jsonArray, bool value)
        {
            Pre.Condition.AssertNotNull(jsonArray, nameof(jsonArray));

            return jsonArray.Add(JSONBooleanValue.Create(value));
        }

        public static MutableJSONArray Add(this MutableJSONArray jsonArray, string value)
        {
            Pre.Condition.AssertNotNull(jsonArray, nameof(jsonArray));

            return jsonArray.Add(JSONStringValue.Create(value));
        }

        public static MutableJSONArray Set(this MutableJSONArray jsonArray, int index, bool value)
        {
            Pre.Condition.AssertNotNull(jsonArray, nameof(jsonArray));

            return jsonArray.Set(index, JSONBooleanValue.Create(value));
        }

        public static MutableJSONArray Set(this MutableJSONArray jsonArray, int index, string value)
        {
            Pre.Condition.AssertNotNull(jsonArray, nameof(jsonArray));

            return jsonArray.Set(index, JSONStringValue.Create(value));
        }

        public static MutableJSONArray SetNull(this MutableJSONArray jsonArray, int index)
        {
            Pre.Condition.AssertNotNull(jsonArray, nameof(jsonArray));

            return jsonArray.Set(index, JSONNull.Create());
        }
    }
}

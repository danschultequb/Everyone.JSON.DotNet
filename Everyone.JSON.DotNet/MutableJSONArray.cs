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

        public virtual MutableJSONArray Add(bool value)
        {
            return this.Add(JSONBooleanValue.Create(value));
        }

        public virtual MutableJSONArray Add(string value)
        {
            return this.Add(JSONStringValue.Create(value));
        }

        public override MutableJSONArray Set(int index, JSONValue value)
        {
            Pre.Condition.AssertNotNull(value, nameof(value));

            return base.Set(index, value);
        }

        public virtual MutableJSONArray Set(int index, bool value)
        {
            return this.Set(index, JSONBooleanValue.Create(value));
        }

        public virtual MutableJSONArray Set(int index, string value)
        {
            return this.Set(index, JSONStringValue.Create(value));
        }

        public virtual MutableJSONArray SetNull(int index)
        {
            return this.Set(index, JSONNull.Null);
        }
    }
}

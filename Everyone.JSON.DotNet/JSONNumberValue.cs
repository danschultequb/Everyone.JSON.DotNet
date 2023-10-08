namespace Everyone
{
    public interface JSONNumberValue : JSONValue
    {
        public static JSONLongValue Create(long value)
        {
            return JSONLongValue.Create(value);
        }

        public static JSONDoubleValue Create(double value)
        {
            return JSONDoubleValue.Create(value);
        }
    }
}

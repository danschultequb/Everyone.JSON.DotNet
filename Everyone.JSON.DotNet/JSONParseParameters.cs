namespace Everyone
{
    /// <summary>
    /// Parameters that can be passed to the different JSON parse functions.
    /// </summary>
    public class JSONParseParameters
    {
        protected JSONParseParameters()
        {
        }

        public static JSONParseParameters Create()
        {
            return new JSONParseParameters();
        }
    }
}

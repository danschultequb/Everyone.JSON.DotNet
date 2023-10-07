namespace Everyone
{
    public class JSONParseState
    {
        private readonly JSONParseParameters parameters;

        protected JSONParseState(JSONParseParameters parameters)
        {
            Pre.Condition.AssertNotNull(parameters, nameof(parameters));

            this.parameters = parameters;
        }

        public static JSONParseState Create(JSONParseParameters parameters)
        {
            return new JSONParseState(parameters);
        }
    }
}

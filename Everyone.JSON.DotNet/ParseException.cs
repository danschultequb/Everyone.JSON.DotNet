using System;

namespace Everyone
{
    public class ParseException : Exception
    {
        public ParseException(string message)
            : base(message)
        {
            Pre.Condition.AssertNotNullAndNotEmpty(message, nameof(message));
        }
    }
}

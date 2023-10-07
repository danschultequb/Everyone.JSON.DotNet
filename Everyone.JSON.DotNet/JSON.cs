using System.Collections;

namespace Everyone
{
    public static class JSON
    {
        public static Result<JSONString> ParseString(JSONParseParameters parameters)
        {
            Pre.Condition.AssertNotNull(parameters, nameof(parameters));

            return JSON.ParseString(JSONParseState.Create(parameters));
        }

        public static Result<JSONString> ParseString(JSONParseState parseState)
        {
            Pre.Condition.AssertNotNull(parseState, nameof(parseState));

            return Result.Create(() =>
            {
                return JSONString.Create("not right", endQuote: null);
            });
        }

        public static bool IsLetter(char character)
        {
            return ('a' <= character && character <= 'z') ||
                ('A' <= character && character <= 'Z');
        }

        /// <summary>
        /// Get whether the provided <see cref="char"/> is considered whitespace.
        /// </summary>
        /// <param name="character">The <see cref="char"/> to check.</param>
        public static bool IsWhitespace(char character)
        {
            bool result;
            switch (character)
            {
                case '\x20': // ' '
                case '\x09': // '\t'
                case '\x0A': // '\n'
                case '\x0D': // '\r'
                    result = true;
                    break;

                default:
                    result = false;
                    break;
            }
            return result;
        }

        public static bool IsDigit(char character)
        {
            return '0' <= character && character <= '9';
        }
    }
}

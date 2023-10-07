namespace Everyone
{
    public static class JSONTests
    {
        public static void Test(TestRunner runner)
        {
            runner.TestType(typeof(JSON), () =>
            {
                runner.TestMethod($"ParseString({nameof(JSONParseParameters)}", () =>
                {
                    runner.Test("with null", (Test test) =>
                    {
                        test.AssertThrows(() => JSON.ParseString((JSONParseParameters)null!),
                            new PreConditionFailure(
                                "Expression: parameters",
                                "Expected: not null",
                                "Actual:   null"));
                    });
                });

                runner.TestMethod("IsLetter(char)", () =>
                {
                    void IsLetterTest(char value, bool expected)
                    {
                        runner.Test($"with {value.EscapeAndQuote()}", (Test test) =>
                        {
                            test.AssertEqual(expected, JSON.IsLetter(value));
                        });
                    }

                    IsLetterTest('a', true);
                    IsLetterTest('b', true);
                    IsLetterTest('y', true);
                    IsLetterTest('z', true);
                    IsLetterTest('A', true);
                    IsLetterTest('B', true);
                    IsLetterTest('Y', true);
                    IsLetterTest('Z', true);

                    IsLetterTest('.', false);
                    IsLetterTest('_', false);
                    IsLetterTest('0', false);
                    IsLetterTest('1', false);
                    IsLetterTest('8', false);
                    IsLetterTest('9', false);
                });

                runner.TestMethod("IsWhitespace(char)", () =>
                {
                    void IsWhitespaceTest(char value, bool expected)
                    {
                        runner.Test($"with {value.EscapeAndQuote()}", (Test test) =>
                        {
                            test.AssertEqual(expected, JSON.IsWhitespace(value));
                        });
                    }

                    IsWhitespaceTest(' ', true);
                    IsWhitespaceTest('\r', true);
                    IsWhitespaceTest('\n', true);
                    IsWhitespaceTest('\t', true);

                    IsWhitespaceTest('a', false);
                    IsWhitespaceTest('_', false);
                    IsWhitespaceTest('\0', false);
                    IsWhitespaceTest('\f', false);
                    IsWhitespaceTest('\v', false);
                });

                runner.TestMethod("IsDigit(char)", () =>
                {
                    void IsDigitTest(char value, bool expected)
                    {
                        runner.Test($"with {value.EscapeAndQuote()}", (Test test) =>
                        {
                            test.AssertEqual(expected, JSON.IsDigit(value));
                        });
                    }

                    for (int i = 0; i < 10; i++)
                    {
                        IsDigitTest((char)('0' + i), true);
                    }

                    IsDigitTest('a', false);
                    IsDigitTest(' ', false);
                });
            });
        }
    }
}

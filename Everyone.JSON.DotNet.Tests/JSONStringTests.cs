using System;

namespace Everyone
{
    public static class JSONStringTests
    {
        public static void Test(TestRunner runner)
        {
            runner.TestType<JSONString>(() =>
            {
                runner.TestMethod("Create(string,char?)", () =>
                {
                    void CreateTest(string text, char? endQuote, Exception? expectedException = null)
                    {
                        runner.Test($"with {Language.AndList(new object?[] { text, endQuote }.Map(runner.ToString))}", (Test test) =>
                        {
                            test.AssertThrows(expectedException, () =>
                            {
                                JSONString json = JSONString.Create(text, endQuote);
                                test.AssertNotNull(json);
                                test.AssertEqual(text, json.Text);
                                test.AssertEqual(text[0], json.StartQuote);
                                test.AssertEqual(endQuote, json.EndQuote);
                            });
                        });
                    }

                    CreateTest(
                        text: null!,
                        endQuote: null,
                        expectedException: new PreConditionFailure(
                            "Expression: text",
                            "Expected: not null and not empty",
                            "Actual:   null"));
                    CreateTest(
                        text: "",
                        endQuote: null,
                        expectedException: new PreConditionFailure(
                            "Expression: text",
                            "Expected: not null and not empty",
                            "Actual:   \"\""));
                    CreateTest(
                        text: "'",
                        endQuote: null);
                    CreateTest(
                        text: "hello",
                        endQuote: null,
                        expectedException: new PreConditionFailure(
                            "Expression: text.First()",
                            "Expected: one of ['\\'','\"']",
                            "Actual:   'h'"));
                    
                    CreateTest(
                        text: "'hello",
                        endQuote: null);
                    CreateTest(
                        text: "\"hello",
                        endQuote: null);

                    CreateTest(
                        text: "'hello\"",
                        endQuote: null);
                    CreateTest(
                        text: "\"hello'",
                        endQuote: null);

                    CreateTest("'hello'", endQuote: '\'');
                    CreateTest("\"hello\"", endQuote: '"');
                });

                runner.TestMethod("Value", () =>
                {
                    void GetValueTest(JSONString jsonString, string expected)
                    {
                        runner.Test($"with {jsonString}", (Test test) =>
                        {
                            test.AssertEqual(expected, jsonString.Value);
                        });
                    }

                    GetValueTest(JSONString.Create("'", null), "");
                    GetValueTest(JSONString.Create("'abc", null), "abc");

                    GetValueTest(JSONString.Create("\"", null), "");
                    GetValueTest(JSONString.Create("\"abc", null), "abc");

                    GetValueTest(JSONString.Create("''", '\''), "");
                    GetValueTest(JSONString.Create("'abc'", '\''), "abc");

                    GetValueTest(JSONString.Create("\"\"", '\"'), "");
                    GetValueTest(JSONString.Create("\"123\"", '"'), "123");
                });

                runner.TestMethod("ToString()", () =>
                {
                    void ToStringTest(JSONString jsonString, string expected)
                    {
                        runner.Test($"with {jsonString}", (Test test) =>
                        {
                            test.AssertEqual(expected, jsonString.ToString());
                        });
                    }

                    ToStringTest(
                        jsonString: JSONString.Create("'hello'", endQuote: '\''),
                        expected: "{\"Type\":\"QuotedString,\"Text\":\"'hello'\"}");
                    ToStringTest(
                        jsonString: JSONString.Create("'hello'", endQuote: null),
                        expected: "{\"Type\":\"QuotedString,\"Text\":\"'hello'\"}");
                    ToStringTest(
                        jsonString: JSONString.Create("\"abc", endQuote: null),
                        expected: "{\"Type\":\"QuotedString,\"Text\":\"\\\"abc\"}");
                });

                runner.TestMethod("Equals(object?)", () =>
                {
                    void EqualsTest(JSONString jsonString, object? rhs, bool expected)
                    {
                        runner.Test($"with {Language.AndList(jsonString, runner.ToString(rhs))}", (Test test) =>
                        {
                            test.AssertEqual(expected, jsonString.Equals(rhs));
                        });
                    }

                    EqualsTest(JSONString.Create("''", '\''), null, false);
                    EqualsTest(JSONString.Create("''", '\''), "''", false);
                    EqualsTest(JSONString.Create("''", '\''), JSONString.Create("''", '\''), true);
                    EqualsTest(JSONString.Create("''", '\''), JSONString.Create("\"\"", '\"'), false);
                    EqualsTest(JSONString.Create("'a'", '\''), JSONString.Create("'a'", '\''), true);
                    EqualsTest(JSONString.Create("'a'", '\''), JSONString.Create("\"a\"", '\"'), false);
                });

                runner.TestMethod("Equals(JSONToken?)", () =>
                {
                    void EqualsTest(JSONString jsonString, JSONToken? rhs, bool expected)
                    {
                        runner.Test($"with {Language.AndList(jsonString, runner.ToString(rhs))}", (Test test) =>
                        {
                            test.AssertEqual(expected, jsonString.Equals(rhs));
                        });
                    }

                    EqualsTest(JSONString.Create("''", '\''), null, false);
                    EqualsTest(JSONString.Create("''", '\''), JSONToken.Null, false);
                    EqualsTest(JSONString.Create("''", '\''), JSONString.Create("''", '\''), true);
                    EqualsTest(JSONString.Create("''", '\''), JSONString.Create("\"\"", '\"'), false);
                    EqualsTest(JSONString.Create("'a'", '\''), JSONString.Create("'a'", '\''), true);
                    EqualsTest(JSONString.Create("'a'", '\''), JSONString.Create("\"a\"", '\"'), false);
                });

                runner.TestMethod("Equals(JSONString?)", () =>
                {
                    void EqualsTest(JSONString jsonString, JSONString? rhs, bool expected)
                    {
                        runner.Test($"with {Language.AndList(jsonString, runner.ToString(rhs))}", (Test test) =>
                        {
                            test.AssertEqual(expected, jsonString.Equals(rhs));
                        });
                    }

                    EqualsTest(JSONString.Create("''", '\''), null, false);
                    EqualsTest(JSONString.Create("''", '\''), JSONString.Create("''", null), false);
                    EqualsTest(JSONString.Create("''", '\''), JSONString.Create("''", '\''), true);
                    EqualsTest(JSONString.Create("''", '\''), JSONString.Create("\"\"", null), false);
                    EqualsTest(JSONString.Create("''", '\''), JSONString.Create("\"\"", '\"'), false);
                    EqualsTest(JSONString.Create("'a'", '\''), JSONString.Create("'a'", null), false);
                    EqualsTest(JSONString.Create("'a'", '\''), JSONString.Create("'a'", '\''), true);
                    EqualsTest(JSONString.Create("'a'", '\''), JSONString.Create("\"a\"", null), false);
                    EqualsTest(JSONString.Create("'a'", '\''), JSONString.Create("\"a\"", '\"'), false);
                });

                runner.TestMethod("GetHashCode()", () =>
                {
                    void GetHashCodeTest(JSONString lhs, JSONString rhs)
                    {
                        runner.Test($"with {Language.AndList(lhs, runner.ToString(rhs))}", (Test test) =>
                        {
                            test.AssertEqual(lhs.Equals(rhs), lhs.GetHashCode() == rhs.GetHashCode());
                        });
                    }

                    GetHashCodeTest(JSONString.Create("''", '\''), JSONString.Create("''", '\''));
                    GetHashCodeTest(JSONString.Create("''", '\''), JSONString.Create("\"\"", '\"'));
                    GetHashCodeTest(JSONString.Create("'a'", '\''), JSONString.Create("'a'", '\''));
                    GetHashCodeTest(JSONString.Create("'a'", '\''), JSONString.Create("\"a\"", '\"'));
                });
            });
        }
    }
}

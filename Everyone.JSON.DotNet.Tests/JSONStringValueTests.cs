using System;

namespace Everyone
{
    public static class JSONStringValueTests
    {
        public static void Test(TestRunner runner)
        {
            runner.TestType<JSONStringValue>(() =>
            {
                runner.TestMethod("Create(string)", () =>
                {
                    void CreateTest(string value, Exception? expectedException = null)
                    {
                        runner.Test($"with {runner.ToString(value)}", (Test test) =>
                        {
                            test.AssertThrows(expectedException, () =>
                            {
                                JSONStringValue json = JSONStringValue.Create(value);
                                test.AssertNotNull(json);
                                test.AssertEqual(value, json.GetValue());
                            });
                        });
                    }

                    CreateTest(null!, new PreConditionFailure(
                        "Expression: value",
                        "Expected: not null",
                        "Actual:   null"));
                    CreateTest("");
                    CreateTest("abc");
                });

                runner.TestMethod("ToString()", () =>
                {
                    void ToStringTest(JSONStringValue json, string expected)
                    {
                        runner.Test($"with {runner.ToString(json)}", (Test test) =>
                        {
                            test.AssertEqual(expected, json.ToString());
                        });
                    }

                    ToStringTest(JSONStringValue.Create(""), "\"\"");
                    ToStringTest(JSONStringValue.Create("abc"), "\"abc\"");
                    ToStringTest(JSONStringValue.Create(" \r\n\t "), "\" \\r\\n\\t \"");
                });

                runner.TestMethod("Equals(object?)", () =>
                {
                    void EqualsTest(JSONStringValue json, object? rhs, bool expected)
                    {
                        runner.Test($"with {Language.AndList(new object?[] { json, rhs }.Map(runner.ToString))}", (Test test) =>
                        {
                            test.AssertEqual(expected, json.Equals(rhs));
                        });
                    }

                    EqualsTest(JSONStringValue.Create("abc"), null, false);
                    EqualsTest(JSONStringValue.Create("abc"), "abc", false);
                    EqualsTest(JSONStringValue.Create("abc"), JSONStringValue.Create(""), false);
                    EqualsTest(JSONStringValue.Create("abc"), JSONStringValue.Create("abc"), true);
                });

                runner.TestMethod("GetHashCode()", () =>
                {
                    void GetHashCodeTest(JSONStringValue json, object? rhs)
                    {
                        runner.Test($"with {Language.AndList(new object?[] { json, rhs }.Map(runner.ToString))}", (Test test) =>
                        {
                            test.AssertEqual(json.Equals(rhs), json.GetHashCode() == rhs?.GetHashCode());
                        });
                    }

                    GetHashCodeTest(JSONStringValue.Create("abc"), null);
                    GetHashCodeTest(JSONStringValue.Create("abc"), "abc");
                    GetHashCodeTest(JSONStringValue.Create("abc"), JSONStringValue.Create(""));
                    GetHashCodeTest(JSONStringValue.Create("abc"), JSONStringValue.Create("abc"));
                });
            });
        }
    }
}

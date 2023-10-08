namespace Everyone
{
    public static class JSONBooleanValueTests
    {
        public static void Test(TestRunner runner)
        {
            runner.TestType<JSONBooleanValue>(() =>
            {
                runner.TestMethod("Create(bool)", () =>
                {
                    void CreateTest(bool value)
                    {
                        runner.Test($"with {runner.ToString(value)}", (Test test) =>
                        {
                            JSONBooleanValue json = JSONBooleanValue.Create(value);
                            test.AssertNotNull(json);
                            test.AssertEqual(value, json.GetValue());
                        });
                    }

                    CreateTest(false);
                    CreateTest(true);
                });

                runner.Test("True", (Test test) =>
                {
                    test.AssertEqual(true, JSONBooleanValue.True.GetValue());
                    test.AssertSame(JSONBooleanValue.True, JSONBooleanValue.True);
                });

                runner.Test("False", (Test test) =>
                {
                    test.AssertEqual(false, JSONBooleanValue.False.GetValue());
                    test.AssertSame(JSONBooleanValue.False, JSONBooleanValue.False);
                });

                runner.TestMethod("ToString()", () =>
                {
                    void ToStringTest(JSONBooleanValue json, string expected)
                    {
                        runner.Test($"with {runner.ToString(json)}", (Test test) =>
                        {
                            test.AssertEqual(expected, json.ToString());
                        });
                    }

                    ToStringTest(JSONBooleanValue.False, "false");
                    ToStringTest(JSONBooleanValue.True, "true");
                });

                runner.TestMethod("Equals(object?)", () =>
                {
                    void EqualsTest(JSONBooleanValue json, object? rhs, bool expected)
                    {
                        runner.Test($"with {Language.AndList(new object?[] { json, rhs }.Map(runner.ToString))}", (Test test) =>
                        {
                            test.AssertEqual(expected, json.Equals(rhs));
                        });
                    }

                    EqualsTest(JSONBooleanValue.False, null, false);
                    EqualsTest(JSONBooleanValue.False, "false", false);
                    EqualsTest(JSONBooleanValue.False, false, false);
                    EqualsTest(JSONBooleanValue.False, JSONBooleanValue.False, true);
                    EqualsTest(JSONBooleanValue.False, JSONBooleanValue.True, false);
                });

                runner.TestMethod("GetHashCode()", () =>
                {
                    void GetHashCodeTest(JSONBooleanValue json, object? rhs)
                    {
                        runner.Test($"with {Language.AndList(new object?[] { json, rhs }.Map(runner.ToString))}", (Test test) =>
                        {
                            test.AssertEqual(json.Equals(rhs), json.GetHashCode() == rhs?.GetHashCode());
                        });
                    }

                    GetHashCodeTest(JSONBooleanValue.False, null);
                    GetHashCodeTest(JSONBooleanValue.False, "false");
                    GetHashCodeTest(JSONBooleanValue.False, false);
                    GetHashCodeTest(JSONBooleanValue.False, JSONBooleanValue.False);
                    GetHashCodeTest(JSONBooleanValue.False, JSONBooleanValue.True);
                });
            });
        }
    }
}

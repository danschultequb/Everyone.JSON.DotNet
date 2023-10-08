namespace Everyone
{
    public static class JSONLongValueTests
    {
        public static void Test(TestRunner runner)
        {
            runner.TestType<JSONLongValue>(() =>
            {
                runner.TestMethod("Create(long)", () =>
                {
                    void CreateTest(long value)
                    {
                        runner.Test($"with {runner.ToString(value)}", (Test test) =>
                        {
                            JSONLongValue json = JSONLongValue.Create(value);
                            test.AssertNotNull(json);
                            test.AssertEqual(value, json.GetValue());
                        });
                    }

                    CreateTest(-1);
                    CreateTest(0);
                    CreateTest(1);
                    CreateTest(123123512);
                });

                runner.TestMethod("ToString()", () =>
                {
                    void ToStringTest(JSONLongValue json, string expected)
                    {
                        runner.Test($"with {runner.ToString(json)}", (Test test) =>
                        {
                            test.AssertEqual(expected, json.ToString());
                        });
                    }

                    ToStringTest(JSONLongValue.Create(-1), "-1");
                    ToStringTest(JSONLongValue.Create(0), "0");
                    ToStringTest(JSONLongValue.Create(1), "1");
                    ToStringTest(JSONLongValue.Create(123123512), "123123512");
                });

                runner.TestMethod("Equals(object?)", () =>
                {
                    void EqualsTest(JSONLongValue json, object? rhs, bool expected)
                    {
                        runner.Test($"with {Language.AndList(new object?[] { json, rhs }.Map(runner.ToString))}", (Test test) =>
                        {
                            test.AssertEqual(expected, json.Equals(rhs));
                        });
                    }

                    EqualsTest(JSONLongValue.Create(123), null, false);
                    EqualsTest(JSONLongValue.Create(123), "123", false);
                    EqualsTest(JSONLongValue.Create(123), 123, false);
                    EqualsTest(JSONLongValue.Create(123), JSONLongValue.Create(-123), false);
                    EqualsTest(JSONLongValue.Create(123), JSONLongValue.Create(123), true);
                });

                runner.TestMethod("GetHashCode()", () =>
                {
                    void GetHashCodeTest(JSONLongValue json, object? rhs)
                    {
                        runner.Test($"with {Language.AndList(new object?[] { json, rhs }.Map(runner.ToString))}", (Test test) =>
                        {
                            test.AssertEqual(json.Equals(rhs), json.GetHashCode() == rhs?.GetHashCode());
                        });
                    }

                    GetHashCodeTest(JSONLongValue.Create(123), null);
                    GetHashCodeTest(JSONLongValue.Create(123), "123");
                    GetHashCodeTest(JSONLongValue.Create(123), 123);
                    GetHashCodeTest(JSONLongValue.Create(123), JSONLongValue.Create(-123));
                    GetHashCodeTest(JSONLongValue.Create(123), JSONLongValue.Create(123));
                });
            });
        }
    }
}

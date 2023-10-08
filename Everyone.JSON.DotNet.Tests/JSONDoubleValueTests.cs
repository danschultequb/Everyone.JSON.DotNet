namespace Everyone
{
    public static class JSONDoubleValueTests
    {
        public static void Test(TestRunner runner)
        {
            runner.TestType<JSONDoubleValue>(() =>
            {
                runner.TestMethod("Create(double)", () =>
                {
                    void CreateTest(double value)
                    {
                        runner.Test($"with {runner.ToString(value)}", (Test test) =>
                        {
                            JSONDoubleValue json = JSONDoubleValue.Create(value);
                            test.AssertNotNull(json);
                            test.AssertEqual(value, json.GetValue());
                        });
                    }

                    CreateTest(-1);
                    CreateTest(0);
                    CreateTest(1);
                    CreateTest(123123512.23234);
                });

                runner.TestMethod("ToString()", () =>
                {
                    void ToStringTest(JSONDoubleValue json, string expected)
                    {
                        runner.Test($"with {runner.ToString(json)}", (Test test) =>
                        {
                            test.AssertEqual(expected, json.ToString());
                        });
                    }

                    ToStringTest(JSONDoubleValue.Create(-1), "-1");
                    ToStringTest(JSONDoubleValue.Create(0), "0");
                    ToStringTest(JSONDoubleValue.Create(1), "1");
                    ToStringTest(JSONDoubleValue.Create(123123512.23234), "123123512.23234");
                });

                runner.TestMethod("Equals(object?)", () =>
                {
                    void EqualsTest(JSONDoubleValue json, object? rhs, bool expected)
                    {
                        runner.Test($"with {Language.AndList(new object?[] { json, rhs }.Map(runner.ToString))}", (Test test) =>
                        {
                            test.AssertEqual(expected, json.Equals(rhs));
                        });
                    }

                    EqualsTest(JSONDoubleValue.Create(1.23), null, false);
                    EqualsTest(JSONDoubleValue.Create(1.23), "1.23", false);
                    EqualsTest(JSONDoubleValue.Create(1.23), 1.23, false);
                    EqualsTest(JSONDoubleValue.Create(1.23), JSONDoubleValue.Create(-1.23), false);
                    EqualsTest(JSONDoubleValue.Create(1.23), JSONDoubleValue.Create(1.23), true);
                });

                runner.TestMethod("GetHashCode()", () =>
                {
                    void GetHashCodeTest(JSONDoubleValue json, object? rhs)
                    {
                        runner.Test($"with {Language.AndList(new object?[] { json, rhs }.Map(runner.ToString))}", (Test test) =>
                        {
                            test.AssertEqual(json.Equals(rhs), json.GetHashCode() == rhs?.GetHashCode());
                        });
                    }

                    GetHashCodeTest(JSONDoubleValue.Create(1.23), null);
                    GetHashCodeTest(JSONDoubleValue.Create(1.23), "1.23");
                    GetHashCodeTest(JSONDoubleValue.Create(1.23), 1.23);
                    GetHashCodeTest(JSONDoubleValue.Create(1.23), JSONDoubleValue.Create(-1.23));
                    GetHashCodeTest(JSONDoubleValue.Create(1.23), JSONDoubleValue.Create(1.23));
                });
            });
        }
    }
}

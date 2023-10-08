namespace Everyone
{
    public static class JSONNullTests
    {
        public static void Test(TestRunner runner)
        {
            runner.TestType<JSONNull>(() =>
            {
                runner.TestMethod("Create()", (Test test) =>
                {
                    JSONNull json = JSONNull.Create();
                    test.AssertNotNull(json);
                    test.AssertSame(json, JSONNull.Create());
                });

                runner.TestMethod("Equals(object?)", () =>
                {
                    void EqualsTest(JSONNull json, object? rhs, bool expected)
                    {
                        runner.Test($"with {Language.AndList(new object?[] { json, rhs }.Map(runner.ToString))}", (Test test) =>
                        {
                            test.AssertEqual(expected, json.Equals(rhs));
                        });
                    }

                    EqualsTest(JSONNull.Create(), null, false);
                    EqualsTest(JSONNull.Create(), "null", false);
                    EqualsTest(JSONNull.Create(), JSONNumber.Create(0), false);
                    EqualsTest(JSONNull.Create(), JSONNull.Create(), true);
                });

                runner.TestMethod("GetHashCode()", () =>
                {
                    void GetHashCodeTest(JSONNull json, object? rhs)
                    {
                        runner.Test($"with {Language.AndList(new object?[] { json, rhs }.Map(runner.ToString))}", (Test test) =>
                        {
                            test.AssertEqual(json.Equals(rhs), json.GetHashCode() == HashCode.Get(rhs));
                        });
                    }

                    GetHashCodeTest(JSONNull.Create(), null);
                    GetHashCodeTest(JSONNull.Create(), "null");
                    GetHashCodeTest(JSONNull.Create(), JSONNumber.Create(0));
                    GetHashCodeTest(JSONNull.Create(), JSONNull.Create());
                });
            });
        }
    }
}

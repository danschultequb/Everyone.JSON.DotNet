namespace Everyone
{
    public static class JSONNumberValueTests
    {
        public static void Test(TestRunner runner)
        {
            runner.TestType<JSONNumberValue>(() =>
            {
                runner.TestMethod("Create(long)", () =>
                {
                    void CreateTest(long value)
                    {
                        runner.Test($"with {runner.ToString(value)}", (Test test) =>
                        {
                            JSONLongValue json = JSONNumberValue.Create(value);
                            test.AssertNotNull(json);
                            test.AssertEqual(value, json.GetValue());
                        });
                    }

                    CreateTest(-1);
                    CreateTest(0);
                    CreateTest(1);
                });

                runner.TestMethod("Create(double)", () =>
                {
                    void CreateTest(double value)
                    {
                        runner.Test($"with {runner.ToString(value)}", (Test test) =>
                        {
                            JSONDoubleValue json = JSONNumberValue.Create(value);
                            test.AssertNotNull(json);
                            test.AssertEqual(value, json.GetValue());
                        });
                    }

                    CreateTest(-1);
                    CreateTest(0);
                    CreateTest(1);
                });
            });
        }
    }
}

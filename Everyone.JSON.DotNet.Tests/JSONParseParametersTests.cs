namespace Everyone
{
    public static class JSONParseParametersTests
    {
        public static void Test(TestRunner runner)
        {
            runner.TestType<JSONParseParameters>(() =>
            {
                runner.TestMethod("Create()", (Test test) =>
                {
                    JSONParseParameters parameters = JSONParseParameters.Create();
                    test.AssertNotNull(parameters);
                });
            });
        }
    }
}

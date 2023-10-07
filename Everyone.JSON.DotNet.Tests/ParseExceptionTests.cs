using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Everyone
{
    public static class ParseExceptionTests
    {
        public static void Test(TestRunner runner)
        {
            runner.TestType<ParseException>(() =>
            {
                runner.TestMethod("Constructor(string)", () =>
                {
                    void ConstructorTest(string message, Exception? expectedException = null)
                    {
                        runner.Test($"with {runner.ToString(message)}", (Test test) =>
                        {
                            test.AssertThrows(expectedException, () =>
                            {
                                ParseException e = new ParseException(message);
                                test.AssertEqual(message, e.Message);
                            });
                        });
                    }

                    ConstructorTest(null!, new PreConditionFailure(
                        "Expression: message",
                        "Expected: not null and not empty",
                        "Actual:   null"));
                    ConstructorTest("", new PreConditionFailure(
                        "Expression: message",
                        "Expected: not null and not empty",
                        "Actual:   \"\""));
                    ConstructorTest("abc");
                });
            });
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Everyone
{
    public static class JSONParseStateTests
    {
        public static void Test(TestRunner runner)
        {
            runner.TestType<JSONParseState>(() =>
            {
                runner.TestMethod($"Create({nameof(JSONParseParameters)}", () =>
                {
                    runner.Test("with null", (Test test) =>
                    {
                        test.AssertThrows(() => JSONParseState.Create(null!),
                            new PreConditionFailure(
                                "Expression: parameters",
                                "Expected: not null",
                                "Actual:   null"));
                    });

                    runner.Test("with non-null", (Test test) =>
                    {
                        JSONParseState parseState = JSONParseState.Create(JSONParseParameters.Create());
                        test.AssertNotNull(parseState);
                    });
                });
            });
        }
    }
}

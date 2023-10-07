using System;

namespace Everyone
{
    public static class DocumentSpanTests
    {
        public static void Test(TestRunner runner)
        {
            runner.TestType<DocumentSpan>(() =>
            {
                runner.TestMethod($"Create({nameof(DocumentPosition)},{nameof(DocumentPosition)})", () =>
                {
                    void CreateTest(DocumentPosition start, DocumentPosition end, Exception? expectedException = null)
                    {
                        runner.Test($"with {Language.AndList(new[] { start, end }.Map(runner.ToString))}", (Test test) =>
                        {
                            test.AssertThrows(expectedException, () =>
                            {
                                DocumentSpan span = DocumentSpan.Create(start, end);
                                test.AssertNotNull(span);
                                test.AssertEqual(start, span.Start);
                                test.AssertEqual(end, span.End);
                            });
                        });
                    }

                    CreateTest(
                        start: null!,
                        end: DocumentPosition.Create(3, 4, 5),
                        expectedException: new PreConditionFailure(
                            "Expression: start",
                            "Expected: not null",
                            "Actual:   null"));
                    CreateTest(
                        start: DocumentPosition.Create(0, 1, 2),
                        end: null!,
                        expectedException: new PreConditionFailure(
                            "Expression: end",
                            "Expected: not null",
                            "Actual:   null"));
                    CreateTest(
                        start: DocumentPosition.Create(0, 1, 2),
                        end: DocumentPosition.Create(0, 1, 2));
                    CreateTest(
                        start: DocumentPosition.Create(0, 1, 2),
                        end: DocumentPosition.Create(3, 4, 5));
                    CreateTest(
                        start: DocumentPosition.Create(3, 4, 5),
                        end: DocumentPosition.Create(0, 1, 2),
                        expectedException: new PreConditionFailure(
                            "Expression: end.CharacterIndex",
                            "Expected: greater than or equal to 3",
                            "Actual:   0"));
                    CreateTest(
                        start: DocumentPosition.Create(3, 4, 5),
                        end: DocumentPosition.Create(10, 1, 2),
                        expectedException: new PreConditionFailure(
                            "Expression: end.LineIndex",
                            "Expected: greater than or equal to 4",
                            "Actual:   1"));
                    CreateTest(
                        start: DocumentPosition.Create(3, 4, 5),
                        end: DocumentPosition.Create(10, 4, 2),
                        expectedException: new PreConditionFailure(
                            "Expression: end.LineIndex != start.LineIndex || end.ColumnIndex >= start.ColumnIndex",
                            "Expected: True",
                            "Actual:   False"));
                    CreateTest(
                        start: DocumentPosition.Create(3, 4, 5),
                        end: DocumentPosition.Create(10, 4, 5));
                    CreateTest(
                        start: DocumentPosition.Create(3, 4, 5),
                        end: DocumentPosition.Create(10, 4, 6));
                    CreateTest(
                        start: DocumentPosition.Create(3, 4, 5),
                        end: DocumentPosition.Create(10, 11, 2));
                    CreateTest(
                        start: DocumentPosition.Create(3, 4, 5),
                        end: DocumentPosition.Create(10, 11, 5));
                    CreateTest(
                        start: DocumentPosition.Create(3, 4, 5),
                        end: DocumentPosition.Create(10, 11, 6));
                });

                runner.TestMethod("Equals(object?)", () =>
                {
                    void EqualsTest(DocumentSpan span, object? rhs, bool expected)
                    {
                        runner.Test($"with {Language.AndList(new object?[] { span, rhs }.Map(runner.ToString))}", (Test test) =>
                        {
                            test.AssertEqual(expected, span.Equals(rhs));
                        });
                    }

                    EqualsTest(
                        span: DocumentSpan.Create(
                            start: DocumentPosition.Create(0, 1, 2),
                            end: DocumentPosition.Create(3, 4, 5)),
                        rhs: null,
                        expected: false);
                    EqualsTest(
                        span: DocumentSpan.Create(
                            start: DocumentPosition.Create(0, 1, 2),
                            end: DocumentPosition.Create(3, 4, 5)),
                        rhs: "hello",
                        expected: false);
                    EqualsTest(
                        span: DocumentSpan.Create(
                            start: DocumentPosition.Create(0, 1, 2),
                            end: DocumentPosition.Create(3, 4, 5)),
                        rhs: DocumentSpan.Create(
                            start: DocumentPosition.Create(0, 1, 2),
                            end: DocumentPosition.Create(3, 4, 5)),
                        expected: true);
                    EqualsTest(
                        span: DocumentSpan.Create(
                            start: DocumentPosition.Create(0, 1, 2),
                            end: DocumentPosition.Create(3, 4, 5)),
                        rhs: DocumentSpan.Create(
                            start: DocumentPosition.Create(1, 1, 2),
                            end: DocumentPosition.Create(3, 4, 5)),
                        expected: false);
                    EqualsTest(
                        span: DocumentSpan.Create(
                            start: DocumentPosition.Create(0, 1, 2),
                            end: DocumentPosition.Create(3, 4, 5)),
                        rhs: DocumentSpan.Create(
                            start: DocumentPosition.Create(0, 2, 2),
                            end: DocumentPosition.Create(3, 4, 5)),
                        expected: false);
                    EqualsTest(
                        span: DocumentSpan.Create(
                            start: DocumentPosition.Create(0, 1, 2),
                            end: DocumentPosition.Create(3, 4, 5)),
                        rhs: DocumentSpan.Create(
                            start: DocumentPosition.Create(0, 1, 3),
                            end: DocumentPosition.Create(3, 4, 5)),
                        expected: false);
                    EqualsTest(
                        span: DocumentSpan.Create(
                            start: DocumentPosition.Create(0, 1, 2),
                            end: DocumentPosition.Create(3, 4, 5)),
                        rhs: DocumentSpan.Create(
                            start: DocumentPosition.Create(0, 1, 2),
                            end: DocumentPosition.Create(4, 4, 5)),
                        expected: false);
                    EqualsTest(
                        span: DocumentSpan.Create(
                            start: DocumentPosition.Create(0, 1, 2),
                            end: DocumentPosition.Create(3, 4, 5)),
                        rhs: DocumentSpan.Create(
                            start: DocumentPosition.Create(0, 1, 2),
                            end: DocumentPosition.Create(3, 5, 5)),
                        expected: false);
                    EqualsTest(
                        span: DocumentSpan.Create(
                            start: DocumentPosition.Create(0, 1, 2),
                            end: DocumentPosition.Create(3, 4, 5)),
                        rhs: DocumentSpan.Create(
                            start: DocumentPosition.Create(0, 1, 2),
                            end: DocumentPosition.Create(3, 4, 6)),
                        expected: false);
                });

                runner.TestMethod("Equals(DocumentSpan?)", () =>
                {
                    void EqualsTest(DocumentSpan span, DocumentSpan? rhs, bool expected)
                    {
                        runner.Test($"with {Language.AndList(new object?[] { span, rhs }.Map(runner.ToString))}", (Test test) =>
                        {
                            test.AssertEqual(expected, span.Equals(rhs));
                        });
                    }

                    EqualsTest(
                        span: DocumentSpan.Create(
                            start: DocumentPosition.Create(0, 1, 2),
                            end: DocumentPosition.Create(3, 4, 5)),
                        rhs: null,
                        expected: false);
                    EqualsTest(
                        span: DocumentSpan.Create(
                            start: DocumentPosition.Create(0, 1, 2),
                            end: DocumentPosition.Create(3, 4, 5)),
                        rhs: DocumentSpan.Create(
                            start: DocumentPosition.Create(0, 1, 2),
                            end: DocumentPosition.Create(3, 4, 5)),
                        expected: true);
                    EqualsTest(
                        span: DocumentSpan.Create(
                            start: DocumentPosition.Create(0, 1, 2),
                            end: DocumentPosition.Create(3, 4, 5)),
                        rhs: DocumentSpan.Create(
                            start: DocumentPosition.Create(1, 1, 2),
                            end: DocumentPosition.Create(3, 4, 5)),
                        expected: false);
                    EqualsTest(
                        span: DocumentSpan.Create(
                            start: DocumentPosition.Create(0, 1, 2),
                            end: DocumentPosition.Create(3, 4, 5)),
                        rhs: DocumentSpan.Create(
                            start: DocumentPosition.Create(0, 2, 2),
                            end: DocumentPosition.Create(3, 4, 5)),
                        expected: false);
                    EqualsTest(
                        span: DocumentSpan.Create(
                            start: DocumentPosition.Create(0, 1, 2),
                            end: DocumentPosition.Create(3, 4, 5)),
                        rhs: DocumentSpan.Create(
                            start: DocumentPosition.Create(0, 1, 3),
                            end: DocumentPosition.Create(3, 4, 5)),
                        expected: false);
                    EqualsTest(
                        span: DocumentSpan.Create(
                            start: DocumentPosition.Create(0, 1, 2),
                            end: DocumentPosition.Create(3, 4, 5)),
                        rhs: DocumentSpan.Create(
                            start: DocumentPosition.Create(0, 1, 2),
                            end: DocumentPosition.Create(4, 4, 5)),
                        expected: false);
                    EqualsTest(
                        span: DocumentSpan.Create(
                            start: DocumentPosition.Create(0, 1, 2),
                            end: DocumentPosition.Create(3, 4, 5)),
                        rhs: DocumentSpan.Create(
                            start: DocumentPosition.Create(0, 1, 2),
                            end: DocumentPosition.Create(3, 5, 5)),
                        expected: false);
                    EqualsTest(
                        span: DocumentSpan.Create(
                            start: DocumentPosition.Create(0, 1, 2),
                            end: DocumentPosition.Create(3, 4, 5)),
                        rhs: DocumentSpan.Create(
                            start: DocumentPosition.Create(0, 1, 2),
                            end: DocumentPosition.Create(3, 4, 6)),
                        expected: false);
                });

                runner.TestMethod("GetHashCode()", () =>
                {
                    void GetHashCodeTest(DocumentSpan lhs, DocumentSpan rhs)
                    {
                        runner.Test($"with {Language.AndList(new[] { lhs, rhs }.Map(runner.ToString))}", (Test test) =>
                        {
                            test.AssertEqual(lhs.Equals(rhs), lhs.GetHashCode() == rhs.GetHashCode());
                        });
                    }

                    GetHashCodeTest(
                        lhs: DocumentSpan.Create(
                            start: DocumentPosition.Create(0, 1, 2),
                            end: DocumentPosition.Create(3, 4, 5)),
                        rhs: DocumentSpan.Create(
                            start: DocumentPosition.Create(0, 1, 2),
                            end: DocumentPosition.Create(3, 4, 5)));
                    GetHashCodeTest(
                        lhs: DocumentSpan.Create(
                            start: DocumentPosition.Create(0, 1, 2),
                            end: DocumentPosition.Create(3, 4, 5)),
                        rhs: DocumentSpan.Create(
                            start: DocumentPosition.Create(1, 1, 2),
                            end: DocumentPosition.Create(3, 4, 5)));
                    GetHashCodeTest(
                        lhs: DocumentSpan.Create(
                            start: DocumentPosition.Create(0, 1, 2),
                            end: DocumentPosition.Create(3, 4, 5)),
                        rhs: DocumentSpan.Create(
                            start: DocumentPosition.Create(0, 2, 2),
                            end: DocumentPosition.Create(3, 4, 5)));
                    GetHashCodeTest(
                        lhs: DocumentSpan.Create(
                            start: DocumentPosition.Create(0, 1, 2),
                            end: DocumentPosition.Create(3, 4, 5)),
                        rhs: DocumentSpan.Create(
                            start: DocumentPosition.Create(0, 1, 3),
                            end: DocumentPosition.Create(3, 4, 5)));
                    GetHashCodeTest(
                        lhs: DocumentSpan.Create(
                            start: DocumentPosition.Create(0, 1, 2),
                            end: DocumentPosition.Create(3, 4, 5)),
                        rhs: DocumentSpan.Create(
                            start: DocumentPosition.Create(0, 1, 2),
                            end: DocumentPosition.Create(4, 4, 5)));
                    GetHashCodeTest(
                        lhs: DocumentSpan.Create(
                            start: DocumentPosition.Create(0, 1, 2),
                            end: DocumentPosition.Create(3, 4, 5)),
                        rhs: DocumentSpan.Create(
                            start: DocumentPosition.Create(0, 1, 2),
                            end: DocumentPosition.Create(3, 5, 5)));
                    GetHashCodeTest(
                        lhs: DocumentSpan.Create(
                            start: DocumentPosition.Create(0, 1, 2),
                            end: DocumentPosition.Create(3, 4, 5)),
                        rhs: DocumentSpan.Create(
                            start: DocumentPosition.Create(0, 1, 2),
                            end: DocumentPosition.Create(3, 4, 6)));
                });

                runner.TestMethod("ToString()", () =>
                {
                    void ToStringTest(DocumentSpan span, string expected)
                    {
                        runner.Test($"with {span}", (Test test) =>
                        {
                            test.AssertEqual(expected, span.ToString());
                        });
                    }

                    ToStringTest(
                        span: DocumentSpan.Create(
                            DocumentPosition.Create(0, 1, 2),
                            DocumentPosition.Create(3, 4, 5)),
                        expected: "{\"Start\":{\"CharacterIndex\":0,\"LineIndex\":1,\"ColumnIndex\":2},\"End\":{\"CharacterIndex\":3,\"LineIndex\":4,\"ColumnIndex\":5}}");
                    ToStringTest(
                        span: DocumentSpan.Create(
                            DocumentPosition.Create(6, 7, 8),
                            DocumentPosition.Create(9, 10, 11)),
                        expected: "{\"Start\":{\"CharacterIndex\":6,\"LineIndex\":7,\"ColumnIndex\":8},\"End\":{\"CharacterIndex\":9,\"LineIndex\":10,\"ColumnIndex\":11}}");
                });
            });
        }
    }
}

using System;

namespace Everyone
{
    public static class DocumentPositionTests
    {
        public static void Test(TestRunner runner)
        {
            runner.TestType<DocumentPosition>(() =>
            {
                runner.TestMethod("Create(int,int,int)", () =>
                {
                    void CreateTest(int characterIndex, int lineIndex, int columnIndex, Exception? expectedException = null)
                    {
                        runner.Test($"with {Language.AndList(new[] { characterIndex, lineIndex, columnIndex }.Map(runner.ToString))}", (Test test) =>
                        {
                            test.AssertThrows(expectedException, () =>
                            {
                                DocumentPosition position = DocumentPosition.Create(characterIndex, lineIndex, columnIndex);
                                test.AssertNotNull(position);
                                test.AssertEqual(characterIndex, position.CharacterIndex);
                                test.AssertEqual(characterIndex + 1, position.CharacterNumber);
                                test.AssertEqual(lineIndex, position.LineIndex);
                                test.AssertEqual(lineIndex + 1, position.LineNumber);
                                test.AssertEqual(columnIndex, position.ColumnIndex);
                                test.AssertEqual(columnIndex + 1, position.ColumnNumber);
                            });
                        });
                    }

                    CreateTest(
                        characterIndex: -1,
                        lineIndex: 1,
                        columnIndex: 2,
                        expectedException: new PreConditionFailure(
                            "Expression: characterIndex",
                            "Expected: greater than or equal to 0",
                            "Actual:   -1"));
                    CreateTest(
                        characterIndex: 0,
                        lineIndex: -1,
                        columnIndex: 2,
                        expectedException: new PreConditionFailure(
                            "Expression: lineIndex",
                            "Expected: greater than or equal to 0",
                            "Actual:   -1"));
                    CreateTest(
                        characterIndex: 0,
                        lineIndex: 1,
                        columnIndex: -1,
                        expectedException: new PreConditionFailure(
                            "Expression: columnIndex",
                            "Expected: greater than or equal to 0",
                            "Actual:   -1"));
                    CreateTest(
                        characterIndex: 0,
                        lineIndex: 1,
                        columnIndex: 2);
                });

                runner.TestMethod("Equals(object?)", () =>
                {
                    void EqualsTest(DocumentPosition position, object? rhs, bool expected)
                    {
                        runner.Test($"with {Language.AndList(new object?[] { position, rhs }.Map(runner.ToString))}", (Test test) =>
                        {
                            test.AssertEqual(expected, position.Equals(rhs));
                        });
                    }

                    EqualsTest(DocumentPosition.Create(0, 1, 2), null, false);
                    EqualsTest(DocumentPosition.Create(0, 1, 2), "hello", false);
                    EqualsTest(DocumentPosition.Create(0, 1, 2), DocumentPosition.Create(0, 1, 2), true);
                    EqualsTest(DocumentPosition.Create(0, 1, 2), DocumentPosition.Create(-1, 1, 2), false);
                    EqualsTest(DocumentPosition.Create(0, 1, 2), DocumentPosition.Create(0, -1, 2), false);
                    EqualsTest(DocumentPosition.Create(0, 1, 2), DocumentPosition.Create(0, 1, -2), false);
                });

                runner.TestMethod("Equals(DocumentPosition?)", () =>
                {
                    void EqualsTest(DocumentPosition position, DocumentPosition? rhs, bool expected)
                    {
                        runner.Test($"with {Language.AndList(new object?[] { position, rhs }.Map(runner.ToString))}", (Test test) =>
                        {
                            test.AssertEqual(expected, position.Equals(rhs));
                        });
                    }

                    EqualsTest(DocumentPosition.Create(0, 1, 2), null, false);
                    EqualsTest(DocumentPosition.Create(0, 1, 2), DocumentPosition.Create(0, 1, 2), true);
                    EqualsTest(DocumentPosition.Create(0, 1, 2), DocumentPosition.Create(-1, 1, 2), false);
                    EqualsTest(DocumentPosition.Create(0, 1, 2), DocumentPosition.Create(0, -1, 2), false);
                    EqualsTest(DocumentPosition.Create(0, 1, 2), DocumentPosition.Create(0, 1, -2), false);
                });

                runner.TestMethod("GetHashCode()", () =>
                {
                    void GetHashCodeTest(DocumentPosition lhs, DocumentPosition rhs)
                    {
                        runner.Test($"with {Language.AndList(lhs, rhs)}", (Test test) =>
                        {
                            test.AssertEqual(lhs.Equals(rhs), lhs.GetHashCode() == rhs.GetHashCode());
                        });
                    }

                    GetHashCodeTest(DocumentPosition.Create(0, 1, 2), DocumentPosition.Create(0, 1, 2));
                    GetHashCodeTest(DocumentPosition.Create(0, 1, 2), DocumentPosition.Create(-1, 1, 2));
                    GetHashCodeTest(DocumentPosition.Create(0, 1, 2), DocumentPosition.Create(0, -1, 2));
                    GetHashCodeTest(DocumentPosition.Create(0, 1, 2), DocumentPosition.Create(0, 1, -2));
                });

                runner.TestMethod("ToString()", () =>
                {
                    void ToStringTest(DocumentPosition position, string expected)
                    {
                        runner.Test($"with {position.ToString()}", (Test test) =>
                        {
                            test.AssertEqual(expected, position.ToString());
                        });
                    }

                    ToStringTest(DocumentPosition.Create(0, 1, 2), "{\"CharacterIndex\":0,\"LineIndex\":1,\"ColumnIndex\":2}");
                    ToStringTest(DocumentPosition.Create(3, 4, 5), "{\"CharacterIndex\":3,\"LineIndex\":4,\"ColumnIndex\":5}");
                });
            });
        }
    }
}

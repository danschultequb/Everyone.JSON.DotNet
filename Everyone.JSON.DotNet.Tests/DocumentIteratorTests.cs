using System;
using System.Collections.Generic;

namespace Everyone
{
    public static class DocumentIteratorTests
    {
        public static void Test(TestRunner runner)
        {
            runner.TestType<DocumentIterator>(() =>
            {
                runner.TestMethod("Create(IEnumerable<char>)", () =>
                {
                    void CreateTest(IEnumerable<char> characters, Exception? expectedException = null)
                    {
                        runner.Test($"with {runner.ToString(characters)}", (Test test) =>
                        {
                            test.AssertThrows(expectedException, () =>
                            {
                                using (DocumentIterator iterator = DocumentIterator.Create(characters))
                                {
                                    test.AssertNotNull(iterator);
                                    test.AssertNotDisposed(iterator);
                                    test.AssertFalse(iterator.HasStarted());
                                    test.AssertFalse(iterator.HasCurrent());
                                }
                            });
                        });
                    }

                    CreateTest(
                        characters: null!,
                        expectedException: new PreConditionFailure(
                            "Expression: characters",
                            "Expected: not null",
                            "Actual:   null"));
                    CreateTest(new char[0]);
                    CreateTest("");
                    CreateTest(Iterator.Create<char>());
                    CreateTest(Iterable.Create<char>());
                });

                runner.TestMethod("Next()", () =>
                {
                    void NextTest(string text)
                    {
                        runner.Test($"with {runner.ToString(text)}", (Test test) =>
                        {
                            using (DocumentIterator documentIterator = DocumentIterator.Create(text))
                            {
                                int expectedCharacterIndex = 0;
                                int expectedLineIndex = 0;
                                int expectedColumnIndex = 0;

                                foreach (char character in text)
                                {
                                    test.AssertTrue(documentIterator.Next());
                                    test.AssertTrue(documentIterator.HasStarted());
                                    test.AssertTrue(documentIterator.HasCurrent());
                                    test.AssertEqual(character, documentIterator.Current);
                                    test.AssertNotDisposed(documentIterator);

                                    test.AssertEqual(expectedCharacterIndex, documentIterator.CharacterIndex);
                                    test.AssertEqual(expectedCharacterIndex + 1, documentIterator.CharacterNumber);

                                    test.AssertEqual(expectedLineIndex, documentIterator.LineIndex);
                                    test.AssertEqual(expectedLineIndex + 1, documentIterator.LineNumber);

                                    test.AssertEqual(expectedColumnIndex, documentIterator.ColumnIndex);
                                    test.AssertEqual(expectedColumnIndex + 1, documentIterator.ColumnNumber);

                                    test.AssertEqual(
                                        expected: DocumentPosition.Create(
                                            characterIndex: expectedCharacterIndex,
                                            lineIndex: expectedLineIndex,
                                            columnIndex: expectedColumnIndex),
                                        actual: documentIterator.Position);

                                    expectedCharacterIndex++;
                                    if (documentIterator.Current == '\n')
                                    {
                                        expectedLineIndex++;
                                        expectedColumnIndex = 0;
                                    }
                                    else
                                    {
                                        expectedColumnIndex++;
                                    }
                                }

                                for (int i = 0; i < 2; i++)
                                {
                                    test.AssertFalse(documentIterator.Next());
                                    test.AssertTrue(documentIterator.HasStarted());
                                    test.AssertFalse(documentIterator.HasCurrent());
                                    test.AssertNotDisposed(documentIterator);
                                    
                                    test.AssertEqual(expectedCharacterIndex, documentIterator.CharacterIndex);
                                    test.AssertEqual(expectedCharacterIndex + 1, documentIterator.CharacterNumber);

                                    test.AssertEqual(expectedLineIndex, documentIterator.LineIndex);
                                    test.AssertEqual(expectedLineIndex + 1, documentIterator.LineNumber);

                                    test.AssertEqual(expectedColumnIndex, documentIterator.ColumnIndex);
                                    test.AssertEqual(expectedColumnIndex + 1, documentIterator.ColumnNumber);

                                    test.AssertEqual(
                                        expected: DocumentPosition.Create(
                                            characterIndex: expectedCharacterIndex,
                                            lineIndex: expectedLineIndex,
                                            columnIndex: expectedColumnIndex),
                                        actual: documentIterator.Position);
                                }
                            }
                        });
                    }

                    NextTest("");
                    NextTest("abc");
                    NextTest("Hello world!");
                    NextTest("a\r\nb\rc\nd\n");
                });
            });
        }
    }
}

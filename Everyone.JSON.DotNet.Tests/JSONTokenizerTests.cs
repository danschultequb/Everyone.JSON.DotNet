using System;
using System.Collections.Generic;

namespace Everyone
{
    public static class JSONTokenizerTests
    {
        public static void Test(TestRunner runner)
        {
            runner.TestType<JSONTokenizer>(() =>
            {
                runner.TestMethod("Create(IEnumerable<char>)", () =>
                {
                    void CreateTest(IEnumerable<char> characters, Exception? expectedException = null)
                    {
                        runner.Test($"with {runner.ToString(characters)} ({Types.GetFullName(characters)})", (Test test) =>
                        {
                            test.AssertThrows(expectedException, () =>
                            {
                                using (JSONTokenizer tokenizer = JSONTokenizer.Create(characters))
                                {
                                    test.AssertNotNull(tokenizer);
                                    test.AssertNotDisposed(tokenizer);
                                    test.AssertFalse(tokenizer.HasStarted());
                                    test.AssertFalse(tokenizer.HasCurrent());
                                    test.AssertThrows(() => { JSONToken _ = tokenizer.Current; },
                                        new PreConditionFailure(
                                            "Expression: this.HasCurrent()",
                                            "Expected: True",
                                            "Actual:   False"));
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
                    CreateTest(characters: "");
                    CreateTest(characters: "abc");
                    CreateTest(characters: new[] { 'a', 'b', 'c' });
                    CreateTest(characters: List.Create('a', 'b', 'c'));
                });

                runner.TestMethod("Dispose()", (Test test) =>
                {
                    using (JSONTokenizer tokenizer = JSONTokenizer.Create(""))
                    {
                        test.AssertNotDisposed(tokenizer);

                        test.AssertTrue(tokenizer.Dispose());
                        test.AssertDisposed(tokenizer);

                        for (int i = 0; i < 2; i++)
                        {
                            test.AssertFalse(tokenizer.Dispose());
                            test.AssertDisposed(tokenizer);
                        }
                    }
                });

                runner.TestMethod("Next()", () =>
                {
                    void NextTest(IEnumerable<char> characters, IEnumerable<JSONToken> expected)
                    {
                        runner.Test($"with {runner.ToString(characters)}", (Test test) =>
                        {
                            using (JSONTokenizer tokenizer = JSONTokenizer.Create(characters))
                            {
                                foreach (JSONToken expectedToken in expected)
                                {
                                    test.AssertTrue(tokenizer.Next(), "tokenizer.Next()");
                                    test.AssertTrue(tokenizer.HasStarted(), "tokenizer.HasStarted()");
                                    test.AssertTrue(tokenizer.HasCurrent(), "tokenizer.HasCurrent()");
                                    test.AssertEqual(expectedToken, tokenizer.Current, "tokenizer.Current");
                                }

                                for (int i = 0; i < 2; i++)
                                {
                                    test.AssertFalse(tokenizer.Next(), "tokenizer.Next()");
                                    test.AssertTrue(tokenizer.HasStarted(), "tokenizer.HasStarted()");
                                    test.AssertFalse(tokenizer.HasCurrent(), "tokenizer.HasCurrent()");
                                }
                            }
                        });
                    }

                    NextTest(
                        characters: "",
                        expected: new JSONToken[0]);
                    NextTest(
                        characters: "{",
                        expected: new[] { JSONToken.LeftCurlyBracket });
                    NextTest(
                        characters: "}",
                        expected: new[] { JSONToken.RightCurlyBracket });
                    NextTest(
                        characters: "[",
                        expected: new[] { JSONToken.LeftSquareBracket });
                    NextTest(
                        characters: "]",
                        expected: new[] { JSONToken.RightSquareBracket });
                    NextTest(
                        characters: ":",
                        expected: new[] { JSONToken.Colon });
                    NextTest(
                        characters: ",",
                        expected: new[] { JSONToken.Comma });
                    NextTest(
                        characters: "n",
                        expected: new[] { JSONToken.Unknown("n") });
                    NextTest(
                        characters: "nu",
                        expected: new[] { JSONToken.Unknown("nu") });
                    NextTest(
                        characters: "nul",
                        expected: new[] { JSONToken.Unknown("nul") });
                    NextTest(
                        characters: "null",
                        expected: new[] { JSONToken.Null });
                    NextTest(
                        characters: "nullo",
                        expected: new[] { JSONToken.Unknown("nullo") });
                    NextTest(
                        characters: "NULL",
                        expected: new[] { JSONToken.Unknown("NULL") });
                    NextTest(
                        characters: " ",
                        expected: new[] { JSONToken.Whitespace(" ") });
                    NextTest(
                        characters: "\t",
                        expected: new[] { JSONToken.Whitespace("\t") });
                    NextTest(
                        characters: "\r",
                        expected: new[] { JSONToken.Whitespace("\r") });
                    NextTest(
                        characters: "\n",
                        expected: new[] { JSONToken.Whitespace("\n") });
                    NextTest(
                        characters: "\f",
                        expected: new[] { JSONToken.Unknown("\f") });
                    NextTest(
                        characters: "\v",
                        expected: new[] { JSONToken.Unknown("\v") });
                    NextTest(
                        characters: "   ",
                        expected: new[] { JSONToken.Whitespace("   ") });
                    NextTest(
                        characters: " \t \r \n ",
                        expected: new[] { JSONToken.Whitespace(" \t \r \n ") });
                    NextTest(
                        characters: "'",
                        expected: new[] { JSONString.Create("'", endQuote: null) });
                    NextTest(
                        characters: "\"",
                        expected: new[] { JSONString.Create("\"", endQuote: null) });
                    NextTest(
                        characters: "''",
                        expected: new[] { JSONString.Create("''", endQuote: '\'') });
                    NextTest(
                        characters: "\"\"",
                        expected: new[] { JSONString.Create("\"\"", endQuote: '\"') });
                    NextTest(
                        characters: "'hello'",
                        expected: new[] { JSONString.Create("'hello'", '\'') });
                    NextTest(
                        characters: "'He said, \\\"Hi there!\\\"'",
                        expected: new[] { JSONString.Create("'He said, \\\"Hi there!\\\"'", '\'') });
                    NextTest(
                        characters: "\"Jonny's Sandles\"",
                        expected: new[] { JSONString.Create("\"Jonny's Sandles\"", '"') });
                    NextTest(
                        characters: "'Missing end quote",
                        expected: new[] { JSONString.Create("'Missing end quote", null) });
                    NextTest(
                        characters: "\"Missing end quote",
                        expected: new[] { JSONString.Create("\"Missing end quote", null) });
                    NextTest(
                        characters: "false",
                        expected: new[] { JSONToken.False });
                    NextTest(
                        characters: "true",
                        expected: new[] { JSONToken.True });
                    NextTest(
                        characters: "FALSE",
                        expected: new[] { JSONToken.Unknown("FALSE") });
                    NextTest(
                        characters: "TRUE",
                        expected: new[] { JSONToken.Unknown("TRUE") });
                    NextTest(
                        characters: "0",
                        expected: new[] { JSONToken.Number("0") });
                    NextTest(
                        characters: "1",
                        expected: new[] { JSONToken.Number("1") });
                    NextTest(
                        characters: "123",
                        expected: new[] { JSONToken.Number("123") });
                    NextTest(
                        characters: "1.23",
                        expected: new[] { JSONToken.Number("1.23") });
                    NextTest(
                        characters: "1.",
                        expected: new[] { JSONToken.Number("1.") });
                    NextTest(
                        characters: ".1",
                        expected: new[] { JSONToken.Number(".1") });
                    NextTest(
                        characters: ".",
                        expected: new[] { JSONToken.Unknown(".") });
                    NextTest(
                        characters: "-",
                        expected: new[] { JSONToken.Unknown("-") });
                    NextTest(
                        characters: "+",
                        expected: new[] { JSONToken.Unknown("+") });
                    NextTest(
                        characters: "-.",
                        expected: new[] { JSONToken.Unknown("-.") });
                    NextTest(
                        characters: "+.",
                        expected: new[] { JSONToken.Unknown("+.") });
                    NextTest(
                        characters: "1e",
                        expected: new[] { JSONNumber.Create("1e") });
                    NextTest(
                        characters: "1e-",
                        expected: new[] { JSONNumber.Create("1e-") });
                    NextTest(
                        characters: "1e+",
                        expected: new[] { JSONNumber.Create("1e+") });
                    NextTest(
                        characters: "1e2",
                        expected: new[] { JSONNumber.Create("1e2") });
                    NextTest(
                        characters: "1e-2",
                        expected: new[] { JSONNumber.Create("1e-2") });
                    NextTest(
                        characters: "1e+2",
                        expected: new[] { JSONNumber.Create("1e+2") });
                    NextTest(
                        characters: "@",
                        expected: new[] { JSONToken.Unknown("@") });
                    NextTest(
                        characters: "?",
                        expected: new[] { JSONToken.Unknown("?") });
                });
            });
        }
    }
}

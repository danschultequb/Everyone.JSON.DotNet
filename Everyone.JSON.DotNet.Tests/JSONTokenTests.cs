using System;

namespace Everyone
{
    public static class JSONTokenTests
    {
        public static void Test(TestRunner runner)
        {
            runner.TestType<JSONToken>(() =>
            {
                runner.TestMethod($"Create(string,{nameof(JSONTokenType)}", () =>
                {
                    void CreateTest(string text, JSONTokenType type, Exception? expectedException = null)
                    {
                        runner.Test($"with {Language.AndList(new object[] { text, type }.Map(runner.ToString))}", (Test test) =>
                        {
                            test.AssertThrows(expectedException, () =>
                            {
                                JSONToken token = JSONToken.Create(text, type);
                                test.AssertNotNull(token);
                                test.AssertEqual(text, token.Text);
                                test.AssertEqual(type, token.Type);
                            });
                        });
                    }

                    CreateTest(
                        text: null!,
                        type: JSONTokenType.Null,
                        expectedException: new PreConditionFailure(
                            "Expression: text",
                            "Expected: not null and not empty",
                            "Actual:   null"));
                    CreateTest(
                        text: "",
                        type: JSONTokenType.Null,
                        expectedException: new PreConditionFailure(
                            "Expression: text",
                            "Expected: not null and not empty",
                            "Actual:   \"\""));
                    CreateTest(
                        text: "123",
                        type: JSONTokenType.Number);
                });

                runner.TestMethod("Equals(object?)", () =>
                {
                    void EqualsTest(JSONToken token, object? rhs, bool expected)
                    {
                        runner.Test($"with {Language.AndList(new object?[] { token, rhs }.Map(runner.ToString))}", (Test test) =>
                        {
                            test.AssertEqual(expected, token.Equals(rhs));
                        });
                    }

                    EqualsTest(JSONToken.Comma, null, false);
                    EqualsTest(JSONToken.Comma, ",", false);
                    EqualsTest(JSONToken.Comma, JSONToken.Comma, true);
                    EqualsTest(JSONToken.Comma, JSONToken.Create(",", JSONTokenType.Null), false);
                    EqualsTest(JSONToken.Number("5"), JSONToken.Number("5.0"), false);
                });

                runner.TestMethod($"Equals({nameof(JSONToken)}?)", () =>
                {
                    void EqualsTest(JSONToken token, JSONToken? rhs, bool expected)
                    {
                        runner.Test($"with {Language.AndList(new object?[] { token, rhs }.Map(runner.ToString))}", (Test test) =>
                        {
                            test.AssertEqual(expected, token.Equals(rhs));
                        });
                    }

                    EqualsTest(JSONToken.Comma, null, false);
                    EqualsTest(JSONToken.Comma, JSONToken.Comma, true);
                    EqualsTest(JSONToken.Comma, JSONToken.Create(",", JSONTokenType.Null), false);
                    EqualsTest(JSONToken.Number("5"), JSONToken.Number("5.0"), false);
                });

                runner.TestMethod($"GetHashCode({nameof(JSONToken)}?)", () =>
                {
                    void EqualsTest(JSONToken token, JSONToken rhs)
                    {
                        runner.Test($"with {Language.AndList(new[] { token, rhs }.Map(runner.ToString))}", (Test test) =>
                        {
                            test.AssertEqual(token.Equals(rhs), token.GetHashCode() == rhs.GetHashCode());
                        });
                    }

                    EqualsTest(JSONToken.Comma, JSONToken.Comma);
                    EqualsTest(JSONToken.Comma, JSONToken.Create(",", JSONTokenType.Null));
                    EqualsTest(JSONToken.Number("5"), JSONToken.Number("5.0"));
                });

                runner.TestMethod("LeftCurlyBracket", (Test test) =>
                {
                    JSONToken token = JSONToken.LeftCurlyBracket;
                    test.AssertNotNull(token);
                    test.AssertEqual("{", token.Text);
                    test.AssertEqual(JSONTokenType.LeftCurlyBracket, token.Type);
                });

                runner.TestMethod("RightCurlyBracket", (Test test) =>
                {
                    JSONToken token = JSONToken.RightCurlyBracket;
                    test.AssertNotNull(token);
                    test.AssertEqual("}", token.Text);
                    test.AssertEqual(JSONTokenType.RightCurlyBracket, token.Type);
                });

                runner.TestMethod("LeftSquareBracket", (Test test) =>
                {
                    JSONToken token = JSONToken.LeftSquareBracket;
                    test.AssertNotNull(token);
                    test.AssertEqual("[", token.Text);
                    test.AssertEqual(JSONTokenType.LeftSquareBracket, token.Type);
                });

                runner.TestMethod("RightSquareBracket", (Test test) =>
                {
                    JSONToken token = JSONToken.RightSquareBracket;
                    test.AssertNotNull(token);
                    test.AssertEqual("]", token.Text);
                    test.AssertEqual(JSONTokenType.RightSquareBracket, token.Type);
                });

                runner.TestMethod("Colon", (Test test) =>
                {
                    JSONToken token = JSONToken.Colon;
                    test.AssertNotNull(token);
                    test.AssertEqual(":", token.Text);
                    test.AssertEqual(JSONTokenType.Colon, token.Type);
                });

                runner.TestMethod("Comma", (Test test) =>
                {
                    JSONToken token = JSONToken.Comma;
                    test.AssertNotNull(token);
                    test.AssertEqual(",", token.Text);
                    test.AssertEqual(JSONTokenType.Comma, token.Type);
                });

                runner.TestMethod("Null", (Test test) =>
                {
                    JSONToken token = JSONToken.Null;
                    test.AssertNotNull(token);
                    test.AssertEqual("null", token.Text);
                    test.AssertEqual(JSONTokenType.Null, token.Type);
                });

                runner.TestMethod("Whitespace(string)", () =>
                {
                    void WhitespaceTest(string text, Exception? expectedException = null)
                    {
                        runner.Test($"with {runner.ToString(text)}", (Test test) =>
                        {
                            test.AssertThrows(expectedException, () =>
                            {
                                JSONToken token = JSONToken.Whitespace(text);
                                test.AssertNotNull(token);
                                test.AssertEqual(text, token.Text);
                                test.AssertEqual(JSONTokenType.Whitespace, token.Type);
                            });
                        });
                    }

                    WhitespaceTest(
                        text: null!,
                        expectedException: new PreConditionFailure(
                            "Expression: text",
                            "Expected: not null and not empty",
                            "Actual:   null"));
                    WhitespaceTest(
                        text: "",
                        expectedException: new PreConditionFailure(
                            "Expression: text",
                            "Expected: not null and not empty",
                            "Actual:   \"\""));
                    WhitespaceTest("abc");
                    WhitespaceTest(" ");
                    WhitespaceTest("\t");
                    WhitespaceTest("\r");
                    WhitespaceTest("\n");
                    WhitespaceTest("\r\n");
                    WhitespaceTest("  \t\t  \n\n \r\n");
                });

                runner.TestMethod("QuotedString(string)", () =>
                {
                    void QuotedStringTest(string text, char? endQuote, Exception? expectedException = null)
                    {
                        runner.Test($"with {Language.AndList(new object?[] { text, endQuote }.Map(runner.ToString))}", (Test test) =>
                        {
                            test.AssertThrows(expectedException, () =>
                            {
                                JSONString token = JSONToken.QuotedString(text, endQuote);
                                test.AssertNotNull(token);
                                test.AssertEqual(text, token.Text);
                                test.AssertEqual(endQuote, token.EndQuote);
                                test.AssertEqual(JSONTokenType.QuotedString, token.Type);
                            });
                        });
                    }

                    QuotedStringTest(
                        text: null!,
                        endQuote: null,
                        expectedException: new PreConditionFailure(
                            "Expression: text",
                            "Expected: not null and not empty",
                            "Actual:   null"));
                    QuotedStringTest(
                        text: "",
                        endQuote: null,
                        expectedException: new PreConditionFailure(
                            "Expression: text",
                            "Expected: not null and not empty",
                            "Actual:   \"\""));
                    QuotedStringTest(
                        text: "abc",
                        endQuote: null,
                        expectedException: new PreConditionFailure(
                            "Expression: text.First()",
                            "Expected: one of ['\\'','\"']",
                            "Actual:   'a'"));
                    QuotedStringTest(
                        text: " ",
                        endQuote: null,
                        expectedException: new PreConditionFailure(
                            "Expression: text.First()",
                            "Expected: one of ['\\'','\"']",
                            "Actual:   ' '"));
                    QuotedStringTest("'", null);
                    QuotedStringTest("\"", null);
                    QuotedStringTest("''", null);
                    QuotedStringTest("''", '\'');
                    QuotedStringTest("\"\"", null);
                    QuotedStringTest("\"\"", '"');
                    QuotedStringTest("'hello'", null);
                    QuotedStringTest("'hello'", '\'');
                    QuotedStringTest("'  \n  '", null);
                    QuotedStringTest("'  \n  '", '\'');
                });

                runner.TestMethod("Boolean(string)", () =>
                {
                    void BooleanTest(string text, Exception? expectedException = null)
                    {
                        runner.Test($"with {runner.ToString(text)}", (Test test) =>
                        {
                            test.AssertThrows(expectedException, () =>
                            {
                                JSONToken token = JSONToken.Boolean(text);
                                test.AssertNotNull(token);
                                test.AssertEqual(text, token.Text);
                                test.AssertEqual(JSONTokenType.Boolean, token.Type);
                            });
                        });
                    }

                    BooleanTest(
                        text: null!,
                        expectedException: new PreConditionFailure(
                            "Expression: text",
                            "Expected: not null and not empty",
                            "Actual:   null"));
                    BooleanTest(
                        text: "",
                        expectedException: new PreConditionFailure(
                            "Expression: text",
                            "Expected: not null and not empty",
                            "Actual:   \"\""));
                    BooleanTest("abc");
                    BooleanTest(" ");
                    BooleanTest("false");
                    BooleanTest("FALSE");
                    BooleanTest("true");
                    BooleanTest("TRUE");
                });

                runner.TestMethod("Boolean(bool)", () =>
                {
                    void BooleanTest(bool value)
                    {
                        runner.Test($"with {runner.ToString(value)}", (Test test) =>
                        {
                            JSONToken token = JSONToken.Boolean(value);
                            test.AssertNotNull(token);
                            test.AssertEqual(value.ToString().ToLower(), token.Text);
                            test.AssertEqual(JSONTokenType.Boolean, token.Type);
                        });
                    }

                    BooleanTest(true);
                    BooleanTest(false);
                });

                runner.TestMethod("False", (Test test) =>
                {
                    JSONToken token = JSONToken.False;
                    test.AssertNotNull(token);
                    test.AssertEqual("false", token.Text);
                    test.AssertEqual(JSONTokenType.Boolean, token.Type);
                });

                runner.TestMethod("True", (Test test) =>
                {
                    JSONToken token = JSONToken.True;
                    test.AssertNotNull(token);
                    test.AssertEqual("true", token.Text);
                    test.AssertEqual(JSONTokenType.Boolean, token.Type);
                });

                runner.TestMethod("Number(string)", () =>
                {
                    void NumberTest(string text, Exception? expectedException = null)
                    {
                        runner.Test($"with {runner.ToString(text)}", (Test test) =>
                        {
                            test.AssertThrows(expectedException, () =>
                            {
                                JSONToken token = JSONToken.Number(text);
                                test.AssertNotNull(token);
                                test.AssertEqual(text, token.Text);
                                test.AssertEqual(JSONTokenType.Number, token.Type);
                            });
                        });
                    }

                    NumberTest(
                        text: null!,
                        expectedException: new PreConditionFailure(
                            "Expression: text",
                            "Expected: not null and not empty",
                            "Actual:   null"));
                    NumberTest(
                        text: "",
                        expectedException: new PreConditionFailure(
                            "Expression: text",
                            "Expected: not null and not empty",
                            "Actual:   \"\""));
                    NumberTest("abc");
                    NumberTest(" ");
                    NumberTest("1");
                    NumberTest("123");
                    NumberTest("123159871359871349587194358729348752987345");
                    NumberTest("0");
                    NumberTest("1.3");
                    NumberTest("1.3e10");
                    NumberTest("1.3e-10");
                });

                runner.TestMethod("Number(long)", () =>
                {
                    void NumberTest(long value)
                    {
                        runner.Test($"with {runner.ToString(value)}", (Test test) =>
                        {
                            JSONToken token = JSONToken.Number(value);
                            test.AssertNotNull(token);
                            test.AssertEqual(value.ToString(), token.Text);
                            test.AssertEqual(JSONTokenType.Number, token.Type);
                        });
                    }

                    NumberTest(0);
                    NumberTest(1);
                    NumberTest(-1);
                    NumberTest(1325481723498713249L);
                });

                runner.TestMethod("Number(double)", () =>
                {
                    void NumberTest(double value)
                    {
                        runner.Test($"with {runner.ToString(value)}", (Test test) =>
                        {
                            JSONToken token = JSONToken.Number(value);
                            test.AssertNotNull(token);
                            test.AssertEqual(value.ToString(), token.Text);
                            test.AssertEqual(JSONTokenType.Number, token.Type);
                        });
                    }

                    NumberTest(0.0);
                    NumberTest(1.0);
                    NumberTest(-1.0);
                    NumberTest(1325481723498713249.0);
                    NumberTest(-1325481723498713249.0);
                    NumberTest(0.1325481723498713249);
                    NumberTest(-0.1325481723498713249);
                });

                runner.TestMethod("LineComment(string)", () =>
                {
                    void LineCommentTest(string text, Exception? expectedException = null)
                    {
                        runner.Test($"with {runner.ToString(text)}", (Test test) =>
                        {
                            test.AssertThrows(expectedException, () =>
                            {
                                JSONToken token = JSONToken.LineComment(text);
                                test.AssertNotNull(token);
                                test.AssertEqual(text, token.Text);
                                test.AssertEqual(JSONTokenType.LineComment, token.Type);
                            });
                        });
                    }

                    LineCommentTest(
                        text: null!,
                        expectedException: new PreConditionFailure(
                            "Expression: text",
                            "Expected: not null and not empty",
                            "Actual:   null"));
                    LineCommentTest(
                        text: "",
                        expectedException: new PreConditionFailure(
                            "Expression: text",
                            "Expected: not null and not empty",
                            "Actual:   \"\""));
                    LineCommentTest("abc");
                    LineCommentTest(" ");
                    LineCommentTest("1");
                    LineCommentTest("//");
                    LineCommentTest("//       ");
                    LineCommentTest("// Hello there");
                    LineCommentTest("// a // b // c // d");
                });

                runner.TestMethod("BlockComment(string)", () =>
                {
                    void BlockCommentTest(string text, Exception? expectedException = null)
                    {
                        runner.Test($"with {runner.ToString(text)}", (Test test) =>
                        {
                            test.AssertThrows(expectedException, () =>
                            {
                                JSONToken token = JSONToken.BlockComment(text);
                                test.AssertNotNull(token);
                                test.AssertEqual(text, token.Text);
                                test.AssertEqual(JSONTokenType.BlockComment, token.Type);
                            });
                        });
                    }

                    BlockCommentTest(
                        text: null!,
                        expectedException: new PreConditionFailure(
                            "Expression: text",
                            "Expected: not null and not empty",
                            "Actual:   null"));
                    BlockCommentTest(
                        text: "",
                        expectedException: new PreConditionFailure(
                            "Expression: text",
                            "Expected: not null and not empty",
                            "Actual:   \"\""));
                    BlockCommentTest("abc");
                    BlockCommentTest(" ");
                    BlockCommentTest("1");
                    BlockCommentTest("//");
                    BlockCommentTest("/*");
                    BlockCommentTest("/**");
                    BlockCommentTest("/**/");
                    BlockCommentTest("/* */");
                    BlockCommentTest("/* // */");
                });
            });
        }
    }
}

using System;

namespace Everyone
{
    public static class JSONArrayTests
    {
        public static void Test(TestRunner runner)
        {
            runner.TestType<JSONArray>(() =>
            {
                runner.TestMethod("Create()", (Test test) =>
                {
                    MutableJSONArray json = JSONArray.Create();
                    test.AssertNotNull(json);
                });
            });
        }

        public static void Test(TestRunner runner, Func<JSONArray> creator)
        {
            runner.TestType<JSONArray>(() =>
            {
                runner.TestMethod("Get(int)", () =>
                {
                    runner.Test("with negative", (Test test) =>
                    {
                        JSONArray json = creator.Invoke();

                        test.AssertThrows(() => json.Get(-1),
                            new PreConditionFailure(
                                "Expression: this",
                                "Expected: not null and not empty",
                                "Actual:   []"));
                    });

                    runner.Test("with too large", (Test test) =>
                    {
                        JSONArray json = creator.Invoke();

                        test.AssertThrows(() => json.Get(0),
                            new PreConditionFailure(
                                "Expression: this",
                                "Expected: not null and not empty",
                                "Actual:   []"));
                    });
                });

                runner.TestMethod("Get<T>(int)", () =>
                {
                    runner.Test("with negative", (Test test) =>
                    {
                        JSONArray json = creator.Invoke();

                        test.AssertThrows(() => json.Get<JSONObject>(-1),
                            new PreConditionFailure(
                                "Expression: this",
                                "Expected: not null and not empty",
                                "Actual:   []"));
                    });

                    runner.Test("with too large", (Test test) =>
                    {
                        JSONArray json = creator.Invoke();

                        test.AssertThrows(() => json.Get<JSONObject>(0),
                            new PreConditionFailure(
                                "Expression: this",
                                "Expected: not null and not empty",
                                "Actual:   []"));
                    });
                });

                runner.TestMethod("GetAs<T>(int)", () =>
                {
                    runner.Test("with negative", (Test test) =>
                    {
                        JSONArray json = creator.Invoke();

                        test.AssertThrows(() => json.GetAs<JSONObject>(-1),
                            new PreConditionFailure(
                                "Expression: this",
                                "Expected: not null and not empty",
                                "Actual:   []"));
                    });

                    runner.Test("with too large", (Test test) =>
                    {
                        JSONArray json = creator.Invoke();

                        test.AssertThrows(() => json.GetAs<JSONObject>(0),
                            new PreConditionFailure(
                                "Expression: this",
                                "Expected: not null and not empty",
                                "Actual:   []"));
                    });
                });

                runner.TestMethod("GetObject(int)", () =>
                {
                    runner.Test("with negative", (Test test) =>
                    {
                        JSONArray json = creator.Invoke();

                        test.AssertThrows(() => json.GetObject(-1),
                            new PreConditionFailure(
                                "Expression: this",
                                "Expected: not null and not empty",
                                "Actual:   []"));
                    });

                    runner.Test("with too large", (Test test) =>
                    {
                        JSONArray json = creator.Invoke();

                        test.AssertThrows(() => json.GetObject(0),
                            new PreConditionFailure(
                                "Expression: this",
                                "Expected: not null and not empty",
                                "Actual:   []"));
                    });
                });

                runner.TestMethod("GetAsObject(int)", () =>
                {
                    runner.Test("with negative", (Test test) =>
                    {
                        JSONArray json = creator.Invoke();

                        test.AssertThrows(() => json.GetAsObject(-1),
                            new PreConditionFailure(
                                "Expression: this",
                                "Expected: not null and not empty",
                                "Actual:   []"));
                    });

                    runner.Test("with too large", (Test test) =>
                    {
                        JSONArray json = creator.Invoke();

                        test.AssertThrows(() => json.GetAsObject(0),
                            new PreConditionFailure(
                                "Expression: this",
                                "Expected: not null and not empty",
                                "Actual:   []"));
                    });
                });

                runner.TestMethod("GetBoolean(int)", () =>
                {
                    runner.Test("with negative", (Test test) =>
                    {
                        JSONArray json = creator.Invoke();

                        test.AssertThrows(() => json.GetBoolean(-1),
                            new PreConditionFailure(
                                "Expression: this",
                                "Expected: not null and not empty",
                                "Actual:   []"));
                    });

                    runner.Test("with too large", (Test test) =>
                    {
                        JSONArray json = creator.Invoke();

                        test.AssertThrows(() => json.GetBoolean(0),
                            new PreConditionFailure(
                                "Expression: this",
                                "Expected: not null and not empty",
                                "Actual:   []"));
                    });
                });

                runner.TestMethod("GetAsBoolean(int)", () =>
                {
                    runner.Test("with negative", (Test test) =>
                    {
                        JSONArray json = creator.Invoke();

                        test.AssertThrows(() => json.GetAsBoolean(-1),
                            new PreConditionFailure(
                                "Expression: this",
                                "Expected: not null and not empty",
                                "Actual:   []"));
                    });

                    runner.Test("with too large", (Test test) =>
                    {
                        JSONArray json = creator.Invoke();

                        test.AssertThrows(() => json.GetAsBoolean(0),
                            new PreConditionFailure(
                                "Expression: this",
                                "Expected: not null and not empty",
                                "Actual:   []"));
                    });
                });

                runner.TestMethod("GetString(int)", () =>
                {
                    runner.Test("with negative", (Test test) =>
                    {
                        JSONArray json = creator.Invoke();

                        test.AssertThrows(() => json.GetString(-1),
                            new PreConditionFailure(
                                "Expression: this",
                                "Expected: not null and not empty",
                                "Actual:   []"));
                    });

                    runner.Test("with too large", (Test test) =>
                    {
                        JSONArray json = creator.Invoke();

                        test.AssertThrows(() => json.GetString(0),
                            new PreConditionFailure(
                                "Expression: this",
                                "Expected: not null and not empty",
                                "Actual:   []"));
                    });
                });

                runner.TestMethod("GetAsString(int)", () =>
                {
                    runner.Test("with negative", (Test test) =>
                    {
                        JSONArray json = creator.Invoke();

                        test.AssertThrows(() => json.GetAsString(-1),
                            new PreConditionFailure(
                                "Expression: this",
                                "Expected: not null and not empty",
                                "Actual:   []"));
                    });

                    runner.Test("with too large", (Test test) =>
                    {
                        JSONArray json = creator.Invoke();

                        test.AssertThrows(() => json.GetAsString(0),
                            new PreConditionFailure(
                                "Expression: this",
                                "Expected: not null and not empty",
                                "Actual:   []"));
                    });
                });

                runner.TestMethod("GetNull(int)", () =>
                {
                    runner.Test("with negative", (Test test) =>
                    {
                        JSONArray json = creator.Invoke();

                        test.AssertThrows(() => json.GetNull(-1),
                            new PreConditionFailure(
                                "Expression: this",
                                "Expected: not null and not empty",
                                "Actual:   []"));
                    });

                    runner.Test("with too large", (Test test) =>
                    {
                        JSONArray json = creator.Invoke();

                        test.AssertThrows(() => json.GetNull(0),
                            new PreConditionFailure(
                                "Expression: this",
                                "Expected: not null and not empty",
                                "Actual:   []"));
                    });
                });

                runner.TestMethod("GetAsNull(int)", () =>
                {
                    runner.Test("with negative", (Test test) =>
                    {
                        JSONArray json = creator.Invoke();

                        test.AssertThrows(() => json.GetAsNull(-1),
                            new PreConditionFailure(
                                "Expression: this",
                                "Expected: not null and not empty",
                                "Actual:   []"));
                    });

                    runner.Test("with too large", (Test test) =>
                    {
                        JSONArray json = creator.Invoke();

                        test.AssertThrows(() => json.GetAsNull(0),
                            new PreConditionFailure(
                                "Expression: this",
                                "Expected: not null and not empty",
                                "Actual:   []"));
                    });
                });
            });
        }
    }
}

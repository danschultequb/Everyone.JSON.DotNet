using System;

namespace Everyone
{
    public static class JSONObjectTests
    {
        public static void Test(TestRunner runner)
        {
            runner.TestType<JSONObject>(() =>
            {
                runner.TestMethod("Create()", (Test test) =>
                {
                    MutableJSONObject jsonObject = JSONObject.Create();
                    test.AssertNotNull(jsonObject);
                });
            });
        }

        public static void Test(TestRunner runner, Func<JSONObject> creator)
        {
            runner.TestType<JSONObject>(() =>
            {
                runner.TestMethod("Get(string)", () =>
                {
                    runner.Test("with null", (Test test) =>
                    {
                        JSONObject json = creator.Invoke();

                        test.AssertThrows(() => json.Get(null!),
                            new PreConditionFailure(
                                "Expression: propertyName",
                                "Expected: not null and not empty",
                                "Actual:   null"));
                    });

                    runner.Test("with empty", (Test test) =>
                    {
                        JSONObject json = creator.Invoke();

                        test.AssertThrows(() => json.Get(""),
                            new PreConditionFailure(
                                "Expression: propertyName",
                                "Expected: not null and not empty",
                                "Actual:   \"\""));
                    });

                    runner.Test("with not found property name", (Test test) =>
                    {
                        JSONObject json = creator.Invoke();

                        Result<JSONValue> getResult = json.Get("not-found");
                        test.AssertNotNull(getResult);
                        test.AssertThrows(() => getResult.Await(),
                            new NotFoundException("Could not find the key: not-found"));
                    });
                });

                runner.TestMethod("Get<T>(string)", () =>
                {
                    runner.Test("with null", (Test test) =>
                    {
                        JSONObject json = creator.Invoke();

                        test.AssertThrows(() => json.Get<JSONObject>(null!),
                            new PreConditionFailure(
                                "Expression: propertyName",
                                "Expected: not null and not empty",
                                "Actual:   null"));
                    });

                    runner.Test("with empty", (Test test) =>
                    {
                        JSONObject json = creator.Invoke();

                        test.AssertThrows(() => json.Get<JSONObject>(""),
                            new PreConditionFailure(
                                "Expression: propertyName",
                                "Expected: not null and not empty",
                                "Actual:   \"\""));
                    });

                    runner.Test("with not found property name", (Test test) =>
                    {
                        JSONObject json = creator.Invoke();

                        Result<JSONObject> getResult = json.Get<JSONObject>("not-found");
                        test.AssertNotNull(getResult);
                        test.AssertThrows(() => getResult.Await(),
                            new NotFoundException("Could not find the key: not-found"));
                    });
                });

                runner.TestMethod("GetAs<T>(string)", () =>
                {
                    runner.Test("with null", (Test test) =>
                    {
                        JSONObject json = creator.Invoke();

                        test.AssertThrows(() => json.GetAs<JSONObject>(null!),
                            new PreConditionFailure(
                                "Expression: propertyName",
                                "Expected: not null and not empty",
                                "Actual:   null"));
                    });

                    runner.Test("with empty", (Test test) =>
                    {
                        JSONObject json = creator.Invoke();

                        test.AssertThrows(() => json.GetAs<JSONObject>(""),
                            new PreConditionFailure(
                                "Expression: propertyName",
                                "Expected: not null and not empty",
                                "Actual:   \"\""));
                    });

                    runner.Test("with not found property name", (Test test) =>
                    {
                        JSONObject json = creator.Invoke();

                        Result<JSONObject?> getResult = json.GetAs<JSONObject>("not-found");
                        test.AssertNotNull(getResult);
                        test.AssertThrows(() => getResult.Await(),
                            new NotFoundException("Could not find the key: not-found"));
                    });
                });

                runner.TestMethod("GetObject(string)", () =>
                {
                    runner.Test("with null", (Test test) =>
                    {
                        JSONObject json = creator.Invoke();

                        test.AssertThrows(() => json.GetObject(null!),
                            new PreConditionFailure(
                                "Expression: propertyName",
                                "Expected: not null and not empty",
                                "Actual:   null"));
                    });

                    runner.Test("with empty", (Test test) =>
                    {
                        JSONObject json = creator.Invoke();

                        test.AssertThrows(() => json.GetObject(""),
                            new PreConditionFailure(
                                "Expression: propertyName",
                                "Expected: not null and not empty",
                                "Actual:   \"\""));
                    });

                    runner.Test("with not found property name", (Test test) =>
                    {
                        JSONObject json = creator.Invoke();

                        Result<JSONObject> getResult = json.GetObject("not-found");
                        test.AssertNotNull(getResult);
                        test.AssertThrows(() => getResult.Await(),
                            new NotFoundException("Could not find the key: not-found"));
                    });
                });

                runner.TestMethod("GetAsObject(string)", () =>
                {
                    runner.Test("with null", (Test test) =>
                    {
                        JSONObject json = creator.Invoke();

                        test.AssertThrows(() => json.GetAsObject(null!),
                            new PreConditionFailure(
                                "Expression: propertyName",
                                "Expected: not null and not empty",
                                "Actual:   null"));
                    });

                    runner.Test("with empty", (Test test) =>
                    {
                        JSONObject json = creator.Invoke();

                        test.AssertThrows(() => json.GetAsObject(""),
                            new PreConditionFailure(
                                "Expression: propertyName",
                                "Expected: not null and not empty",
                                "Actual:   \"\""));
                    });

                    runner.Test("with not found property name", (Test test) =>
                    {
                        JSONObject json = creator.Invoke();

                        Result<JSONObject?> getResult = json.GetAsObject("not-found");
                        test.AssertNotNull(getResult);
                        test.AssertThrows(() => getResult.Await(),
                            new NotFoundException("Could not find the key: not-found"));
                    });
                });

                runner.TestMethod("GetBoolean(string)", () =>
                {
                    runner.Test("with null", (Test test) =>
                    {
                        JSONObject json = creator.Invoke();

                        test.AssertThrows(() => json.GetBoolean(null!),
                            new PreConditionFailure(
                                "Expression: propertyName",
                                "Expected: not null and not empty",
                                "Actual:   null"));
                    });

                    runner.Test("with empty", (Test test) =>
                    {
                        JSONObject json = creator.Invoke();

                        test.AssertThrows(() => json.GetBoolean(""),
                            new PreConditionFailure(
                                "Expression: propertyName",
                                "Expected: not null and not empty",
                                "Actual:   \"\""));
                    });

                    runner.Test("with not found property name", (Test test) =>
                    {
                        JSONObject json = creator.Invoke();

                        Result<bool> getResult = json.GetBoolean("not-found");
                        test.AssertNotNull(getResult);
                        test.AssertThrows(() => getResult.Await(),
                            new NotFoundException("Could not find the key: not-found"));
                    });
                });

                runner.TestMethod("GetAsBoolean(string)", () =>
                {
                    runner.Test("with null", (Test test) =>
                    {
                        JSONObject json = creator.Invoke();

                        test.AssertThrows(() => json.GetAsBoolean(null!),
                            new PreConditionFailure(
                                "Expression: propertyName",
                                "Expected: not null and not empty",
                                "Actual:   null"));
                    });

                    runner.Test("with empty", (Test test) =>
                    {
                        JSONObject json = creator.Invoke();

                        test.AssertThrows(() => json.GetAsBoolean(""),
                            new PreConditionFailure(
                                "Expression: propertyName",
                                "Expected: not null and not empty",
                                "Actual:   \"\""));
                    });

                    runner.Test("with not found property name", (Test test) =>
                    {
                        JSONObject json = creator.Invoke();

                        Result<bool?> getResult = json.GetAsBoolean("not-found");
                        test.AssertNotNull(getResult);
                        test.AssertThrows(() => getResult.Await(),
                            new NotFoundException("Could not find the key: not-found"));
                    });
                });

                runner.TestMethod("GetString(string)", () =>
                {
                    runner.Test("with null", (Test test) =>
                    {
                        JSONObject json = creator.Invoke();

                        test.AssertThrows(() => json.GetString(null!),
                            new PreConditionFailure(
                                "Expression: propertyName",
                                "Expected: not null and not empty",
                                "Actual:   null"));
                    });

                    runner.Test("with empty", (Test test) =>
                    {
                        JSONObject json = creator.Invoke();

                        test.AssertThrows(() => json.GetString(""),
                            new PreConditionFailure(
                                "Expression: propertyName",
                                "Expected: not null and not empty",
                                "Actual:   \"\""));
                    });

                    runner.Test("with not found property name", (Test test) =>
                    {
                        JSONObject json = creator.Invoke();

                        Result<string> getResult = json.GetString("not-found");
                        test.AssertNotNull(getResult);
                        test.AssertThrows(() => getResult.Await(),
                            new NotFoundException("Could not find the key: not-found"));
                    });
                });

                runner.TestMethod("GetAsString(string)", () =>
                {
                    runner.Test("with null", (Test test) =>
                    {
                        JSONObject json = creator.Invoke();

                        test.AssertThrows(() => json.GetAsString(null!),
                            new PreConditionFailure(
                                "Expression: propertyName",
                                "Expected: not null and not empty",
                                "Actual:   null"));
                    });

                    runner.Test("with empty", (Test test) =>
                    {
                        JSONObject json = creator.Invoke();

                        test.AssertThrows(() => json.GetAsString(""),
                            new PreConditionFailure(
                                "Expression: propertyName",
                                "Expected: not null and not empty",
                                "Actual:   \"\""));
                    });

                    runner.Test("with not found property name", (Test test) =>
                    {
                        JSONObject json = creator.Invoke();

                        Result<string?> getResult = json.GetAsString("not-found");
                        test.AssertNotNull(getResult);
                        test.AssertThrows(() => getResult.Await(),
                            new NotFoundException("Could not find the key: not-found"));
                    });
                });

                runner.TestMethod("GetNull(string)", () =>
                {
                    runner.Test("with null", (Test test) =>
                    {
                        JSONObject json = creator.Invoke();

                        test.AssertThrows(() => json.GetNull(null!),
                            new PreConditionFailure(
                                "Expression: propertyName",
                                "Expected: not null and not empty",
                                "Actual:   null"));
                    });

                    runner.Test("with empty", (Test test) =>
                    {
                        JSONObject json = creator.Invoke();

                        test.AssertThrows(() => json.GetNull(""),
                            new PreConditionFailure(
                                "Expression: propertyName",
                                "Expected: not null and not empty",
                                "Actual:   \"\""));
                    });

                    runner.Test("with not found property name", (Test test) =>
                    {
                        JSONObject json = creator.Invoke();

                        Result<JSONNull> getResult = json.GetNull("not-found");
                        test.AssertNotNull(getResult);
                        test.AssertThrows(() => getResult.Await(),
                            new NotFoundException("Could not find the key: not-found"));
                    });
                });
            });
        }
    }
}

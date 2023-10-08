using System;

namespace Everyone
{
    public static class MutableJSONObjectTests
    {
        public static void Test(TestRunner runner)
        {
            runner.TestType<MutableJSONObject>(() =>
            {
                JSONObjectTests.Test(runner, MutableJSONObject.Create);

                runner.TestMethod("Create()", (Test test) =>
                {
                    MutableJSONObject jsonObject = MutableJSONObject.Create();
                    test.AssertNotNull(jsonObject);
                });

                runner.TestMethod("Get(string)", () =>
                {
                    runner.Test("with existing property name", (Test test) =>
                    {
                        JSONObject propertyValue = JSONObject.Create();
                        MutableJSONObject json = MutableJSONObject.Create()
                            .Set("found", propertyValue);

                        Result<JSONValue> getResult = json.Get("found");
                        test.AssertSame(propertyValue, getResult.Await());
                    });
                });

                runner.TestMethod("Get<T>(string)", () =>
                {
                    runner.Test("with existing property name and matching property value type", (Test test) =>
                    {
                        JSONObject propertyValue = JSONObject.Create();
                        MutableJSONObject json = MutableJSONObject.Create()
                            .Set("found", propertyValue);

                        Result<JSONObject> getResult = json.Get<JSONObject>("found");
                        test.AssertSame(propertyValue, getResult.Await());
                    });

                    runner.Test("with existing property name and non-matching property value type", (Test test) =>
                    {
                        JSONBooleanValue propertyValue = JSONBooleanValue.True;
                        MutableJSONObject json = MutableJSONObject.Create()
                            .Set("found", propertyValue);

                        Result<JSONObject> getResult = json.Get<JSONObject>("found");
                        test.AssertThrows(() => getResult.Await(),
                            new InvalidCastException($"Unable to cast object of type '{Types.GetFullName<JSONBooleanValue>()}' to type '{Types.GetFullName<JSONObject>()}'."));
                    });
                });

                runner.TestMethod("GetAs<T>(string)", () =>
                {
                    runner.Test("with existing property name and matching property value type", (Test test) =>
                    {
                        JSONObject propertyValue = JSONObject.Create();
                        MutableJSONObject json = MutableJSONObject.Create()
                            .Set("found", propertyValue);

                        Result<JSONObject?> getResult = json.GetAs<JSONObject>("found");
                        test.AssertSame(propertyValue, getResult.Await());
                    });

                    runner.Test("with existing property name and non-matching property value type", (Test test) =>
                    {
                        JSONBooleanValue propertyValue = JSONBooleanValue.True;
                        MutableJSONObject json = MutableJSONObject.Create()
                            .Set("found", propertyValue);

                        Result<JSONObject?> getResult = json.GetAs<JSONObject>("found");
                        test.AssertNull(getResult.Await());
                    });
                });

                runner.TestMethod("GetObject(string)", () =>
                {
                    runner.Test("with existing property name and matching property value type", (Test test) =>
                    {
                        MutableJSONObject propertyValue = JSONObject.Create();
                        MutableJSONObject json = MutableJSONObject.Create()
                            .Set("found", propertyValue);

                        Result<MutableJSONObject> getResult = json.GetObject("found");
                        test.AssertSame(propertyValue, getResult.Await());
                    });

                    runner.Test("with existing property name and non-matching property value type", (Test test) =>
                    {
                        JSONBooleanValue propertyValue = JSONBooleanValue.True;
                        MutableJSONObject json = MutableJSONObject.Create()
                            .Set("found", propertyValue);

                        Result<MutableJSONObject> getResult = json.GetObject("found");
                        test.AssertThrows(() => getResult.Await(),
                            new InvalidCastException($"Unable to cast object of type '{Types.GetFullName<JSONBooleanValue>()}' to type '{Types.GetFullName<MutableJSONObject>()}'."));
                    });
                });

                runner.TestMethod("GetAsObject(string)", () =>
                {
                    runner.Test("with existing property name and matching property value type", (Test test) =>
                    {
                        MutableJSONObject propertyValue = JSONObject.Create();
                        MutableJSONObject json = MutableJSONObject.Create()
                            .Set("found", propertyValue);

                        Result<MutableJSONObject?> getResult = json.GetAsObject("found");
                        test.AssertSame(propertyValue, getResult.Await());
                    });

                    runner.Test("with existing property name and non-matching property value type", (Test test) =>
                    {
                        JSONBooleanValue propertyValue = JSONBooleanValue.True;
                        MutableJSONObject json = MutableJSONObject.Create()
                            .Set("found", propertyValue);

                        Result<MutableJSONObject?> getResult = json.GetAsObject("found");
                        test.AssertNull(getResult.Await());
                    });
                });

                runner.TestMethod("GetBoolean(string)", () =>
                {
                    runner.Test("with existing property name and matching property value type", (Test test) =>
                    {
                        MutableJSONObject json = MutableJSONObject.Create()
                            .Set("found", true);

                        Result<bool> getResult = json.GetBoolean("found");
                        test.AssertTrue(getResult.Await());
                    });

                    runner.Test("with existing property name and non-matching property value type", (Test test) =>
                    {
                        JSONObject propertyValue = JSONObject.Create();
                        MutableJSONObject json = MutableJSONObject.Create()
                            .Set("found", propertyValue);

                        Result<bool> getResult = json.GetBoolean("found");
                        test.AssertThrows(() => getResult.Await(),
                            new InvalidCastException($"Unable to cast object of type '{Types.GetFullName<MutableJSONObject>()}' to type '{Types.GetFullName<JSONBooleanValue>()}'."));
                    });
                });

                runner.TestMethod("GetAsBoolean(string)", () =>
                {
                    runner.Test("with existing property name and matching property value type", (Test test) =>
                    {
                        MutableJSONObject json = MutableJSONObject.Create()
                            .Set("found", true);

                        Result<bool?> getResult = json.GetAsBoolean("found");
                        test.AssertTrue(getResult.Await());
                    });

                    runner.Test("with existing property name and non-matching property value type", (Test test) =>
                    {
                        JSONObject propertyValue = JSONObject.Create();
                        MutableJSONObject json = MutableJSONObject.Create()
                            .Set("found", propertyValue);

                        Result<bool?> getResult = json.GetAsBoolean("found");
                        test.AssertNull(getResult.Await());
                    });
                });

                runner.TestMethod("GetString(string)", () =>
                {
                    runner.Test("with existing property name and matching property value type", (Test test) =>
                    {
                        MutableJSONObject json = MutableJSONObject.Create()
                            .Set("found", "b");

                        Result<string> getResult = json.GetString("found");
                        test.AssertEqual("b", getResult.Await());
                    });

                    runner.Test("with existing property name and non-matching property value type", (Test test) =>
                    {
                        JSONObject propertyValue = JSONObject.Create();
                        MutableJSONObject json = MutableJSONObject.Create()
                            .Set("found", propertyValue);

                        Result<string> getResult = json.GetString("found");
                        test.AssertThrows(() => getResult.Await(),
                            new InvalidCastException($"Unable to cast object of type '{Types.GetFullName<MutableJSONObject>()}' to type '{Types.GetFullName<JSONStringValue>()}'."));
                    });
                });

                runner.TestMethod("GetAsString(string)", () =>
                {
                    runner.Test("with existing property name and matching property value type", (Test test) =>
                    {
                        MutableJSONObject json = MutableJSONObject.Create()
                            .Set("found", "b");

                        Result<string?> getResult = json.GetAsString("found");
                        test.AssertEqual("b", getResult.Await());
                    });

                    runner.Test("with existing property name and non-matching property value type", (Test test) =>
                    {
                        JSONObject propertyValue = JSONObject.Create();
                        MutableJSONObject json = MutableJSONObject.Create()
                            .Set("found", propertyValue);

                        Result<string?> getResult = json.GetAsString("found");
                        test.AssertNull(getResult.Await());
                    });
                });

                runner.TestMethod($"Set(string,{nameof(JSONValue)})", () =>
                {
                    runner.Test("with null propertyName", (Test test) =>
                    {
                        MutableJSONObject json = MutableJSONObject.Create();
                        test.AssertThrows(() => json.Set(null!, JSONObject.Create()),
                            new PreConditionFailure(
                                "Expression: propertyName",
                                "Expected: not null and not empty",
                                "Actual:   null"));
                    });

                    runner.Test("with empty propertyName", (Test test) =>
                    {
                        MutableJSONObject json = MutableJSONObject.Create();
                        test.AssertThrows(() => json.Set("", JSONObject.Create()),
                            new PreConditionFailure(
                                "Expression: propertyName",
                                "Expected: not null and not empty",
                                "Actual:   \"\""));
                    });

                    runner.Test("with null propertyValue", (Test test) =>
                    {
                        MutableJSONObject json = MutableJSONObject.Create();
                        test.AssertThrows(() => json.Set("a", (JSONValue)null!),
                            new PreConditionFailure(
                                "Expression: propertyValue",
                                "Expected: not null",
                                "Actual:   null"));
                    });

                    runner.Test("with non-null propertyValue", (Test test) =>
                    {
                        MutableJSONObject json = MutableJSONObject.Create();
                        JSONObject propertyValue = JSONObject.Create();
                        
                        MutableJSONObject setResult = json.Set("a", propertyValue);
                        test.AssertSame(json, setResult);
                        test.AssertSame(propertyValue, json.Get("a").Await());
                    });
                });

                runner.TestMethod($"Set(string,bool)", () =>
                {
                    runner.Test("with null propertyName", (Test test) =>
                    {
                        MutableJSONObject json = MutableJSONObject.Create();
                        test.AssertThrows(() => json.Set(null!, true),
                            new PreConditionFailure(
                                "Expression: propertyName",
                                "Expected: not null and not empty",
                                "Actual:   null"));
                    });

                    runner.Test("with empty propertyName", (Test test) =>
                    {
                        MutableJSONObject json = MutableJSONObject.Create();
                        test.AssertThrows(() => json.Set("", false),
                            new PreConditionFailure(
                                "Expression: propertyName",
                                "Expected: not null and not empty",
                                "Actual:   \"\""));
                    });

                    runner.Test("with non-null propertyName", (Test test) =>
                    {
                        MutableJSONObject json = MutableJSONObject.Create();
                        
                        MutableJSONObject setResult = json.Set("a", false);
                        test.AssertSame(json, setResult);
                        test.AssertEqual(false, json.GetBoolean("a").Await());
                    });
                });

                runner.TestMethod($"Set(string,string)", () =>
                {
                    runner.Test("with null propertyName", (Test test) =>
                    {
                        MutableJSONObject json = MutableJSONObject.Create();
                        test.AssertThrows(() => json.Set(null!, "b"),
                            new PreConditionFailure(
                                "Expression: propertyName",
                                "Expected: not null and not empty",
                                "Actual:   null"));
                    });

                    runner.Test("with empty propertyName", (Test test) =>
                    {
                        MutableJSONObject json = MutableJSONObject.Create();
                        test.AssertThrows(() => json.Set("", "b"),
                            new PreConditionFailure(
                                "Expression: propertyName",
                                "Expected: not null and not empty",
                                "Actual:   \"\""));
                    });

                    runner.Test("with non-null propertyName", (Test test) =>
                    {
                        MutableJSONObject json = MutableJSONObject.Create();

                        MutableJSONObject setResult = json.Set("a", "b");
                        test.AssertSame(json, setResult);
                        test.AssertEqual("b", json.GetString("a").Await());
                    });
                });

                runner.TestMethod($"SetNull(string)", () =>
                {
                    runner.Test("with null propertyName", (Test test) =>
                    {
                        MutableJSONObject json = MutableJSONObject.Create();
                        test.AssertThrows(() => json.SetNull(null!),
                            new PreConditionFailure(
                                "Expression: propertyName",
                                "Expected: not null and not empty",
                                "Actual:   null"));
                    });

                    runner.Test("with empty propertyName", (Test test) =>
                    {
                        MutableJSONObject json = MutableJSONObject.Create();
                        test.AssertThrows(() => json.SetNull(""),
                            new PreConditionFailure(
                                "Expression: propertyName",
                                "Expected: not null and not empty",
                                "Actual:   \"\""));
                    });

                    runner.Test("with non-null propertyName", (Test test) =>
                    {
                        MutableJSONObject json = MutableJSONObject.Create();

                        MutableJSONObject setResult = json.SetNull("a");
                        test.AssertSame(json, setResult);
                        test.AssertEqual(JSONNull.Create(), json.GetNull("a").Await());
                    });
                });
            });
        }
    }
}

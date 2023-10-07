using System;

namespace Everyone
{
    public static class MutableJSONArrayTests
    {
        public static void Test(TestRunner runner)
        {
            runner.TestType<MutableJSONArray>(() =>
            {
                JSONArrayTests.Test(runner, () => MutableJSONArray.Create());

                runner.TestMethod("Create(params JSONValue[])", () =>
                {
                    runner.Test("with no arguments", (Test test) =>
                    {
                        MutableJSONArray jsonObject = MutableJSONArray.Create();
                        test.AssertNotNull(jsonObject);
                    });

                    runner.Test("with null", (Test test) =>
                    {
                        test.AssertThrows(() => MutableJSONArray.Create(null!),
                            new PreConditionFailure(
                                "Expression: values",
                                "Expected: not null",
                                "Actual:   null"));
                    });
                });

                runner.TestMethod("Get(int)", () =>
                {
                    runner.Test("with existing index", (Test test) =>
                    {
                        JSONObject value = JSONObject.Create();
                        MutableJSONArray json = MutableJSONArray.Create()
                            .Add(value);

                        JSONValue getResult = json.Get(0);
                        test.AssertSame(value, getResult);
                    });
                });

                runner.TestMethod("Get<T>(int)", () =>
                {
                    runner.Test("with existing index and matching value type", (Test test) =>
                    {
                        JSONObject propertyValue = JSONObject.Create();
                        MutableJSONArray json = MutableJSONArray.Create()
                            .Add(propertyValue);

                        Result<JSONObject> getResult = json.Get<JSONObject>(0);
                        test.AssertSame(propertyValue, getResult.Await());
                    });

                    runner.Test("with existing index and non-matching value type", (Test test) =>
                    {
                        JSONBooleanValue propertyValue = JSONBooleanValue.True;
                        MutableJSONArray json = MutableJSONArray.Create()
                            .Add(propertyValue);

                        Result<JSONObject> getResult = json.Get<JSONObject>(0);
                        test.AssertThrows(() => getResult.Await(),
                            new InvalidCastException($"Unable to cast object of type '{Types.GetFullName<JSONBooleanValue>()}' to type '{Types.GetFullName<JSONObject>()}'."));
                    });
                });

                runner.TestMethod("GetAs<T>(int)", () =>
                {
                    runner.Test("with existing index and matching value type", (Test test) =>
                    {
                        JSONObject propertyValue = JSONObject.Create();
                        MutableJSONArray json = MutableJSONArray.Create()
                            .Add(propertyValue);

                        Result<JSONObject?> getResult = json.GetAs<JSONObject>(0);
                        test.AssertSame(propertyValue, getResult.Await());
                    });

                    runner.Test("with existing index and non-matching value type", (Test test) =>
                    {
                        JSONBooleanValue propertyValue = JSONBooleanValue.True;
                        MutableJSONArray json = MutableJSONArray.Create()
                            .Add(propertyValue);

                        Result<JSONObject?> getResult = json.GetAs<JSONObject>(0);
                        test.AssertNull(getResult.Await());
                    });
                });

                runner.TestMethod("GetObject(int)", () =>
                {
                    runner.Test("with existing index and matching value type", (Test test) =>
                    {
                        JSONObject propertyValue = JSONObject.Create();
                        MutableJSONArray json = MutableJSONArray.Create()
                            .Add(propertyValue);

                        Result<JSONObject> getResult = json.GetObject(0);
                        test.AssertSame(propertyValue, getResult.Await());
                    });

                    runner.Test("with existing index and non-matching value type", (Test test) =>
                    {
                        JSONBooleanValue propertyValue = JSONBooleanValue.True;
                        MutableJSONArray json = MutableJSONArray.Create()
                            .Add(propertyValue);

                        Result<JSONObject> getResult = json.GetObject(0);
                        test.AssertThrows(() => getResult.Await(),
                            new InvalidCastException($"Unable to cast object of type '{Types.GetFullName<JSONBooleanValue>()}' to type '{Types.GetFullName<JSONObject>()}'."));
                    });
                });

                runner.TestMethod("GetAsObject(int)", () =>
                {
                    runner.Test("with existing index and matching value type", (Test test) =>
                    {
                        JSONObject propertyValue = JSONObject.Create();
                        MutableJSONArray json = MutableJSONArray.Create()
                            .Add(propertyValue);

                        Result<JSONObject?> getResult = json.GetAsObject(0);
                        test.AssertSame(propertyValue, getResult.Await());
                    });

                    runner.Test("with existing index and non-matching value type", (Test test) =>
                    {
                        JSONBooleanValue propertyValue = JSONBooleanValue.True;
                        MutableJSONArray json = MutableJSONArray.Create()
                            .Add(propertyValue);

                        Result<JSONObject?> getResult = json.GetAsObject(0);
                        test.AssertNull(getResult.Await());
                    });
                });

                runner.TestMethod("GetBoolean(int)", () =>
                {
                    runner.Test("with existing index and matching value type", (Test test) =>
                    {
                        MutableJSONArray json = MutableJSONArray.Create()
                            .Add(true);

                        Result<bool> getResult = json.GetBoolean(0);
                        test.AssertTrue(getResult.Await());
                    });

                    runner.Test("with existing index and non-matching value type", (Test test) =>
                    {
                        JSONObject propertyValue = JSONObject.Create();
                        MutableJSONArray json = MutableJSONArray.Create()
                            .Add(propertyValue);

                        Result<bool> getResult = json.GetBoolean(0);
                        test.AssertThrows(() => getResult.Await(),
                            new InvalidCastException($"Unable to cast object of type '{Types.GetFullName<MutableJSONObject>()}' to type '{Types.GetFullName<JSONBooleanValue>()}'."));
                    });
                });

                runner.TestMethod("GetAsBoolean(int)", () =>
                {
                    runner.Test("with existing index and matching value type", (Test test) =>
                    {
                        MutableJSONArray json = MutableJSONArray.Create()
                            .Add(true);

                        Result<bool?> getResult = json.GetAsBoolean(0);
                        test.AssertTrue(getResult.Await());
                    });

                    runner.Test("with existing index and non-matching value type", (Test test) =>
                    {
                        JSONObject propertyValue = JSONObject.Create();
                        MutableJSONArray json = MutableJSONArray.Create()
                            .Add(propertyValue);

                        Result<bool?> getResult = json.GetAsBoolean(0);
                        test.AssertNull(getResult.Await());
                    });
                });

                runner.TestMethod("GetString(int)", () =>
                {
                    runner.Test("with existing index and matching value type", (Test test) =>
                    {
                        MutableJSONArray json = MutableJSONArray.Create()
                            .Add("b");

                        Result<string> getResult = json.GetString(0);
                        test.AssertEqual("b", getResult.Await());
                    });

                    runner.Test("with existing index and non-matching value type", (Test test) =>
                    {
                        JSONObject propertyValue = JSONObject.Create();
                        MutableJSONArray json = MutableJSONArray.Create()
                            .Add(propertyValue);

                        Result<string> getResult = json.GetString(0);
                        test.AssertThrows(() => getResult.Await(),
                            new InvalidCastException($"Unable to cast object of type '{Types.GetFullName<MutableJSONObject>()}' to type '{Types.GetFullName<JSONStringValue>()}'."));
                    });
                });

                runner.TestMethod("GetAsString(int)", () =>
                {
                    runner.Test("with existing index and matching value type", (Test test) =>
                    {
                        MutableJSONArray json = MutableJSONArray.Create()
                            .Add("b");

                        Result<string?> getResult = json.GetAsString(0);
                        test.AssertEqual("b", getResult.Await());
                    });

                    runner.Test("with existing index and non-matching value type", (Test test) =>
                    {
                        JSONObject propertyValue = JSONObject.Create();
                        MutableJSONArray json = MutableJSONArray.Create()
                            .Add(propertyValue);

                        Result<string?> getResult = json.GetAsString(0);
                        test.AssertNull(getResult.Await());
                    });
                });

                runner.TestMethod($"Set(int,{nameof(JSONValue)})", () =>
                {
                    runner.Test("with negative index", (Test test) =>
                    {
                        MutableJSONArray json = MutableJSONArray.Create();
                        test.AssertThrows(() => json.Set(-1, JSONObject.Create()),
                            new PreConditionFailure(
                                "Expression: this",
                                "Expected: not null and not empty",
                                "Actual:   []"));
                    });

                    runner.Test("with too large index", (Test test) =>
                    {
                        MutableJSONArray json = MutableJSONArray.Create();
                        test.AssertThrows(() => json.Set(0, JSONObject.Create()),
                            new PreConditionFailure(
                                "Expression: this",
                                "Expected: not null and not empty",
                                "Actual:   []"));
                    });

                    runner.Test("with null value", (Test test) =>
                    {
                        MutableJSONArray json = MutableJSONArray.Create().Add(false);
                        test.AssertThrows(() => json.Set(0, (JSONValue)null!),
                            new PreConditionFailure(
                                "Expression: value",
                                "Expected: not null",
                                "Actual:   null"));
                    });

                    runner.Test("with non-null value", (Test test) =>
                    {
                        MutableJSONArray json = MutableJSONArray.Create().Add(false);
                        JSONObject value = JSONObject.Create();

                        MutableJSONArray setResult = json.Set(0, value);
                        test.AssertSame(json, setResult);
                        test.AssertSame(value, json.Get(0));
                    });
                });

                runner.TestMethod($"Set(int,bool)", () =>
                {
                    runner.Test("with negative index", (Test test) =>
                    {
                        MutableJSONArray json = MutableJSONArray.Create();
                        test.AssertThrows(() => json.Set(-1, true),
                            new PreConditionFailure(
                                "Expression: this",
                                "Expected: not null and not empty",
                                "Actual:   []"));
                    });

                    runner.Test("with too large index", (Test test) =>
                    {
                        MutableJSONArray json = MutableJSONArray.Create();
                        test.AssertThrows(() => json.Set(0, false),
                            new PreConditionFailure(
                                "Expression: this",
                                "Expected: not null and not empty",
                                "Actual:   []"));
                    });

                    runner.Test("with valid index", (Test test) =>
                    {
                        MutableJSONArray json = MutableJSONArray.Create().Add("hello");

                        MutableJSONArray setResult = json.Set(0, false);
                        test.AssertSame(json, setResult);
                        test.AssertEqual(false, json.GetBoolean(0).Await());
                    });
                });

                runner.TestMethod($"Set(int,string)", () =>
                {
                    runner.Test("with negative index", (Test test) =>
                    {
                        MutableJSONArray json = MutableJSONArray.Create();
                        test.AssertThrows(() => json.Set(-1, "b"),
                            new PreConditionFailure(
                                "Expression: this",
                                "Expected: not null and not empty",
                                "Actual:   []"));
                    });

                    runner.Test("with too large index", (Test test) =>
                    {
                        MutableJSONArray json = MutableJSONArray.Create();
                        test.AssertThrows(() => json.Set(0, "b"),
                            new PreConditionFailure(
                                "Expression: this",
                                "Expected: not null and not empty",
                                "Actual:   []"));
                    });

                    runner.Test("with null value", (Test test) =>
                    {
                        MutableJSONArray json = MutableJSONArray.Create().Add(false);
                        test.AssertThrows(() => json.Set(0, (string)null!),
                            new PreConditionFailure(
                                "Expression: value",
                                "Expected: not null",
                                "Actual:   null"));
                    });

                    runner.Test("with valid index", (Test test) =>
                    {
                        MutableJSONArray json = MutableJSONArray.Create().Add(false);

                        MutableJSONArray setResult = json.Set(0, "b");
                        test.AssertSame(json, setResult);
                        test.AssertEqual("b", json.GetString(0).Await());
                    });
                });

                runner.TestMethod($"SetNull(int)", () =>
                {
                    runner.Test("with negative index", (Test test) =>
                    {
                        MutableJSONArray json = MutableJSONArray.Create();
                        test.AssertThrows(() => json.SetNull(-1),
                            new PreConditionFailure(
                                "Expression: this",
                                "Expected: not null and not empty",
                                "Actual:   []"));
                    });

                    runner.Test("with too large index", (Test test) =>
                    {
                        MutableJSONArray json = MutableJSONArray.Create();
                        test.AssertThrows(() => json.SetNull(0),
                            new PreConditionFailure(
                                "Expression: this",
                                "Expected: not null and not empty",
                                "Actual:   []"));
                    });

                    runner.Test("with valid index", (Test test) =>
                    {
                        MutableJSONArray json = MutableJSONArray.Create().Add(false);

                        MutableJSONArray setResult = json.SetNull(0);
                        test.AssertSame(json, setResult);
                        test.AssertEqual(JSONNull.Null, json.GetNull(0).Await());
                    });
                });
            });
        }
    }
}

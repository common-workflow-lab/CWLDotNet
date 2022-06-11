﻿using System.Collections.Generic;
using System.Text.Json;
using CWLDotNet;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Test.Loader;

[TestClass]
public class IdMapLoaderTests
{
    readonly AnyLoader innerLoader = new();

    [TestMethod]
    public void TestLoad()
    {
        IdMapLoader<object> loader = new(innerLoader, "key", "value");
        Dictionary<string, object> doc = new()
        {
            { "shaggy", new Dictionary<string, string>() { { "value", "scooby" } } },
            {"fred", "daphne"},
            {"velma", new List<string>() {"fred", "candy"}}
        };

        List<object> expected = new() {
            { new Dictionary<string, string>() {{"value", "daphne"}, {"key" , "fred"} } },
            { new Dictionary<string, string>() {{"value", "scooby"}, {"key" , "shaggy"} }},
            { new Dictionary<string, object>() {{"value", new List<string>(){"fred", "candy"}}, {"key" , "velma"} }}
        };
        object res = loader.Load(doc, "", new LoadingOptions());
        Assert.AreEqual(JsonSerializer.Serialize(expected), JsonSerializer.Serialize(res), "IdMaps are not equal");
    }

    [TestMethod]
    public void TestException()
    {
        IdMapLoader<object> loader = new(innerLoader, "key");
        Dictionary<string, object> doc = new()
        {
            {"fred", "daphne"}
        };

        try
        {
            object res = loader.Load(doc, "", new LoadingOptions());
        }
        catch (ValidationException e)
        {
            Assert.IsInstanceOfType(e, typeof(ValidationException));
            Assert.AreEqual("No mapPredicate was specified", e.Message);
            return;
        }

        Assert.Fail("No ValidationException thrown");
    }
}

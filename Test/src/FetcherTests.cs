﻿using System.Net;
using System.Net.Http;
using CWLDotNet;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using RichardSzalay.MockHttp;

namespace Test.Loader;

[TestClass]
public class FetcherTests
{
    [TestMethod]
    public void TestFetchTextHttp()
    {
        MockHttpMessageHandler mockHttp = new();
        mockHttp.When("http://www.example.com")
        .Respond("application/text", "test");
        DefaultFetcher fetcher = new(new HttpClient(mockHttp));
        Assert.AreEqual("test", fetcher.FetchText("http://www.example.com"));
    }

    [TestMethod]
    public void TestFetchTextHttps()
    {
        MockHttpMessageHandler mockHttp = new();
        mockHttp.When("https://www.example.com")
        .Respond("application/text", "test");
        DefaultFetcher fetcher = new(new HttpClient(mockHttp));
        Assert.AreEqual("test", fetcher.FetchText("https://www.example.com"));
    }

    [TestMethod]
    public void TestFetchTextFile()
    {
        // TODO
        //DefaultFetcher fetcher = new DefaultFetcher();
        //Assert.AreEqual("test", fetcher.FetchText(Path.Combine(Environment.CurrentDirectory,"data/test.txt")));
    }

    [TestMethod]
    [ExpectedException(typeof(ValidationException))]
    public void TestFetchTextNotFound()
    {
        MockHttpMessageHandler mockHttp = new();
        mockHttp.When("https://www.example.com").Respond(HttpStatusCode.NotFound);
        DefaultFetcher fetcher = new(new HttpClient(mockHttp));
        fetcher.FetchText("https://www.example.com");
    }

    [TestMethod]
    public void TestJoin()
    {
        DefaultFetcher fetcher = new();
        Assert.AreEqual("http://example.com/one", fetcher.Urljoin("http://example.com/base", "one"));
        Assert.AreEqual("http://example.com/two", fetcher.Urljoin("http://example.com/base", "two"));
        Assert.AreEqual("http://example.com/base#three", fetcher.Urljoin("http://example.com/base", "#three"));
        Assert.AreEqual("http://example.com/four#five", fetcher.Urljoin("http://example.com/base", "four#five"));
        Assert.AreEqual("_:five", fetcher.Urljoin("http://example.com/base", "_:five"));
    }
}

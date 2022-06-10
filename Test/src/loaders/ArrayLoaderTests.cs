using Microsoft.VisualStudio.TestTools.UnitTesting;
using CWLDotNet;
using System.Collections.Generic;

namespace Test.Loader;

[TestClass]
public class ArrayLoaderTests
{
    readonly ArrayLoader<int> testLoader = new(new PrimitiveLoader<int>());
    [TestMethod]
    public void TestMethod1()
    {
        List<int> testValues = new() { 1, 2, 3, 4 };
        testLoader.Load(testValues, "", new LoadingOptions(), "");
    }
}
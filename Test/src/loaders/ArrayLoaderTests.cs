using Microsoft.VisualStudio.TestTools.UnitTesting;
using CWLDotNet;
using System.Collections.Generic;

namespace Test.Loader;

[TestClass]
public class ArrayLoaderTests
{
    ArrayLoader<int> testLoader = new ArrayLoader<int>(new PrimitiveLoader<int>());
    [TestMethod]
    public void TestMethod1()
    {
        var testValues = new List<int> { 1, 2, 3, 4 };
        var test = testLoader.Load(testValues, "", null, "");
    }
}
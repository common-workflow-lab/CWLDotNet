using Microsoft.VisualStudio.TestTools.UnitTesting;
using CWLDotNet;
namespace Test.Loader;

[TestClass]
public class PrimitiveLoaderStringTests
{
    PrimitiveLoader<string> primString = new PrimitiveLoader<string>();

    [TestMethod]
    public void TestMethod1()
    {
        Assert.AreEqual("", primString.Load("", "", null, ""));
        Assert.AreEqual("abcde", primString.Load("abcde", "", null, ""));
        Assert.AreEqual("1", primString.Load("1", "", null, ""));
    }

    [TestMethod]
    [ExpectedException(typeof(ValidationException))]
    public void TestExceptionInt()
    {
        primString.Load(2, "", null, "");
    }

    [TestMethod]
    [ExpectedException(typeof(ValidationException))]
    public void TestExceptionFloat()
    {
        primString.Load(2.0f, "", null, "");
    }

    [TestMethod]
    [ExpectedException(typeof(ValidationException))]
    public void TestExceptionDouble()
    {
        primString.Load(2.0, "", null, "");
    }

    [TestMethod]
    [ExpectedException(typeof(ValidationException))]
    public void TestExceptionNull()
    {
        primString.Load(null, "", null, "");
    }
}
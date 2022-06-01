using Microsoft.VisualStudio.TestTools.UnitTesting;
using CWLDotNet;
namespace Test.Loader;

[TestClass]
public class PrimitiveLoaderFloatTests
{
    PrimitiveLoader<float> primFloat = new PrimitiveLoader<float>();

    [TestMethod]
    public void TestMethod1()
    {
        Assert.AreEqual(1.0f, primFloat.Load(1.0f, "", null, ""));
        Assert.AreEqual(-1.0f, primFloat.Load(-1.0f, "", null, ""));
        Assert.AreEqual(0.0f, primFloat.Load(0.0f, "", null, ""));
    }

    [TestMethod]
    [ExpectedException(typeof(ValidationException))]
    public void TestExceptionStringEmpty()
    {
        primFloat.Load("", "", null, "");
    }

    [TestMethod]
    [ExpectedException(typeof(ValidationException))]
    public void TestExceptionStringNumber()
    {
        primFloat.Load("1.0f", "", null, "");
    }

    [TestMethod]
    [ExpectedException(typeof(ValidationException))]
    public void TestExceptionDouble()
    {
        primFloat.Load(2.5, "", null, "");
    }

    [TestMethod]
    [ExpectedException(typeof(ValidationException))]
    public void TestExceptionInt()
    {
        primFloat.Load(2, "", null, "");
    }

    [TestMethod]
    [ExpectedException(typeof(ValidationException))]
    public void TestExceptionNull()
    {
        primFloat.Load(null, "", null, "");
    }
}
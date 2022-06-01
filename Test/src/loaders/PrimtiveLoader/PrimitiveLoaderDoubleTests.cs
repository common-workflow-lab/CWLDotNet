using Microsoft.VisualStudio.TestTools.UnitTesting;
using CWLDotNet;
namespace Test.Loader;

[TestClass]
public class PrimitiveLoaderDoubleTests
{
    PrimitiveLoader<double> primDouble = new PrimitiveLoader<double>();

    [TestMethod]
    public void TestMethod1()
    {
        Assert.AreEqual(1.0, primDouble.Load(1.0, "", null, ""));
        Assert.AreEqual(-1.0, primDouble.Load(-1.0, "", null, ""));
        Assert.AreEqual(0.0, primDouble.Load(0.0, "", null, ""));
    }

    [TestMethod]
    [ExpectedException(typeof(ValidationException))]
    public void TestExceptionStringEmpty()
    {
        primDouble.Load("", "", null, "");
    }

    [TestMethod]
    [ExpectedException(typeof(ValidationException))]
    public void TestExceptionStringNumber()
    {
        primDouble.Load("1.0", "", null, "");
    }

    [TestMethod]
    [ExpectedException(typeof(ValidationException))]
    public void TestExceptionFloat()
    {
        primDouble.Load(2.5f, "", null, "");
    }

    [TestMethod]
    [ExpectedException(typeof(ValidationException))]
    public void TestExceptionInt()
    {
        primDouble.Load(2, "", null, "");
    }

    [TestMethod]
    [ExpectedException(typeof(ValidationException))]
    public void TestExceptionNull()
    {
        primDouble.Load(null, "", null, "");
    }
}
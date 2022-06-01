using Microsoft.VisualStudio.TestTools.UnitTesting;
using CWLDotNet;
namespace Test.Loader;

[TestClass]
public class PrimitiveLoaderIntTests
{
    PrimitiveLoader<int> primInt = new PrimitiveLoader<int>();

    [TestMethod]
    public void TestMethod1()
    {
        Assert.AreEqual(1, primInt.Load(1, "", null, ""));
        Assert.AreEqual(-1, primInt.Load(-1, "", null, ""));
        Assert.AreEqual(0, primInt.Load(0, "", null, ""));
    }

    [TestMethod]
    [ExpectedException(typeof(ValidationException))]
    public void TestExceptionStringEmpty()
    {
        primInt.Load("", "", null, "");
    }

    [TestMethod]
    [ExpectedException(typeof(ValidationException))]
    public void TestExceptionStringNumber()
    {
        primInt.Load("1", "", null, "");
    }

    [TestMethod]
    [ExpectedException(typeof(ValidationException))]
    public void TestExceptionDouble()
    {
        primInt.Load(2.5, "", null, "");
    }

    [TestMethod]
    [ExpectedException(typeof(ValidationException))]
    public void TestExceptionFloat()
    {
        primInt.Load(2.5f, "", null, "");
    }

    [TestMethod]
    [ExpectedException(typeof(ValidationException))]
    public void TestExceptionNull()
    {
        primInt.Load(null, "", null, "");
    }
}
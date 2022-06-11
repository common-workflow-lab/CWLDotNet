using Microsoft.VisualStudio.TestTools.UnitTesting;
using CWLDotNet;

namespace Test.Loader;

[TestClass]
public class EnumLoaderTests
{
    enum TestEnum
    {
        A,
        B,
        C,
        D
    }

    readonly EnumLoader<TestEnum> loader = new();

    [TestMethod]
    public void TestLoad()
    {

        Assert.AreEqual(TestEnum.A, loader.Load("A", "", new LoadingOptions()));
    }

    [TestMethod]
    public void TestLoadFailure()
    {
        try
        {
            loader.Load("E", "", new LoadingOptions());
        }
        catch (ValidationException e)
        {
            Assert.IsInstanceOfType(e, typeof(ValidationException));
            Assert.AreEqual("Symbol not contained in TestEnum Enum, expected one of A, B, C, D", e.Message);
            return;
        }
        Assert.Fail("No ValidationException thrown");
    }
}

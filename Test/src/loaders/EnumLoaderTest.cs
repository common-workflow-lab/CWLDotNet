using Microsoft.VisualStudio.TestTools.UnitTesting;
using CWLDotNet;
namespace Test.Loader;

[TestClass]
public class EnumLoaderTest
{
    enum TestEnum  {
        A,
        B,
        C,
        D
    }

    EnumLoader<TestEnum> testLoader = new EnumLoader<TestEnum>();

    [TestMethod]
    public void TestMethod1()
    {
        testLoader.Load("E", "", null, "");

    }
}
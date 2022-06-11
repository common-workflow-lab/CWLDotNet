using Microsoft.VisualStudio.TestTools.UnitTesting;
using CWLDotNet;

namespace Test.Loader;

[TestClass]
public class ExpressionLoaderTests
{
    readonly ExpressionLoader loader = new();

    [TestMethod]
    public void TestLoad()
    {
        Assert.AreEqual("abcd", loader.Load("abcd", "", new LoadingOptions()));
    }

    [TestMethod]
    public void TestLoadFailure()
    {
        try
        {
            loader.Load(1, "", new LoadingOptions());
        }
        catch (ValidationException e)
        {
            Assert.IsInstanceOfType(e, typeof(ValidationException));
            Assert.AreEqual("Expected a string", e.Message);
            return;
        }
        Assert.Fail("No ValidationException thrown");
    }
}

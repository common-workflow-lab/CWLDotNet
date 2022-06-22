

using CWLDotNet;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OneOf;
using OneOf.Types;
using System;
using System.IO;

namespace Test;

[TestClass]
public class ExampleTests
{

    [TestMethod]
    public void Testvalid_stderr_shortcut()
    {
        var file = System.IO.File.ReadAllText("data/examples/valid-stderr-shortcut.cwl");
        var doc = RootLoader.LoadDocument(file,
            new Uri(Path.GetFullPath("data/examples/valid-stderr-shortcut.cwl")).AbsoluteUri);
    }
    
    [TestMethod]
    public void Testvalid_bwa_mem_tool()
    {
        var file = System.IO.File.ReadAllText("data/examples/valid-bwa-mem-tool.cwl");
        var doc = RootLoader.LoadDocument(file,
            new Uri(Path.GetFullPath("data/examples/valid-bwa-mem-tool.cwl")).AbsoluteUri);
    }
    
    [TestMethod]
    public void Testvalid_cat3_tool_mediumcut()
    {
        var file = System.IO.File.ReadAllText("data/examples/valid-cat3-tool-mediumcut.cwl");
        var doc = RootLoader.LoadDocument(file,
            new Uri(Path.GetFullPath("data/examples/valid-cat3-tool-mediumcut.cwl")).AbsoluteUri);
    }
    
    [TestMethod]
    public void Testvalid_cat1_testcli()
    {
        var file = System.IO.File.ReadAllText("data/examples/valid-cat1-testcli.cwl");
        var doc = RootLoader.LoadDocument(file,
            new Uri(Path.GetFullPath("data/examples/valid-cat1-testcli.cwl")).AbsoluteUri);
    }
    
    [TestMethod]
    public void Testvalid_null_expression2_tool()
    {
        var file = System.IO.File.ReadAllText("data/examples/valid-null-expression2-tool.cwl");
        var doc = RootLoader.LoadDocument(file,
            new Uri(Path.GetFullPath("data/examples/valid-null-expression2-tool.cwl")).AbsoluteUri);
    }
    
    [TestMethod]
    public void Testvalid_cat3_tool_shortcut()
    {
        var file = System.IO.File.ReadAllText("data/examples/valid-cat3-tool-shortcut.cwl");
        var doc = RootLoader.LoadDocument(file,
            new Uri(Path.GetFullPath("data/examples/valid-cat3-tool-shortcut.cwl")).AbsoluteUri);
    }
    
    [TestMethod]
    public void Testvalid_binding_test()
    {
        var file = System.IO.File.ReadAllText("data/examples/valid-binding-test.cwl");
        var doc = RootLoader.LoadDocument(file,
            new Uri(Path.GetFullPath("data/examples/valid-binding-test.cwl")).AbsoluteUri);
    }
    
    [TestMethod]
    public void Testvalid_tmap_tool()
    {
        var file = System.IO.File.ReadAllText("data/examples/valid-tmap-tool.cwl");
        var doc = RootLoader.LoadDocument(file,
            new Uri(Path.GetFullPath("data/examples/valid-tmap-tool.cwl")).AbsoluteUri);
    }
    
    [TestMethod]
    public void Testvalid_cat4_tool()
    {
        var file = System.IO.File.ReadAllText("data/examples/valid-cat4-tool.cwl");
        var doc = RootLoader.LoadDocument(file,
            new Uri(Path.GetFullPath("data/examples/valid-cat4-tool.cwl")).AbsoluteUri);
    }
    
    [TestMethod]
    public void Testvalid_stderr()
    {
        var file = System.IO.File.ReadAllText("data/examples/valid-stderr.cwl");
        var doc = RootLoader.LoadDocument(file,
            new Uri(Path.GetFullPath("data/examples/valid-stderr.cwl")).AbsoluteUri);
    }
    
    [TestMethod]
    public void Testvalid_any_type_compat()
    {
        var file = System.IO.File.ReadAllText("data/examples/valid-any-type-compat.cwl");
        var doc = RootLoader.LoadDocument(file,
            new Uri(Path.GetFullPath("data/examples/valid-any-type-compat.cwl")).AbsoluteUri);
    }
    
    [TestMethod]
    public void Testvalid_parseInt_tool()
    {
        var file = System.IO.File.ReadAllText("data/examples/valid-parseInt-tool.cwl");
        var doc = RootLoader.LoadDocument(file,
            new Uri(Path.GetFullPath("data/examples/valid-parseInt-tool.cwl")).AbsoluteUri);
    }
    
    [TestMethod]
    public void Testvalid_dir2()
    {
        var file = System.IO.File.ReadAllText("data/examples/valid-dir2.cwl");
        var doc = RootLoader.LoadDocument(file,
            new Uri(Path.GetFullPath("data/examples/valid-dir2.cwl")).AbsoluteUri);
    }
    
    [TestMethod]
    public void Testvalid_wc2_tool()
    {
        var file = System.IO.File.ReadAllText("data/examples/valid-wc2-tool.cwl");
        var doc = RootLoader.LoadDocument(file,
            new Uri(Path.GetFullPath("data/examples/valid-wc2-tool.cwl")).AbsoluteUri);
    }
    
    [TestMethod]
    public void Testvalid_null_expression1_tool()
    {
        var file = System.IO.File.ReadAllText("data/examples/valid-null-expression1-tool.cwl");
        var doc = RootLoader.LoadDocument(file,
            new Uri(Path.GetFullPath("data/examples/valid-null-expression1-tool.cwl")).AbsoluteUri);
    }
    
    [TestMethod]
    public void Testvalid_stderr_mediumcut()
    {
        var file = System.IO.File.ReadAllText("data/examples/valid-stderr-mediumcut.cwl");
        var doc = RootLoader.LoadDocument(file,
            new Uri(Path.GetFullPath("data/examples/valid-stderr-mediumcut.cwl")).AbsoluteUri);
    }
    
    [TestMethod]
    public void Testvalid_cat3_tool()
    {
        var file = System.IO.File.ReadAllText("data/examples/valid-cat3-tool.cwl");
        var doc = RootLoader.LoadDocument(file,
            new Uri(Path.GetFullPath("data/examples/valid-cat3-tool.cwl")).AbsoluteUri);
    }
    
    [TestMethod]
    public void Testvalid_template_tool()
    {
        var file = System.IO.File.ReadAllText("data/examples/valid-template-tool.cwl");
        var doc = RootLoader.LoadDocument(file,
            new Uri(Path.GetFullPath("data/examples/valid-template-tool.cwl")).AbsoluteUri);
    }
    
    [TestMethod]
    public void Testvalid_cat_tool()
    {
        var file = System.IO.File.ReadAllText("data/examples/valid-cat-tool.cwl");
        var doc = RootLoader.LoadDocument(file,
            new Uri(Path.GetFullPath("data/examples/valid-cat-tool.cwl")).AbsoluteUri);
    }
    
}

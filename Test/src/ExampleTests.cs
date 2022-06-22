using System;
using System.IO;
using CWLDotNet;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OneOf;
using OneOf.Types;

namespace Test;

[TestClass]
public class ExampleTests
{

    [TestMethod]
    public void Testvalid_stderr_shortcut()
    {
        string? file = System.IO.File.ReadAllText("data/examples/valid-stderr-shortcut.cwl");
        RootLoader.LoadDocument(file!,
            new Uri(Path.GetFullPath("data/examples/valid-stderr-shortcut.cwl")).AbsoluteUri);
    }

    [TestMethod]
    public void Testvalid_bwa_mem_tool()
    {
        string? file = System.IO.File.ReadAllText("data/examples/valid-bwa-mem-tool.cwl");
        RootLoader.LoadDocument(file!,
            new Uri(Path.GetFullPath("data/examples/valid-bwa-mem-tool.cwl")).AbsoluteUri);
    }

    [TestMethod]
    public void Testvalid_cat3_tool_mediumcut()
    {
        string? file = System.IO.File.ReadAllText("data/examples/valid-cat3-tool-mediumcut.cwl");
        RootLoader.LoadDocument(file!,
            new Uri(Path.GetFullPath("data/examples/valid-cat3-tool-mediumcut.cwl")).AbsoluteUri);
    }

    [TestMethod]
    public void Testvalid_cat1_testcli()
    {
        string? file = System.IO.File.ReadAllText("data/examples/valid-cat1-testcli.cwl");
        RootLoader.LoadDocument(file!,
            new Uri(Path.GetFullPath("data/examples/valid-cat1-testcli.cwl")).AbsoluteUri);
    }

    [TestMethod]
    public void Testvalid_null_expression2_tool()
    {
        string? file = System.IO.File.ReadAllText("data/examples/valid-null-expression2-tool.cwl");
        RootLoader.LoadDocument(file!,
            new Uri(Path.GetFullPath("data/examples/valid-null-expression2-tool.cwl")).AbsoluteUri);
    }

    [TestMethod]
    public void Testvalid_cat3_tool_shortcut()
    {
        string? file = System.IO.File.ReadAllText("data/examples/valid-cat3-tool-shortcut.cwl");
        RootLoader.LoadDocument(file!,
            new Uri(Path.GetFullPath("data/examples/valid-cat3-tool-shortcut.cwl")).AbsoluteUri);
    }

    [TestMethod]
    public void Testvalid_binding_test()
    {
        string? file = System.IO.File.ReadAllText("data/examples/valid-binding-test.cwl");
        RootLoader.LoadDocument(file!,
            new Uri(Path.GetFullPath("data/examples/valid-binding-test.cwl")).AbsoluteUri);
    }

    [TestMethod]
    public void Testvalid_tmap_tool()
    {
        string? file = System.IO.File.ReadAllText("data/examples/valid-tmap-tool.cwl");
        RootLoader.LoadDocument(file!,
            new Uri(Path.GetFullPath("data/examples/valid-tmap-tool.cwl")).AbsoluteUri);
    }

    [TestMethod]
    public void Testvalid_cat4_tool()
    {
        string? file = System.IO.File.ReadAllText("data/examples/valid-cat4-tool.cwl");
        RootLoader.LoadDocument(file!,
            new Uri(Path.GetFullPath("data/examples/valid-cat4-tool.cwl")).AbsoluteUri);
    }

    [TestMethod]
    public void Testvalid_stderr()
    {
        string? file = System.IO.File.ReadAllText("data/examples/valid-stderr.cwl");
        RootLoader.LoadDocument(file!,
            new Uri(Path.GetFullPath("data/examples/valid-stderr.cwl")).AbsoluteUri);
    }

    [TestMethod]
    public void Testvalid_any_type_compat()
    {
        string? file = System.IO.File.ReadAllText("data/examples/valid-any-type-compat.cwl");
        RootLoader.LoadDocument(file!,
            new Uri(Path.GetFullPath("data/examples/valid-any-type-compat.cwl")).AbsoluteUri);
    }

    [TestMethod]
    public void Testvalid_parseInt_tool()
    {
        string? file = System.IO.File.ReadAllText("data/examples/valid-parseInt-tool.cwl");
        RootLoader.LoadDocument(file!,
            new Uri(Path.GetFullPath("data/examples/valid-parseInt-tool.cwl")).AbsoluteUri);
    }

    [TestMethod]
    public void Testvalid_dir2()
    {
        string? file = System.IO.File.ReadAllText("data/examples/valid-dir2.cwl");
        RootLoader.LoadDocument(file!,
            new Uri(Path.GetFullPath("data/examples/valid-dir2.cwl")).AbsoluteUri);
    }

    [TestMethod]
    public void Testvalid_wc2_tool()
    {
        string? file = System.IO.File.ReadAllText("data/examples/valid-wc2-tool.cwl");
        RootLoader.LoadDocument(file!,
            new Uri(Path.GetFullPath("data/examples/valid-wc2-tool.cwl")).AbsoluteUri);
    }

    [TestMethod]
    public void Testvalid_null_expression1_tool()
    {
        string? file = System.IO.File.ReadAllText("data/examples/valid-null-expression1-tool.cwl");
        RootLoader.LoadDocument(file!,
            new Uri(Path.GetFullPath("data/examples/valid-null-expression1-tool.cwl")).AbsoluteUri);
    }

    [TestMethod]
    public void Testvalid_stderr_mediumcut()
    {
        string? file = System.IO.File.ReadAllText("data/examples/valid-stderr-mediumcut.cwl");
        RootLoader.LoadDocument(file!,
            new Uri(Path.GetFullPath("data/examples/valid-stderr-mediumcut.cwl")).AbsoluteUri);
    }

    [TestMethod]
    public void Testvalid_cat3_tool()
    {
        string? file = System.IO.File.ReadAllText("data/examples/valid-cat3-tool.cwl");
        RootLoader.LoadDocument(file!,
            new Uri(Path.GetFullPath("data/examples/valid-cat3-tool.cwl")).AbsoluteUri);
    }

    [TestMethod]
    public void Testvalid_template_tool()
    {
        string? file = System.IO.File.ReadAllText("data/examples/valid-template-tool.cwl");
        RootLoader.LoadDocument(file!,
            new Uri(Path.GetFullPath("data/examples/valid-template-tool.cwl")).AbsoluteUri);
    }

    [TestMethod]
    public void Testvalid_cat_tool()
    {
        string? file = System.IO.File.ReadAllText("data/examples/valid-cat-tool.cwl");
        RootLoader.LoadDocument(file!,
            new Uri(Path.GetFullPath("data/examples/valid-cat-tool.cwl")).AbsoluteUri);
    }

}

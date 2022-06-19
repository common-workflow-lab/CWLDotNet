using CWLDotNet;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OneOf;
using OneOf.Types;
namespace Test.Loader;

using System.Collections;
using System.Collections.Generic;
[TestClass]
public class ExampleTest
{
    [TestMethod]
    public void few()
    {
            var x = @"#!/usr/bin/env cwl-runner

cwlVersion: v1.0
class: CommandLineTool
baseCommand: echo
inputs:
  message:
    type: string
    inputBinding:
      position: 1
outputs: []
    ";
        var mycmd = new CommandLineTool(inputs: new(), outputs: new());
        var doc = RootLoader.LoadDocument(x, "file:///test.cwl", new LoadingOptions());
        doc.Switch(
          commandLineTool => System.Console.WriteLine(commandLineTool.Save()),
          x => throw new System.Exception(),
          y => throw new System.Exception(),
          z => throw new System.Exception(),
          d => throw new System.Exception()
        );
    }
}

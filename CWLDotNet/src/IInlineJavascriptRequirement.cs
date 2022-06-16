using LanguageExt;

namespace CWLDotNet;

/// <summary>
/// Auto-generated interface for https://w3id.org/cwl/cwl#InlineJavascriptRequirement
///
/// Indicates that the workflow platform must support inline Javascript expressions.
/// If this requirement is not present, the workflow platform must not perform expression
/// interpolatation.
/// 
/// </summary>
public interface IInlineJavascriptRequirement : IProcessRequirement {

    /// <summary>
    /// Always 'InlineJavascriptRequirement'
    /// </summary>
    public new InlineJavascriptRequirement_class class_ { get; set; }

    /// <summary>
    /// Additional code fragments that will also be inserted
    /// before executing the expression code.  Allows for function definitions that may
    /// be called from CWL expressions.
    /// 
    /// </summary>
    public Option<List<string>> expressionLib { get; set; }
}
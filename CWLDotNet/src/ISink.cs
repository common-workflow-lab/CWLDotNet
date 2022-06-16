using LanguageExt;

namespace CWLDotNet;

/// <summary>
/// Auto-generated interface for https://w3id.org/cwl/cwl#Sink
/// </summary>
public interface ISink  {

    /// <summary>
    /// Specifies one or more workflow parameters that will provide input to
    /// the underlying step parameter.
    /// 
    /// </summary>
    public object source { get; set; }

    /// <summary>
    /// The method to use to merge multiple inbound links into a single array.
    /// If not specified, the default method is "merge_nested".
    /// 
    /// </summary>
    public Option<LinkMergeMethod> linkMerge { get; set; }

    /// <summary>
    /// The method to use to choose non-null elements among multiple sources.
    /// 
    /// </summary>
    public Option<PickValueMethod> pickValue { get; set; }
}
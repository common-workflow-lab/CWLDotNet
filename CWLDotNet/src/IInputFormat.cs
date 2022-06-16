using LanguageExt;

namespace CWLDotNet;

/// <summary>
/// Auto-generated interface for https://w3id.org/cwl/cwl#InputFormat
/// </summary>
public interface IInputFormat  {

    /// <summary>
    /// Only valid when `type: File` or is an array of `items: File`.
    /// 
    /// This must be one or more IRIs of concept nodes
    /// that represents file formats which are allowed as input to this
    /// parameter, preferrably defined within an ontology.  If no ontology is
    /// available, file formats may be tested by exact match.
    /// 
    /// </summary>
    public object format { get; set; }
}
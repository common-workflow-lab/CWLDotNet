using LanguageExt;

namespace CWLDotNet;

/// <summary>
/// Auto-generated interface for https://w3id.org/cwl/cwl#OutputFormat
/// </summary>
public interface IOutputFormat  {

    /// <summary>
    /// Only valid when `type: File` or is an array of `items: File`.
    /// 
    /// This is the file format that will be assigned to the output
    /// File object.
    /// 
    /// </summary>
    public object format { get; set; }
}
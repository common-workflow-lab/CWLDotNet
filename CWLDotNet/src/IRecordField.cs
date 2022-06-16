using LanguageExt;

namespace CWLDotNet;

/// <summary>
/// Auto-generated interface for https://w3id.org/cwl/salad#RecordField
///
/// A field of a record.
/// </summary>
public interface IRecordField : IDocumented {

    /// <summary>
    /// The name of the field
    /// 
    /// </summary>
    public string name { get; set; }

    /// <summary>
    /// A documentation string for this object, or an array of strings which should be concatenated.
    /// </summary>
    public object doc { get; set; }

    /// <summary>
    /// The field type
    /// 
    /// </summary>
    public object type { get; set; }
}
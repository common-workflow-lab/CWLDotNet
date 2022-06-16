using LanguageExt;

namespace CWLDotNet;

/// <summary>
/// Auto-generated interface for https://w3id.org/cwl/cwl#OutputRecordSchema
/// </summary>
public interface IOutputRecordSchema : IRecordSchema,IOutputSchema {

    /// <summary>
    /// The identifier for this type
    /// </summary>
    public Option<string> name { get; set; }

    /// <summary>
    /// Defines the fields of the record.
    /// </summary>
    public Option<List<object>> fields { get; set; }

    /// <summary>
    /// Must be `record`
    /// </summary>
    public enum_d9cba076fca539106791a4f46d198c7fcfbdb779 type { get; set; }

    /// <summary>
    /// A short, human-readable label of this object.
    /// </summary>
    public Option<string> label { get; set; }

    /// <summary>
    /// A documentation string for this object, or an array of strings which should be concatenated.
    /// </summary>
    public object doc { get; set; }
}
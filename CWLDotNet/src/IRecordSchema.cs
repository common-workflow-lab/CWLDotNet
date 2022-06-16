using LanguageExt;

namespace CWLDotNet;

/// <summary>
/// Auto-generated interface for https://w3id.org/cwl/salad#RecordSchema
/// </summary>
public interface IRecordSchema  {

    /// <summary>
    /// Defines the fields of the record.
    /// </summary>
    public Option<List<object>> fields { get; set; }

    /// <summary>
    /// Must be `record`
    /// </summary>
    public enum_d9cba076fca539106791a4f46d198c7fcfbdb779 type { get; set; }
}
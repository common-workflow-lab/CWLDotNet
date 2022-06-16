using LanguageExt;

namespace CWLDotNet;

/// <summary>
/// Auto-generated interface for https://w3id.org/cwl/cwl#OutputArraySchema
/// </summary>
public interface IOutputArraySchema : IArraySchema,IOutputSchema {

    /// <summary>
    /// The identifier for this type
    /// </summary>
    public Option<string> name { get; set; }

    /// <summary>
    /// Defines the type of the array elements.
    /// </summary>
    public object items { get; set; }

    /// <summary>
    /// Must be `array`
    /// </summary>
    public enum_d062602be0b4b8fd33e69e29a841317b6ab665bc type { get; set; }

    /// <summary>
    /// A short, human-readable label of this object.
    /// </summary>
    public Option<string> label { get; set; }

    /// <summary>
    /// A documentation string for this object, or an array of strings which should be concatenated.
    /// </summary>
    public object doc { get; set; }
}
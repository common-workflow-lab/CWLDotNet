using LanguageExt;

namespace CWLDotNet;

/// <summary>
/// Auto-generated interface for https://w3id.org/cwl/cwl#InputEnumSchema
/// </summary>
public interface IInputEnumSchema : IEnumSchema,IInputSchema {

    /// <summary>
    /// The identifier for this type
    /// </summary>
    public Option<string> name { get; set; }

    /// <summary>
    /// Defines the set of valid symbols.
    /// </summary>
    public List<string> symbols { get; set; }

    /// <summary>
    /// Must be `enum`
    /// </summary>
    public enum_d961d79c225752b9fadb617367615ab176b47d77 type { get; set; }

    /// <summary>
    /// A short, human-readable label of this object.
    /// </summary>
    public Option<string> label { get; set; }

    /// <summary>
    /// A documentation string for this object, or an array of strings which should be concatenated.
    /// </summary>
    public object doc { get; set; }
}
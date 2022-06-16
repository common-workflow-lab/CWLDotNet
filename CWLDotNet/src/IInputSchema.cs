using LanguageExt;

namespace CWLDotNet;

/// <summary>
/// Auto-generated interface for https://w3id.org/cwl/cwl#InputSchema
/// </summary>
public interface IInputSchema : IIOSchema {

    /// <summary>
    /// The identifier for this type
    /// </summary>
    public Option<string> name { get; set; }

    /// <summary>
    /// A short, human-readable label of this object.
    /// </summary>
    public Option<string> label { get; set; }

    /// <summary>
    /// A documentation string for this object, or an array of strings which should be concatenated.
    /// </summary>
    public object doc { get; set; }
}
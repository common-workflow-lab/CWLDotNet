using LanguageExt;

namespace CWLDotNet;

/// <summary>
/// Auto-generated interface for https://w3id.org/cwl/salad#ArraySchema
/// </summary>
public interface IArraySchema  {

    /// <summary>
    /// Defines the type of the array elements.
    /// </summary>
    public object items { get; set; }

    /// <summary>
    /// Must be `array`
    /// </summary>
    public enum_d062602be0b4b8fd33e69e29a841317b6ab665bc type { get; set; }
}
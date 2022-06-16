using LanguageExt;

namespace CWLDotNet;

/// <summary>
/// Auto-generated interface for https://w3id.org/cwl/cwl#CommandLineBindable
/// </summary>
public interface ICommandLineBindable  {

    /// <summary>
    /// Describes how to turn this object into command line arguments.
    /// </summary>
    public Option<CommandLineBinding> inputBinding { get; set; }
}
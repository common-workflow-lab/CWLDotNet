using LanguageExt;

namespace CWLDotNet;

/// <summary>
/// Auto-generated interface for https://w3id.org/cwl/cwl#EnvVarRequirement
///
/// Define a list of environment variables which will be set in the
/// execution environment of the tool.  See `EnvironmentDef` for details.
/// 
/// </summary>
public interface IEnvVarRequirement : IProcessRequirement {

    /// <summary>
    /// Always 'EnvVarRequirement'
    /// </summary>
    public new EnvVarRequirement_class class_ { get; set; }

    /// <summary>
    /// The list of environment variables.
    /// </summary>
    public List<object> envDef { get; set; }
}
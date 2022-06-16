using LanguageExt;

namespace CWLDotNet;

/// <summary>
/// Auto-generated interface for https://w3id.org/cwl/cwl#EnvironmentDef
///
/// Define an environment variable that will be set in the runtime environment
/// by the workflow platform when executing the command line tool.  May be the
/// result of executing an expression, such as getting a parameter from input.
/// 
/// </summary>
public interface IEnvironmentDef  {

    /// <summary>
    /// The environment variable name
    /// </summary>
    public string envName { get; set; }

    /// <summary>
    /// The environment variable value
    /// </summary>
    public object envValue { get; set; }
}
using LanguageExt;

namespace CWLDotNet;

/// <summary>
/// Auto-generated interface for https://w3id.org/cwl/cwl#SoftwareRequirement
///
/// A list of software packages that should be configured in the environment of
/// the defined process.
/// 
/// </summary>
public interface ISoftwareRequirement : IProcessRequirement {

    /// <summary>
    /// Always 'SoftwareRequirement'
    /// </summary>
    public new SoftwareRequirement_class class_ { get; set; }

    /// <summary>
    /// The list of software to be configured.
    /// </summary>
    public List<object> packages { get; set; }
}
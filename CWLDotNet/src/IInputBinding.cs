using LanguageExt;

namespace CWLDotNet;

/// <summary>
/// Auto-generated interface for https://w3id.org/cwl/cwl#InputBinding
/// </summary>
public interface IInputBinding  {

    /// <summary>
    /// Use of `loadContents` in `InputBinding` is deprecated.
    /// Preserved for v1.0 backwards compatibility.  Will be removed in
    /// CWL v2.0.  Use `InputParameter.loadContents` instead.
    /// 
    /// </summary>
    public Option<bool> loadContents { get; set; }
}
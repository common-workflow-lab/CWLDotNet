using LanguageExt;

namespace CWLDotNet;

/// <summary>
/// Auto-generated interface for https://w3id.org/cwl/cwl#LoadListingRequirement
///
/// Specify the desired behavior for loading the `listing` field of
/// a Directory object for use by expressions.
/// 
/// </summary>
public interface ILoadListingRequirement : IProcessRequirement {

    /// <summary>
    /// Always 'LoadListingRequirement'
    /// </summary>
    public new LoadListingRequirement_class class_ { get; set; }
    public Option<LoadListingEnum> loadListing { get; set; }
}
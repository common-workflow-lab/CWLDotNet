using LanguageExt;

namespace CWLDotNet;

/// <summary>
/// Auto-generated interface for https://w3id.org/cwl/cwl#LoadContents
/// </summary>
public interface ILoadContents  {

    /// <summary>
    /// Only valid when `type: File` or is an array of `items: File`.
    /// 
    /// If true, the file (or each file in the array) must be a UTF-8
    /// text file 64 KiB or smaller, and the implementation must read
    /// the entire contents of the file (or file array) and place it
    /// in the `contents` field of the File object for use by
    /// expressions.  If the size of the file is greater than 64 KiB,
    /// the implementation must raise a fatal error.
    /// 
    /// </summary>
    public Option<bool> loadContents { get; set; }

    /// <summary>
    /// Only valid when `type: Directory` or is an array of `items: Directory`.
    /// 
    /// Specify the desired behavior for loading the `listing` field of
    /// a Directory object for use by expressions.
    /// 
    /// The order of precedence for loadListing is:
    /// 
    ///   1. `loadListing` on an individual parameter
    ///   2. Inherited from `LoadListingRequirement`
    ///   3. By default: `no_listing`
    /// 
    /// </summary>
    public Option<LoadListingEnum> loadListing { get; set; }
}
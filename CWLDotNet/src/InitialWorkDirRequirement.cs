using System.Collections;
using OneOf;
using OneOf.Types;
namespace CWLDotNet;

/// <summary>
/// Auto-generated class implementation for https://w3id.org/cwl/cwl#InitialWorkDirRequirement
///
/// Define a list of files and subdirectories that must be staged by the workflow platform prior to executing the command line tool.
/// Normally files are staged within the designated output directory. However, when running inside containers, files may be staged at arbitrary locations, see discussion for [`Dirent.entryname`](#Dirent). Together with `DockerRequirement.dockerOutputDirectory` it is possible to control the locations of both input and output files when running in containers.
/// </summary>
public class InitialWorkDirRequirement : IInitialWorkDirRequirement, ISavable {
    readonly LoadingOptions loadingOptions;

    readonly Dictionary<object, object> extensionFields;

    /// <summary>
    /// InitialWorkDirRequirement
    /// </summary>
    public InitialWorkDirRequirement_class class_ { get; set; }

    /// <summary>
    /// The list of files or subdirectories that must be staged prior
    /// to executing the command line tool.
    /// 
    /// Return type of each expression must validate as `["null",
    /// File, Directory, Dirent, {type: array, items: [File,
    /// Directory]}]`.
    /// 
    /// Each `File` or `Directory` that is returned by an Expression
    /// must be added to the designated output directory prior to
    /// executing the tool.
    /// 
    /// Each `Dirent` record that is listed or returned by an
    /// expression specifies a file to be created or staged in the
    /// designated output directory prior to executing the tool.
    /// 
    /// Expressions may return null, in which case they have no effect.
    /// 
    /// Files or Directories which are listed in the input parameters
    /// and appear in the `InitialWorkDirRequirement` listing must
    /// have their `path` set to their staged location.  If the same
    /// File or Directory appears more than once in the
    /// `InitialWorkDirRequirement` listing, the implementation must
    /// choose exactly one value for `path`; how this value is chosen
    /// is undefined.
    /// 
    /// </summary>
    public OneOf<string , List<OneOf<None , Dirent , string , File , Directory , List<OneOf<File , Directory>>>>> listing { get; set; }


    public InitialWorkDirRequirement (OneOf<string , List<OneOf<None , Dirent , string , File , Directory , List<OneOf<File , Directory>>>>> listing, InitialWorkDirRequirement_class? class_ = null, LoadingOptions? loadingOptions = null, Dictionary<object, object>? extensionFields = null) {
        this.loadingOptions = loadingOptions ?? new LoadingOptions();
        this.extensionFields = extensionFields ?? new Dictionary<object, object>();
        this.class_ = class_ ?? InitialWorkDirRequirement_class.INITIALWORKDIRREQUIREMENT;
        this.listing = listing;
    }

    public static ISavable FromDoc(object doc__, string baseUri, LoadingOptions loadingOptions,
        string? docRoot = null)
    {
        List<ValidationException> errors = new();

        if (doc__ is not IDictionary)
        {
            throw new ValidationException("Document has to be of type Dictionary");
        }

        Dictionary<object, object> doc_ = ((IDictionary)doc__)
            .Cast<dynamic>()
            .ToDictionary(entry => entry.Key, entry => entry.Value);
            
        dynamic class_ = default!;
        try
        {
            class_ = LoaderInstances.uriInitialWorkDirRequirement_classLoaderFalseTrueNone
               .LoadField(doc_.GetValueOrDefault("class", null!), baseUri,
                   loadingOptions);
        }
        catch (ValidationException e)
        {
            errors.Add(
              new ValidationException("the `class` field is not valid because: ", e)
            );
        }

        dynamic listing = default!;
        try
        {
            listing = LoaderInstances.union_of_ExpressionLoader_or_array_of_union_of_NullInstance_or_DirentLoader_or_ExpressionLoader_or_FileLoader_or_DirectoryLoader_or_array_of_union_of_FileLoader_or_DirectoryLoader
               .LoadField(doc_.GetValueOrDefault("listing", null!), baseUri,
                   loadingOptions);
        }
        catch (ValidationException e)
        {
            errors.Add(
              new ValidationException("the `listing` field is not valid because: ", e)
            );
        }

        Dictionary<object, object> extensionFields = new();
        foreach (KeyValuePair<object, object> v in doc_)
        {
            if (!attr.Contains(v.Key))
            {
                if (((string)v.Key).Contains(':'))
                {
                    string ex = loadingOptions.ExpandUrl((string)v.Key, "", false, false, null);
                    extensionFields[ex] = v.Value;
                }
                else
                {
                    errors.Add(
                        new ValidationException($"invalid field {v.Key}," +
                        "expected one of `class`, `listing`"));
                    break;
                }
            }

        }

        if (errors.Count > 0)
        {
            throw new ValidationException("", errors);
        }

        var res__ = new InitialWorkDirRequirement(
          loadingOptions: loadingOptions,
          class_: class_,
          listing: listing
        );

        return res__;
    }

    public Dictionary<object, object> Save(bool top = false, string baseUrl = "",
        bool relativeUris = true)
    {
        Dictionary<object, object> r = new();
        foreach (KeyValuePair<object, object> ef in extensionFields)
        {
            r[loadingOptions.PrefixUrl((string)ef.Value)] = ef.Value;
        }

        var class_Val = ISavable.SaveRelativeUri(class_, false,
            relativeUris, null, (string)baseUrl!);
        if(class_Val is not None) {
            r["class"] = class_Val;
        }

        var listingVal = ISavable.Save(listing, false, (string)baseUrl!, relativeUris);
        if(listingVal is not None) {
            r["listing"] = listingVal;
        }

        if (top)
        {
            if (loadingOptions.namespaces != null)
            {
                r["$namespaces"] = loadingOptions.namespaces;
            }

            if (this.loadingOptions.schemas != null)
            {
                r["$schemas"] = loadingOptions.schemas;
            }
        }

        return r;
    }

    static readonly System.Collections.Generic.HashSet<string>attr = new() { "class", "listing" };
}

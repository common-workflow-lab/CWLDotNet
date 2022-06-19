using System.Collections;
using OneOf;
using OneOf.Types;
namespace CWLDotNet;

/// <summary>
/// Auto-generated class implementation for https://w3id.org/cwl/cwl#Directory
///
/// Represents a directory to present to a command line tool.
/// 
/// Directories are represented as objects with `class` of `Directory`.  Directory objects have
/// a number of properties that provide metadata about the directory.
/// 
/// The `location` property of a Directory is a URI that uniquely identifies
/// the directory.  Implementations must support the file:// URI scheme and may
/// support other schemes such as http://.  Alternately to `location`,
/// implementations must also accept the `path` property on Directory, which
/// must be a filesystem path available on the same host as the CWL runner (for
/// inputs) or the runtime environment of a command line tool execution (for
/// command line tool outputs).
/// 
/// A Directory object may have a `listing` field.  This is a list of File and
/// Directory objects that are contained in the Directory.  For each entry in
/// `listing`, the `basename` property defines the name of the File or
/// Subdirectory when staged to disk.  If `listing` is not provided, the
/// implementation must have some way of fetching the Directory listing at
/// runtime based on the `location` field.
/// 
/// If a Directory does not have `location`, it is a Directory literal.  A
/// Directory literal must provide `listing`.  Directory literals must be
/// created on disk at runtime as needed.
/// 
/// The resources in a Directory literal do not need to have any implied
/// relationship in their `location`.  For example, a Directory listing may
/// contain two files located on different hosts.  It is the responsibility of
/// the runtime to ensure that those files are staged to disk appropriately.
/// Secondary files associated with files in `listing` must also be staged to
/// the same Directory.
/// 
/// When executing a CommandLineTool, Directories must be recursively staged
/// first and have local values of `path` assigend.
/// 
/// Directory objects in CommandLineTool output must provide either a
/// `location` URI or a `path` property in the context of the tool execution
/// runtime (local to the compute node, or within the executing container).
/// 
/// An ExpressionTool may forward file references from input to output by using
/// the same value for `location`.
/// 
/// Name conflicts (the same `basename` appearing multiple times in `listing`
/// or in any entry in `secondaryFiles` in the listing) is a fatal error.
/// 
/// </summary>
public class Directory : IDirectory, ISavable {
    readonly LoadingOptions loadingOptions;

    readonly Dictionary<object, object> extensionFields;

    /// <summary>
    /// Must be `Directory` to indicate this object describes a Directory.
    /// </summary>
    public Directory_class class_ { get; set; }

    /// <summary>
    /// An IRI that identifies the directory resource.  This may be a relative
    /// reference, in which case it must be resolved using the base IRI of the
    /// document.  The location may refer to a local or remote resource.  If
    /// the `listing` field is not set, the implementation must use the
    /// location IRI to retrieve directory listing.  If an implementation is
    /// unable to retrieve the directory listing stored at a remote resource (due to
    /// unsupported protocol, access denied, or other issue) it must signal an
    /// error.
    /// 
    /// If the `location` field is not provided, the `listing` field must be
    /// provided.  The implementation must assign a unique identifier for
    /// the `location` field.
    /// 
    /// If the `path` field is provided but the `location` field is not, an
    /// implementation may assign the value of the `path` field to `location`,
    /// then follow the rules above.
    /// 
    /// </summary>
    public OneOf<None , string> location { get; set; }

    /// <summary>
    /// The local path where the Directory is made available prior to executing a
    /// CommandLineTool.  This must be set by the implementation.  This field
    /// must not be used in any other context.  The command line tool being
    /// executed must be able to to access the directory at `path` using the POSIX
    /// `opendir(2)` syscall.
    /// 
    /// If the `path` contains [POSIX shell metacharacters](http://pubs.opengroup.org/onlinepubs/9699919799/utilities/V3_chap02.html#tag_18_02)
    /// (`|`,`&`, `;`, `<`, `>`, `(`,`)`, `$`,`` ` ``, `\`, `"`, `'`,
    /// `<space>`, `<tab>`, and `<newline>`) or characters
    /// [not allowed](http://www.iana.org/assignments/idna-tables-6.3.0/idna-tables-6.3.0.xhtml)
    /// for [Internationalized Domain Names for Applications](https://tools.ietf.org/html/rfc6452)
    /// then implementations may terminate the process with a
    /// `permanentFailure`.
    /// 
    /// </summary>
    public OneOf<None , string> path { get; set; }

    /// <summary>
    /// The base name of the directory, that is, the name of the file without any
    /// leading directory path.  The base name must not contain a slash `/`.
    /// 
    /// If not provided, the implementation must set this field based on the
    /// `location` field by taking the final path component after parsing
    /// `location` as an IRI.  If `basename` is provided, it is not required to
    /// match the value from `location`.
    /// 
    /// When this file is made available to a CommandLineTool, it must be named
    /// with `basename`, i.e. the final component of the `path` field must match
    /// `basename`.
    /// 
    /// </summary>
    public OneOf<None , string> basename { get; set; }

    /// <summary>
    /// List of files or subdirectories contained in this directory.  The name
    /// of each file or subdirectory is determined by the `basename` field of
    /// each `File` or `Directory` object.  It is an error if a `File` shares a
    /// `basename` with any other entry in `listing`.  If two or more
    /// `Directory` object share the same `basename`, this must be treated as
    /// equivalent to a single subdirectory with the listings recursively
    /// merged.
    /// 
    /// </summary>
    public OneOf<None , List<OneOf<File , Directory>>> listing { get; set; }


    public Directory (Directory_class? class_ = null, OneOf<None , string> location = default, OneOf<None , string> path = default, OneOf<None , string> basename = default, OneOf<None , List<OneOf<File , Directory>>> listing = default, LoadingOptions? loadingOptions = null, Dictionary<object, object>? extensionFields = null) {
        this.loadingOptions = loadingOptions ?? new LoadingOptions();
        this.extensionFields = extensionFields ?? new Dictionary<object, object>();
        this.class_ = class_ ?? Directory_class.DIRECTORY;
        this.location = location;
        this.path = path;
        this.basename = basename;
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
            class_ = LoaderInstances.uriDirectory_classLoaderFalseTrueNone
               .LoadField(doc_.GetValueOrDefault("class", null!), baseUri,
                   loadingOptions);
        }
        catch (ValidationException e)
        {
            errors.Add(
              new ValidationException("the `class` field is not valid because: ", e)
            );
        }

        dynamic location = default!;
        if (doc_.ContainsKey("location"))
        {
            try
            {
                location = LoaderInstances.uriunion_of_NullInstance_or_StringInstanceFalseFalseNone
                   .LoadField(doc_.GetValueOrDefault("location", null!), baseUri,
                       loadingOptions);
            }
            catch (ValidationException e)
            {
                errors.Add(
                  new ValidationException("the `location` field is not valid because: ", e)
                );
            }
        }

        dynamic path = default!;
        if (doc_.ContainsKey("path"))
        {
            try
            {
                path = LoaderInstances.uriunion_of_NullInstance_or_StringInstanceFalseFalseNone
                   .LoadField(doc_.GetValueOrDefault("path", null!), baseUri,
                       loadingOptions);
            }
            catch (ValidationException e)
            {
                errors.Add(
                  new ValidationException("the `path` field is not valid because: ", e)
                );
            }
        }

        dynamic basename = default!;
        if (doc_.ContainsKey("basename"))
        {
            try
            {
                basename = LoaderInstances.union_of_NullInstance_or_StringInstance
                   .LoadField(doc_.GetValueOrDefault("basename", null!), baseUri,
                       loadingOptions);
            }
            catch (ValidationException e)
            {
                errors.Add(
                  new ValidationException("the `basename` field is not valid because: ", e)
                );
            }
        }

        dynamic listing = default!;
        if (doc_.ContainsKey("listing"))
        {
            try
            {
                listing = LoaderInstances.union_of_NullInstance_or_array_of_union_of_FileLoader_or_DirectoryLoader
                   .LoadField(doc_.GetValueOrDefault("listing", null!), baseUri,
                       loadingOptions);
            }
            catch (ValidationException e)
            {
                errors.Add(
                  new ValidationException("the `listing` field is not valid because: ", e)
                );
            }
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
                        "expected one of `class`, `location`, `path`, `basename`, `listing`"));
                    break;
                }
            }

        }

        if (errors.Count > 0)
        {
            throw new ValidationException("", errors);
        }

        var res__ = new Directory(
          loadingOptions: loadingOptions,
          class_: class_
        );

        if(location != null) 
        {
            res__.location = location;
        }                      
        
        if(path != null) 
        {
            res__.path = path;
        }                      
        
        if(basename != null) 
        {
            res__.basename = basename;
        }                      
        
        if(listing != null) 
        {
            res__.listing = listing;
        }                      
        
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

        var locationVal = ISavable.SaveRelativeUri(location, false,
            relativeUris, null, (string)baseUrl!);
        if(locationVal is not None) {
            r["location"] = locationVal;
        }

        var pathVal = ISavable.SaveRelativeUri(path, false,
            relativeUris, null, (string)baseUrl!);
        if(pathVal is not None) {
            r["path"] = pathVal;
        }

        var basenameVal = ISavable.Save(basename, false, (string)baseUrl!, relativeUris);
        if(basenameVal is not None) {
            r["basename"] = basenameVal;
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

    static readonly System.Collections.Generic.HashSet<string>attr = new() { "class", "location", "path", "basename", "listing" };
}

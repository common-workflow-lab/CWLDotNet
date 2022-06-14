using System.Collections;

namespace CWLDotNet;

/// <summary>
/// Auto-generated class implementation for https://w3id.org/cwl/cwl#CommandOutputBinding
///
/// Describes how to generate an output parameter based on the files produced
/// by a CommandLineTool.
/// 
/// The output parameter value is generated by applying these operations in the
/// following order:
/// 
///   - glob
///   - loadContents
///   - outputEval
///   - secondaryFiles
/// 
/// </summary>
public class CommandOutputBinding : ICommandOutputBinding, ISavable {
    readonly LoadingOptions loadingOptions;

    readonly Dictionary<object, object> extensionFields;

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
    public object? loadContents { get; set; }

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
    public object? loadListing { get; set; }

    /// <summary>
    /// Find files or directories relative to the output directory, using POSIX
    /// glob(3) pathname matching.  If an array is provided, find files or
    /// directories that match any pattern in the array.  If an expression is
    /// provided, the expression must return a string or an array of strings,
    /// which will then be evaluated as one or more glob patterns.  Must only
    /// match and return files/directories which actually exist.
    /// 
    /// If the value of glob is a relative path pattern (does not
    /// begin with a slash '/') then it is resolved relative to the
    /// output directory.  If the value of the glob is an absolute
    /// path pattern (it does begin with a slash '/') then it must
    /// refer to a path within the output directory.  It is an error
    /// if any glob resolves to a path outside the output directory.
    /// Specifically this means globs that resolve to paths outside the output
    /// directory are illegal.
    /// 
    /// A glob may match a path within the output directory which is
    /// actually a symlink to another file.  In this case, the
    /// expected behavior is for the resulting File/Directory object to take the
    /// `basename` (and corresponding `nameroot` and `nameext`) of the
    /// symlink.  The `location` of the File/Directory is implementation
    /// dependent, but logically the File/Directory should have the same content
    /// as the symlink target.  Platforms may stage output files/directories to
    /// cloud storage that lack the concept of a symlink.  In
    /// this case file content and directories may be duplicated, or (to avoid
    /// duplication) the File/Directory `location` may refer to the symlink
    /// target.
    /// 
    /// It is an error if a symlink in the output directory (or any
    /// symlink in a chain of links) refers to any file or directory
    /// that is not under an input or output directory.
    /// 
    /// Implementations may shut down a container before globbing
    /// output, so globs and expressions must not assume access to the
    /// container filesystem except for declared input and output.
    /// 
    /// </summary>
    public object glob { get; set; }

    /// <summary>
    /// Evaluate an expression to generate the output value.  If
    /// `glob` was specified, the value of `self` must be an array
    /// containing file objects that were matched.  If no files were
    /// matched, `self` must be a zero length array; if a single file
    /// was matched, the value of `self` is an array of a single
    /// element.  The exit code of the process is
    /// available in the expression as `runtime.exitCode`.
    /// 
    /// Additionally if `loadContents` is true, the file must be a
    /// UTF-8 text file 64 KiB or smaller, and the implementation must
    /// read the entire contents of the file (or file array) and place
    /// it in the `contents` field of the File object for use in
    /// `outputEval`.  If the size of the file is greater than 64 KiB,
    /// the implementation must raise a fatal error.
    /// 
    /// If a tool needs to return a large amount of structured data to
    /// the workflow, loading the output object from `cwl.output.json`
    /// bypasses `outputEval` and is not subject to the 64 KiB
    /// `loadContents` limit.
    /// 
    /// </summary>
    public object? outputEval { get; set; }


    public CommandOutputBinding (object loadContents,object loadListing,object glob,object outputEval,LoadingOptions? loadingOptions = null, Dictionary<object, object>? extensionFields = null) {
        this.loadingOptions = loadingOptions ?? new LoadingOptions();
        this.extensionFields = extensionFields ?? new Dictionary<object, object>();
        this.loadContents = loadContents;
        this.loadListing = loadListing;
        this.glob = glob;
        this.outputEval = outputEval;
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
            
        object loadContents = default!;
        if (doc_.ContainsKey("loadContents"))
        {
            try
            {
                loadContents = (object)LoaderInstances.optional_BooleanInstance
                   .LoadField(doc_.GetValueOrDefault("loadContents", null!), baseUri,
                       loadingOptions);
            }
            catch (ValidationException e)
            {
                errors.Add(
                  new ValidationException("the `loadContents` field is not valid because: ", e)
                );
            }
        }

        object loadListing = default!;
        if (doc_.ContainsKey("loadListing"))
        {
            try
            {
                loadListing = (object)LoaderInstances.optional_LoadListingEnumLoader
                   .LoadField(doc_.GetValueOrDefault("loadListing", null!), baseUri,
                       loadingOptions);
            }
            catch (ValidationException e)
            {
                errors.Add(
                  new ValidationException("the `loadListing` field is not valid because: ", e)
                );
            }
        }

        object glob = default!;
        if (doc_.ContainsKey("glob"))
        {
            try
            {
                glob = (object)LoaderInstances.union_of_NullInstance_or_StringInstance_or_ExpressionLoader_or_array_of_StringInstance
                   .LoadField(doc_.GetValueOrDefault("glob", null!), baseUri,
                       loadingOptions);
            }
            catch (ValidationException e)
            {
                errors.Add(
                  new ValidationException("the `glob` field is not valid because: ", e)
                );
            }
        }

        object outputEval = default!;
        if (doc_.ContainsKey("outputEval"))
        {
            try
            {
                outputEval = (object)LoaderInstances.optional_ExpressionLoader
                   .LoadField(doc_.GetValueOrDefault("outputEval", null!), baseUri,
                       loadingOptions);
            }
            catch (ValidationException e)
            {
                errors.Add(
                  new ValidationException("the `outputEval` field is not valid because: ", e)
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
                        "expected one of `loadContents`, `loadListing`, `glob`, `outputEval`"));
                    break;
                }
            }

        }

        if (errors.Count > 0)
        {
            throw new ValidationException("", errors);
        }

        return new CommandOutputBinding(
          loadContents: loadContents,
          loadListing: loadListing,
          glob: glob,
          outputEval: outputEval,
          loadingOptions: loadingOptions
        );
    }

    public Dictionary<object, object> Save(bool top = false, string baseUrl = "",
        bool relativeUris = true)
    {
        Dictionary<object, object> r = new();
        foreach (KeyValuePair<object, object> ef in extensionFields)
        {
            r[loadingOptions.PrefixUrl((string)ef.Value)] = ef.Value;
        }

        if (this.loadContents != null)
        {
            r["loadContents"] =
               ISavable.Save(loadContents, false, (string)baseUrl!, relativeUris);
        }
                
        if (this.loadListing != null)
        {
            r["loadListing"] =
               ISavable.Save(loadListing, false, (string)baseUrl!, relativeUris);
        }
                
        if (this.glob != null)
        {
            r["glob"] =
               ISavable.Save(glob, false, (string)baseUrl!, relativeUris);
        }
                
        if (this.outputEval != null)
        {
            r["outputEval"] =
               ISavable.Save(outputEval, false, (string)baseUrl!, relativeUris);
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

            
    static readonly HashSet<string> attr = new() { "loadContents", "loadListing", "glob", "outputEval" };
}

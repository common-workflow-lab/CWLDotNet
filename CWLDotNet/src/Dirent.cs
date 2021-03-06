using System.Collections;
using OneOf;
using OneOf.Types;

namespace CWLDotNet;

/// <summary>
/// Auto-generated class implementation for https://w3id.org/cwl/cwl#Dirent
///
/// Define a file or subdirectory that must be staged to a particular
/// place prior to executing the command line tool.  May be the result
/// of executing an expression, such as building a configuration file
/// from a template.
/// 
/// Usually files are staged within the [designated output directory](#Runtime_environment).
/// However, under certain circumstances, files may be staged at
/// arbitrary locations, see discussion for `entryname`.
/// 
/// </summary>
public class Dirent : IDirent, ISavable
{
    readonly LoadingOptions loadingOptions;

    readonly Dictionary<object, object> extensionFields;

    /// <summary>
    /// The "target" name of the file or subdirectory.  If `entry` is
    /// a File or Directory, the `entryname` field overrides the value
    /// of `basename` of the File or Directory object.
    /// 
    /// * Required when `entry` evaluates to file contents only
    /// * Optional when `entry` evaluates to a File or Directory object with a `basename`
    /// * Invalid when `entry` evaluates to an array of File or Directory objects.
    /// 
    /// If `entryname` is a relative path, it specifies a name within
    /// the designated output directory.  A relative path starting
    /// with `../` or that resolves to location above the designated output directory is an error.
    /// 
    /// If `entryname` is an absolute path (starts with a slash `/`)
    /// it is an error unless the following conditions are met:
    /// 
    ///   * `DockerRequirement` is present in `requirements`
    ///   * The program is will run inside a software container
    ///   where, from the perspective of the program, the root
    ///   filesystem is not shared with any other user or
    ///   running program.
    /// 
    /// In this case, and the above conditions are met, then
    /// `entryname` may specify the absolute path within the container
    /// where the file or directory must be placed.
    /// 
    /// </summary>
    public OneOf<None, string> entryname { get; set; }

    /// <summary>
    /// If the value is a string literal or an expression which evaluates to a
    /// string, a new text file must be created with the string as the file contents.
    /// 
    /// If the value is an expression that evaluates to a `File` or
    /// `Directory` object, or an array of `File` or `Directory`
    /// objects, this indicates the referenced file or directory
    /// should be added to the designated output directory prior to
    /// executing the tool.
    /// 
    /// If the value is an expression that evaluates to `null`,
    /// nothing is added to the designated output directory, the entry
    /// has no effect.
    /// 
    /// If the value is an expression that evaluates to some other
    /// array, number, or object not consisting of `File` or
    /// `Directory` objects, a new file must be created with the value
    /// serialized to JSON text as the file contents.  The JSON
    /// serialization behavior should match the behavior of string
    /// interpolation of [Parameter
    /// references](#Parameter_references).
    /// 
    /// </summary>
    public OneOf<string> entry { get; set; }

    /// <summary>
    /// If true, the File or Directory (or array of Files or
    /// Directories) declared in `entry` must be writable by the tool.
    /// 
    /// Changes to the file or directory must be isolated and not
    /// visible by any other CommandLineTool process.  This may be
    /// implemented by making a copy of the original file or
    /// directory.
    /// 
    /// Disruptive changes to the referenced file or directory must not
    /// be allowed unless `InplaceUpdateRequirement.inplaceUpdate` is true.
    /// 
    /// Default false (files and directories read-only by default).
    /// 
    /// A directory marked as `writable: true` implies that all files and
    /// subdirectories are recursively writable as well.
    /// 
    /// If `writable` is false, the file may be made available using a
    /// bind mount or file system link to avoid unnecessary copying of
    /// the input file.  Command line tools may receive an error on
    /// attempting to rename or delete files or directories that are
    /// not explicitly marked as writable.
    /// 
    /// </summary>
    public OneOf<None, bool> writable { get; set; }


    public Dirent(OneOf<string> entry, OneOf<None, string> entryname = default, OneOf<None, bool> writable = default, LoadingOptions? loadingOptions = null, Dictionary<object, object>? extensionFields = null)
    {
        this.loadingOptions = loadingOptions ?? new LoadingOptions();
        this.extensionFields = extensionFields ?? new Dictionary<object, object>();
        this.entryname = entryname;
        this.entry = entry;
        this.writable = writable;
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

        dynamic entryname = default!;
        if (doc_.ContainsKey("entryname"))
        {
            try
            {
                entryname = LoaderInstances.union_of_NullInstance_or_StringInstance_or_ExpressionLoader
                   .LoadField(doc_.GetValueOrDefault("entryname", null!), baseUri,
                       loadingOptions);
            }
            catch (ValidationException e)
            {
                errors.Add(
                  new ValidationException("the `entryname` field is not valid because: ", e)
                );
            }
        }

        dynamic entry = default!;
        try
        {
            entry = LoaderInstances.union_of_StringInstance_or_ExpressionLoader
               .LoadField(doc_.GetValueOrDefault("entry", null!), baseUri,
                   loadingOptions);
        }
        catch (ValidationException e)
        {
            errors.Add(
              new ValidationException("the `entry` field is not valid because: ", e)
            );
        }

        dynamic writable = default!;
        if (doc_.ContainsKey("writable"))
        {
            try
            {
                writable = LoaderInstances.union_of_NullInstance_or_BooleanInstance
                   .LoadField(doc_.GetValueOrDefault("writable", null!), baseUri,
                       loadingOptions);
            }
            catch (ValidationException e)
            {
                errors.Add(
                  new ValidationException("the `writable` field is not valid because: ", e)
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
                        "expected one of `entryname`, `entry`, `writable`"));
                    break;
                }
            }

        }

        if (errors.Count > 0)
        {
            throw new ValidationException("", errors);
        }

        Dirent res__ = new(
          loadingOptions: loadingOptions,
          entry: entry
        );

        if (entryname != null)
        {
            res__.entryname = entryname;
        }

        if (writable != null)
        {
            res__.writable = writable;
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

        object? entrynameVal = ISavable.Save(entryname,
                                        false, (string)baseUrl!, relativeUris);
        if (entrynameVal is not null)
        {
            r["entryname"] = entrynameVal;
        }

        object? entryVal = ISavable.Save(entry,
                                        false, (string)baseUrl!, relativeUris);
        if (entryVal is not null)
        {
            r["entry"] = entryVal;
        }

        object? writableVal = ISavable.Save(writable,
                                        false, (string)baseUrl!, relativeUris);
        if (writableVal is not null)
        {
            r["writable"] = writableVal;
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

    static readonly System.Collections.Generic.HashSet<string> attr = new() { "entryname", "entry", "writable" };
}

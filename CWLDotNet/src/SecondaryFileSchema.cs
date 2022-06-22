using System.Collections;
using OneOf;
using OneOf.Types;

namespace CWLDotNet;

/// <summary>
/// Auto-generated class implementation for https://w3id.org/cwl/cwl#SecondaryFileSchema
///
/// Secondary files are specified using the following micro-DSL for secondary files:
/// 
/// * If the value is a string, it is transformed to an object with two fields
///   `pattern` and `required`
/// * By default, the value of `required` is `null`
///   (this indicates default behavior, which may be based on the context)
/// * If the value ends with a question mark `?` the question mark is
///   stripped off and the value of the field `required` is set to `False`
/// * The remaining value is assigned to the field `pattern`
/// 
/// For implementation details and examples, please see
/// [this section](SchemaSalad.html#Domain_Specific_Language_for_secondary_files)
/// in the Schema Salad specification.
/// 
/// </summary>
public class SecondaryFileSchema : ISecondaryFileSchema, ISavable
{
    readonly LoadingOptions loadingOptions;

    readonly Dictionary<object, object> extensionFields;

    /// <summary>
    /// Provides a pattern or expression specifying files or directories that
    /// should be included alongside the primary file.
    /// 
    /// If the value is an expression, the value of `self` in the
    /// expression must be the primary input or output File object to
    /// which this binding applies.  The `basename`, `nameroot` and
    /// `nameext` fields must be present in `self`.  For
    /// `CommandLineTool` inputs the `location` field must also be
    /// present.  For `CommandLineTool` outputs the `path` field must
    /// also be present.  If secondary files were included on an input
    /// File object as part of the Process invocation, they must also
    /// be present in `secondaryFiles` on `self`.
    /// 
    /// The expression must return either: a filename string relative
    /// to the path to the primary File, a File or Directory object
    /// (`class: File` or `class: Directory`) with either `location`
    /// (for inputs) or `path` (for outputs) and `basename` fields
    /// set, or an array consisting of strings or File or Directory
    /// objects as previously described.
    /// 
    /// It is legal to use `location` from a File or Directory object
    /// passed in as input, including `location` from secondary files
    /// on `self`.  If an expression returns a File object with the
    /// same `location` but a different `basename` as a secondary file
    /// that was passed in, the expression result takes precedence.
    /// Setting the basename with an expression this way affects the
    /// `path` where the secondary file will be staged to in the
    /// CommandLineTool.
    /// 
    /// The expression may return "null" in which case there is no
    /// secondary file from that expression.
    /// 
    /// To work on non-filename-preserving storage systems, portable
    /// tool descriptions should treat `location` as an opaque
    /// identifier and avoid constructing new values from `location`,
    /// but should construct relative references using `basename` or
    /// `nameroot` instead, or propagate `location` from defined inputs.
    /// 
    /// If a value in `secondaryFiles` is a string that is not an expression,
    /// it specifies that the following pattern should be applied to the path
    /// of the primary file to yield a filename relative to the primary File:
    /// 
    ///   1. If string ends with `?` character, remove the last `?` and mark
    ///     the resulting secondary file as optional.
    ///   2. If string begins with one or more caret `^` characters, for each
    ///     caret, remove the last file extension from the path (the last
    ///     period `.` and all following characters).  If there are no file
    ///     extensions, the path is unchanged.
    ///   3. Append the remainder of the string to the end of the file path.
    /// 
    /// </summary>
    public OneOf<string> pattern { get; set; }

    /// <summary>
    /// An implementation must not fail workflow execution if `required` is
    /// set to `false` and the expected secondary file does not exist.
    /// Default value for `required` field is `true` for secondary files on
    /// input and `false` for secondary files on output.
    /// 
    /// </summary>
    public OneOf<None, bool, string> required { get; set; }


    public SecondaryFileSchema(OneOf<string> pattern, OneOf<None, bool, string> required = default, LoadingOptions? loadingOptions = null, Dictionary<object, object>? extensionFields = null)
    {
        this.loadingOptions = loadingOptions ?? new LoadingOptions();
        this.extensionFields = extensionFields ?? new Dictionary<object, object>();
        this.pattern = pattern;
        this.required = required;
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

        dynamic pattern = default!;
        try
        {
            pattern = LoaderInstances.union_of_StringInstance_or_ExpressionLoader
               .LoadField(doc_.GetValueOrDefault("pattern", null!), baseUri,
                   loadingOptions);
        }
        catch (ValidationException e)
        {
            errors.Add(
              new ValidationException("the `pattern` field is not valid because: ", e)
            );
        }

        dynamic required = default!;
        if (doc_.ContainsKey("required"))
        {
            try
            {
                required = LoaderInstances.union_of_NullInstance_or_BooleanInstance_or_ExpressionLoader
                   .LoadField(doc_.GetValueOrDefault("required", null!), baseUri,
                       loadingOptions);
            }
            catch (ValidationException e)
            {
                errors.Add(
                  new ValidationException("the `required` field is not valid because: ", e)
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
                        "expected one of `pattern`, `required`"));
                    break;
                }
            }

        }

        if (errors.Count > 0)
        {
            throw new ValidationException("", errors);
        }

        SecondaryFileSchema res__ = new(
          loadingOptions: loadingOptions,
          pattern: pattern
        );

        if (required != null)
        {
            res__.required = required;
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

        object? patternVal = ISavable.Save(pattern,
                                        false, (string)baseUrl!, relativeUris);
        if (patternVal is not null)
        {
            r["pattern"] = patternVal;
        }

        object? requiredVal = ISavable.Save(required,
                                        false, (string)baseUrl!, relativeUris);
        if (requiredVal is not null)
        {
            r["required"] = requiredVal;
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

    static readonly System.Collections.Generic.HashSet<string> attr = new() { "pattern", "required" };
}

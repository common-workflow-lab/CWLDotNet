using System.Collections;
using LanguageExt;

namespace CWLDotNet;

/// <summary>
/// Auto-generated class implementation for https://w3id.org/cwl/cwl#WorkReuse
///
/// For implementations that support reusing output from past work (on
/// the assumption that same code and same input produce same
/// results), control whether to enable or disable the reuse behavior
/// for a particular tool or step (to accomodate situations where that
/// assumption is incorrect).  A reused step is not executed but
/// instead returns the same output as the original execution.
/// 
/// If `WorkReuse` is not specified, correct tools should assume it
/// is enabled by default.
/// 
/// </summary>
public class WorkReuse : IWorkReuse, ISavable {
    readonly LoadingOptions loadingOptions;

    readonly Dictionary<object, object> extensionFields;

    /// <summary>
    /// Always 'WorkReuse'
    /// </summary>
    public WorkReuse_class class_ { get; set; }
    public object enableReuse { get; set; }


    public WorkReuse (WorkReuse_class class_,object enableReuse,LoadingOptions? loadingOptions = null, Dictionary<object, object>? extensionFields = null) {
        this.loadingOptions = loadingOptions ?? new LoadingOptions();
        this.extensionFields = extensionFields ?? new Dictionary<object, object>();
        this.class_ = class_;
        this.enableReuse = enableReuse;
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
            
        WorkReuse_class class_ = default!;
        try
        {
            class_ = (WorkReuse_class)LoaderInstances.uriWorkReuse_classLoaderFalseTrueNone
               .LoadField(doc_.GetValueOrDefault("class", null!), baseUri,
                   loadingOptions);
        }
        catch (ValidationException e)
        {
            errors.Add(
              new ValidationException("the `class` field is not valid because: ", e)
            );
        }

        object enableReuse = default!;
        try
        {
            enableReuse = (object)LoaderInstances.union_of_BooleanInstance_or_ExpressionLoader
               .LoadField(doc_.GetValueOrDefault("enableReuse", null!), baseUri,
                   loadingOptions);
        }
        catch (ValidationException e)
        {
            errors.Add(
              new ValidationException("the `enableReuse` field is not valid because: ", e)
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
                        "expected one of `class`, `enableReuse`"));
                    break;
                }
            }

        }

        if (errors.Count > 0)
        {
            throw new ValidationException("", errors);
        }

        return new WorkReuse(
          class_: class_,
          enableReuse: enableReuse,
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

        r["class"] = ISavable.SaveRelativeUri(class_, false,
                                  relativeUris, null, (string)baseUrl!);
        r["enableReuse"] =
           ISavable.Save(enableReuse, false, (string)baseUrl!, relativeUris);
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

            
    static readonly System.Collections.Generic.HashSet<string>attr = new() { "class", "enableReuse" };
}

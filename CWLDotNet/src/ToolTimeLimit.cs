using System.Collections;
using LanguageExt;

namespace CWLDotNet;

/// <summary>
/// Auto-generated class implementation for https://w3id.org/cwl/cwl#ToolTimeLimit
///
/// Set an upper limit on the execution time of a CommandLineTool.
/// A CommandLineTool whose execution duration exceeds the time
/// limit may be preemptively terminated and considered failed.
/// May also be used by batch systems to make scheduling decisions.
/// The execution duration excludes external operations, such as
/// staging of files, pulling a docker image etc, and only counts
/// wall-time for the execution of the command line itself.
/// 
/// </summary>
public class ToolTimeLimit : IToolTimeLimit, ISavable {
    readonly LoadingOptions loadingOptions;

    readonly Dictionary<object, object> extensionFields;

    /// <summary>
    /// Always 'ToolTimeLimit'
    /// </summary>
    public ToolTimeLimit_class class_ { get; set; }

    /// <summary>
    /// The time limit, in seconds.  A time limit of zero means no
    /// time limit.  Negative time limits are an error.
    /// 
    /// </summary>
    public object timelimit { get; set; }


    public ToolTimeLimit (ToolTimeLimit_class class_,object timelimit,LoadingOptions? loadingOptions = null, Dictionary<object, object>? extensionFields = null) {
        this.loadingOptions = loadingOptions ?? new LoadingOptions();
        this.extensionFields = extensionFields ?? new Dictionary<object, object>();
        this.class_ = class_;
        this.timelimit = timelimit;
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
            
        ToolTimeLimit_class class_ = default!;
        try
        {
            class_ = (ToolTimeLimit_class)LoaderInstances.uriToolTimeLimit_classLoaderFalseTrueNone
               .LoadField(doc_.GetValueOrDefault("class", null!), baseUri,
                   loadingOptions);
        }
        catch (ValidationException e)
        {
            errors.Add(
              new ValidationException("the `class` field is not valid because: ", e)
            );
        }

        object timelimit = default!;
        try
        {
            timelimit = (object)LoaderInstances.union_of_IntegerInstance_or_LongInstance_or_ExpressionLoader
               .LoadField(doc_.GetValueOrDefault("timelimit", null!), baseUri,
                   loadingOptions);
        }
        catch (ValidationException e)
        {
            errors.Add(
              new ValidationException("the `timelimit` field is not valid because: ", e)
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
                        "expected one of `class`, `timelimit`"));
                    break;
                }
            }

        }

        if (errors.Count > 0)
        {
            throw new ValidationException("", errors);
        }

        return new ToolTimeLimit(
          class_: class_,
          timelimit: timelimit,
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
        r["timelimit"] =
           ISavable.Save(timelimit, false, (string)baseUrl!, relativeUris);
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

            
    static readonly System.Collections.Generic.HashSet<string>attr = new() { "class", "timelimit" };
}

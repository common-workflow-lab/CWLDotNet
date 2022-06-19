using System.Collections;
using OneOf;
using OneOf.Types;
namespace CWLDotNet;

/// <summary>
/// Auto-generated class implementation for https://w3id.org/cwl/cwl#EnvironmentDef
///
/// Define an environment variable that will be set in the runtime environment
/// by the workflow platform when executing the command line tool.  May be the
/// result of executing an expression, such as getting a parameter from input.
/// 
/// </summary>
public class EnvironmentDef : IEnvironmentDef, ISavable {
    readonly LoadingOptions loadingOptions;

    readonly Dictionary<object, object> extensionFields;

    /// <summary>
    /// The environment variable name
    /// </summary>
    public string envName { get; set; }

    /// <summary>
    /// The environment variable value
    /// </summary>
    public OneOf<string> envValue { get; set; }


    public EnvironmentDef (string envName, OneOf<string> envValue, LoadingOptions? loadingOptions = null, Dictionary<object, object>? extensionFields = null) {
        this.loadingOptions = loadingOptions ?? new LoadingOptions();
        this.extensionFields = extensionFields ?? new Dictionary<object, object>();
        this.envName = envName;
        this.envValue = envValue;
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
            
        dynamic envName = default!;
        try
        {
            envName = LoaderInstances.StringInstance
               .LoadField(doc_.GetValueOrDefault("envName", null!), baseUri,
                   loadingOptions);
        }
        catch (ValidationException e)
        {
            errors.Add(
              new ValidationException("the `envName` field is not valid because: ", e)
            );
        }

        dynamic envValue = default!;
        try
        {
            envValue = LoaderInstances.union_of_StringInstance_or_ExpressionLoader
               .LoadField(doc_.GetValueOrDefault("envValue", null!), baseUri,
                   loadingOptions);
        }
        catch (ValidationException e)
        {
            errors.Add(
              new ValidationException("the `envValue` field is not valid because: ", e)
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
                        "expected one of `envName`, `envValue`"));
                    break;
                }
            }

        }

        if (errors.Count > 0)
        {
            throw new ValidationException("", errors);
        }

        var res__ = new EnvironmentDef(
          loadingOptions: loadingOptions,
          envName: envName,
          envValue: envValue
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

        var envNameVal = ISavable.Save(envName, false, (string)baseUrl!, relativeUris);
        if(envNameVal is not None) {
            r["envName"] = envNameVal;
        }

        var envValueVal = ISavable.Save(envValue, false, (string)baseUrl!, relativeUris);
        if(envValueVal is not None) {
            r["envValue"] = envValueVal;
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

    static readonly System.Collections.Generic.HashSet<string>attr = new() { "envName", "envValue" };
}

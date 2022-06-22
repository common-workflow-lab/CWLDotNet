using System.Collections;
using OneOf;
using OneOf.Types;

namespace CWLDotNet;

/// <summary>
/// Auto-generated class implementation for https://w3id.org/cwl/cwl#EnvVarRequirement
///
/// Define a list of environment variables which will be set in the
/// execution environment of the tool.  See `EnvironmentDef` for details.
/// 
/// </summary>
public class EnvVarRequirement : IEnvVarRequirement, ISavable
{
    readonly LoadingOptions loadingOptions;

    readonly Dictionary<object, object> extensionFields;

    /// <summary>
    /// Always 'EnvVarRequirement'
    /// </summary>
    public EnvVarRequirement_class class_ { get; set; }

    /// <summary>
    /// The list of environment variables.
    /// </summary>
    public List<EnvironmentDef> envDef { get; set; }


    public EnvVarRequirement(List<EnvironmentDef> envDef, EnvVarRequirement_class? class_ = null, LoadingOptions? loadingOptions = null, Dictionary<object, object>? extensionFields = null)
    {
        this.loadingOptions = loadingOptions ?? new LoadingOptions();
        this.extensionFields = extensionFields ?? new Dictionary<object, object>();
        this.class_ = class_ ?? EnvVarRequirement_class.ENVVARREQUIREMENT;
        this.envDef = envDef;
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
            class_ = LoaderInstances.uriEnvVarRequirement_classLoaderFalseTrueNone
               .LoadField(doc_.GetValueOrDefault("class", null!), baseUri,
                   loadingOptions);
        }
        catch (ValidationException e)
        {
            errors.Add(
              new ValidationException("the `class` field is not valid because: ", e)
            );
        }

        dynamic envDef = default!;
        try
        {
            envDef = LoaderInstances.idmapenvDefarray_of_EnvironmentDefLoader
               .LoadField(doc_.GetValueOrDefault("envDef", null!), baseUri,
                   loadingOptions);
        }
        catch (ValidationException e)
        {
            errors.Add(
              new ValidationException("the `envDef` field is not valid because: ", e)
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
                        "expected one of `class`, `envDef`"));
                    break;
                }
            }

        }

        if (errors.Count > 0)
        {
            throw new ValidationException("", errors);
        }

        EnvVarRequirement res__ = new(
          loadingOptions: loadingOptions,
          class_: class_,
          envDef: envDef
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

        object? class_Val = ISavable.SaveRelativeUri(class_, false,
            relativeUris, null, (string)baseUrl!);
        if (class_Val is not null)
        {
            r["class"] = class_Val;
        }

        object? envDefVal = ISavable.Save(envDef, false, (string)baseUrl!, relativeUris);
        if (envDefVal is not null)
        {
            r["envDef"] = envDefVal;
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

    static readonly System.Collections.Generic.HashSet<string> attr = new() { "class", "envDef" };
}

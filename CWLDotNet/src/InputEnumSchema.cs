using System.Collections;

namespace CWLDotNet;

/// <summary>
/// Auto-generated class implementation for https://w3id.org/cwl/cwl#InputEnumSchema
/// </summary>
public class InputEnumSchema : IInputEnumSchema, ISavable {
    readonly LoadingOptions loadingOptions;

    readonly Dictionary<object, object> extensionFields;

    /// <summary>
    /// The identifier for this type
    /// </summary>
    public object? name { get; set; }

    /// <summary>
    /// Defines the set of valid symbols.
    /// </summary>
    public List<string> symbols { get; set; }

    /// <summary>
    /// Must be `enum`
    /// </summary>
    public enum_d961d79c225752b9fadb617367615ab176b47d77 type { get; set; }

    /// <summary>
    /// A short, human-readable label of this object.
    /// </summary>
    public object? label { get; set; }

    /// <summary>
    /// A documentation string for this object, or an array of strings which should be concatenated.
    /// </summary>
    public object doc { get; set; }


    public InputEnumSchema (object name,List<string> symbols,enum_d961d79c225752b9fadb617367615ab176b47d77 type,object label,object doc,LoadingOptions? loadingOptions = null, Dictionary<object, object>? extensionFields = null) {
        this.loadingOptions = loadingOptions ?? new LoadingOptions();
        this.extensionFields = extensionFields ?? new Dictionary<object, object>();
        this.name = name;
        this.symbols = symbols;
        this.type = type;
        this.label = label;
        this.doc = doc;
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
            
        object name = default!;
        if (doc_.ContainsKey("name"))
        {
            try
            {
                name = (object)LoaderInstances.urioptional_StringInstanceTrueFalseNone
                   .LoadField(doc_.GetValueOrDefault("name", null!), baseUri,
                       loadingOptions);
            }
            catch (ValidationException e)
            {
                errors.Add(
                  new ValidationException("the `name` field is not valid because: ", e)
                );
            }
        }

        if (name == null)
        {
            if (docRoot != null)
            {
                name = docRoot;
            }
            else
            {
                name = "_" + Guid.NewGuid();
            }
        }
        else
        {
            baseUri = (string)name;
        }
            
        List<string> symbols = default!;
        try
        {
            symbols = (List<string>)LoaderInstances.uriarray_of_StringInstanceTrueFalseNone
               .LoadField(doc_.GetValueOrDefault("symbols", null!), baseUri,
                   loadingOptions);
        }
        catch (ValidationException e)
        {
            errors.Add(
              new ValidationException("the `symbols` field is not valid because: ", e)
            );
        }

        enum_d961d79c225752b9fadb617367615ab176b47d77 type = default!;
        try
        {
            type = (enum_d961d79c225752b9fadb617367615ab176b47d77)LoaderInstances.typedslenum_d961d79c225752b9fadb617367615ab176b47d77Loader2
               .LoadField(doc_.GetValueOrDefault("type", null!), baseUri,
                   loadingOptions);
        }
        catch (ValidationException e)
        {
            errors.Add(
              new ValidationException("the `type` field is not valid because: ", e)
            );
        }

        object label = default!;
        if (doc_.ContainsKey("label"))
        {
            try
            {
                label = (object)LoaderInstances.optional_StringInstance
                   .LoadField(doc_.GetValueOrDefault("label", null!), baseUri,
                       loadingOptions);
            }
            catch (ValidationException e)
            {
                errors.Add(
                  new ValidationException("the `label` field is not valid because: ", e)
                );
            }
        }

        object doc = default!;
        if (doc_.ContainsKey("doc"))
        {
            try
            {
                doc = (object)LoaderInstances.union_of_NullInstance_or_StringInstance_or_array_of_StringInstance
                   .LoadField(doc_.GetValueOrDefault("doc", null!), baseUri,
                       loadingOptions);
            }
            catch (ValidationException e)
            {
                errors.Add(
                  new ValidationException("the `doc` field is not valid because: ", e)
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
                        "expected one of `symbols`, `type`, `label`, `doc`, `name`"));
                    break;
                }
            }

        }

        if (errors.Count > 0)
        {
            throw new ValidationException("", errors);
        }

        return new InputEnumSchema(
          symbols: symbols,
          type: type,
          label: label,
          doc: doc,
          name: name,
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

        if (this.name != null)
        {
            r["name"] = ISavable.SaveRelativeUri(this.name, true,
                                      relativeUris, null, (string)baseUrl!);

        }
                
        r["symbols"] = ISavable.SaveRelativeUri(this.symbols, true,
                                  relativeUris, null, (string)this.name!);

        r["type"] =
           ISavable.Save(type, false, (string)this.name!, relativeUris);
        if (this.label != null)
        {
            r["label"] =
               ISavable.Save(label, false, (string)this.name!, relativeUris);
        }
                
        if (this.doc != null)
        {
            r["doc"] =
               ISavable.Save(doc, false, (string)this.name!, relativeUris);
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

            
    static readonly HashSet<string> attr = new() { "symbols", "type", "label", "doc", "name" };
}

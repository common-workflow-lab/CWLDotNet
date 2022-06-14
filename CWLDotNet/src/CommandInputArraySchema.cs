using System.Collections;

namespace CWLDotNet;

/**
 * Auto-generated class implementation for https://w3id.org/cwl/cwl#CommandInputArraySchema
 */
public class CommandInputArraySchema : ICommandInputArraySchema, ISavable {
    readonly LoadingOptions loadingOptions;

    readonly Dictionary<object, object> extensionFields;

  /**
   * The identifier for this type
   */
    public object? name { get; set; }

  /**
   * Defines the type of the array elements.
   */
    public object items { get; set; }

  /**
   * Must be `array`
   */
    public enum_d062602be0b4b8fd33e69e29a841317b6ab665bc type { get; set; }

  /**
   * A short, human-readable label of this object.
   */
    public object? label { get; set; }

  /**
   * A documentation string for this object, or an array of strings which should be concatenated.
   */
    public object doc { get; set; }

  /**
   * Describes how to turn this object into command line arguments.
   */
    public object? inputBinding { get; set; }


    public CommandInputArraySchema (object name,object items,enum_d062602be0b4b8fd33e69e29a841317b6ab665bc type,object label,object doc,object inputBinding,LoadingOptions? loadingOptions = null, Dictionary<object, object>? extensionFields = null) {
        this.loadingOptions = loadingOptions ?? new LoadingOptions();
        this.extensionFields = extensionFields ?? new Dictionary<object, object>();
        this.name = name;
        this.items = items;
        this.type = type;
        this.label = label;
        this.doc = doc;
        this.inputBinding = inputBinding;
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
            
        object items = default!;
        try
        {
            items = (object)LoaderInstances.typedslunion_of_CWLTypeLoader_or_CommandInputRecordSchemaLoader_or_CommandInputEnumSchemaLoader_or_CommandInputArraySchemaLoader_or_StringInstance_or_array_of_union_of_CWLTypeLoader_or_CommandInputRecordSchemaLoader_or_CommandInputEnumSchemaLoader_or_CommandInputArraySchemaLoader_or_StringInstance2
               .LoadField(doc_.GetValueOrDefault("items", null!), baseUri,
                   loadingOptions);
        }
        catch (ValidationException e)
        {
            errors.Add(
              new ValidationException("the `items` field is not valid because: ", e)
            );
        }

        enum_d062602be0b4b8fd33e69e29a841317b6ab665bc type = default!;
        try
        {
            type = (enum_d062602be0b4b8fd33e69e29a841317b6ab665bc)LoaderInstances.typedslenum_d062602be0b4b8fd33e69e29a841317b6ab665bcLoader2
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

        object inputBinding = default!;
        if (doc_.ContainsKey("inputBinding"))
        {
            try
            {
                inputBinding = (object)LoaderInstances.optional_CommandLineBindingLoader
                   .LoadField(doc_.GetValueOrDefault("inputBinding", null!), baseUri,
                       loadingOptions);
            }
            catch (ValidationException e)
            {
                errors.Add(
                  new ValidationException("the `inputBinding` field is not valid because: ", e)
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
                        "expected one of `items`, `type`, `label`, `doc`, `name`, `inputBinding`"));
                    break;
                }
            }

        }

        if (errors.Count > 0)
        {
            throw new ValidationException("", errors);
        }

        return new CommandInputArraySchema(
          items: items,
          type: type,
          label: label,
          doc: doc,
          name: name,
          inputBinding: inputBinding,
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
                
        r["items"] =
           ISavable.Save(items, false, (string)this.name!, relativeUris);
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
                
        if (this.inputBinding != null)
        {
            r["inputBinding"] =
               ISavable.Save(inputBinding, false, (string)this.name!, relativeUris);
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

            
    static readonly HashSet<string> attr = new() { "items", "type", "label", "doc", "name", "inputBinding" };
}

using System.Collections;

namespace CWLDotNet;

/**
 * Auto-generated class implementation for https://w3id.org/cwl/cwl#CommandOutputRecordSchema
 */
public class CommandOutputRecordSchema : ICommandOutputRecordSchema, ISavable {
    readonly LoadingOptions loadingOptions;

    readonly Dictionary<object, object> extensionFields;

  /**
   * The identifier for this type
   */
    public object? name { get; set; }

  /**
   * Defines the fields of the record.
   */
    public object? fields { get; set; }

  /**
   * Must be `record`
   */
    public enum_d9cba076fca539106791a4f46d198c7fcfbdb779 type { get; set; }

  /**
   * A short, human-readable label of this object.
   */
    public object? label { get; set; }

  /**
   * A documentation string for this object, or an array of strings which should be concatenated.
   */
    public object doc { get; set; }


    public CommandOutputRecordSchema (object name,object fields,enum_d9cba076fca539106791a4f46d198c7fcfbdb779 type,object label,object doc,LoadingOptions? loadingOptions = null, Dictionary<object, object>? extensionFields = null) {
        this.loadingOptions = loadingOptions ?? new LoadingOptions();
        this.extensionFields = extensionFields ?? new Dictionary<object, object>();
        this.name = name;
        this.fields = fields;
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
            
        object fields = default!;
        if (doc_.ContainsKey("fields"))
        {
            try
            {
                fields = (object)LoaderInstances.idmapfieldsoptional_array_of_CommandOutputRecordFieldLoader
                   .LoadField(doc_.GetValueOrDefault("fields", null!), baseUri,
                       loadingOptions);
            }
            catch (ValidationException e)
            {
                errors.Add(
                  new ValidationException("the `fields` field is not valid because: ", e)
                );
            }
        }

        enum_d9cba076fca539106791a4f46d198c7fcfbdb779 type = default!;
        try
        {
            type = (enum_d9cba076fca539106791a4f46d198c7fcfbdb779)LoaderInstances.typedslenum_d9cba076fca539106791a4f46d198c7fcfbdb779Loader2
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
                        "expected one of `fields`, `type`, `label`, `doc`, `name`"));
                    break;
                }
            }

        }

        if (errors.Count > 0)
        {
            throw new ValidationException("", errors);
        }

        return new CommandOutputRecordSchema(
          fields: fields,
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
                
        if (this.fields != null)
        {
            r["fields"] =
               ISavable.Save(fields, false, (string)this.name!, relativeUris);
        }
                
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

            
    static readonly HashSet<string> attr = new() { "fields", "type", "label", "doc", "name" };
}

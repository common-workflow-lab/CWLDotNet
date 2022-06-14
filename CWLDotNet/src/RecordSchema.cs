using System.Collections;

namespace CWLDotNet;

/**
 * Auto-generated class implementation for https://w3id.org/cwl/salad#RecordSchema
 */
public class RecordSchema : IRecordSchema, ISavable {
    readonly LoadingOptions loadingOptions;

    readonly Dictionary<object, object> extensionFields;

  /**
   * Defines the fields of the record.
   */
    public object? fields { get; set; }

  /**
   * Must be `record`
   */
    public enum_d9cba076fca539106791a4f46d198c7fcfbdb779 type { get; set; }


    public RecordSchema (object fields,enum_d9cba076fca539106791a4f46d198c7fcfbdb779 type,LoadingOptions? loadingOptions = null, Dictionary<object, object>? extensionFields = null) {
        this.loadingOptions = loadingOptions ?? new LoadingOptions();
        this.extensionFields = extensionFields ?? new Dictionary<object, object>();
        this.fields = fields;
        this.type = type;
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
            
        object fields = default!;
        if (doc_.ContainsKey("fields"))
        {
            try
            {
                fields = (object)LoaderInstances.idmapfieldsoptional_array_of_RecordFieldLoader
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
                        "expected one of `fields`, `type`"));
                    break;
                }
            }

        }

        if (errors.Count > 0)
        {
            throw new ValidationException("", errors);
        }

        return new RecordSchema(
          fields: fields,
          type: type,
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

        if (this.fields != null)
        {
            r["fields"] =
               ISavable.Save(fields, false, (string)baseUrl!, relativeUris);
        }
                
        r["type"] =
           ISavable.Save(type, false, (string)baseUrl!, relativeUris);
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

            
    static readonly HashSet<string> attr = new() { "fields", "type" };
}

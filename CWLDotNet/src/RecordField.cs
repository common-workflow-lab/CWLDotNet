using System.Collections;

namespace CWLDotNet;

/**
 * Auto-generated class implementation for https://w3id.org/cwl/salad#RecordField
 *
 * A field of a record.
 */
public class RecordField : IRecordField, ISavable {
    readonly LoadingOptions loadingOptions;

    readonly Dictionary<object, object> extensionFields;

  /**
   * The name of the field
   * 
   */
    public string name { get; set; }

  /**
   * A documentation string for this object, or an array of strings which should be concatenated.
   */
    public object doc { get; set; }

  /**
   * The field type
   * 
   */
    public object type { get; set; }


    public RecordField (string name,object doc,object type,LoadingOptions? loadingOptions = null, Dictionary<object, object>? extensionFields = null) {
        this.loadingOptions = loadingOptions ?? new LoadingOptions();
        this.extensionFields = extensionFields ?? new Dictionary<object, object>();
        this.name = name;
        this.doc = doc;
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
            
        string name = default!;
        if (doc_.ContainsKey("name"))
        {
            try
            {
                name = (string)LoaderInstances.uriStringInstanceTrueFalseNone
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
                throw new ValidationException("Missing name");
            }
        }
        else
        {
            baseUri = (string)name;
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

        object type = default!;
        try
        {
            type = (object)LoaderInstances.typedslunion_of_PrimitiveTypeLoader_or_RecordSchemaLoader_or_EnumSchemaLoader_or_ArraySchemaLoader_or_StringInstance_or_array_of_union_of_PrimitiveTypeLoader_or_RecordSchemaLoader_or_EnumSchemaLoader_or_ArraySchemaLoader_or_StringInstance2
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
                        "expected one of `doc`, `name`, `type`"));
                    break;
                }
            }

        }

        if (errors.Count > 0)
        {
            throw new ValidationException("", errors);
        }

        return new RecordField(
          doc: doc,
          name: name,
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

        if (this.name != null)
        {
            r["name"] = ISavable.SaveRelativeUri(this.name, true,
                                      relativeUris, null, (string)baseUrl!);

        }
                
        if (this.doc != null)
        {
            r["doc"] =
               ISavable.Save(doc, false, (string)this.name!, relativeUris);
        }
                
        r["type"] =
           ISavable.Save(type, false, (string)this.name!, relativeUris);
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

            
    static readonly HashSet<string> attr = new() { "doc", "name", "type" };
}

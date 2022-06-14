using System.Collections;

namespace CWLDotNet;

/**
 * Auto-generated class implementation for https://w3id.org/cwl/cwl#SchemaDefRequirement
 *
 * This field consists of an array of type definitions which must be used when
 * interpreting the `inputs` and `outputs` fields.  When a `type` field
 * contains a IRI, the implementation must check if the type is defined in
 * `schemaDefs` and use that definition.  If the type is not found in
 * `schemaDefs`, it is an error.  The entries in `schemaDefs` must be
 * processed in the order listed such that later schema definitions may refer
 * to earlier schema definitions.
 * 
 * - **Type definitions are allowed for `enum` and `record` types only.**
 * - Type definitions may be shared by defining them in a file and then
 *   `$include`-ing them in the `types` field.
 * - A file can contain a list of type definitions
 * 
 */
public class SchemaDefRequirement : ISchemaDefRequirement, ISavable {
    readonly LoadingOptions loadingOptions;

    readonly Dictionary<object, object> extensionFields;

  /**
   * Always 'SchemaDefRequirement'
   */
    public SchemaDefRequirement_class class_ { get; set; }

  /**
   * The list of type definitions.
   */
    public List<object> types { get; set; }


    public SchemaDefRequirement (SchemaDefRequirement_class class_,List<object> types,LoadingOptions? loadingOptions = null, Dictionary<object, object>? extensionFields = null) {
        this.loadingOptions = loadingOptions ?? new LoadingOptions();
        this.extensionFields = extensionFields ?? new Dictionary<object, object>();
        this.class_ = class_;
        this.types = types;
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
            
        SchemaDefRequirement_class class_ = default!;
        try
        {
            class_ = (SchemaDefRequirement_class)LoaderInstances.uriSchemaDefRequirement_classLoaderFalseTrueNone
               .LoadField(doc_.GetValueOrDefault("class", null!), baseUri,
                   loadingOptions);
        }
        catch (ValidationException e)
        {
            errors.Add(
              new ValidationException("the `class` field is not valid because: ", e)
            );
        }

        List<object> types = default!;
        try
        {
            types = (List<object>)LoaderInstances.array_of_union_of_CommandInputRecordSchemaLoader_or_CommandInputEnumSchemaLoader_or_CommandInputArraySchemaLoader
               .LoadField(doc_.GetValueOrDefault("types", null!), baseUri,
                   loadingOptions);
        }
        catch (ValidationException e)
        {
            errors.Add(
              new ValidationException("the `types` field is not valid because: ", e)
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
                        "expected one of `class`, `types`"));
                    break;
                }
            }

        }

        if (errors.Count > 0)
        {
            throw new ValidationException("", errors);
        }

        return new SchemaDefRequirement(
          class_: class_,
          types: types,
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

        r["class"] = ISavable.SaveRelativeUri(this.class_, false,
                                  relativeUris, null, (string)baseUrl!);

        r["types"] =
           ISavable.Save(types, false, (string)baseUrl!, relativeUris);
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

            
    static readonly HashSet<string> attr = new() { "class", "types" };
}

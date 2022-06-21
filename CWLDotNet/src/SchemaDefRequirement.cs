using System.Collections;
using OneOf;
using OneOf.Types;
namespace CWLDotNet;

/// <summary>
/// Auto-generated class implementation for https://w3id.org/cwl/cwl#SchemaDefRequirement
///
/// This field consists of an array of type definitions which must be used when
/// interpreting the `inputs` and `outputs` fields.  When a `type` field
/// contains a IRI, the implementation must check if the type is defined in
/// `schemaDefs` and use that definition.  If the type is not found in
/// `schemaDefs`, it is an error.  The entries in `schemaDefs` must be
/// processed in the order listed such that later schema definitions may refer
/// to earlier schema definitions.
/// 
/// - **Type definitions are allowed for `enum` and `record` types only.**
/// - Type definitions may be shared by defining them in a file and then
///   `$include`-ing them in the `types` field.
/// - A file can contain a list of type definitions
/// 
/// </summary>
public class SchemaDefRequirement : ISchemaDefRequirement, ISavable {
    readonly LoadingOptions loadingOptions;

    readonly Dictionary<object, object> extensionFields;

    /// <summary>
    /// Always 'SchemaDefRequirement'
    /// </summary>
    public SchemaDefRequirement_class class_ { get; set; }

    /// <summary>
    /// The list of type definitions.
    /// </summary>
    public List<OneOf<CommandInputRecordSchema , CommandInputEnumSchema , CommandInputArraySchema>> types { get; set; }


    public SchemaDefRequirement (List<OneOf<CommandInputRecordSchema , CommandInputEnumSchema , CommandInputArraySchema>> types, SchemaDefRequirement_class? class_ = null, LoadingOptions? loadingOptions = null, Dictionary<object, object>? extensionFields = null) {
        this.loadingOptions = loadingOptions ?? new LoadingOptions();
        this.extensionFields = extensionFields ?? new Dictionary<object, object>();
        this.class_ = class_ ?? SchemaDefRequirement_class.SCHEMADEFREQUIREMENT;
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
            
        dynamic class_ = default!;
        try
        {
            class_ = LoaderInstances.uriSchemaDefRequirement_classLoaderFalseTrueNone
               .LoadField(doc_.GetValueOrDefault("class", null!), baseUri,
                   loadingOptions);
        }
        catch (ValidationException e)
        {
            errors.Add(
              new ValidationException("the `class` field is not valid because: ", e)
            );
        }

        dynamic types = default!;
        try
        {
            types = LoaderInstances.array_of_union_of_CommandInputRecordSchemaLoader_or_CommandInputEnumSchemaLoader_or_CommandInputArraySchemaLoader
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

        var res__ = new SchemaDefRequirement(
          loadingOptions: loadingOptions,
          class_: class_,
          types: types
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

        var class_Val = ISavable.SaveRelativeUri(class_, false,
            relativeUris, null, (string)baseUrl!);
        if(class_Val is not null) {
            r["class"] = class_Val;
        }

        var typesVal = ISavable.Save(types, false, (string)baseUrl!, relativeUris);
        if(typesVal is not null) {
            r["types"] = typesVal;
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

    static readonly System.Collections.Generic.HashSet<string>attr = new() { "class", "types" };
}

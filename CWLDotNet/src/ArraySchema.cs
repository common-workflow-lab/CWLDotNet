using System.Collections;
using OneOf;
using OneOf.Types;
namespace CWLDotNet;

/// <summary>
/// Auto-generated class implementation for https://w3id.org/cwl/salad#ArraySchema
/// </summary>
public class ArraySchema : IArraySchema, ISavable {
    readonly LoadingOptions loadingOptions;

    readonly Dictionary<object, object> extensionFields;

    /// <summary>
    /// Defines the type of the array elements.
    /// </summary>
    public OneOf<PrimitiveType , RecordSchema , EnumSchema , ArraySchema , string , List<OneOf<PrimitiveType , RecordSchema , EnumSchema , ArraySchema , string>>> items { get; set; }

    /// <summary>
    /// Must be `array`
    /// </summary>
    public enum_d062602be0b4b8fd33e69e29a841317b6ab665bc type { get; set; }


    public ArraySchema (OneOf<PrimitiveType , RecordSchema , EnumSchema , ArraySchema , string , List<OneOf<PrimitiveType , RecordSchema , EnumSchema , ArraySchema , string>>> items, enum_d062602be0b4b8fd33e69e29a841317b6ab665bc type, LoadingOptions? loadingOptions = null, Dictionary<object, object>? extensionFields = null) {
        this.loadingOptions = loadingOptions ?? new LoadingOptions();
        this.extensionFields = extensionFields ?? new Dictionary<object, object>();
        this.items = items;
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
            
        dynamic items = default!;
        try
        {
            items = LoaderInstances.typedslunion_of_PrimitiveTypeLoader_or_RecordSchemaLoader_or_EnumSchemaLoader_or_ArraySchemaLoader_or_StringInstance_or_array_of_union_of_PrimitiveTypeLoader_or_RecordSchemaLoader_or_EnumSchemaLoader_or_ArraySchemaLoader_or_StringInstance2
               .LoadField(doc_.GetValueOrDefault("items", null!), baseUri,
                   loadingOptions);
        }
        catch (ValidationException e)
        {
            errors.Add(
              new ValidationException("the `items` field is not valid because: ", e)
            );
        }

        dynamic type = default!;
        try
        {
            type = LoaderInstances.typedslenum_d062602be0b4b8fd33e69e29a841317b6ab665bcLoader2
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
                        "expected one of `items`, `type`"));
                    break;
                }
            }

        }

        if (errors.Count > 0)
        {
            throw new ValidationException("", errors);
        }

        var res__ = new ArraySchema(
          loadingOptions: loadingOptions,
          items: items,
          type: type
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

        var itemsVal = ISavable.Save(items, false, (string)baseUrl!, relativeUris);
        if(itemsVal is not null) {
            r["items"] = itemsVal;
        }

        var typeVal = ISavable.Save(type, false, (string)baseUrl!, relativeUris);
        if(typeVal is not null) {
            r["type"] = typeVal;
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

    static readonly System.Collections.Generic.HashSet<string>attr = new() { "items", "type" };
}

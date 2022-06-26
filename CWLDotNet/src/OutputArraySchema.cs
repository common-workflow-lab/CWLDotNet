using System.Collections;
using OneOf;
using OneOf.Types;

namespace CWLDotNet;

/// <summary>
/// Auto-generated class implementation for https://w3id.org/cwl/cwl#OutputArraySchema
/// </summary>
public class OutputArraySchema : IOutputArraySchema, ISavable
{
    readonly LoadingOptions loadingOptions;

    readonly Dictionary<object, object> extensionFields;

    /// <summary>
    /// The identifier for this type
    /// </summary>
    public OneOf<None, string> name { get; set; }

    /// <summary>
    /// Defines the type of the array elements.
    /// </summary>
    public OneOf<CWLType, OutputRecordSchema, OutputEnumSchema, OutputArraySchema, string, List<OneOf<CWLType, OutputRecordSchema, OutputEnumSchema, OutputArraySchema, string>>> items { get; set; }

    /// <summary>
    /// Must be `array`
    /// </summary>
    public enum_d062602be0b4b8fd33e69e29a841317b6ab665bc type { get; set; }

    /// <summary>
    /// A short, human-readable label of this object.
    /// </summary>
    public OneOf<None, string> label { get; set; }

    /// <summary>
    /// A documentation string for this object, or an array of strings which should be concatenated.
    /// </summary>
    public OneOf<None, string, List<string>> doc { get; set; }


    public OutputArraySchema(OneOf<CWLType, OutputRecordSchema, OutputEnumSchema, OutputArraySchema, string, List<OneOf<CWLType, OutputRecordSchema, OutputEnumSchema, OutputArraySchema, string>>> items, enum_d062602be0b4b8fd33e69e29a841317b6ab665bc type, OneOf<None, string> name = default, OneOf<None, string> label = default, OneOf<None, string, List<string>> doc = default, LoadingOptions? loadingOptions = null, Dictionary<object, object>? extensionFields = null)
    {
        this.loadingOptions = loadingOptions ?? new LoadingOptions();
        this.extensionFields = extensionFields ?? new Dictionary<object, object>();
        this.name = name;
        this.items = items;
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

        dynamic name = default!;
        if (doc_.ContainsKey("name"))
        {
            try
            {
                name = LoaderInstances.uriunion_of_NullInstance_or_StringInstanceTrueFalseNone
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

        dynamic items = default!;
        try
        {
            items = LoaderInstances.typedslunion_of_CWLTypeLoader_or_OutputRecordSchemaLoader_or_OutputEnumSchemaLoader_or_OutputArraySchemaLoader_or_StringInstance_or_array_of_union_of_CWLTypeLoader_or_OutputRecordSchemaLoader_or_OutputEnumSchemaLoader_or_OutputArraySchemaLoader_or_StringInstance2
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

        dynamic label = default!;
        if (doc_.ContainsKey("label"))
        {
            try
            {
                label = LoaderInstances.union_of_NullInstance_or_StringInstance
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

        dynamic doc = default!;
        if (doc_.ContainsKey("doc"))
        {
            try
            {
                doc = LoaderInstances.union_of_NullInstance_or_StringInstance_or_array_of_StringInstance
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
                        "expected one of `items`, `type`, `label`, `doc`, `name`"));
                    break;
                }
            }

        }

        if (errors.Count > 0)
        {
            throw new ValidationException("", errors);
        }

        OutputArraySchema res__ = new(
          loadingOptions: loadingOptions,
          items: items,
          type: type
        );

        if (name != null)
        {
            res__.name = name;
        }

        if (label != null)
        {
            res__.label = label;
        }

        if (doc != null)
        {
            res__.doc = doc;
        }

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

        object? nameVal = ISavable.SaveRelativeUri(name, true,
            relativeUris, null, (string)baseUrl!);
        if (nameVal is not null)
        {
            r["name"] = nameVal;
        }

        object? itemsVal = ISavable.Save(items,
                                        false, (string)(this.name.Value is None ? "" : name.Value)!, relativeUris);
        if (itemsVal is not null)
        {
            r["items"] = itemsVal;
        }

        object? typeVal = ISavable.Save(type,
                                        false, (string)(this.name.Value is None ? "" : name.Value)!, relativeUris);
        if (typeVal is not null)
        {
            r["type"] = typeVal;
        }

        object? labelVal = ISavable.Save(label,
                                        false, (string)(this.name.Value is None ? "" : name.Value)!, relativeUris);
        if (labelVal is not null)
        {
            r["label"] = labelVal;
        }

        object? docVal = ISavable.Save(doc,
                                        false, (string)(this.name.Value is None ? "" : name.Value)!, relativeUris);
        if (docVal is not null)
        {
            r["doc"] = docVal;
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

    static readonly System.Collections.Generic.HashSet<string> attr = new() { "items", "type", "label", "doc", "name" };
}

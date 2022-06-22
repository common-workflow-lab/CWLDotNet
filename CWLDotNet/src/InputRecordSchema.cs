using System.Collections;
using OneOf;
using OneOf.Types;

namespace CWLDotNet;

/// <summary>
/// Auto-generated class implementation for https://w3id.org/cwl/cwl#InputRecordSchema
/// </summary>
public class InputRecordSchema : IInputRecordSchema, ISavable
{
    readonly LoadingOptions loadingOptions;

    readonly Dictionary<object, object> extensionFields;

    /// <summary>
    /// The identifier for this type
    /// </summary>
    public OneOf<None, string> name { get; set; }

    /// <summary>
    /// Defines the fields of the record.
    /// </summary>
    public OneOf<None, List<InputRecordField>> fields { get; set; }

    /// <summary>
    /// Must be `record`
    /// </summary>
    public enum_d9cba076fca539106791a4f46d198c7fcfbdb779 type { get; set; }

    /// <summary>
    /// A short, human-readable label of this object.
    /// </summary>
    public OneOf<None, string> label { get; set; }

    /// <summary>
    /// A documentation string for this object, or an array of strings which should be concatenated.
    /// </summary>
    public OneOf<None, string, List<string>> doc { get; set; }


    public InputRecordSchema(enum_d9cba076fca539106791a4f46d198c7fcfbdb779 type, OneOf<None, string> name = default, OneOf<None, List<InputRecordField>> fields = default, OneOf<None, string> label = default, OneOf<None, string, List<string>> doc = default, LoadingOptions? loadingOptions = null, Dictionary<object, object>? extensionFields = null)
    {
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

        dynamic fields = default!;
        if (doc_.ContainsKey("fields"))
        {
            try
            {
                fields = LoaderInstances.idmapfieldsunion_of_NullInstance_or_array_of_InputRecordFieldLoader
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

        dynamic type = default!;
        try
        {
            type = LoaderInstances.typedslenum_d9cba076fca539106791a4f46d198c7fcfbdb779Loader2
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
                        "expected one of `fields`, `type`, `label`, `doc`, `name`"));
                    break;
                }
            }

        }

        if (errors.Count > 0)
        {
            throw new ValidationException("", errors);
        }

        InputRecordSchema res__ = new(
          loadingOptions: loadingOptions,
          type: type
        );

        if (name != null)
        {
            res__.name = name;
        }

        if (fields != null)
        {
            res__.fields = fields;
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

        object? fieldsVal = ISavable.Save(fields, false, (string)this.name.AsT1!, relativeUris);
        if (fieldsVal is not null)
        {
            r["fields"] = fieldsVal;
        }

        object? typeVal = ISavable.Save(type, false, (string)this.name.AsT1!, relativeUris);
        if (typeVal is not null)
        {
            r["type"] = typeVal;
        }

        object? labelVal = ISavable.Save(label, false, (string)this.name.AsT1!, relativeUris);
        if (labelVal is not null)
        {
            r["label"] = labelVal;
        }

        object? docVal = ISavable.Save(doc, false, (string)this.name.AsT1!, relativeUris);
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

    static readonly System.Collections.Generic.HashSet<string> attr = new() { "fields", "type", "label", "doc", "name" };
}

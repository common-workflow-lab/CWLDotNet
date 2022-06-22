using System.Collections;
using OneOf;
using OneOf.Types;

namespace CWLDotNet;

/// <summary>
/// Auto-generated class implementation for https://w3id.org/cwl/salad#EnumSchema
///
/// Define an enumerated type.
/// 
/// </summary>
public class EnumSchema : IEnumSchema, ISavable
{
    readonly LoadingOptions loadingOptions;

    readonly Dictionary<object, object> extensionFields;

    /// <summary>
    /// Defines the set of valid symbols.
    /// </summary>
    public List<string> symbols { get; set; }

    /// <summary>
    /// Must be `enum`
    /// </summary>
    public enum_d961d79c225752b9fadb617367615ab176b47d77 type { get; set; }


    public EnumSchema(List<string> symbols, enum_d961d79c225752b9fadb617367615ab176b47d77 type, LoadingOptions? loadingOptions = null, Dictionary<object, object>? extensionFields = null)
    {
        this.loadingOptions = loadingOptions ?? new LoadingOptions();
        this.extensionFields = extensionFields ?? new Dictionary<object, object>();
        this.symbols = symbols;
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

        dynamic symbols = default!;
        try
        {
            symbols = LoaderInstances.uriarray_of_StringInstanceTrueFalseNone
               .LoadField(doc_.GetValueOrDefault("symbols", null!), baseUri,
                   loadingOptions);
        }
        catch (ValidationException e)
        {
            errors.Add(
              new ValidationException("the `symbols` field is not valid because: ", e)
            );
        }

        dynamic type = default!;
        try
        {
            type = LoaderInstances.typedslenum_d961d79c225752b9fadb617367615ab176b47d77Loader2
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
                        "expected one of `symbols`, `type`"));
                    break;
                }
            }

        }

        if (errors.Count > 0)
        {
            throw new ValidationException("", errors);
        }

        EnumSchema res__ = new(
          loadingOptions: loadingOptions,
          symbols: symbols,
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

        object? symbolsVal = ISavable.SaveRelativeUri(symbols, true,
            relativeUris, null, (string)baseUrl!);
        if (symbolsVal is not null)
        {
            r["symbols"] = symbolsVal;
        }

        object? typeVal = ISavable.Save(type,
                                        false, (string)baseUrl!, relativeUris);
        if (typeVal is not null)
        {
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

    static readonly System.Collections.Generic.HashSet<string> attr = new() { "symbols", "type" };
}

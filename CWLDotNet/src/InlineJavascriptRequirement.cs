using System.Collections;
using OneOf;
using OneOf.Types;

namespace CWLDotNet;

/// <summary>
/// Auto-generated class implementation for https://w3id.org/cwl/cwl#InlineJavascriptRequirement
///
/// Indicates that the workflow platform must support inline Javascript expressions.
/// If this requirement is not present, the workflow platform must not perform expression
/// interpolatation.
/// 
/// </summary>
public class InlineJavascriptRequirement : IInlineJavascriptRequirement, ISavable
{
    readonly LoadingOptions loadingOptions;

    readonly Dictionary<object, object> extensionFields;

    /// <summary>
    /// Always 'InlineJavascriptRequirement'
    /// </summary>
    public InlineJavascriptRequirement_class class_ { get; set; }

    /// <summary>
    /// Additional code fragments that will also be inserted
    /// before executing the expression code.  Allows for function definitions that may
    /// be called from CWL expressions.
    /// 
    /// </summary>
    public OneOf<None, List<string>> expressionLib { get; set; }


    public InlineJavascriptRequirement(InlineJavascriptRequirement_class? class_ = null, OneOf<None, List<string>> expressionLib = default, LoadingOptions? loadingOptions = null, Dictionary<object, object>? extensionFields = null)
    {
        this.loadingOptions = loadingOptions ?? new LoadingOptions();
        this.extensionFields = extensionFields ?? new Dictionary<object, object>();
        this.class_ = class_ ?? InlineJavascriptRequirement_class.INLINEJAVASCRIPTREQUIREMENT;
        this.expressionLib = expressionLib;
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
            class_ = LoaderInstances.uriInlineJavascriptRequirement_classLoaderFalseTrueNone
               .LoadField(doc_.GetValueOrDefault("class", null!), baseUri,
                   loadingOptions);
        }
        catch (ValidationException e)
        {
            errors.Add(
              new ValidationException("the `class` field is not valid because: ", e)
            );
        }

        dynamic expressionLib = default!;
        if (doc_.ContainsKey("expressionLib"))
        {
            try
            {
                expressionLib = LoaderInstances.union_of_NullInstance_or_array_of_StringInstance
                   .LoadField(doc_.GetValueOrDefault("expressionLib", null!), baseUri,
                       loadingOptions);
            }
            catch (ValidationException e)
            {
                errors.Add(
                  new ValidationException("the `expressionLib` field is not valid because: ", e)
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
                        "expected one of `class`, `expressionLib`"));
                    break;
                }
            }

        }

        if (errors.Count > 0)
        {
            throw new ValidationException("", errors);
        }

        InlineJavascriptRequirement res__ = new(
          loadingOptions: loadingOptions,
          class_: class_
        );

        if (expressionLib != null)
        {
            res__.expressionLib = expressionLib;
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

        object? class_Val = ISavable.SaveRelativeUri(class_, false,
            relativeUris, null, (string)baseUrl!);
        if (class_Val is not null)
        {
            r["class"] = class_Val;
        }

        object? expressionLibVal = ISavable.Save(expressionLib, false, (string)baseUrl!, relativeUris);
        if (expressionLibVal is not null)
        {
            r["expressionLib"] = expressionLibVal;
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

    static readonly System.Collections.Generic.HashSet<string> attr = new() { "class", "expressionLib" };
}

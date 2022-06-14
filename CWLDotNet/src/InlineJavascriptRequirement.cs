using System.Collections;

namespace CWLDotNet;

/**
 * Auto-generated class implementation for https://w3id.org/cwl/cwl#InlineJavascriptRequirement
 *
 * Indicates that the workflow platform must support inline Javascript expressions.
 * If this requirement is not present, the workflow platform must not perform expression
 * interpolatation.
 * 
 */
public class InlineJavascriptRequirement : IInlineJavascriptRequirement, ISavable {
    readonly LoadingOptions loadingOptions;

    readonly Dictionary<object, object> extensionFields;

  /**
   * Always 'InlineJavascriptRequirement'
   */
    public InlineJavascriptRequirement_class class_ { get; set; }

  /**
   * Additional code fragments that will also be inserted
   * before executing the expression code.  Allows for function definitions that may
   * be called from CWL expressions.
   * 
   */
    public object? expressionLib { get; set; }


    public InlineJavascriptRequirement (InlineJavascriptRequirement_class class_,object expressionLib,LoadingOptions? loadingOptions = null, Dictionary<object, object>? extensionFields = null) {
        this.loadingOptions = loadingOptions ?? new LoadingOptions();
        this.extensionFields = extensionFields ?? new Dictionary<object, object>();
        this.class_ = class_;
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
            
        InlineJavascriptRequirement_class class_ = default!;
        try
        {
            class_ = (InlineJavascriptRequirement_class)LoaderInstances.uriInlineJavascriptRequirement_classLoaderFalseTrueNone
               .LoadField(doc_.GetValueOrDefault("class", null!), baseUri,
                   loadingOptions);
        }
        catch (ValidationException e)
        {
            errors.Add(
              new ValidationException("the `class` field is not valid because: ", e)
            );
        }

        object expressionLib = default!;
        if (doc_.ContainsKey("expressionLib"))
        {
            try
            {
                expressionLib = (object)LoaderInstances.optional_array_of_StringInstance
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

        return new InlineJavascriptRequirement(
          class_: class_,
          expressionLib: expressionLib,
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

        if (this.expressionLib != null)
        {
            r["expressionLib"] =
               ISavable.Save(expressionLib, false, (string)baseUrl!, relativeUris);
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

            
    static readonly HashSet<string> attr = new() { "class", "expressionLib" };
}

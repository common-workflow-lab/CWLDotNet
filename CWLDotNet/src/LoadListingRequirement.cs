using System.Collections;
using OneOf;
using OneOf.Types;

namespace CWLDotNet;

/// <summary>
/// Auto-generated class implementation for https://w3id.org/cwl/cwl#LoadListingRequirement
///
/// Specify the desired behavior for loading the `listing` field of
/// a Directory object for use by expressions.
/// 
/// </summary>
public class LoadListingRequirement : ILoadListingRequirement, ISavable
{
    readonly LoadingOptions loadingOptions;

    readonly Dictionary<object, object> extensionFields;

    /// <summary>
    /// Always 'LoadListingRequirement'
    /// </summary>
    public LoadListingRequirement_class class_ { get; set; }
    public OneOf<None, LoadListingEnum> loadListing { get; set; }


    public LoadListingRequirement(LoadListingRequirement_class? class_ = null, OneOf<None, LoadListingEnum> loadListing = default, LoadingOptions? loadingOptions = null, Dictionary<object, object>? extensionFields = null)
    {
        this.loadingOptions = loadingOptions ?? new LoadingOptions();
        this.extensionFields = extensionFields ?? new Dictionary<object, object>();
        this.class_ = class_ ?? LoadListingRequirement_class.LOADLISTINGREQUIREMENT;
        this.loadListing = loadListing;
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
            class_ = LoaderInstances.uriLoadListingRequirement_classLoaderFalseTrueNone
               .LoadField(doc_.GetValueOrDefault("class", null!), baseUri,
                   loadingOptions);
        }
        catch (ValidationException e)
        {
            errors.Add(
              new ValidationException("the `class` field is not valid because: ", e)
            );
        }

        dynamic loadListing = default!;
        if (doc_.ContainsKey("loadListing"))
        {
            try
            {
                loadListing = LoaderInstances.union_of_NullInstance_or_LoadListingEnumLoader
                   .LoadField(doc_.GetValueOrDefault("loadListing", null!), baseUri,
                       loadingOptions);
            }
            catch (ValidationException e)
            {
                errors.Add(
                  new ValidationException("the `loadListing` field is not valid because: ", e)
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
                        "expected one of `class`, `loadListing`"));
                    break;
                }
            }

        }

        if (errors.Count > 0)
        {
            throw new ValidationException("", errors);
        }

        LoadListingRequirement res__ = new(
          loadingOptions: loadingOptions,
          class_: class_
        );

        if (loadListing != null)
        {
            res__.loadListing = loadListing;
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

        object? loadListingVal = ISavable.Save(loadListing,
                                        false, (string)baseUrl!, relativeUris);
        if (loadListingVal is not null)
        {
            r["loadListing"] = loadListingVal;
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

    static readonly System.Collections.Generic.HashSet<string> attr = new() { "class", "loadListing" };
}

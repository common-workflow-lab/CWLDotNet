using System.Collections;
using OneOf;
using OneOf.Types;
namespace CWLDotNet;

/// <summary>
/// Auto-generated class implementation for https://w3id.org/cwl/cwl#NetworkAccess
///
/// Indicate whether a process requires outgoing IPv4/IPv6 network
/// access.  Choice of IPv4 or IPv6 is implementation and site
/// specific, correct tools must support both.
/// 
/// If `networkAccess` is false or not specified, tools must not
/// assume network access, except for localhost (the loopback device).
/// 
/// If `networkAccess` is true, the tool must be able to make outgoing
/// connections to network resources.  Resources may be on a private
/// subnet or the public Internet.  However, implementations and sites
/// may apply their own security policies to restrict what is
/// accessible by the tool.
/// 
/// Enabling network access does not imply a publically routable IP
/// address or the ability to accept inbound connections.
/// 
/// </summary>
public class NetworkAccess : INetworkAccess, ISavable {
    readonly LoadingOptions loadingOptions;

    readonly Dictionary<object, object> extensionFields;

    /// <summary>
    /// Always 'NetworkAccess'
    /// </summary>
    public NetworkAccess_class class_ { get; set; }
    public OneOf<bool , string> networkAccess { get; set; }


    public NetworkAccess (OneOf<bool , string> networkAccess, NetworkAccess_class? class_ = null, LoadingOptions? loadingOptions = null, Dictionary<object, object>? extensionFields = null) {
        this.loadingOptions = loadingOptions ?? new LoadingOptions();
        this.extensionFields = extensionFields ?? new Dictionary<object, object>();
        this.class_ = class_ ?? NetworkAccess_class.NETWORKACCESS;
        this.networkAccess = networkAccess;
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
            class_ = LoaderInstances.uriNetworkAccess_classLoaderFalseTrueNone
               .LoadField(doc_.GetValueOrDefault("class", null!), baseUri,
                   loadingOptions);
        }
        catch (ValidationException e)
        {
            errors.Add(
              new ValidationException("the `class` field is not valid because: ", e)
            );
        }

        dynamic networkAccess = default!;
        try
        {
            networkAccess = LoaderInstances.union_of_BooleanInstance_or_ExpressionLoader
               .LoadField(doc_.GetValueOrDefault("networkAccess", null!), baseUri,
                   loadingOptions);
        }
        catch (ValidationException e)
        {
            errors.Add(
              new ValidationException("the `networkAccess` field is not valid because: ", e)
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
                        "expected one of `class`, `networkAccess`"));
                    break;
                }
            }

        }

        if (errors.Count > 0)
        {
            throw new ValidationException("", errors);
        }

        var res__ = new NetworkAccess(
          loadingOptions: loadingOptions,
          class_: class_,
          networkAccess: networkAccess
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

        var networkAccessVal = ISavable.Save(networkAccess, false, (string)baseUrl!, relativeUris);
        if(networkAccessVal is not null) {
            r["networkAccess"] = networkAccessVal;
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

    static readonly System.Collections.Generic.HashSet<string>attr = new() { "class", "networkAccess" };
}

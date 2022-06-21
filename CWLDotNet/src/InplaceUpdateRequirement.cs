using System.Collections;
using OneOf;
using OneOf.Types;
namespace CWLDotNet;

/// <summary>
/// Auto-generated class implementation for https://w3id.org/cwl/cwl#InplaceUpdateRequirement
///
/// 
/// If `inplaceUpdate` is true, then an implementation supporting this
/// feature may permit tools to directly update files with `writable:
/// true` in InitialWorkDirRequirement.  That is, as an optimization,
/// files may be destructively modified in place as opposed to copied
/// and updated.
/// 
/// An implementation must ensure that only one workflow step may
/// access a writable file at a time.  It is an error if a file which
/// is writable by one workflow step file is accessed (for reading or
/// writing) by any other workflow step running independently.
/// However, a file which has been updated in a previous completed
/// step may be used as input to multiple steps, provided it is
/// read-only in every step.
/// 
/// Workflow steps which modify a file must produce the modified file
/// as output.  Downstream steps which futher process the file must
/// use the output of previous steps, and not refer to a common input
/// (this is necessary for both ordering and correctness).
/// 
/// Workflow authors should provide this in the `hints` section.  The
/// intent of this feature is that workflows produce the same results
/// whether or not InplaceUpdateRequirement is supported by the
/// implementation, and this feature is primarily available as an
/// optimization for particular environments.
/// 
/// Users and implementers should be aware that workflows that
/// destructively modify inputs may not be repeatable or reproducible.
/// In particular, enabling this feature implies that WorkReuse should
/// not be enabled.
/// 
/// </summary>
public class InplaceUpdateRequirement : IInplaceUpdateRequirement, ISavable {
    readonly LoadingOptions loadingOptions;

    readonly Dictionary<object, object> extensionFields;

    /// <summary>
    /// Always 'InplaceUpdateRequirement'
    /// </summary>
    public InplaceUpdateRequirement_class class_ { get; set; }
    public bool inplaceUpdate { get; set; }


    public InplaceUpdateRequirement (bool inplaceUpdate, InplaceUpdateRequirement_class? class_ = null, LoadingOptions? loadingOptions = null, Dictionary<object, object>? extensionFields = null) {
        this.loadingOptions = loadingOptions ?? new LoadingOptions();
        this.extensionFields = extensionFields ?? new Dictionary<object, object>();
        this.class_ = class_ ?? InplaceUpdateRequirement_class.INPLACEUPDATEREQUIREMENT;
        this.inplaceUpdate = inplaceUpdate;
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
            class_ = LoaderInstances.uriInplaceUpdateRequirement_classLoaderFalseTrueNone
               .LoadField(doc_.GetValueOrDefault("class", null!), baseUri,
                   loadingOptions);
        }
        catch (ValidationException e)
        {
            errors.Add(
              new ValidationException("the `class` field is not valid because: ", e)
            );
        }

        dynamic inplaceUpdate = default!;
        try
        {
            inplaceUpdate = LoaderInstances.BooleanInstance
               .LoadField(doc_.GetValueOrDefault("inplaceUpdate", null!), baseUri,
                   loadingOptions);
        }
        catch (ValidationException e)
        {
            errors.Add(
              new ValidationException("the `inplaceUpdate` field is not valid because: ", e)
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
                        "expected one of `class`, `inplaceUpdate`"));
                    break;
                }
            }

        }

        if (errors.Count > 0)
        {
            throw new ValidationException("", errors);
        }

        var res__ = new InplaceUpdateRequirement(
          loadingOptions: loadingOptions,
          class_: class_,
          inplaceUpdate: inplaceUpdate
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

        var inplaceUpdateVal = ISavable.Save(inplaceUpdate, false, (string)baseUrl!, relativeUris);
        if(inplaceUpdateVal is not null) {
            r["inplaceUpdate"] = inplaceUpdateVal;
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

    static readonly System.Collections.Generic.HashSet<string>attr = new() { "class", "inplaceUpdate" };
}

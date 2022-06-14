using System.Collections;

namespace CWLDotNet;

/// <summary>
/// Auto-generated class implementation for https://w3id.org/cwl/cwl#WorkflowStepInput
///
/// The input of a workflow step connects an upstream parameter (from the
/// workflow inputs, or the outputs of other workflows steps) with the input
/// parameters of the process specified by the `run` field. Only input parameters
/// declared by the target process will be passed through at runtime to the process
/// though additonal parameters may be specified (for use within `valueFrom`
/// expressions for instance) - unconnected or unused parameters do not represent an
/// error condition.
/// 
/// # Input object
/// 
/// A WorkflowStepInput object must contain an `id` field in the form
/// `#fieldname` or `#prefix/fieldname`.  When the `id` field contains a slash
/// `/` the field name consists of the characters following the final slash
/// (the prefix portion may contain one or more slashes to indicate scope).
/// This defines a field of the workflow step input object with the value of
/// the `source` parameter(s).
/// 
/// # Merging multiple inbound data links
/// 
/// To merge multiple inbound data links,
/// [MultipleInputFeatureRequirement](#MultipleInputFeatureRequirement) must be specified
/// in the workflow or workflow step requirements.
/// 
/// If the sink parameter is an array, or named in a [workflow
/// scatter](#WorkflowStep) operation, there may be multiple inbound
/// data links listed in the `source` field.  The values from the
/// input links are merged depending on the method specified in the
/// `linkMerge` field.  If both `linkMerge` and `pickValue` are null
/// or not specified, and there is more than one element in the
/// `source` array, the default method is "merge_nested".
/// 
/// If both `linkMerge` and `pickValue` are null or not specified, and
/// there is only a single element in the `source`, then the input
/// parameter takes the scalar value from the single input link (it is
/// *not* wrapped in a single-list).
/// 
/// * **merge_nested**
/// 
///   The input must be an array consisting of exactly one entry for each
///   input link.  If "merge_nested" is specified with a single link, the value
///   from the link must be wrapped in a single-item list.
/// 
/// * **merge_flattened**
/// 
///   1. The source and sink parameters must be compatible types, or the source
///      type must be compatible with single element from the "items" type of
///      the destination array parameter.
///   2. Source parameters which are arrays are concatenated.
///      Source parameters which are single element types are appended as
///      single elements.
/// 
/// # Picking non-null values among inbound data links
/// 
/// If present, `pickValue` specifies how to picking non-null values among inbound data links.
/// 
/// `pickValue` is evaluated
///   1. Once all source values from upstream step or parameters are available.
///   2. After `linkMerge`.
///   3. Before `scatter` or `valueFrom`.
/// 
/// This is specifically intended to be useful in combination with
/// [conditional execution](#WorkflowStep), where several upstream
/// steps may be connected to a single input (`source` is a list), and
/// skipped steps produce null values.
/// 
/// Static type checkers should check for type consistency after infering what the type
/// will be after `pickValue` is applied, just as they do currently for `linkMerge`.
/// 
/// * **first_non_null**
/// 
///   For the first level of a list input, pick the first non-null element.  The result is a scalar.
///   It is an error if there is no non-null element.  Examples:
///   * `[null, x, null, y] -> x`
///   * `[null, [null], null, y] -> [null]`
///   * `[null, null, null] -> Runtime Error`
/// 
///   *Intended use case*: If-else pattern where the
///   value comes either from a conditional step or from a default or
///   fallback value. The conditional step(s) should be placed first in
///   the list.
/// 
/// * **the_only_non_null**
/// 
///   For the first level of a list input, pick the single non-null element.  The result is a scalar.
///   It is an error if there is more than one non-null element.  Examples:
/// 
///   * `[null, x, null] -> x`
///   * `[null, x, null, y] -> Runtime Error`
///   * `[null, [null], null] -> [null]`
///   * `[null, null, null] -> Runtime Error`
/// 
///   *Intended use case*: Switch type patterns where developer considers
///   more than one active code path as a workflow error
///   (possibly indicating an error in writing `when` condition expressions).
/// 
/// * **all_non_null**
/// 
///   For the first level of a list input, pick all non-null values.
///   The result is a list, which may be empty.  Examples:
/// 
///   * `[null, x, null] -> [x]`
///   * `[x, null, y] -> [x, y]`
///   * `[null, [x], [null]] -> [[x], [null]]`
///   * `[null, null, null] -> []`
/// 
///   *Intended use case*: It is valid to have more than one source, but
///    sources are conditional, so null sources (from skipped steps)
///    should be filtered out.
/// 
/// </summary>
public class WorkflowStepInput : IWorkflowStepInput, ISavable {
    readonly LoadingOptions loadingOptions;

    readonly Dictionary<object, object> extensionFields;

    /// <summary>
    /// The unique identifier for this object.
    /// </summary>
    public object? id { get; set; }

    /// <summary>
    /// Specifies one or more workflow parameters that will provide input to
    /// the underlying step parameter.
    /// 
    /// </summary>
    public object source { get; set; }

    /// <summary>
    /// The method to use to merge multiple inbound links into a single array.
    /// If not specified, the default method is "merge_nested".
    /// 
    /// </summary>
    public object? linkMerge { get; set; }

    /// <summary>
    /// The method to use to choose non-null elements among multiple sources.
    /// 
    /// </summary>
    public object? pickValue { get; set; }

    /// <summary>
    /// Only valid when `type: File` or is an array of `items: File`.
    /// 
    /// If true, the file (or each file in the array) must be a UTF-8
    /// text file 64 KiB or smaller, and the implementation must read
    /// the entire contents of the file (or file array) and place it
    /// in the `contents` field of the File object for use by
    /// expressions.  If the size of the file is greater than 64 KiB,
    /// the implementation must raise a fatal error.
    /// 
    /// </summary>
    public object? loadContents { get; set; }

    /// <summary>
    /// Only valid when `type: Directory` or is an array of `items: Directory`.
    /// 
    /// Specify the desired behavior for loading the `listing` field of
    /// a Directory object for use by expressions.
    /// 
    /// The order of precedence for loadListing is:
    /// 
    ///   1. `loadListing` on an individual parameter
    ///   2. Inherited from `LoadListingRequirement`
    ///   3. By default: `no_listing`
    /// 
    /// </summary>
    public object? loadListing { get; set; }

    /// <summary>
    /// A short, human-readable label of this object.
    /// </summary>
    public object? label { get; set; }

    /// <summary>
    /// The default value for this parameter to use if either there is no
    /// `source` field, or the value produced by the `source` is `null`.  The
    /// default must be applied prior to scattering or evaluating `valueFrom`.
    /// 
    /// </summary>
    public object? default_ { get; set; }

    /// <summary>
    /// To use valueFrom, [StepInputExpressionRequirement](#StepInputExpressionRequirement) must
    /// be specified in the workflow or workflow step requirements.
    /// 
    /// If `valueFrom` is a constant string value, use this as the value for
    /// this input parameter.
    /// 
    /// If `valueFrom` is a parameter reference or expression, it must be
    /// evaluated to yield the actual value to be assiged to the input field.
    /// 
    /// The `self` value in the parameter reference or expression must be
    /// 1. `null` if there is no `source` field
    /// 2. the value of the parameter(s) specified in the `source` field when this
    /// workflow input parameter **is not** specified in this workflow step's `scatter` field.
    /// 3. an element of the parameter specified in the `source` field when this workflow input
    /// parameter **is** specified in this workflow step's `scatter` field.
    /// 
    /// The value of `inputs` in the parameter reference or expression must be
    /// the input object to the workflow step after assigning the `source`
    /// values, applying `default`, and then scattering.  The order of
    /// evaluating `valueFrom` among step input parameters is undefined and the
    /// result of evaluating `valueFrom` on a parameter must not be visible to
    /// evaluation of `valueFrom` on other parameters.
    /// 
    /// </summary>
    public object valueFrom { get; set; }


    public WorkflowStepInput (object id,object source,object linkMerge,object pickValue,object loadContents,object loadListing,object label,object default_,object valueFrom,LoadingOptions? loadingOptions = null, Dictionary<object, object>? extensionFields = null) {
        this.loadingOptions = loadingOptions ?? new LoadingOptions();
        this.extensionFields = extensionFields ?? new Dictionary<object, object>();
        this.id = id;
        this.source = source;
        this.linkMerge = linkMerge;
        this.pickValue = pickValue;
        this.loadContents = loadContents;
        this.loadListing = loadListing;
        this.label = label;
        this.default_ = default_;
        this.valueFrom = valueFrom;
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
            
        object id = default!;
        if (doc_.ContainsKey("id"))
        {
            try
            {
                id = (object)LoaderInstances.urioptional_StringInstanceTrueFalseNone
                   .LoadField(doc_.GetValueOrDefault("id", null!), baseUri,
                       loadingOptions);
            }
            catch (ValidationException e)
            {
                errors.Add(
                  new ValidationException("the `id` field is not valid because: ", e)
                );
            }
        }

        if (id == null)
        {
            if (docRoot != null)
            {
                id = docRoot;
            }
            else
            {
                id = "_" + Guid.NewGuid();
            }
        }
        else
        {
            baseUri = (string)id;
        }
            
        object source = default!;
        if (doc_.ContainsKey("source"))
        {
            try
            {
                source = (object)LoaderInstances.uriunion_of_NullInstance_or_StringInstance_or_array_of_StringInstanceFalseFalse2
                   .LoadField(doc_.GetValueOrDefault("source", null!), baseUri,
                       loadingOptions);
            }
            catch (ValidationException e)
            {
                errors.Add(
                  new ValidationException("the `source` field is not valid because: ", e)
                );
            }
        }

        object linkMerge = default!;
        if (doc_.ContainsKey("linkMerge"))
        {
            try
            {
                linkMerge = (object)LoaderInstances.optional_LinkMergeMethodLoader
                   .LoadField(doc_.GetValueOrDefault("linkMerge", null!), baseUri,
                       loadingOptions);
            }
            catch (ValidationException e)
            {
                errors.Add(
                  new ValidationException("the `linkMerge` field is not valid because: ", e)
                );
            }
        }

        object pickValue = default!;
        if (doc_.ContainsKey("pickValue"))
        {
            try
            {
                pickValue = (object)LoaderInstances.optional_PickValueMethodLoader
                   .LoadField(doc_.GetValueOrDefault("pickValue", null!), baseUri,
                       loadingOptions);
            }
            catch (ValidationException e)
            {
                errors.Add(
                  new ValidationException("the `pickValue` field is not valid because: ", e)
                );
            }
        }

        object loadContents = default!;
        if (doc_.ContainsKey("loadContents"))
        {
            try
            {
                loadContents = (object)LoaderInstances.optional_BooleanInstance
                   .LoadField(doc_.GetValueOrDefault("loadContents", null!), baseUri,
                       loadingOptions);
            }
            catch (ValidationException e)
            {
                errors.Add(
                  new ValidationException("the `loadContents` field is not valid because: ", e)
                );
            }
        }

        object loadListing = default!;
        if (doc_.ContainsKey("loadListing"))
        {
            try
            {
                loadListing = (object)LoaderInstances.optional_LoadListingEnumLoader
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

        object label = default!;
        if (doc_.ContainsKey("label"))
        {
            try
            {
                label = (object)LoaderInstances.optional_StringInstance
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

        object default_ = default!;
        if (doc_.ContainsKey("default"))
        {
            try
            {
                default_ = (object)LoaderInstances.optional_AnyInstance
                   .LoadField(doc_.GetValueOrDefault("default", null!), baseUri,
                       loadingOptions);
            }
            catch (ValidationException e)
            {
                errors.Add(
                  new ValidationException("the `default` field is not valid because: ", e)
                );
            }
        }

        object valueFrom = default!;
        if (doc_.ContainsKey("valueFrom"))
        {
            try
            {
                valueFrom = (object)LoaderInstances.union_of_NullInstance_or_StringInstance_or_ExpressionLoader
                   .LoadField(doc_.GetValueOrDefault("valueFrom", null!), baseUri,
                       loadingOptions);
            }
            catch (ValidationException e)
            {
                errors.Add(
                  new ValidationException("the `valueFrom` field is not valid because: ", e)
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
                        "expected one of `id`, `source`, `linkMerge`, `pickValue`, `loadContents`, `loadListing`, `label`, `default`, `valueFrom`"));
                    break;
                }
            }

        }

        if (errors.Count > 0)
        {
            throw new ValidationException("", errors);
        }

        return new WorkflowStepInput(
          id: id,
          source: source,
          linkMerge: linkMerge,
          pickValue: pickValue,
          loadContents: loadContents,
          loadListing: loadListing,
          label: label,
          default_: default_,
          valueFrom: valueFrom,
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

        if (this.id != null)
        {
            r["id"] = ISavable.SaveRelativeUri(this.id, true,
                                      relativeUris, null, (string)baseUrl!);

        }
                
        if (this.source != null)
        {
            r["source"] = ISavable.SaveRelativeUri(this.source, false,
                                      relativeUris, 2, (string)this.id!);

        }
                
        if (this.linkMerge != null)
        {
            r["linkMerge"] =
               ISavable.Save(linkMerge, false, (string)this.id!, relativeUris);
        }
                
        if (this.pickValue != null)
        {
            r["pickValue"] =
               ISavable.Save(pickValue, false, (string)this.id!, relativeUris);
        }
                
        if (this.loadContents != null)
        {
            r["loadContents"] =
               ISavable.Save(loadContents, false, (string)this.id!, relativeUris);
        }
                
        if (this.loadListing != null)
        {
            r["loadListing"] =
               ISavable.Save(loadListing, false, (string)this.id!, relativeUris);
        }
                
        if (this.label != null)
        {
            r["label"] =
               ISavable.Save(label, false, (string)this.id!, relativeUris);
        }
                
        if (this.default_ != null)
        {
            r["default"] =
               ISavable.Save(default_, false, (string)this.id!, relativeUris);
        }
                
        if (this.valueFrom != null)
        {
            r["valueFrom"] =
               ISavable.Save(valueFrom, false, (string)this.id!, relativeUris);
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

            
    static readonly HashSet<string> attr = new() { "id", "source", "linkMerge", "pickValue", "loadContents", "loadListing", "label", "default", "valueFrom" };
}

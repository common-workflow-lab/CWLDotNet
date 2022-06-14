using System.Collections;

namespace CWLDotNet;

/// <summary>
/// Auto-generated class implementation for https://w3id.org/cwl/cwl#ResourceRequirement
///
/// Specify basic hardware resource requirements.
/// 
/// "min" is the minimum amount of a resource that must be reserved to
/// schedule a job. If "min" cannot be satisfied, the job should not
/// be run.
/// 
/// "max" is the maximum amount of a resource that the job shall be
/// allocated. If a node has sufficient resources, multiple jobs may
/// be scheduled on a single node provided each job's "max" resource
/// requirements are met. If a job attempts to exceed its resource
/// allocation, an implementation may deny additional resources, which
/// may result in job failure.
/// 
/// If both "min" and "max" are specified, an implementation may
/// choose to allocate any amount between "min" and "max", with the
/// actual allocation provided in the `runtime` object.
/// 
/// If "min" is specified but "max" is not, then "max" == "min"
/// If "max" is specified by "min" is not, then "min" == "max".
/// 
/// It is an error if max < min.
/// 
/// It is an error if the value of any of these fields is negative.
/// 
/// If neither "min" nor "max" is specified for a resource, use the default values below.
/// 
/// </summary>
public class ResourceRequirement : IResourceRequirement, ISavable {
    readonly LoadingOptions loadingOptions;

    readonly Dictionary<object, object> extensionFields;

    /// <summary>
    /// Always 'ResourceRequirement'
    /// </summary>
    public ResourceRequirement_class class_ { get; set; }

    /// <summary>
    /// Minimum reserved number of CPU cores (default is 1).
    /// 
    /// May be a fractional value to indicate to a scheduling
    /// algorithm that one core can be allocated to multiple
    /// jobs. For example, a value of 0.25 indicates that up to 4
    /// jobs may run in parallel on 1 core.  A value of 1.25 means
    /// that up to 3 jobs can run on a 4 core system (4/1.25 ≈ 3).
    /// 
    /// Processes can only share a core allocation if the sum of each
    /// of their `ramMax`, `tmpdirMax`, and `outdirMax` requests also
    /// do not exceed the capacity of the node.
    /// 
    /// Processes sharing a core must have the same level of isolation
    /// (typically a container or VM) that they would normally.
    /// 
    /// The reported number of CPU cores reserved for the process,
    /// which is available to expressions on the CommandLineTool as
    /// `runtime.cores`, must be a non-zero integer, and may be
    /// calculated by rounding up the cores request to the next whole
    /// number.
    /// 
    /// Scheduling systems may allocate fractional CPU resources by
    /// setting quotas or scheduling weights.  Scheduling systems that
    /// do not support fractional CPUs may round up the request to the
    /// next whole number.
    /// 
    /// </summary>
    public object coresMin { get; set; }

    /// <summary>
    /// Maximum reserved number of CPU cores.
    /// 
    /// See `coresMin` for discussion about fractional CPU requests.
    /// 
    /// </summary>
    public object coresMax { get; set; }

    /// <summary>
    /// Minimum reserved RAM in mebibytes (2**20) (default is 256)
    /// 
    /// May be a fractional value.  If so, the actual RAM request must
    /// be rounded up to the next whole number.  The reported amount of
    /// RAM reserved for the process, which is available to
    /// expressions on the CommandLineTool as `runtime.ram`, must be a
    /// non-zero integer.
    /// 
    /// </summary>
    public object ramMin { get; set; }

    /// <summary>
    /// Maximum reserved RAM in mebibytes (2**20)
    /// 
    /// See `ramMin` for discussion about fractional RAM requests.
    /// 
    /// </summary>
    public object ramMax { get; set; }

    /// <summary>
    /// Minimum reserved filesystem based storage for the designated temporary directory, in mebibytes (2**20) (default is 1024)
    /// 
    /// May be a fractional value.  If so, the actual storage request
    /// must be rounded up to the next whole number.  The reported
    /// amount of storage reserved for the process, which is available
    /// to expressions on the CommandLineTool as `runtime.tmpdirSize`,
    /// must be a non-zero integer.
    /// 
    /// </summary>
    public object tmpdirMin { get; set; }

    /// <summary>
    /// Maximum reserved filesystem based storage for the designated temporary directory, in mebibytes (2**20)
    /// 
    /// See `tmpdirMin` for discussion about fractional storage requests.
    /// 
    /// </summary>
    public object tmpdirMax { get; set; }

    /// <summary>
    /// Minimum reserved filesystem based storage for the designated output directory, in mebibytes (2**20) (default is 1024)
    /// 
    /// May be a fractional value.  If so, the actual storage request
    /// must be rounded up to the next whole number.  The reported
    /// amount of storage reserved for the process, which is available
    /// to expressions on the CommandLineTool as `runtime.outdirSize`,
    /// must be a non-zero integer.
    /// 
    /// </summary>
    public object outdirMin { get; set; }

    /// <summary>
    /// Maximum reserved filesystem based storage for the designated output directory, in mebibytes (2**20)
    /// 
    /// See `outdirMin` for discussion about fractional storage requests.
    /// 
    /// </summary>
    public object outdirMax { get; set; }


    public ResourceRequirement (ResourceRequirement_class class_,object coresMin,object coresMax,object ramMin,object ramMax,object tmpdirMin,object tmpdirMax,object outdirMin,object outdirMax,LoadingOptions? loadingOptions = null, Dictionary<object, object>? extensionFields = null) {
        this.loadingOptions = loadingOptions ?? new LoadingOptions();
        this.extensionFields = extensionFields ?? new Dictionary<object, object>();
        this.class_ = class_;
        this.coresMin = coresMin;
        this.coresMax = coresMax;
        this.ramMin = ramMin;
        this.ramMax = ramMax;
        this.tmpdirMin = tmpdirMin;
        this.tmpdirMax = tmpdirMax;
        this.outdirMin = outdirMin;
        this.outdirMax = outdirMax;
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
            
        ResourceRequirement_class class_ = default!;
        try
        {
            class_ = (ResourceRequirement_class)LoaderInstances.uriResourceRequirement_classLoaderFalseTrueNone
               .LoadField(doc_.GetValueOrDefault("class", null!), baseUri,
                   loadingOptions);
        }
        catch (ValidationException e)
        {
            errors.Add(
              new ValidationException("the `class` field is not valid because: ", e)
            );
        }

        object coresMin = default!;
        if (doc_.ContainsKey("coresMin"))
        {
            try
            {
                coresMin = (object)LoaderInstances.union_of_NullInstance_or_IntegerInstance_or_LongInstance_or_DoubleInstance_or_ExpressionLoader
                   .LoadField(doc_.GetValueOrDefault("coresMin", null!), baseUri,
                       loadingOptions);
            }
            catch (ValidationException e)
            {
                errors.Add(
                  new ValidationException("the `coresMin` field is not valid because: ", e)
                );
            }
        }

        object coresMax = default!;
        if (doc_.ContainsKey("coresMax"))
        {
            try
            {
                coresMax = (object)LoaderInstances.union_of_NullInstance_or_IntegerInstance_or_LongInstance_or_DoubleInstance_or_ExpressionLoader
                   .LoadField(doc_.GetValueOrDefault("coresMax", null!), baseUri,
                       loadingOptions);
            }
            catch (ValidationException e)
            {
                errors.Add(
                  new ValidationException("the `coresMax` field is not valid because: ", e)
                );
            }
        }

        object ramMin = default!;
        if (doc_.ContainsKey("ramMin"))
        {
            try
            {
                ramMin = (object)LoaderInstances.union_of_NullInstance_or_IntegerInstance_or_LongInstance_or_DoubleInstance_or_ExpressionLoader
                   .LoadField(doc_.GetValueOrDefault("ramMin", null!), baseUri,
                       loadingOptions);
            }
            catch (ValidationException e)
            {
                errors.Add(
                  new ValidationException("the `ramMin` field is not valid because: ", e)
                );
            }
        }

        object ramMax = default!;
        if (doc_.ContainsKey("ramMax"))
        {
            try
            {
                ramMax = (object)LoaderInstances.union_of_NullInstance_or_IntegerInstance_or_LongInstance_or_DoubleInstance_or_ExpressionLoader
                   .LoadField(doc_.GetValueOrDefault("ramMax", null!), baseUri,
                       loadingOptions);
            }
            catch (ValidationException e)
            {
                errors.Add(
                  new ValidationException("the `ramMax` field is not valid because: ", e)
                );
            }
        }

        object tmpdirMin = default!;
        if (doc_.ContainsKey("tmpdirMin"))
        {
            try
            {
                tmpdirMin = (object)LoaderInstances.union_of_NullInstance_or_IntegerInstance_or_LongInstance_or_DoubleInstance_or_ExpressionLoader
                   .LoadField(doc_.GetValueOrDefault("tmpdirMin", null!), baseUri,
                       loadingOptions);
            }
            catch (ValidationException e)
            {
                errors.Add(
                  new ValidationException("the `tmpdirMin` field is not valid because: ", e)
                );
            }
        }

        object tmpdirMax = default!;
        if (doc_.ContainsKey("tmpdirMax"))
        {
            try
            {
                tmpdirMax = (object)LoaderInstances.union_of_NullInstance_or_IntegerInstance_or_LongInstance_or_DoubleInstance_or_ExpressionLoader
                   .LoadField(doc_.GetValueOrDefault("tmpdirMax", null!), baseUri,
                       loadingOptions);
            }
            catch (ValidationException e)
            {
                errors.Add(
                  new ValidationException("the `tmpdirMax` field is not valid because: ", e)
                );
            }
        }

        object outdirMin = default!;
        if (doc_.ContainsKey("outdirMin"))
        {
            try
            {
                outdirMin = (object)LoaderInstances.union_of_NullInstance_or_IntegerInstance_or_LongInstance_or_DoubleInstance_or_ExpressionLoader
                   .LoadField(doc_.GetValueOrDefault("outdirMin", null!), baseUri,
                       loadingOptions);
            }
            catch (ValidationException e)
            {
                errors.Add(
                  new ValidationException("the `outdirMin` field is not valid because: ", e)
                );
            }
        }

        object outdirMax = default!;
        if (doc_.ContainsKey("outdirMax"))
        {
            try
            {
                outdirMax = (object)LoaderInstances.union_of_NullInstance_or_IntegerInstance_or_LongInstance_or_DoubleInstance_or_ExpressionLoader
                   .LoadField(doc_.GetValueOrDefault("outdirMax", null!), baseUri,
                       loadingOptions);
            }
            catch (ValidationException e)
            {
                errors.Add(
                  new ValidationException("the `outdirMax` field is not valid because: ", e)
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
                        "expected one of `class`, `coresMin`, `coresMax`, `ramMin`, `ramMax`, `tmpdirMin`, `tmpdirMax`, `outdirMin`, `outdirMax`"));
                    break;
                }
            }

        }

        if (errors.Count > 0)
        {
            throw new ValidationException("", errors);
        }

        return new ResourceRequirement(
          class_: class_,
          coresMin: coresMin,
          coresMax: coresMax,
          ramMin: ramMin,
          ramMax: ramMax,
          tmpdirMin: tmpdirMin,
          tmpdirMax: tmpdirMax,
          outdirMin: outdirMin,
          outdirMax: outdirMax,
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

        if (this.coresMin != null)
        {
            r["coresMin"] =
               ISavable.Save(coresMin, false, (string)baseUrl!, relativeUris);
        }
                
        if (this.coresMax != null)
        {
            r["coresMax"] =
               ISavable.Save(coresMax, false, (string)baseUrl!, relativeUris);
        }
                
        if (this.ramMin != null)
        {
            r["ramMin"] =
               ISavable.Save(ramMin, false, (string)baseUrl!, relativeUris);
        }
                
        if (this.ramMax != null)
        {
            r["ramMax"] =
               ISavable.Save(ramMax, false, (string)baseUrl!, relativeUris);
        }
                
        if (this.tmpdirMin != null)
        {
            r["tmpdirMin"] =
               ISavable.Save(tmpdirMin, false, (string)baseUrl!, relativeUris);
        }
                
        if (this.tmpdirMax != null)
        {
            r["tmpdirMax"] =
               ISavable.Save(tmpdirMax, false, (string)baseUrl!, relativeUris);
        }
                
        if (this.outdirMin != null)
        {
            r["outdirMin"] =
               ISavable.Save(outdirMin, false, (string)baseUrl!, relativeUris);
        }
                
        if (this.outdirMax != null)
        {
            r["outdirMax"] =
               ISavable.Save(outdirMax, false, (string)baseUrl!, relativeUris);
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

            
    static readonly HashSet<string> attr = new() { "class", "coresMin", "coresMax", "ramMin", "ramMax", "tmpdirMin", "tmpdirMax", "outdirMin", "outdirMax" };
}

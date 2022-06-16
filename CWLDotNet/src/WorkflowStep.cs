using System.Collections;
using LanguageExt;

namespace CWLDotNet;

/// <summary>
/// Auto-generated class implementation for https://w3id.org/cwl/cwl#WorkflowStep
///
/// A workflow step is an executable element of a workflow.  It specifies the
/// underlying process implementation (such as `CommandLineTool` or another
/// `Workflow`) in the `run` field and connects the input and output parameters
/// of the underlying process to workflow parameters.
/// 
/// # Scatter/gather
/// 
/// To use scatter/gather,
/// [ScatterFeatureRequirement](#ScatterFeatureRequirement) must be specified
/// in the workflow or workflow step requirements.
/// 
/// A "scatter" operation specifies that the associated workflow step or
/// subworkflow should execute separately over a list of input elements.  Each
/// job making up a scatter operation is independent and may be executed
/// concurrently.
/// 
/// The `scatter` field specifies one or more input parameters which will be
/// scattered.  An input parameter may be listed more than once.  The declared
/// type of each input parameter is implicitly becomes an array of items of the
/// input parameter type.  If a parameter is listed more than once, it becomes
/// a nested array.  As a result, upstream parameters which are connected to
/// scattered parameters must be arrays.
/// 
/// All output parameter types are also implicitly wrapped in arrays.  Each job
/// in the scatter results in an entry in the output array.
/// 
/// If any scattered parameter runtime value is an empty array, all outputs are
/// set to empty arrays and no work is done for the step, according to
/// applicable scattering rules.
/// 
/// If `scatter` declares more than one input parameter, `scatterMethod`
/// describes how to decompose the input into a discrete set of jobs.
/// 
///   * **dotproduct** specifies that each of the input arrays are aligned and one
///       element taken from each array to construct each job.  It is an error
///       if all input arrays are not the same length.
/// 
///   * **nested_crossproduct** specifies the Cartesian product of the inputs,
///       producing a job for every combination of the scattered inputs.  The
///       output must be nested arrays for each level of scattering, in the
///       order that the input arrays are listed in the `scatter` field.
/// 
///   * **flat_crossproduct** specifies the Cartesian product of the inputs,
///       producing a job for every combination of the scattered inputs.  The
///       output arrays must be flattened to a single level, but otherwise listed in the
///       order that the input arrays are listed in the `scatter` field.
/// 
/// # Conditional execution (Optional)
/// 
/// Conditional execution makes execution of a step conditional on an
/// expression.  A step that is not executed is "skipped".  A skipped
/// step produces `null` for all output parameters.
/// 
/// The condition is evaluated after `scatter`, using the input object
/// of each individual scatter job.  This means over a set of scatter
/// jobs, some may be executed and some may be skipped.  When the
/// results are gathered, skipped steps must be `null` in the output
/// arrays.
/// 
/// The `when` field controls conditional execution.  This is an
/// expression that must be evaluated with `inputs` bound to the step
/// input object (or individual scatter job), and returns a boolean
/// value.  It is an error if this expression returns a value other
/// than `true` or `false`.
/// 
/// Conditionals in CWL are an optional feature and are not required
/// to be implemented by all consumers of CWL documents.  An
/// implementation that does not support conditionals must return a
/// fatal error when attempting execute a workflow that uses
/// conditional constructs the implementation does not support.
/// 
/// # Subworkflows
/// 
/// To specify a nested workflow as part of a workflow step,
/// [SubworkflowFeatureRequirement](#SubworkflowFeatureRequirement) must be
/// specified in the workflow or workflow step requirements.
/// 
/// It is a fatal error if a workflow directly or indirectly invokes itself as
/// a subworkflow (recursive workflows are not allowed).
/// 
/// </summary>
public class WorkflowStep : IWorkflowStep, ISavable {
    readonly LoadingOptions loadingOptions;

    readonly Dictionary<object, object> extensionFields;

    /// <summary>
    /// The unique identifier for this object.
    /// </summary>
    public Option<string> id { get; set; }

    /// <summary>
    /// A short, human-readable label of this object.
    /// </summary>
    public Option<string> label { get; set; }

    /// <summary>
    /// A documentation string for this object, or an array of strings which should be concatenated.
    /// </summary>
    public object doc { get; set; }

    /// <summary>
    /// Defines the input parameters of the workflow step.  The process is ready to
    /// run when all required input parameters are associated with concrete
    /// values.  Input parameters include a schema for each parameter which is
    /// used to validate the input object.  It may also be used build a user
    /// interface for constructing the input object.
    /// 
    /// </summary>
    public List<object> in_ { get; set; }

    /// <summary>
    /// Defines the parameters representing the output of the process.  May be
    /// used to generate and/or validate the output object.
    /// 
    /// </summary>
    public List<object> out_ { get; set; }

    /// <summary>
    /// Declares requirements that apply to either the runtime environment or the
    /// workflow engine that must be met in order to execute this workflow step.  If
    /// an implementation cannot satisfy all requirements, or a requirement is
    /// listed which is not recognized by the implementation, it is a fatal
    /// error and the implementation must not attempt to run the process,
    /// unless overridden at user option.
    /// 
    /// </summary>
    public Option<List<object>> requirements { get; set; }

    /// <summary>
    /// Declares hints applying to either the runtime environment or the
    /// workflow engine that may be helpful in executing this workflow step.  It is
    /// not an error if an implementation cannot satisfy all hints, however
    /// the implementation may report a warning.
    /// 
    /// </summary>
    public Option<List<object>> hints { get; set; }

    /// <summary>
    /// Specifies the process to run.  If `run` is a string, it must be an absolute IRI
    /// or a relative path from the primary document.
    /// 
    /// </summary>
    public object run { get; set; }

    /// <summary>
    /// If defined, only run the step when the expression evaluates to
    /// `true`.  If `false` the step is skipped.  A skipped step
    /// produces a `null` on each output.
    /// 
    /// </summary>
    public Option<string> when { get; set; }
    public object scatter { get; set; }

    /// <summary>
    /// Required if `scatter` is an array of more than one element.
    /// 
    /// </summary>
    public Option<ScatterMethod> scatterMethod { get; set; }


    public WorkflowStep (Option<string> id,Option<string> label,object doc,List<object> in_,List<object> out_,Option<List<object>> requirements,Option<List<object>> hints,object run,Option<string> when,object scatter,Option<ScatterMethod> scatterMethod,LoadingOptions? loadingOptions = null, Dictionary<object, object>? extensionFields = null) {
        this.loadingOptions = loadingOptions ?? new LoadingOptions();
        this.extensionFields = extensionFields ?? new Dictionary<object, object>();
        this.id = id;
        this.label = label;
        this.doc = doc;
        this.in_ = in_;
        this.out_ = out_;
        this.requirements = requirements;
        this.hints = hints;
        this.run = run;
        this.when = when;
        this.scatter = scatter;
        this.scatterMethod = scatterMethod;
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
            
        Option<string> id = default!;
        if (doc_.ContainsKey("id"))
        {
            try
            {
                id = (Option<string>)LoaderInstances.urioptional_StringInstanceTrueFalseNone
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
            
        Option<string> label = default!;
        if (doc_.ContainsKey("label"))
        {
            try
            {
                label = (Option<string>)LoaderInstances.optional_StringInstance
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

        object doc = default!;
        if (doc_.ContainsKey("doc"))
        {
            try
            {
                doc = (object)LoaderInstances.union_of_NullInstance_or_StringInstance_or_array_of_StringInstance
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

        List<object> in_ = default!;
        try
        {
            in_ = (List<object>)LoaderInstances.idmapin_array_of_WorkflowStepInputLoader
               .LoadField(doc_.GetValueOrDefault("in", null!), baseUri,
                   loadingOptions);
        }
        catch (ValidationException e)
        {
            errors.Add(
              new ValidationException("the `in` field is not valid because: ", e)
            );
        }

        List<object> out_ = default!;
        try
        {
            out_ = (List<object>)LoaderInstances.uriarray_of_union_of_StringInstance_or_WorkflowStepOutputLoaderTrueFalseNone
               .LoadField(doc_.GetValueOrDefault("out", null!), baseUri,
                   loadingOptions);
        }
        catch (ValidationException e)
        {
            errors.Add(
              new ValidationException("the `out` field is not valid because: ", e)
            );
        }

        Option<List<object>> requirements = default!;
        if (doc_.ContainsKey("requirements"))
        {
            try
            {
                requirements = (Option<List<object>>)LoaderInstances.idmaprequirementsoptional_array_of_union_of_InlineJavascriptRequirementLoader_or_SchemaDefRequirementLoader_or_LoadListingRequirementLoader_or_DockerRequirementLoader_or_SoftwareRequirementLoader_or_InitialWorkDirRequirementLoader_or_EnvVarRequirementLoader_or_ShellCommandRequirementLoader_or_ResourceRequirementLoader_or_WorkReuseLoader_or_NetworkAccessLoader_or_InplaceUpdateRequirementLoader_or_ToolTimeLimitLoader_or_SubworkflowFeatureRequirementLoader_or_ScatterFeatureRequirementLoader_or_MultipleInputFeatureRequirementLoader_or_StepInputExpressionRequirementLoader
                   .LoadField(doc_.GetValueOrDefault("requirements", null!), baseUri,
                       loadingOptions);
            }
            catch (ValidationException e)
            {
                errors.Add(
                  new ValidationException("the `requirements` field is not valid because: ", e)
                );
            }
        }

        Option<List<object>> hints = default!;
        if (doc_.ContainsKey("hints"))
        {
            try
            {
                hints = (Option<List<object>>)LoaderInstances.idmaphintsoptional_array_of_AnyInstance
                   .LoadField(doc_.GetValueOrDefault("hints", null!), baseUri,
                       loadingOptions);
            }
            catch (ValidationException e)
            {
                errors.Add(
                  new ValidationException("the `hints` field is not valid because: ", e)
                );
            }
        }

        object run = default!;
        try
        {
            run = (object)LoaderInstances.union_of_StringInstance_or_CommandLineToolLoader_or_ExpressionToolLoader_or_WorkflowLoader_or_OperationLoader
               .LoadField(doc_.GetValueOrDefault("run", null!), baseUri,
                   loadingOptions);
        }
        catch (ValidationException e)
        {
            errors.Add(
              new ValidationException("the `run` field is not valid because: ", e)
            );
        }

        Option<string> when = default!;
        if (doc_.ContainsKey("when"))
        {
            try
            {
                when = (Option<string>)LoaderInstances.optional_ExpressionLoader
                   .LoadField(doc_.GetValueOrDefault("when", null!), baseUri,
                       loadingOptions);
            }
            catch (ValidationException e)
            {
                errors.Add(
                  new ValidationException("the `when` field is not valid because: ", e)
                );
            }
        }

        object scatter = default!;
        if (doc_.ContainsKey("scatter"))
        {
            try
            {
                scatter = (object)LoaderInstances.uriunion_of_NullInstance_or_StringInstance_or_array_of_StringInstanceFalseFalse0
                   .LoadField(doc_.GetValueOrDefault("scatter", null!), baseUri,
                       loadingOptions);
            }
            catch (ValidationException e)
            {
                errors.Add(
                  new ValidationException("the `scatter` field is not valid because: ", e)
                );
            }
        }

        Option<ScatterMethod> scatterMethod = default!;
        if (doc_.ContainsKey("scatterMethod"))
        {
            try
            {
                scatterMethod = (Option<ScatterMethod>)LoaderInstances.urioptional_ScatterMethodLoaderFalseTrueNone
                   .LoadField(doc_.GetValueOrDefault("scatterMethod", null!), baseUri,
                       loadingOptions);
            }
            catch (ValidationException e)
            {
                errors.Add(
                  new ValidationException("the `scatterMethod` field is not valid because: ", e)
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
                        "expected one of `id`, `label`, `doc`, `in`, `out`, `requirements`, `hints`, `run`, `when`, `scatter`, `scatterMethod`"));
                    break;
                }
            }

        }

        if (errors.Count > 0)
        {
            throw new ValidationException("", errors);
        }

        return new WorkflowStep(
          id: id,
          label: label,
          doc: doc,
          in_: in_,
          out_: out_,
          requirements: requirements,
          hints: hints,
          run: run,
          when: when,
          scatter: scatter,
          scatterMethod: scatterMethod,
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

        id.IfSome(id =>
        {
            r["id"] = ISavable.SaveRelativeUri(id, true,
                                      relativeUris, null, (string)baseUrl!);
        });
                    
        label.IfSome(label =>
        {
            r["label"] =
               ISavable.Save(label, false, (string)this.id!, relativeUris);
        });
                    
        if(doc != null)
        {
            r["doc"] =
               ISavable.Save(doc, false, (string)this.id!, relativeUris);
        }
                    
        r["in"] =
           ISavable.Save(in_, false, (string)this.id!, relativeUris);
        r["out"] = ISavable.SaveRelativeUri(out_, true,
                                  relativeUris, null, (string)this.id!);
        requirements.IfSome(requirements =>
        {
            r["requirements"] =
               ISavable.Save(requirements, false, (string)this.id!, relativeUris);
        });
                    
        hints.IfSome(hints =>
        {
            r["hints"] =
               ISavable.Save(hints, false, (string)this.id!, relativeUris);
        });
                    
        r["run"] =
           ISavable.Save(run, false, (string)this.id!, relativeUris);
        when.IfSome(when =>
        {
            r["when"] =
               ISavable.Save(when, false, (string)this.id!, relativeUris);
        });
                    
        if(scatter != null)
        {
            r["scatter"] = ISavable.SaveRelativeUri(scatter, false,
                                      relativeUris, 0, (string)this.id!);
        }
                    
        scatterMethod.IfSome(scatterMethod =>
        {
            r["scatterMethod"] = ISavable.SaveRelativeUri(scatterMethod, false,
                                      relativeUris, null, (string)this.id!);
        });
                    
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

            
    static readonly System.Collections.Generic.HashSet<string>attr = new() { "id", "label", "doc", "in", "out", "requirements", "hints", "run", "when", "scatter", "scatterMethod" };
}

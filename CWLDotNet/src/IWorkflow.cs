using LanguageExt;

namespace CWLDotNet;

/// <summary>
/// Auto-generated interface for https://w3id.org/cwl/cwl#Workflow
///
/// A workflow describes a set of **steps** and the **dependencies** between
/// those steps.  When a step produces output that will be consumed by a
/// second step, the first step is a dependency of the second step.
/// 
/// When there is a dependency, the workflow engine must execute the preceding
/// step and wait for it to successfully produce output before executing the
/// dependent step.  If two steps are defined in the workflow graph that
/// are not directly or indirectly dependent, these steps are **independent**,
/// and may execute in any order or execute concurrently.  A workflow is
/// complete when all steps have been executed.
/// 
/// Dependencies between parameters are expressed using the `source`
/// field on [workflow step input parameters](#WorkflowStepInput) and
/// `outputSource` field on [workflow output
/// parameters](#WorkflowOutputParameter).
/// 
/// The `source` field on each workflow step input parameter expresses
/// the data links that contribute to the value of the step input
/// parameter (the "sink").  A workflow step can only begin execution
/// when every data link connected to a step has been fulfilled.
/// 
/// The `outputSource` field on each workflow step input parameter
/// expresses the data links that contribute to the value of the
/// workflow output parameter (the "sink").  Workflow execution cannot
/// complete successfully until every data link connected to an output
/// parameter has been fulfilled.
/// 
/// ## Workflow success and failure
/// 
/// A completed step must result in one of `success`, `temporaryFailure` or
/// `permanentFailure` states.  An implementation may choose to retry a step
/// execution which resulted in `temporaryFailure`.  An implementation may
/// choose to either continue running other steps of a workflow, or terminate
/// immediately upon `permanentFailure`.
/// 
/// * If any step of a workflow execution results in `permanentFailure`, then
/// the workflow status is `permanentFailure`.
/// 
/// * If one or more steps result in `temporaryFailure` and all other steps
/// complete `success` or are not executed, then the workflow status is
/// `temporaryFailure`.
/// 
/// * If all workflow steps are executed and complete with `success`, then the
/// workflow status is `success`.
/// 
/// # Extensions
/// 
/// [ScatterFeatureRequirement](#ScatterFeatureRequirement) and
/// [SubworkflowFeatureRequirement](#SubworkflowFeatureRequirement) are
/// available as standard [extensions](#Extensions_and_Metadata) to core
/// workflow semantics.
/// 
/// </summary>
public interface IWorkflow : IProcess {

    /// <summary>
    /// The unique identifier for this object.
    /// </summary>
    public Option<string> id { get; set; }
    public new Workflow_class class_ { get; set; }

    /// <summary>
    /// A short, human-readable label of this object.
    /// </summary>
    public Option<string> label { get; set; }

    /// <summary>
    /// A documentation string for this object, or an array of strings which should be concatenated.
    /// </summary>
    public object doc { get; set; }

    /// <summary>
    /// Defines the input parameters of the process.  The process is ready to
    /// run when all required input parameters are associated with concrete
    /// values.  Input parameters include a schema for each parameter which is
    /// used to validate the input object.  It may also be used to build a user
    /// interface for constructing the input object.
    /// 
    /// When accepting an input object, all input parameters must have a value.
    /// If an input parameter is missing from the input object, it must be
    /// assigned a value of `null` (or the value of `default` for that
    /// parameter, if provided) for the purposes of validation and evaluation
    /// of expressions.
    /// 
    /// </summary>
    public List<object> inputs { get; set; }

    /// <summary>
    /// Defines the parameters representing the output of the process.  May be
    /// used to generate and/or validate the output object.
    /// 
    /// </summary>
    public List<object> outputs { get; set; }

    /// <summary>
    /// Declares requirements that apply to either the runtime environment or the
    /// workflow engine that must be met in order to execute this process.  If
    /// an implementation cannot satisfy all requirements, or a requirement is
    /// listed which is not recognized by the implementation, it is a fatal
    /// error and the implementation must not attempt to run the process,
    /// unless overridden at user option.
    /// 
    /// </summary>
    public Option<List<object>> requirements { get; set; }

    /// <summary>
    /// Declares hints applying to either the runtime environment or the
    /// workflow engine that may be helpful in executing this process.  It is
    /// not an error if an implementation cannot satisfy all hints, however
    /// the implementation may report a warning.
    /// 
    /// </summary>
    public Option<List<object>> hints { get; set; }

    /// <summary>
    /// CWL document version. Always required at the document root. Not
    /// required for a Process embedded inside another Process.
    /// 
    /// </summary>
    public Option<CWLVersion> cwlVersion { get; set; }

    /// <summary>
    /// An identifier for the type of computational operation, of this Process.
    /// Especially useful for "class: Operation", but can also be used for
    /// CommandLineTool, Workflow, or ExpressionTool.
    /// 
    /// If provided, then this must be an IRI of a concept node that
    /// represents the type of operation, preferrably defined within an ontology.
    /// 
    /// For example, in the domain of bioinformatics, one can use an IRI from
    /// the EDAM Ontology's [Operation concept nodes](http://edamontology.org/operation_0004),
    /// like [Alignment](http://edamontology.org/operation_2928),
    /// or [Clustering](http://edamontology.org/operation_3432); or a more
    /// specific Operation concept like
    /// [Split read mapping](http://edamontology.org/operation_3199).
    /// 
    /// </summary>
    public Option<List<string>> intent { get; set; }

    /// <summary>
    /// The individual steps that make up the workflow.  Each step is executed when all of its
    /// input data links are fufilled.  An implementation may choose to execute
    /// the steps in a different order than listed and/or execute steps
    /// concurrently, provided that dependencies between steps are met.
    /// 
    /// </summary>
    public List<object> steps { get; set; }
}
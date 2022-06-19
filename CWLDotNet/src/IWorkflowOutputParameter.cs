#pragma warning disable CS0108
namespace CWLDotNet;

/// <summary>
/// Auto-generated interface for https://w3id.org/cwl/cwl#WorkflowOutputParameter
///
/// Describe an output parameter of a workflow.  The parameter must be
/// connected to one or more parameters defined in the workflow that
/// will provide the value of the output parameter. It is legal to
/// connect a WorkflowInputParameter to a WorkflowOutputParameter.
/// 
/// See [WorkflowStepInput](#WorkflowStepInput) for discussion of
/// `linkMerge` and `pickValue`.
/// 
/// </summary>
public interface IWorkflowOutputParameter : IOutputParameter {
}
using LanguageExt;

namespace CWLDotNet;

/// <summary>
/// Auto-generated interface for https://w3id.org/cwl/cwl#StepInputExpressionRequirement
///
/// Indicate that the workflow platform must support the `valueFrom` field
/// of [WorkflowStepInput](#WorkflowStepInput).
/// 
/// </summary>
public interface IStepInputExpressionRequirement : IProcessRequirement {

    /// <summary>
    /// Always 'StepInputExpressionRequirement'
    /// </summary>
    public new StepInputExpressionRequirement_class class_ { get; set; }
}
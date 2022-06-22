#pragma warning disable CS0108
namespace CWLDotNet;

/// <summary>
/// Auto-generated interface for https://w3id.org/cwl/cwl#Operation
///
/// This record describes an abstract operation.  It is a potential
/// step of a workflow that has not yet been bound to a concrete
/// implementation.  It specifies an input and output signature, but
/// does not provide enough information to be executed.  An
/// implementation (or other tooling) may provide a means of binding
/// an Operation to a concrete process (such as Workflow,
/// CommandLineTool, or ExpressionTool) with a compatible signature.
/// 
/// </summary>
public interface IOperation : IProcess
{
}

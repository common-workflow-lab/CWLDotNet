#pragma warning disable CS0108
namespace CWLDotNet;

/// <summary>
/// Auto-generated interface for https://w3id.org/cwl/cwl#CommandOutputBinding
///
/// Describes how to generate an output parameter based on the files produced
/// by a CommandLineTool.
/// 
/// The output parameter value is generated by applying these operations in the
/// following order:
/// 
///   - glob
///   - loadContents
///   - outputEval
///   - secondaryFiles
/// 
/// </summary>
public interface ICommandOutputBinding : ILoadContents
{
}

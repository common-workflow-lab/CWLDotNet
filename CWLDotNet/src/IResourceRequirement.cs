using LanguageExt;

namespace CWLDotNet;

/// <summary>
/// Auto-generated interface for https://w3id.org/cwl/cwl#ResourceRequirement
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
public interface IResourceRequirement : IProcessRequirement {

    /// <summary>
    /// Always 'ResourceRequirement'
    /// </summary>
    public new ResourceRequirement_class class_ { get; set; }

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
}
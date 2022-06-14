using System.Collections;

namespace CWLDotNet;

/// <summary>
/// Auto-generated class implementation for https://w3id.org/cwl/cwl#DockerRequirement
///
/// Indicates that a workflow component should be run in a
/// [Docker](http://docker.com) or Docker-compatible (such as
/// [Singularity](https://www.sylabs.io/) and [udocker](https://github.com/indigo-dc/udocker)) container environment and
/// specifies how to fetch or build the image.
/// 
/// If a CommandLineTool lists `DockerRequirement` under
/// `hints` (or `requirements`), it may (or must) be run in the specified Docker
/// container.
/// 
/// The platform must first acquire or install the correct Docker image as
/// specified by `dockerPull`, `dockerImport`, `dockerLoad` or `dockerFile`.
/// 
/// The platform must execute the tool in the container using `docker run` with
/// the appropriate Docker image and tool command line.
/// 
/// The workflow platform may provide input files and the designated output
/// directory through the use of volume bind mounts.  The platform should rewrite
/// file paths in the input object to correspond to the Docker bind mounted
/// locations. That is, the platform should rewrite values in the parameter context
/// such as `runtime.outdir`, `runtime.tmpdir` and others to be valid paths
/// within the container. The platform must ensure that `runtime.outdir` and
/// `runtime.tmpdir` are distinct directories.
/// 
/// When running a tool contained in Docker, the workflow platform must not
/// assume anything about the contents of the Docker container, such as the
/// presence or absence of specific software, except to assume that the
/// generated command line represents a valid command within the runtime
/// environment of the container.
/// 
/// A container image may specify an
/// [ENTRYPOINT](https://docs.docker.com/engine/reference/builder/#entrypoint)
/// and/or
/// [CMD](https://docs.docker.com/engine/reference/builder/#cmd).
/// Command line arguments will be appended after all elements of
/// ENTRYPOINT, and will override all elements specified using CMD (in
/// other words, CMD is only used when the CommandLineTool definition
/// produces an empty command line).
/// 
/// Use of implicit ENTRYPOINT or CMD are discouraged due to reproducibility
/// concerns of the implicit hidden execution point (For further discussion, see
/// [https://doi.org/10.12688/f1000research.15140.1](https://doi.org/10.12688/f1000research.15140.1)). Portable
/// CommandLineTool wrappers in which use of a container is optional must not rely on ENTRYPOINT or CMD.
/// CommandLineTools which do rely on ENTRYPOINT or CMD must list `DockerRequirement` in the
/// `requirements` section.
/// 
/// ## Interaction with other requirements
/// 
/// If [EnvVarRequirement](#EnvVarRequirement) is specified alongside a
/// DockerRequirement, the environment variables must be provided to Docker
/// using `--env` or `--env-file` and interact with the container's preexisting
/// environment as defined by Docker.
/// 
/// </summary>
public class DockerRequirement : IDockerRequirement, ISavable {
    readonly LoadingOptions loadingOptions;

    readonly Dictionary<object, object> extensionFields;

    /// <summary>
    /// Always 'DockerRequirement'
    /// </summary>
    public DockerRequirement_class class_ { get; set; }

    /// <summary>
    /// Specify a Docker image to retrieve using `docker pull`. Can contain the
    /// immutable digest to ensure an exact container is used:
    /// `dockerPull: ubuntu@sha256:45b23dee08af5e43a7fea6c4cf9c25ccf269ee113168c19722f87876677c5cb2`
    /// 
    /// </summary>
    public object? dockerPull { get; set; }

    /// <summary>
    /// Specify a HTTP URL from which to download a Docker image using `docker load`.
    /// </summary>
    public object? dockerLoad { get; set; }

    /// <summary>
    /// Supply the contents of a Dockerfile which will be built using `docker build`.
    /// </summary>
    public object? dockerFile { get; set; }

    /// <summary>
    /// Provide HTTP URL to download and gunzip a Docker images using `docker import.
    /// </summary>
    public object? dockerImport { get; set; }

    /// <summary>
    /// The image id that will be used for `docker run`.  May be a
    /// human-readable image name or the image identifier hash.  May be skipped
    /// if `dockerPull` is specified, in which case the `dockerPull` image id
    /// must be used.
    /// 
    /// </summary>
    public object? dockerImageId { get; set; }

    /// <summary>
    /// Set the designated output directory to a specific location inside the
    /// Docker container.
    /// 
    /// </summary>
    public object? dockerOutputDirectory { get; set; }


    public DockerRequirement (DockerRequirement_class class_,object dockerPull,object dockerLoad,object dockerFile,object dockerImport,object dockerImageId,object dockerOutputDirectory,LoadingOptions? loadingOptions = null, Dictionary<object, object>? extensionFields = null) {
        this.loadingOptions = loadingOptions ?? new LoadingOptions();
        this.extensionFields = extensionFields ?? new Dictionary<object, object>();
        this.class_ = class_;
        this.dockerPull = dockerPull;
        this.dockerLoad = dockerLoad;
        this.dockerFile = dockerFile;
        this.dockerImport = dockerImport;
        this.dockerImageId = dockerImageId;
        this.dockerOutputDirectory = dockerOutputDirectory;
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
            
        DockerRequirement_class class_ = default!;
        try
        {
            class_ = (DockerRequirement_class)LoaderInstances.uriDockerRequirement_classLoaderFalseTrueNone
               .LoadField(doc_.GetValueOrDefault("class", null!), baseUri,
                   loadingOptions);
        }
        catch (ValidationException e)
        {
            errors.Add(
              new ValidationException("the `class` field is not valid because: ", e)
            );
        }

        object dockerPull = default!;
        if (doc_.ContainsKey("dockerPull"))
        {
            try
            {
                dockerPull = (object)LoaderInstances.optional_StringInstance
                   .LoadField(doc_.GetValueOrDefault("dockerPull", null!), baseUri,
                       loadingOptions);
            }
            catch (ValidationException e)
            {
                errors.Add(
                  new ValidationException("the `dockerPull` field is not valid because: ", e)
                );
            }
        }

        object dockerLoad = default!;
        if (doc_.ContainsKey("dockerLoad"))
        {
            try
            {
                dockerLoad = (object)LoaderInstances.optional_StringInstance
                   .LoadField(doc_.GetValueOrDefault("dockerLoad", null!), baseUri,
                       loadingOptions);
            }
            catch (ValidationException e)
            {
                errors.Add(
                  new ValidationException("the `dockerLoad` field is not valid because: ", e)
                );
            }
        }

        object dockerFile = default!;
        if (doc_.ContainsKey("dockerFile"))
        {
            try
            {
                dockerFile = (object)LoaderInstances.optional_StringInstance
                   .LoadField(doc_.GetValueOrDefault("dockerFile", null!), baseUri,
                       loadingOptions);
            }
            catch (ValidationException e)
            {
                errors.Add(
                  new ValidationException("the `dockerFile` field is not valid because: ", e)
                );
            }
        }

        object dockerImport = default!;
        if (doc_.ContainsKey("dockerImport"))
        {
            try
            {
                dockerImport = (object)LoaderInstances.optional_StringInstance
                   .LoadField(doc_.GetValueOrDefault("dockerImport", null!), baseUri,
                       loadingOptions);
            }
            catch (ValidationException e)
            {
                errors.Add(
                  new ValidationException("the `dockerImport` field is not valid because: ", e)
                );
            }
        }

        object dockerImageId = default!;
        if (doc_.ContainsKey("dockerImageId"))
        {
            try
            {
                dockerImageId = (object)LoaderInstances.optional_StringInstance
                   .LoadField(doc_.GetValueOrDefault("dockerImageId", null!), baseUri,
                       loadingOptions);
            }
            catch (ValidationException e)
            {
                errors.Add(
                  new ValidationException("the `dockerImageId` field is not valid because: ", e)
                );
            }
        }

        object dockerOutputDirectory = default!;
        if (doc_.ContainsKey("dockerOutputDirectory"))
        {
            try
            {
                dockerOutputDirectory = (object)LoaderInstances.optional_StringInstance
                   .LoadField(doc_.GetValueOrDefault("dockerOutputDirectory", null!), baseUri,
                       loadingOptions);
            }
            catch (ValidationException e)
            {
                errors.Add(
                  new ValidationException("the `dockerOutputDirectory` field is not valid because: ", e)
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
                        "expected one of `class`, `dockerPull`, `dockerLoad`, `dockerFile`, `dockerImport`, `dockerImageId`, `dockerOutputDirectory`"));
                    break;
                }
            }

        }

        if (errors.Count > 0)
        {
            throw new ValidationException("", errors);
        }

        return new DockerRequirement(
          class_: class_,
          dockerPull: dockerPull,
          dockerLoad: dockerLoad,
          dockerFile: dockerFile,
          dockerImport: dockerImport,
          dockerImageId: dockerImageId,
          dockerOutputDirectory: dockerOutputDirectory,
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

        if (this.dockerPull != null)
        {
            r["dockerPull"] =
               ISavable.Save(dockerPull, false, (string)baseUrl!, relativeUris);
        }
                
        if (this.dockerLoad != null)
        {
            r["dockerLoad"] =
               ISavable.Save(dockerLoad, false, (string)baseUrl!, relativeUris);
        }
                
        if (this.dockerFile != null)
        {
            r["dockerFile"] =
               ISavable.Save(dockerFile, false, (string)baseUrl!, relativeUris);
        }
                
        if (this.dockerImport != null)
        {
            r["dockerImport"] =
               ISavable.Save(dockerImport, false, (string)baseUrl!, relativeUris);
        }
                
        if (this.dockerImageId != null)
        {
            r["dockerImageId"] =
               ISavable.Save(dockerImageId, false, (string)baseUrl!, relativeUris);
        }
                
        if (this.dockerOutputDirectory != null)
        {
            r["dockerOutputDirectory"] =
               ISavable.Save(dockerOutputDirectory, false, (string)baseUrl!, relativeUris);
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

            
    static readonly HashSet<string> attr = new() { "class", "dockerPull", "dockerLoad", "dockerFile", "dockerImport", "dockerImageId", "dockerOutputDirectory" };
}

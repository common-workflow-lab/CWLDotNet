using System.Collections;

namespace CWLDotNet;

/**
 * Auto-generated class implementation for https://w3id.org/cwl/cwl#SoftwarePackage
 */
public class SoftwarePackage : ISoftwarePackage, ISavable {
    readonly LoadingOptions loadingOptions;

    readonly Dictionary<object, object> extensionFields;

  /**
   * The name of the software to be made available. If the name is
   * common, inconsistent, or otherwise ambiguous it should be combined with
   * one or more identifiers in the `specs` field.
   * 
   */
    public string package_ { get; set; }

  /**
   * The (optional) versions of the software that are known to be
   * compatible.
   * 
   */
    public object? version { get; set; }

  /**
   * One or more [IRI](https://en.wikipedia.org/wiki/Internationalized_Resource_Identifier)s
   * identifying resources for installing or enabling the software named in
   * the `package` field. Implementations may provide resolvers which map
   * these software identifer IRIs to some configuration action; or they can
   * use only the name from the `package` field on a best effort basis.
   * 
   * For example, the IRI https://packages.debian.org/bowtie could
   * be resolved with `apt-get install bowtie`. The IRI
   * https://anaconda.org/bioconda/bowtie could be resolved with `conda
   * install -c bioconda bowtie`.
   * 
   * IRIs can also be system independent and used to map to a specific
   * software installation or selection mechanism.
   * Using [RRID](https://www.identifiers.org/rrid/) as an example:
   * https://identifiers.org/rrid/RRID:SCR_005476
   * could be fulfilled using the above mentioned Debian or bioconda
   * package, a local installation managed by [Environment Modules](http://modules.sourceforge.net/),
   * or any other mechanism the platform chooses. IRIs can also be from
   * identifer sources that are discipline specific yet still system
   * independent. As an example, the equivalent [ELIXIR Tools and Data
   * Service Registry](https://bio.tools) IRI to the previous RRID example is
   * https://bio.tools/tool/bowtie2/version/2.2.8.
   * If supported by a given registry, implementations are encouraged to
   * query these system independent sofware identifier IRIs directly for
   * links to packaging systems.
   * 
   * A site specific IRI can be listed as well. For example, an academic
   * computing cluster using Environment Modules could list the IRI
   * `https://hpc.example.edu/modules/bowtie-tbb/1.22` to indicate that
   * `module load bowtie-tbb/1.1.2` should be executed to make available
   * `bowtie` version 1.1.2 compiled with the TBB library prior to running
   * the accompanying Workflow or CommandLineTool. Note that the example IRI
   * is specific to a particular institution and computing environment as
   * the Environment Modules system does not have a common namespace or
   * standardized naming convention.
   * 
   * This last example is the least portable and should only be used if
   * mechanisms based off of the `package` field or more generic IRIs are
   * unavailable or unsuitable. While harmless to other sites, site specific
   * software IRIs should be left out of shared CWL descriptions to avoid
   * clutter.
   * 
   */
    public object? specs { get; set; }


    public SoftwarePackage (string package_,object version,object specs,LoadingOptions? loadingOptions = null, Dictionary<object, object>? extensionFields = null) {
        this.loadingOptions = loadingOptions ?? new LoadingOptions();
        this.extensionFields = extensionFields ?? new Dictionary<object, object>();
        this.package_ = package_;
        this.version = version;
        this.specs = specs;
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
            
        string package_ = default!;
        try
        {
            package_ = (string)LoaderInstances.StringInstance
               .LoadField(doc_.GetValueOrDefault("package", null!), baseUri,
                   loadingOptions);
        }
        catch (ValidationException e)
        {
            errors.Add(
              new ValidationException("the `package` field is not valid because: ", e)
            );
        }

        object version = default!;
        if (doc_.ContainsKey("version"))
        {
            try
            {
                version = (object)LoaderInstances.optional_array_of_StringInstance
                   .LoadField(doc_.GetValueOrDefault("version", null!), baseUri,
                       loadingOptions);
            }
            catch (ValidationException e)
            {
                errors.Add(
                  new ValidationException("the `version` field is not valid because: ", e)
                );
            }
        }

        object specs = default!;
        if (doc_.ContainsKey("specs"))
        {
            try
            {
                specs = (object)LoaderInstances.urioptional_array_of_StringInstanceFalseFalseNone
                   .LoadField(doc_.GetValueOrDefault("specs", null!), baseUri,
                       loadingOptions);
            }
            catch (ValidationException e)
            {
                errors.Add(
                  new ValidationException("the `specs` field is not valid because: ", e)
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
                        "expected one of `package`, `version`, `specs`"));
                    break;
                }
            }

        }

        if (errors.Count > 0)
        {
            throw new ValidationException("", errors);
        }

        return new SoftwarePackage(
          package_: package_,
          version: version,
          specs: specs,
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

        r["package"] =
           ISavable.Save(package_, false, (string)baseUrl!, relativeUris);
        if (this.version != null)
        {
            r["version"] =
               ISavable.Save(version, false, (string)baseUrl!, relativeUris);
        }
                
        if (this.specs != null)
        {
            r["specs"] = ISavable.SaveRelativeUri(this.specs, false,
                                      relativeUris, null, (string)baseUrl!);

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

            
    static readonly HashSet<string> attr = new() { "package", "version", "specs" };
}

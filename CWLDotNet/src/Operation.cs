using System.Collections;

namespace CWLDotNet;

/// <summary>
/// Auto-generated class implementation for https://w3id.org/cwl/cwl#Operation
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
public class Operation : IOperation, ISavable {
    readonly LoadingOptions loadingOptions;

    readonly Dictionary<object, object> extensionFields;

    /// <summary>
    /// The unique identifier for this object.
    /// </summary>
    public object? id { get; set; }
    public Operation_class class_ { get; set; }

    /// <summary>
    /// A short, human-readable label of this object.
    /// </summary>
    public object? label { get; set; }

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
    public List<OperationInputParameter> inputs { get; set; }

    /// <summary>
    /// Defines the parameters representing the output of the process.  May be
    /// used to generate and/or validate the output object.
    /// 
    /// </summary>
    public List<OperationOutputParameter> outputs { get; set; }

    /// <summary>
    /// Declares requirements that apply to either the runtime environment or the
    /// workflow engine that must be met in order to execute this process.  If
    /// an implementation cannot satisfy all requirements, or a requirement is
    /// listed which is not recognized by the implementation, it is a fatal
    /// error and the implementation must not attempt to run the process,
    /// unless overridden at user option.
    /// 
    /// </summary>
    public object? requirements { get; set; }

    /// <summary>
    /// Declares hints applying to either the runtime environment or the
    /// workflow engine that may be helpful in executing this process.  It is
    /// not an error if an implementation cannot satisfy all hints, however
    /// the implementation may report a warning.
    /// 
    /// </summary>
    public object? hints { get; set; }

    /// <summary>
    /// CWL document version. Always required at the document root. Not
    /// required for a Process embedded inside another Process.
    /// 
    /// </summary>
    public object? cwlVersion { get; set; }

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
    public object? intent { get; set; }


    public Operation (object id,Operation_class class_,object label,object doc,List<OperationInputParameter> inputs,List<OperationOutputParameter> outputs,object requirements,object hints,object cwlVersion,object intent,LoadingOptions? loadingOptions = null, Dictionary<object, object>? extensionFields = null) {
        this.loadingOptions = loadingOptions ?? new LoadingOptions();
        this.extensionFields = extensionFields ?? new Dictionary<object, object>();
        this.id = id;
        this.class_ = class_;
        this.label = label;
        this.doc = doc;
        this.inputs = inputs;
        this.outputs = outputs;
        this.requirements = requirements;
        this.hints = hints;
        this.cwlVersion = cwlVersion;
        this.intent = intent;
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
            
        object id = default!;
        if (doc_.ContainsKey("id"))
        {
            try
            {
                id = (object)LoaderInstances.urioptional_StringInstanceTrueFalseNone
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
            
        Operation_class class_ = default!;
        try
        {
            class_ = (Operation_class)LoaderInstances.uriOperation_classLoaderFalseTrueNone
               .LoadField(doc_.GetValueOrDefault("class", null!), baseUri,
                   loadingOptions);
        }
        catch (ValidationException e)
        {
            errors.Add(
              new ValidationException("the `class` field is not valid because: ", e)
            );
        }

        object label = default!;
        if (doc_.ContainsKey("label"))
        {
            try
            {
                label = (object)LoaderInstances.optional_StringInstance
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

        List<OperationInputParameter> inputs = default!;
        try
        {
            inputs = (List<OperationInputParameter>)LoaderInstances.idmapinputsarray_of_OperationInputParameterLoader
               .LoadField(doc_.GetValueOrDefault("inputs", null!), baseUri,
                   loadingOptions);
        }
        catch (ValidationException e)
        {
            errors.Add(
              new ValidationException("the `inputs` field is not valid because: ", e)
            );
        }

        List<OperationOutputParameter> outputs = default!;
        try
        {
            outputs = (List<OperationOutputParameter>)LoaderInstances.idmapoutputsarray_of_OperationOutputParameterLoader
               .LoadField(doc_.GetValueOrDefault("outputs", null!), baseUri,
                   loadingOptions);
        }
        catch (ValidationException e)
        {
            errors.Add(
              new ValidationException("the `outputs` field is not valid because: ", e)
            );
        }

        object requirements = default!;
        if (doc_.ContainsKey("requirements"))
        {
            try
            {
                requirements = (object)LoaderInstances.idmaprequirementsoptional_array_of_union_of_InlineJavascriptRequirementLoader_or_SchemaDefRequirementLoader_or_LoadListingRequirementLoader_or_DockerRequirementLoader_or_SoftwareRequirementLoader_or_InitialWorkDirRequirementLoader_or_EnvVarRequirementLoader_or_ShellCommandRequirementLoader_or_ResourceRequirementLoader_or_WorkReuseLoader_or_NetworkAccessLoader_or_InplaceUpdateRequirementLoader_or_ToolTimeLimitLoader_or_SubworkflowFeatureRequirementLoader_or_ScatterFeatureRequirementLoader_or_MultipleInputFeatureRequirementLoader_or_StepInputExpressionRequirementLoader
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

        object hints = default!;
        if (doc_.ContainsKey("hints"))
        {
            try
            {
                hints = (object)LoaderInstances.idmaphintsoptional_array_of_AnyInstance
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

        object cwlVersion = default!;
        if (doc_.ContainsKey("cwlVersion"))
        {
            try
            {
                cwlVersion = (object)LoaderInstances.urioptional_CWLVersionLoaderFalseTrueNone
                   .LoadField(doc_.GetValueOrDefault("cwlVersion", null!), baseUri,
                       loadingOptions);
            }
            catch (ValidationException e)
            {
                errors.Add(
                  new ValidationException("the `cwlVersion` field is not valid because: ", e)
                );
            }
        }

        object intent = default!;
        if (doc_.ContainsKey("intent"))
        {
            try
            {
                intent = (object)LoaderInstances.urioptional_array_of_StringInstanceTrueFalseNone
                   .LoadField(doc_.GetValueOrDefault("intent", null!), baseUri,
                       loadingOptions);
            }
            catch (ValidationException e)
            {
                errors.Add(
                  new ValidationException("the `intent` field is not valid because: ", e)
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
                        "expected one of `id`, `label`, `doc`, `inputs`, `outputs`, `requirements`, `hints`, `cwlVersion`, `intent`, `class`"));
                    break;
                }
            }

        }

        if (errors.Count > 0)
        {
            throw new ValidationException("", errors);
        }

        return new Operation(
          id: id,
          label: label,
          doc: doc,
          inputs: inputs,
          outputs: outputs,
          requirements: requirements,
          hints: hints,
          cwlVersion: cwlVersion,
          intent: intent,
          class_: class_,
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

        if (this.id != null)
        {
            r["id"] = ISavable.SaveRelativeUri(this.id, true,
                                      relativeUris, null, (string)baseUrl!);

        }
                
        r["class"] = ISavable.SaveRelativeUri(this.class_, false,
                                  relativeUris, null, (string)this.id!);

        if (this.label != null)
        {
            r["label"] =
               ISavable.Save(label, false, (string)this.id!, relativeUris);
        }
                
        if (this.doc != null)
        {
            r["doc"] =
               ISavable.Save(doc, false, (string)this.id!, relativeUris);
        }
                
        r["inputs"] =
           ISavable.Save(inputs, false, (string)this.id!, relativeUris);
        r["outputs"] =
           ISavable.Save(outputs, false, (string)this.id!, relativeUris);
        if (this.requirements != null)
        {
            r["requirements"] =
               ISavable.Save(requirements, false, (string)this.id!, relativeUris);
        }
                
        if (this.hints != null)
        {
            r["hints"] =
               ISavable.Save(hints, false, (string)this.id!, relativeUris);
        }
                
        if (this.cwlVersion != null)
        {
            r["cwlVersion"] = ISavable.SaveRelativeUri(this.cwlVersion, false,
                                      relativeUris, null, (string)this.id!);

        }
                
        if (this.intent != null)
        {
            r["intent"] = ISavable.SaveRelativeUri(this.intent, true,
                                      relativeUris, null, (string)this.id!);

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

            
    static readonly HashSet<string> attr = new() { "id", "label", "doc", "inputs", "outputs", "requirements", "hints", "cwlVersion", "intent", "class" };
}

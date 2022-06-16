using System.Collections;
using LanguageExt;

namespace CWLDotNet;

/// <summary>
/// Auto-generated class implementation for https://w3id.org/cwl/cwl#ExpressionTool
///
/// An ExpressionTool is a type of Process object that can be run by itself
/// or as a Workflow step. It executes a pure Javascript expression that has
/// access to the same input parameters as a workflow. It is meant to be used
/// sparingly as a way to isolate complex Javascript expressions that need to
/// operate on input data and produce some result; perhaps just a
/// rearrangement of the inputs. No Docker software container is required
/// or allowed.
/// 
/// </summary>
public class ExpressionTool : IExpressionTool, ISavable {
    readonly LoadingOptions loadingOptions;

    readonly Dictionary<object, object> extensionFields;

    /// <summary>
    /// The unique identifier for this object.
    /// </summary>
    public Option<string> id { get; set; }
    public ExpressionTool_class class_ { get; set; }

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
    /// The expression to execute.  The expression must return a plain
    /// Javascript object which matches the output parameters of the
    /// ExpressionTool.
    /// 
    /// </summary>
    public string expression { get; set; }


    public ExpressionTool (Option<string> id,ExpressionTool_class class_,Option<string> label,object doc,List<object> inputs,List<object> outputs,Option<List<object>> requirements,Option<List<object>> hints,Option<CWLVersion> cwlVersion,Option<List<string>> intent,string expression,LoadingOptions? loadingOptions = null, Dictionary<object, object>? extensionFields = null) {
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
        this.expression = expression;
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
            
        ExpressionTool_class class_ = default!;
        try
        {
            class_ = (ExpressionTool_class)LoaderInstances.uriExpressionTool_classLoaderFalseTrueNone
               .LoadField(doc_.GetValueOrDefault("class", null!), baseUri,
                   loadingOptions);
        }
        catch (ValidationException e)
        {
            errors.Add(
              new ValidationException("the `class` field is not valid because: ", e)
            );
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

        List<object> inputs = default!;
        try
        {
            inputs = (List<object>)LoaderInstances.idmapinputsarray_of_WorkflowInputParameterLoader
               .LoadField(doc_.GetValueOrDefault("inputs", null!), baseUri,
                   loadingOptions);
        }
        catch (ValidationException e)
        {
            errors.Add(
              new ValidationException("the `inputs` field is not valid because: ", e)
            );
        }

        List<object> outputs = default!;
        try
        {
            outputs = (List<object>)LoaderInstances.idmapoutputsarray_of_ExpressionToolOutputParameterLoader
               .LoadField(doc_.GetValueOrDefault("outputs", null!), baseUri,
                   loadingOptions);
        }
        catch (ValidationException e)
        {
            errors.Add(
              new ValidationException("the `outputs` field is not valid because: ", e)
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

        Option<CWLVersion> cwlVersion = default!;
        if (doc_.ContainsKey("cwlVersion"))
        {
            try
            {
                cwlVersion = (Option<CWLVersion>)LoaderInstances.urioptional_CWLVersionLoaderFalseTrueNone
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

        Option<List<string>> intent = default!;
        if (doc_.ContainsKey("intent"))
        {
            try
            {
                intent = (Option<List<string>>)LoaderInstances.urioptional_array_of_StringInstanceTrueFalseNone
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

        string expression = default!;
        try
        {
            expression = (string)LoaderInstances.ExpressionLoader
               .LoadField(doc_.GetValueOrDefault("expression", null!), baseUri,
                   loadingOptions);
        }
        catch (ValidationException e)
        {
            errors.Add(
              new ValidationException("the `expression` field is not valid because: ", e)
            );
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
                        "expected one of `id`, `label`, `doc`, `inputs`, `outputs`, `requirements`, `hints`, `cwlVersion`, `intent`, `class`, `expression`"));
                    break;
                }
            }

        }

        if (errors.Count > 0)
        {
            throw new ValidationException("", errors);
        }

        return new ExpressionTool(
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
          expression: expression,
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
                    
        r["class"] = ISavable.SaveRelativeUri(class_, false,
                                  relativeUris, null, (string)this.id!);
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
                    
        r["inputs"] =
           ISavable.Save(inputs, false, (string)this.id!, relativeUris);
        r["outputs"] =
           ISavable.Save(outputs, false, (string)this.id!, relativeUris);
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
                    
        cwlVersion.IfSome(cwlVersion =>
        {
            r["cwlVersion"] = ISavable.SaveRelativeUri(cwlVersion, false,
                                      relativeUris, null, (string)this.id!);
        });
                    
        intent.IfSome(intent =>
        {
            r["intent"] = ISavable.SaveRelativeUri(intent, true,
                                      relativeUris, null, (string)this.id!);
        });
                    
        r["expression"] =
           ISavable.Save(expression, false, (string)this.id!, relativeUris);
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

            
    static readonly System.Collections.Generic.HashSet<string>attr = new() { "id", "label", "doc", "inputs", "outputs", "requirements", "hints", "cwlVersion", "intent", "class", "expression" };
}

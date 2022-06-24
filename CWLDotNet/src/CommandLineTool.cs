using System.Collections;
using OneOf;
using OneOf.Types;

namespace CWLDotNet;

/// <summary>
/// Auto-generated class implementation for https://w3id.org/cwl/cwl#CommandLineTool
///
/// This defines the schema of the CWL Command Line Tool Description document.
/// 
/// </summary>
public class CommandLineTool : ICommandLineTool, ISavable
{
    readonly LoadingOptions loadingOptions;

    readonly Dictionary<object, object> extensionFields;

    /// <summary>
    /// The unique identifier for this object.
    /// </summary>
    public OneOf<None, string> id { get; set; }
    public CommandLineTool_class class_ { get; set; }

    /// <summary>
    /// A short, human-readable label of this object.
    /// </summary>
    public OneOf<None, string> label { get; set; }

    /// <summary>
    /// A documentation string for this object, or an array of strings which should be concatenated.
    /// </summary>
    public OneOf<None, string, List<string>> doc { get; set; }

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
    public List<CommandInputParameter> inputs { get; set; }

    /// <summary>
    /// Defines the parameters representing the output of the process.  May be
    /// used to generate and/or validate the output object.
    /// 
    /// </summary>
    public List<CommandOutputParameter> outputs { get; set; }

    /// <summary>
    /// Declares requirements that apply to either the runtime environment or the
    /// workflow engine that must be met in order to execute this process.  If
    /// an implementation cannot satisfy all requirements, or a requirement is
    /// listed which is not recognized by the implementation, it is a fatal
    /// error and the implementation must not attempt to run the process,
    /// unless overridden at user option.
    /// 
    /// </summary>
    public OneOf<None, List<OneOf<InlineJavascriptRequirement, SchemaDefRequirement, LoadListingRequirement, DockerRequirement, SoftwareRequirement, InitialWorkDirRequirement, EnvVarRequirement, ShellCommandRequirement, ResourceRequirement, WorkReuse, NetworkAccess, InplaceUpdateRequirement, ToolTimeLimit, SubworkflowFeatureRequirement, ScatterFeatureRequirement, MultipleInputFeatureRequirement, StepInputExpressionRequirement>>> requirements { get; set; }

    /// <summary>
    /// Declares hints applying to either the runtime environment or the
    /// workflow engine that may be helpful in executing this process.  It is
    /// not an error if an implementation cannot satisfy all hints, however
    /// the implementation may report a warning.
    /// 
    /// </summary>
    public OneOf<None, List<object>> hints { get; set; }

    /// <summary>
    /// CWL document version. Always required at the document root. Not
    /// required for a Process embedded inside another Process.
    /// 
    /// </summary>
    public OneOf<None, CWLVersion> cwlVersion { get; set; }

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
    public OneOf<None, List<string>> intent { get; set; }

    /// <summary>
    /// Specifies the program to execute.  If an array, the first element of
    /// the array is the command to execute, and subsequent elements are
    /// mandatory command line arguments.  The elements in `baseCommand` must
    /// appear before any command line bindings from `inputBinding` or
    /// `arguments`.
    /// 
    /// If `baseCommand` is not provided or is an empty array, the first
    /// element of the command line produced after processing `inputBinding` or
    /// `arguments` must be used as the program to execute.
    /// 
    /// If the program includes a path separator character it must
    /// be an absolute path, otherwise it is an error.  If the program does not
    /// include a path separator, search the `$PATH` variable in the runtime
    /// environment of the workflow runner find the absolute path of the
    /// executable.
    /// 
    /// </summary>
    public OneOf<None, string, List<string>> baseCommand { get; set; }

    /// <summary>
    /// Command line bindings which are not directly associated with input
    /// parameters. If the value is a string, it is used as a string literal
    /// argument. If it is an Expression, the result of the evaluation is used
    /// as an argument.
    /// 
    /// </summary>
    public OneOf<None, List<OneOf<string, CommandLineBinding>>> arguments_ { get; set; }

    /// <summary>
    /// A path to a file whose contents must be piped into the command's
    /// standard input stream.
    /// 
    /// </summary>
    public OneOf<None, string> stdin { get; set; }

    /// <summary>
    /// Capture the command's standard error stream to a file written to
    /// the designated output directory.
    /// 
    /// If `stderr` is a string, it specifies the file name to use.
    /// 
    /// If `stderr` is an expression, the expression is evaluated and must
    /// return a string with the file name to use to capture stderr.  If the
    /// return value is not a string, or the resulting path contains illegal
    /// characters (such as the path separator `/`) it is an error.
    /// 
    /// </summary>
    public OneOf<None, string> stderr { get; set; }

    /// <summary>
    /// Capture the command's standard output stream to a file written to
    /// the designated output directory.
    /// 
    /// If the `CommandLineTool` contains logically chained commands
    /// (e.g. `echo a &amp;&amp; echo b`) `stdout` must include the output of
    /// every command.
    /// 
    /// If `stdout` is a string, it specifies the file name to use.
    /// 
    /// If `stdout` is an expression, the expression is evaluated and must
    /// return a string with the file name to use to capture stdout.  If the
    /// return value is not a string, or the resulting path contains illegal
    /// characters (such as the path separator `/`) it is an error.
    /// 
    /// </summary>
    public OneOf<None, string> stdout { get; set; }

    /// <summary>
    /// Exit codes that indicate the process completed successfully.
    /// 
    /// If not specified, only exit code 0 is considered success.
    /// 
    /// </summary>
    public OneOf<None, List<int>> successCodes { get; set; }

    /// <summary>
    /// Exit codes that indicate the process failed due to a possibly
    /// temporary condition, where executing the process with the same
    /// runtime environment and inputs may produce different results.
    /// 
    /// If not specified, no exit codes are considered temporary failure.
    /// 
    /// </summary>
    public OneOf<None, List<int>> temporaryFailCodes { get; set; }

    /// <summary>
    /// Exit codes that indicate the process failed due to a permanent logic error, where executing the process with the same runtime environment and same inputs is expected to always fail.
    /// If not specified, all exit codes except 0 are considered permanent failure.
    /// </summary>
    public OneOf<None, List<int>> permanentFailCodes { get; set; }


    public CommandLineTool(List<CommandInputParameter> inputs, List<CommandOutputParameter> outputs, OneOf<None, string> id = default, CommandLineTool_class? class_ = null, OneOf<None, string> label = default, OneOf<None, string, List<string>> doc = default, OneOf<None, List<OneOf<InlineJavascriptRequirement, SchemaDefRequirement, LoadListingRequirement, DockerRequirement, SoftwareRequirement, InitialWorkDirRequirement, EnvVarRequirement, ShellCommandRequirement, ResourceRequirement, WorkReuse, NetworkAccess, InplaceUpdateRequirement, ToolTimeLimit, SubworkflowFeatureRequirement, ScatterFeatureRequirement, MultipleInputFeatureRequirement, StepInputExpressionRequirement>>> requirements = default, OneOf<None, List<object>> hints = default, OneOf<None, CWLVersion> cwlVersion = default, OneOf<None, List<string>> intent = default, OneOf<None, string, List<string>> baseCommand = default, OneOf<None, List<OneOf<string, CommandLineBinding>>> arguments_ = default, OneOf<None, string> stdin = default, OneOf<None, string> stderr = default, OneOf<None, string> stdout = default, OneOf<None, List<int>> successCodes = default, OneOf<None, List<int>> temporaryFailCodes = default, OneOf<None, List<int>> permanentFailCodes = default, LoadingOptions? loadingOptions = null, Dictionary<object, object>? extensionFields = null)
    {
        this.loadingOptions = loadingOptions ?? new LoadingOptions();
        this.extensionFields = extensionFields ?? new Dictionary<object, object>();
        this.id = id;
        this.class_ = class_ ?? CommandLineTool_class.COMMANDLINETOOL;
        this.label = label;
        this.doc = doc;
        this.inputs = inputs;
        this.outputs = outputs;
        this.requirements = requirements;
        this.hints = hints;
        this.cwlVersion = cwlVersion;
        this.intent = intent;
        this.baseCommand = baseCommand;
        this.arguments_ = arguments_;
        this.stdin = stdin;
        this.stderr = stderr;
        this.stdout = stdout;
        this.successCodes = successCodes;
        this.temporaryFailCodes = temporaryFailCodes;
        this.permanentFailCodes = permanentFailCodes;
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

        dynamic id = default!;
        if (doc_.ContainsKey("id"))
        {
            try
            {
                id = LoaderInstances.uriunion_of_NullInstance_or_StringInstanceTrueFalseNone
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

        dynamic class_ = default!;
        try
        {
            class_ = LoaderInstances.uriCommandLineTool_classLoaderFalseTrueNone
               .LoadField(doc_.GetValueOrDefault("class", null!), baseUri,
                   loadingOptions);
        }
        catch (ValidationException e)
        {
            errors.Add(
              new ValidationException("the `class` field is not valid because: ", e)
            );
        }

        dynamic label = default!;
        if (doc_.ContainsKey("label"))
        {
            try
            {
                label = LoaderInstances.union_of_NullInstance_or_StringInstance
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

        dynamic doc = default!;
        if (doc_.ContainsKey("doc"))
        {
            try
            {
                doc = LoaderInstances.union_of_NullInstance_or_StringInstance_or_array_of_StringInstance
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

        dynamic inputs = default!;
        try
        {
            inputs = LoaderInstances.idmapinputsarray_of_CommandInputParameterLoader
               .LoadField(doc_.GetValueOrDefault("inputs", null!), baseUri,
                   loadingOptions);
        }
        catch (ValidationException e)
        {
            errors.Add(
              new ValidationException("the `inputs` field is not valid because: ", e)
            );
        }

        dynamic outputs = default!;
        try
        {
            outputs = LoaderInstances.idmapoutputsarray_of_CommandOutputParameterLoader
               .LoadField(doc_.GetValueOrDefault("outputs", null!), baseUri,
                   loadingOptions);
        }
        catch (ValidationException e)
        {
            errors.Add(
              new ValidationException("the `outputs` field is not valid because: ", e)
            );
        }

        dynamic requirements = default!;
        if (doc_.ContainsKey("requirements"))
        {
            try
            {
                requirements = LoaderInstances.idmaprequirementsunion_of_NullInstance_or_array_of_union_of_InlineJavascriptRequirementLoader_or_SchemaDefRequirementLoader_or_LoadListingRequirementLoader_or_DockerRequirementLoader_or_SoftwareRequirementLoader_or_InitialWorkDirRequirementLoader_or_EnvVarRequirementLoader_or_ShellCommandRequirementLoader_or_ResourceRequirementLoader_or_WorkReuseLoader_or_NetworkAccessLoader_or_InplaceUpdateRequirementLoader_or_ToolTimeLimitLoader_or_SubworkflowFeatureRequirementLoader_or_ScatterFeatureRequirementLoader_or_MultipleInputFeatureRequirementLoader_or_StepInputExpressionRequirementLoader
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

        dynamic hints = default!;
        if (doc_.ContainsKey("hints"))
        {
            try
            {
                hints = LoaderInstances.idmaphintsunion_of_NullInstance_or_array_of_AnyInstance
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

        dynamic cwlVersion = default!;
        if (doc_.ContainsKey("cwlVersion"))
        {
            try
            {
                cwlVersion = LoaderInstances.uriunion_of_NullInstance_or_CWLVersionLoaderFalseTrueNone
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

        dynamic intent = default!;
        if (doc_.ContainsKey("intent"))
        {
            try
            {
                intent = LoaderInstances.uriunion_of_NullInstance_or_array_of_StringInstanceTrueFalseNone
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

        dynamic baseCommand = default!;
        if (doc_.ContainsKey("baseCommand"))
        {
            try
            {
                baseCommand = LoaderInstances.union_of_NullInstance_or_StringInstance_or_array_of_StringInstance
                   .LoadField(doc_.GetValueOrDefault("baseCommand", null!), baseUri,
                       loadingOptions);
            }
            catch (ValidationException e)
            {
                errors.Add(
                  new ValidationException("the `baseCommand` field is not valid because: ", e)
                );
            }
        }

        dynamic arguments_ = default!;
        if (doc_.ContainsKey("arguments"))
        {
            try
            {
                arguments_ = LoaderInstances.union_of_NullInstance_or_array_of_union_of_StringInstance_or_ExpressionLoader_or_CommandLineBindingLoader
                   .LoadField(doc_.GetValueOrDefault("arguments", null!), baseUri,
                       loadingOptions);
            }
            catch (ValidationException e)
            {
                errors.Add(
                  new ValidationException("the `arguments` field is not valid because: ", e)
                );
            }
        }

        dynamic stdin = default!;
        if (doc_.ContainsKey("stdin"))
        {
            try
            {
                stdin = LoaderInstances.union_of_NullInstance_or_StringInstance_or_ExpressionLoader
                   .LoadField(doc_.GetValueOrDefault("stdin", null!), baseUri,
                       loadingOptions);
            }
            catch (ValidationException e)
            {
                errors.Add(
                  new ValidationException("the `stdin` field is not valid because: ", e)
                );
            }
        }

        dynamic stderr = default!;
        if (doc_.ContainsKey("stderr"))
        {
            try
            {
                stderr = LoaderInstances.union_of_NullInstance_or_StringInstance_or_ExpressionLoader
                   .LoadField(doc_.GetValueOrDefault("stderr", null!), baseUri,
                       loadingOptions);
            }
            catch (ValidationException e)
            {
                errors.Add(
                  new ValidationException("the `stderr` field is not valid because: ", e)
                );
            }
        }

        dynamic stdout = default!;
        if (doc_.ContainsKey("stdout"))
        {
            try
            {
                stdout = LoaderInstances.union_of_NullInstance_or_StringInstance_or_ExpressionLoader
                   .LoadField(doc_.GetValueOrDefault("stdout", null!), baseUri,
                       loadingOptions);
            }
            catch (ValidationException e)
            {
                errors.Add(
                  new ValidationException("the `stdout` field is not valid because: ", e)
                );
            }
        }

        dynamic successCodes = default!;
        if (doc_.ContainsKey("successCodes"))
        {
            try
            {
                successCodes = LoaderInstances.union_of_NullInstance_or_array_of_IntegerInstance
                   .LoadField(doc_.GetValueOrDefault("successCodes", null!), baseUri,
                       loadingOptions);
            }
            catch (ValidationException e)
            {
                errors.Add(
                  new ValidationException("the `successCodes` field is not valid because: ", e)
                );
            }
        }

        dynamic temporaryFailCodes = default!;
        if (doc_.ContainsKey("temporaryFailCodes"))
        {
            try
            {
                temporaryFailCodes = LoaderInstances.union_of_NullInstance_or_array_of_IntegerInstance
                   .LoadField(doc_.GetValueOrDefault("temporaryFailCodes", null!), baseUri,
                       loadingOptions);
            }
            catch (ValidationException e)
            {
                errors.Add(
                  new ValidationException("the `temporaryFailCodes` field is not valid because: ", e)
                );
            }
        }

        dynamic permanentFailCodes = default!;
        if (doc_.ContainsKey("permanentFailCodes"))
        {
            try
            {
                permanentFailCodes = LoaderInstances.union_of_NullInstance_or_array_of_IntegerInstance
                   .LoadField(doc_.GetValueOrDefault("permanentFailCodes", null!), baseUri,
                       loadingOptions);
            }
            catch (ValidationException e)
            {
                errors.Add(
                  new ValidationException("the `permanentFailCodes` field is not valid because: ", e)
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
                        "expected one of `id`, `label`, `doc`, `inputs`, `outputs`, `requirements`, `hints`, `cwlVersion`, `intent`, `class`, `baseCommand`, `arguments`, `stdin`, `stderr`, `stdout`, `successCodes`, `temporaryFailCodes`, `permanentFailCodes`"));
                    break;
                }
            }

        }

        if (errors.Count > 0)
        {
            throw new ValidationException("", errors);
        }

        CommandLineTool res__ = new(
          loadingOptions: loadingOptions,
          class_: class_,
          inputs: inputs,
          outputs: outputs
        );

        if (id != null)
        {
            res__.id = id;
        }

        if (label != null)
        {
            res__.label = label;
        }

        if (doc != null)
        {
            res__.doc = doc;
        }

        if (requirements != null)
        {
            res__.requirements = requirements;
        }

        if (hints != null)
        {
            res__.hints = hints;
        }

        if (cwlVersion != null)
        {
            res__.cwlVersion = cwlVersion;
        }

        if (intent != null)
        {
            res__.intent = intent;
        }

        if (baseCommand != null)
        {
            res__.baseCommand = baseCommand;
        }

        if (arguments_ != null)
        {
            res__.arguments_ = arguments_;
        }

        if (stdin != null)
        {
            res__.stdin = stdin;
        }

        if (stderr != null)
        {
            res__.stderr = stderr;
        }

        if (stdout != null)
        {
            res__.stdout = stdout;
        }

        if (successCodes != null)
        {
            res__.successCodes = successCodes;
        }

        if (temporaryFailCodes != null)
        {
            res__.temporaryFailCodes = temporaryFailCodes;
        }

        if (permanentFailCodes != null)
        {
            res__.permanentFailCodes = permanentFailCodes;
        }

        return res__;
    }

    public Dictionary<object, object> Save(bool top = false, string baseUrl = "",
        bool relativeUris = true)
    {
        Dictionary<object, object> r = new();
        foreach (KeyValuePair<object, object> ef in extensionFields)
        {
            r[loadingOptions.PrefixUrl((string)ef.Value)] = ef.Value;
        }

        object? idVal = ISavable.SaveRelativeUri(id, true,
            relativeUris, null, (string)baseUrl!);
        if (idVal is not null)
        {
            r["id"] = idVal;
        }

        object? class_Val = ISavable.SaveRelativeUri(class_, false,
            relativeUris, null, (string)this.id.AsT1!);
        if (class_Val is not null)
        {
            r["class"] = class_Val;
        }

        object? labelVal = ISavable.Save(label,
                                        false, (string)this.id.AsT1!, relativeUris);
        if (labelVal is not null)
        {
            r["label"] = labelVal;
        }

        object? docVal = ISavable.Save(doc,
                                        false, (string)this.id.AsT1!, relativeUris);
        if (docVal is not null)
        {
            r["doc"] = docVal;
        }

        object? inputsVal = ISavable.Save(inputs,
                                        false, (string)this.id.AsT1!, relativeUris);
        if (inputsVal is not null)
        {
            r["inputs"] = inputsVal;
        }

        object? outputsVal = ISavable.Save(outputs,
                                        false, (string)this.id.AsT1!, relativeUris);
        if (outputsVal is not null)
        {
            r["outputs"] = outputsVal;
        }

        object? requirementsVal = ISavable.Save(requirements,
                                        false, (string)this.id.AsT1!, relativeUris);
        if (requirementsVal is not null)
        {
            r["requirements"] = requirementsVal;
        }

        object? hintsVal = ISavable.Save(hints,
                                        false, (string)this.id.AsT1!, relativeUris);
        if (hintsVal is not null)
        {
            r["hints"] = hintsVal;
        }

        object? cwlVersionVal = ISavable.SaveRelativeUri(cwlVersion, false,
            relativeUris, null, (string)this.id.AsT1!);
        if (cwlVersionVal is not null)
        {
            r["cwlVersion"] = cwlVersionVal;
        }

        object? intentVal = ISavable.SaveRelativeUri(intent, true,
            relativeUris, null, (string)this.id.AsT1!);
        if (intentVal is not null)
        {
            r["intent"] = intentVal;
        }

        object? baseCommandVal = ISavable.Save(baseCommand,
                                        false, (string)this.id.AsT1!, relativeUris);
        if (baseCommandVal is not null)
        {
            r["baseCommand"] = baseCommandVal;
        }

        object? arguments_Val = ISavable.Save(arguments_,
                                        false, (string)this.id.AsT1!, relativeUris);
        if (arguments_Val is not null)
        {
            r["arguments"] = arguments_Val;
        }

        object? stdinVal = ISavable.Save(stdin,
                                        false, (string)this.id.AsT1!, relativeUris);
        if (stdinVal is not null)
        {
            r["stdin"] = stdinVal;
        }

        object? stderrVal = ISavable.Save(stderr,
                                        false, (string)this.id.AsT1!, relativeUris);
        if (stderrVal is not null)
        {
            r["stderr"] = stderrVal;
        }

        object? stdoutVal = ISavable.Save(stdout,
                                        false, (string)this.id.AsT1!, relativeUris);
        if (stdoutVal is not null)
        {
            r["stdout"] = stdoutVal;
        }

        object? successCodesVal = ISavable.Save(successCodes,
                                        false, (string)this.id.AsT1!, relativeUris);
        if (successCodesVal is not null)
        {
            r["successCodes"] = successCodesVal;
        }

        object? temporaryFailCodesVal = ISavable.Save(temporaryFailCodes,
                                        false, (string)this.id.AsT1!, relativeUris);
        if (temporaryFailCodesVal is not null)
        {
            r["temporaryFailCodes"] = temporaryFailCodesVal;
        }

        object? permanentFailCodesVal = ISavable.Save(permanentFailCodes,
                                        false, (string)this.id.AsT1!, relativeUris);
        if (permanentFailCodesVal is not null)
        {
            r["permanentFailCodes"] = permanentFailCodesVal;
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

    static readonly System.Collections.Generic.HashSet<string> attr = new() { "id", "label", "doc", "inputs", "outputs", "requirements", "hints", "cwlVersion", "intent", "class", "baseCommand", "arguments", "stdin", "stderr", "stdout", "successCodes", "temporaryFailCodes", "permanentFailCodes" };
}

using System.Collections;
using OneOf;
using OneOf.Types;

namespace CWLDotNet;

/// <summary>
/// Auto-generated class implementation for https://w3id.org/cwl/cwl#WorkflowInputParameter
/// </summary>
public class WorkflowInputParameter : IWorkflowInputParameter, ISavable
{
    readonly LoadingOptions loadingOptions;

    readonly Dictionary<object, object> extensionFields;

    /// <summary>
    /// The unique identifier for this object.
    /// </summary>
    public OneOf<None, string> id { get; set; }

    /// <summary>
    /// A short, human-readable label of this object.
    /// </summary>
    public OneOf<None, string> label { get; set; }

    /// <summary>
    /// Only valid when `type: File` or is an array of `items: File`.
    /// 
    /// Provides a pattern or expression specifying files or
    /// directories that should be included alongside the primary
    /// file.  Secondary files may be required or optional.  When not
    /// explicitly specified, secondary files specified for `inputs`
    /// are required and `outputs` are optional.  An implementation
    /// must include matching Files and Directories in the
    /// `secondaryFiles` property of the primary file.  These Files
    /// and Directories must be transferred and staged alongside the
    /// primary file.  An implementation may fail workflow execution
    /// if a required secondary file does not exist.
    /// 
    /// If the value is an expression, the value of `self` in the expression
    /// must be the primary input or output File object to which this binding
    /// applies.  The `basename`, `nameroot` and `nameext` fields must be
    /// present in `self`.  For `CommandLineTool` outputs the `path` field must
    /// also be present.  The expression must return a filename string relative
    /// to the path to the primary File, a File or Directory object with either
    /// `path` or `location` and `basename` fields set, or an array consisting
    /// of strings or File or Directory objects.  It is legal to reference an
    /// unchanged File or Directory object taken from input as a secondaryFile.
    /// The expression may return "null" in which case there is no secondaryFile
    /// from that expression.
    /// 
    /// To work on non-filename-preserving storage systems, portable tool
    /// descriptions should avoid constructing new values from `location`, but
    /// should construct relative references using `basename` or `nameroot`
    /// instead.
    /// 
    /// If a value in `secondaryFiles` is a string that is not an expression,
    /// it specifies that the following pattern should be applied to the path
    /// of the primary file to yield a filename relative to the primary File:
    /// 
    ///   1. If string ends with `?` character, remove the last `?` and mark
    ///     the resulting secondary file as optional.
    ///   2. If string begins with one or more caret `^` characters, for each
    ///     caret, remove the last file extension from the path (the last
    ///     period `.` and all following characters).  If there are no file
    ///     extensions, the path is unchanged.
    ///   3. Append the remainder of the string to the end of the file path.
    /// 
    /// </summary>
    public OneOf<None, SecondaryFileSchema, List<SecondaryFileSchema>> secondaryFiles { get; set; }

    /// <summary>
    /// Only valid when `type: File` or is an array of `items: File`.
    /// 
    /// A value of `true` indicates that the file is read or written
    /// sequentially without seeking.  An implementation may use this flag to
    /// indicate whether it is valid to stream file contents using a named
    /// pipe.  Default: `false`.
    /// 
    /// </summary>
    public OneOf<None, bool> streamable { get; set; }

    /// <summary>
    /// A documentation string for this object, or an array of strings which should be concatenated.
    /// </summary>
    public OneOf<None, string, List<string>> doc { get; set; }

    /// <summary>
    /// Only valid when `type: File` or is an array of `items: File`.
    /// 
    /// This must be one or more IRIs of concept nodes
    /// that represents file formats which are allowed as input to this
    /// parameter, preferrably defined within an ontology.  If no ontology is
    /// available, file formats may be tested by exact match.
    /// 
    /// </summary>
    public OneOf<None, string, List<string>> format { get; set; }

    /// <summary>
    /// Only valid when `type: File` or is an array of `items: File`.
    /// 
    /// If true, the file (or each file in the array) must be a UTF-8
    /// text file 64 KiB or smaller, and the implementation must read
    /// the entire contents of the file (or file array) and place it
    /// in the `contents` field of the File object for use by
    /// expressions.  If the size of the file is greater than 64 KiB,
    /// the implementation must raise a fatal error.
    /// 
    /// </summary>
    public OneOf<None, bool> loadContents { get; set; }

    /// <summary>
    /// Only valid when `type: Directory` or is an array of `items: Directory`.
    /// 
    /// Specify the desired behavior for loading the `listing` field of
    /// a Directory object for use by expressions.
    /// 
    /// The order of precedence for loadListing is:
    /// 
    ///   1. `loadListing` on an individual parameter
    ///   2. Inherited from `LoadListingRequirement`
    ///   3. By default: `no_listing`
    /// 
    /// </summary>
    public OneOf<None, LoadListingEnum> loadListing { get; set; }

    /// <summary>
    /// The default value to use for this parameter if the parameter is missing
    /// from the input object, or if the value of the parameter in the input
    /// object is `null`.  Default values are applied before evaluating expressions
    /// (e.g. dependent `valueFrom` fields).
    /// 
    /// </summary>
    public OneOf<None, object> default_ { get; set; }

    /// <summary>
    /// Specify valid types of data that may be assigned to this parameter.
    /// 
    /// </summary>
    public OneOf<CWLType, InputRecordSchema, InputEnumSchema, InputArraySchema, string, List<OneOf<CWLType, InputRecordSchema, InputEnumSchema, InputArraySchema, string>>> type { get; set; }

    /// <summary>
    /// Deprecated.  Preserved for v1.0 backwards compatibility.  Will be removed in
    /// CWL v2.0.  Use `WorkflowInputParameter.loadContents` instead.
    /// 
    /// </summary>
    public OneOf<None, InputBinding> inputBinding { get; set; }


    public WorkflowInputParameter(OneOf<CWLType, InputRecordSchema, InputEnumSchema, InputArraySchema, string, List<OneOf<CWLType, InputRecordSchema, InputEnumSchema, InputArraySchema, string>>> type, OneOf<None, string> id = default, OneOf<None, string> label = default, OneOf<None, SecondaryFileSchema, List<SecondaryFileSchema>> secondaryFiles = default, OneOf<None, bool> streamable = default, OneOf<None, string, List<string>> doc = default, OneOf<None, string, List<string>> format = default, OneOf<None, bool> loadContents = default, OneOf<None, LoadListingEnum> loadListing = default, OneOf<None, object> default_ = default, OneOf<None, InputBinding> inputBinding = default, LoadingOptions? loadingOptions = null, Dictionary<object, object>? extensionFields = null)
    {
        this.loadingOptions = loadingOptions ?? new LoadingOptions();
        this.extensionFields = extensionFields ?? new Dictionary<object, object>();
        this.id = id;
        this.label = label;
        this.secondaryFiles = secondaryFiles;
        this.streamable = streamable;
        this.doc = doc;
        this.format = format;
        this.loadContents = loadContents;
        this.loadListing = loadListing;
        this.default_ = default_;
        this.type = type;
        this.inputBinding = inputBinding;
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

        dynamic secondaryFiles = default!;
        if (doc_.ContainsKey("secondaryFiles"))
        {
            try
            {
                secondaryFiles = LoaderInstances.secondaryfilesdslunion_of_NullInstance_or_SecondaryFileSchemaLoader_or_array_of_SecondaryFileSchemaLoader
                   .LoadField(doc_.GetValueOrDefault("secondaryFiles", null!), baseUri,
                       loadingOptions);
            }
            catch (ValidationException e)
            {
                errors.Add(
                  new ValidationException("the `secondaryFiles` field is not valid because: ", e)
                );
            }
        }

        dynamic streamable = default!;
        if (doc_.ContainsKey("streamable"))
        {
            try
            {
                streamable = LoaderInstances.union_of_NullInstance_or_BooleanInstance
                   .LoadField(doc_.GetValueOrDefault("streamable", null!), baseUri,
                       loadingOptions);
            }
            catch (ValidationException e)
            {
                errors.Add(
                  new ValidationException("the `streamable` field is not valid because: ", e)
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

        dynamic format = default!;
        if (doc_.ContainsKey("format"))
        {
            try
            {
                format = LoaderInstances.uriunion_of_NullInstance_or_StringInstance_or_array_of_StringInstance_or_ExpressionLoaderTrueFalseNone
                   .LoadField(doc_.GetValueOrDefault("format", null!), baseUri,
                       loadingOptions);
            }
            catch (ValidationException e)
            {
                errors.Add(
                  new ValidationException("the `format` field is not valid because: ", e)
                );
            }
        }

        dynamic loadContents = default!;
        if (doc_.ContainsKey("loadContents"))
        {
            try
            {
                loadContents = LoaderInstances.union_of_NullInstance_or_BooleanInstance
                   .LoadField(doc_.GetValueOrDefault("loadContents", null!), baseUri,
                       loadingOptions);
            }
            catch (ValidationException e)
            {
                errors.Add(
                  new ValidationException("the `loadContents` field is not valid because: ", e)
                );
            }
        }

        dynamic loadListing = default!;
        if (doc_.ContainsKey("loadListing"))
        {
            try
            {
                loadListing = LoaderInstances.union_of_NullInstance_or_LoadListingEnumLoader
                   .LoadField(doc_.GetValueOrDefault("loadListing", null!), baseUri,
                       loadingOptions);
            }
            catch (ValidationException e)
            {
                errors.Add(
                  new ValidationException("the `loadListing` field is not valid because: ", e)
                );
            }
        }

        dynamic default_ = default!;
        if (doc_.ContainsKey("default"))
        {
            try
            {
                default_ = LoaderInstances.union_of_NullInstance_or_AnyInstance
                   .LoadField(doc_.GetValueOrDefault("default", null!), baseUri,
                       loadingOptions);
            }
            catch (ValidationException e)
            {
                errors.Add(
                  new ValidationException("the `default` field is not valid because: ", e)
                );
            }
        }

        dynamic type = default!;
        try
        {
            type = LoaderInstances.typedslunion_of_CWLTypeLoader_or_InputRecordSchemaLoader_or_InputEnumSchemaLoader_or_InputArraySchemaLoader_or_StringInstance_or_array_of_union_of_CWLTypeLoader_or_InputRecordSchemaLoader_or_InputEnumSchemaLoader_or_InputArraySchemaLoader_or_StringInstance2
               .LoadField(doc_.GetValueOrDefault("type", null!), baseUri,
                   loadingOptions);
        }
        catch (ValidationException e)
        {
            errors.Add(
              new ValidationException("the `type` field is not valid because: ", e)
            );
        }

        dynamic inputBinding = default!;
        if (doc_.ContainsKey("inputBinding"))
        {
            try
            {
                inputBinding = LoaderInstances.union_of_NullInstance_or_InputBindingLoader
                   .LoadField(doc_.GetValueOrDefault("inputBinding", null!), baseUri,
                       loadingOptions);
            }
            catch (ValidationException e)
            {
                errors.Add(
                  new ValidationException("the `inputBinding` field is not valid because: ", e)
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
                        "expected one of `label`, `secondaryFiles`, `streamable`, `doc`, `id`, `format`, `loadContents`, `loadListing`, `default`, `type`, `inputBinding`"));
                    break;
                }
            }

        }

        if (errors.Count > 0)
        {
            throw new ValidationException("", errors);
        }

        WorkflowInputParameter res__ = new(
          loadingOptions: loadingOptions,
          type: type
        );

        if (id != null)
        {
            res__.id = id;
        }

        if (label != null)
        {
            res__.label = label;
        }

        if (secondaryFiles != null)
        {
            res__.secondaryFiles = secondaryFiles;
        }

        if (streamable != null)
        {
            res__.streamable = streamable;
        }

        if (doc != null)
        {
            res__.doc = doc;
        }

        if (format != null)
        {
            res__.format = format;
        }

        if (loadContents != null)
        {
            res__.loadContents = loadContents;
        }

        if (loadListing != null)
        {
            res__.loadListing = loadListing;
        }

        if (default_ != null)
        {
            res__.default_ = default_;
        }

        if (inputBinding != null)
        {
            res__.inputBinding = inputBinding;
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

        object? labelVal = ISavable.Save(label,
                                        false, (string)(this.id.Value is None ? "" : id.Value)!, relativeUris);
        if (labelVal is not null)
        {
            r["label"] = labelVal;
        }

        object? secondaryFilesVal = ISavable.Save(secondaryFiles,
                                        false, (string)(this.id.Value is None ? "" : id.Value)!, relativeUris);
        if (secondaryFilesVal is not null)
        {
            r["secondaryFiles"] = secondaryFilesVal;
        }

        object? streamableVal = ISavable.Save(streamable,
                                        false, (string)(this.id.Value is None ? "" : id.Value)!, relativeUris);
        if (streamableVal is not null)
        {
            r["streamable"] = streamableVal;
        }

        object? docVal = ISavable.Save(doc,
                                        false, (string)(this.id.Value is None ? "" : id.Value)!, relativeUris);
        if (docVal is not null)
        {
            r["doc"] = docVal;
        }

        object? formatVal = ISavable.SaveRelativeUri(format, true,
            relativeUris, null, (string)(this.id.Value is None ? "" : id.Value)!);
        if (formatVal is not null)
        {
            r["format"] = formatVal;
        }

        object? loadContentsVal = ISavable.Save(loadContents,
                                        false, (string)(this.id.Value is None ? "" : id.Value)!, relativeUris);
        if (loadContentsVal is not null)
        {
            r["loadContents"] = loadContentsVal;
        }

        object? loadListingVal = ISavable.Save(loadListing,
                                        false, (string)(this.id.Value is None ? "" : id.Value)!, relativeUris);
        if (loadListingVal is not null)
        {
            r["loadListing"] = loadListingVal;
        }

        object? default_Val = ISavable.Save(default_,
                                        false, (string)(this.id.Value is None ? "" : id.Value)!, relativeUris);
        if (default_Val is not null)
        {
            r["default"] = default_Val;
        }

        object? typeVal = ISavable.Save(type,
                                        false, (string)(this.id.Value is None ? "" : id.Value)!, relativeUris);
        if (typeVal is not null)
        {
            r["type"] = typeVal;
        }

        object? inputBindingVal = ISavable.Save(inputBinding,
                                        false, (string)(this.id.Value is None ? "" : id.Value)!, relativeUris);
        if (inputBindingVal is not null)
        {
            r["inputBinding"] = inputBindingVal;
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

    static readonly System.Collections.Generic.HashSet<string> attr = new() { "label", "secondaryFiles", "streamable", "doc", "id", "format", "loadContents", "loadListing", "default", "type", "inputBinding" };
}

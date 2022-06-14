using System.Collections;

namespace CWLDotNet;

/// <summary>
/// Auto-generated class implementation for https://w3id.org/cwl/cwl#OperationInputParameter
///
/// Describe an input parameter of an operation.
/// 
/// </summary>
public class OperationInputParameter : IOperationInputParameter, ISavable {
    readonly LoadingOptions loadingOptions;

    readonly Dictionary<object, object> extensionFields;

    /// <summary>
    /// The unique identifier for this object.
    /// </summary>
    public object? id { get; set; }

    /// <summary>
    /// A short, human-readable label of this object.
    /// </summary>
    public object? label { get; set; }

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
    public object secondaryFiles { get; set; }

    /// <summary>
    /// Only valid when `type: File` or is an array of `items: File`.
    /// 
    /// A value of `true` indicates that the file is read or written
    /// sequentially without seeking.  An implementation may use this flag to
    /// indicate whether it is valid to stream file contents using a named
    /// pipe.  Default: `false`.
    /// 
    /// </summary>
    public object? streamable { get; set; }

    /// <summary>
    /// A documentation string for this object, or an array of strings which should be concatenated.
    /// </summary>
    public object doc { get; set; }

    /// <summary>
    /// Only valid when `type: File` or is an array of `items: File`.
    /// 
    /// This must be one or more IRIs of concept nodes
    /// that represents file formats which are allowed as input to this
    /// parameter, preferrably defined within an ontology.  If no ontology is
    /// available, file formats may be tested by exact match.
    /// 
    /// </summary>
    public object format { get; set; }

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
    public object? loadContents { get; set; }

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
    public object? loadListing { get; set; }

    /// <summary>
    /// The default value to use for this parameter if the parameter is missing
    /// from the input object, or if the value of the parameter in the input
    /// object is `null`.  Default values are applied before evaluating expressions
    /// (e.g. dependent `valueFrom` fields).
    /// 
    /// </summary>
    public object? default_ { get; set; }

    /// <summary>
    /// Specify valid types of data that may be assigned to this parameter.
    /// 
    /// </summary>
    public object type { get; set; }


    public OperationInputParameter (object id,object label,object secondaryFiles,object streamable,object doc,object format,object loadContents,object loadListing,object default_,object type,LoadingOptions? loadingOptions = null, Dictionary<object, object>? extensionFields = null) {
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

        object secondaryFiles = default!;
        if (doc_.ContainsKey("secondaryFiles"))
        {
            try
            {
                secondaryFiles = (object)LoaderInstances.secondaryfilesdslunion_of_NullInstance_or_SecondaryFileSchemaLoader_or_array_of_SecondaryFileSchemaLoader
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

        object streamable = default!;
        if (doc_.ContainsKey("streamable"))
        {
            try
            {
                streamable = (object)LoaderInstances.optional_BooleanInstance
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

        object format = default!;
        if (doc_.ContainsKey("format"))
        {
            try
            {
                format = (object)LoaderInstances.uriunion_of_NullInstance_or_StringInstance_or_array_of_StringInstance_or_ExpressionLoaderTrueFalseNone
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

        object loadContents = default!;
        if (doc_.ContainsKey("loadContents"))
        {
            try
            {
                loadContents = (object)LoaderInstances.optional_BooleanInstance
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

        object loadListing = default!;
        if (doc_.ContainsKey("loadListing"))
        {
            try
            {
                loadListing = (object)LoaderInstances.optional_LoadListingEnumLoader
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

        object default_ = default!;
        if (doc_.ContainsKey("default"))
        {
            try
            {
                default_ = (object)LoaderInstances.optional_AnyInstance
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

        object type = default!;
        try
        {
            type = (object)LoaderInstances.typedslunion_of_CWLTypeLoader_or_InputRecordSchemaLoader_or_InputEnumSchemaLoader_or_InputArraySchemaLoader_or_StringInstance_or_array_of_union_of_CWLTypeLoader_or_InputRecordSchemaLoader_or_InputEnumSchemaLoader_or_InputArraySchemaLoader_or_StringInstance2
               .LoadField(doc_.GetValueOrDefault("type", null!), baseUri,
                   loadingOptions);
        }
        catch (ValidationException e)
        {
            errors.Add(
              new ValidationException("the `type` field is not valid because: ", e)
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
                        "expected one of `label`, `secondaryFiles`, `streamable`, `doc`, `id`, `format`, `loadContents`, `loadListing`, `default`, `type`"));
                    break;
                }
            }

        }

        if (errors.Count > 0)
        {
            throw new ValidationException("", errors);
        }

        return new OperationInputParameter(
          label: label,
          secondaryFiles: secondaryFiles,
          streamable: streamable,
          doc: doc,
          id: id,
          format: format,
          loadContents: loadContents,
          loadListing: loadListing,
          default_: default_,
          type: type,
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
                
        if (this.label != null)
        {
            r["label"] =
               ISavable.Save(label, false, (string)this.id!, relativeUris);
        }
                
        if (this.secondaryFiles != null)
        {
            r["secondaryFiles"] =
               ISavable.Save(secondaryFiles, false, (string)this.id!, relativeUris);
        }
                
        if (this.streamable != null)
        {
            r["streamable"] =
               ISavable.Save(streamable, false, (string)this.id!, relativeUris);
        }
                
        if (this.doc != null)
        {
            r["doc"] =
               ISavable.Save(doc, false, (string)this.id!, relativeUris);
        }
                
        if (this.format != null)
        {
            r["format"] = ISavable.SaveRelativeUri(this.format, true,
                                      relativeUris, null, (string)this.id!);

        }
                
        if (this.loadContents != null)
        {
            r["loadContents"] =
               ISavable.Save(loadContents, false, (string)this.id!, relativeUris);
        }
                
        if (this.loadListing != null)
        {
            r["loadListing"] =
               ISavable.Save(loadListing, false, (string)this.id!, relativeUris);
        }
                
        if (this.default_ != null)
        {
            r["default"] =
               ISavable.Save(default_, false, (string)this.id!, relativeUris);
        }
                
        r["type"] =
           ISavable.Save(type, false, (string)this.id!, relativeUris);
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

            
    static readonly HashSet<string> attr = new() { "label", "secondaryFiles", "streamable", "doc", "id", "format", "loadContents", "loadListing", "default", "type" };
}

using System.Collections;
using LanguageExt;

namespace CWLDotNet;

/// <summary>
/// Auto-generated class implementation for https://w3id.org/cwl/cwl#CommandInputRecordField
/// </summary>
public class CommandInputRecordField : ICommandInputRecordField, ISavable {
    readonly LoadingOptions loadingOptions;

    readonly Dictionary<object, object> extensionFields;

    /// <summary>
    /// The name of the field
    /// 
    /// </summary>
    public string name { get; set; }

    /// <summary>
    /// A documentation string for this object, or an array of strings which should be concatenated.
    /// </summary>
    public object doc { get; set; }

    /// <summary>
    /// The field type
    /// 
    /// </summary>
    public object type { get; set; }

    /// <summary>
    /// A short, human-readable label of this object.
    /// </summary>
    public Option<string> label { get; set; }

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
    public Option<bool> streamable { get; set; }

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
    public Option<bool> loadContents { get; set; }

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
    public Option<LoadListingEnum> loadListing { get; set; }

    /// <summary>
    /// Describes how to turn this object into command line arguments.
    /// </summary>
    public Option<CommandLineBinding> inputBinding { get; set; }


    public CommandInputRecordField (string name,object doc,object type,Option<string> label,object secondaryFiles,Option<bool> streamable,object format,Option<bool> loadContents,Option<LoadListingEnum> loadListing,Option<CommandLineBinding> inputBinding,LoadingOptions? loadingOptions = null, Dictionary<object, object>? extensionFields = null) {
        this.loadingOptions = loadingOptions ?? new LoadingOptions();
        this.extensionFields = extensionFields ?? new Dictionary<object, object>();
        this.name = name;
        this.doc = doc;
        this.type = type;
        this.label = label;
        this.secondaryFiles = secondaryFiles;
        this.streamable = streamable;
        this.format = format;
        this.loadContents = loadContents;
        this.loadListing = loadListing;
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
            
        string name = default!;
        if (doc_.ContainsKey("name"))
        {
            try
            {
                name = (string)LoaderInstances.uriStringInstanceTrueFalseNone
                   .LoadField(doc_.GetValueOrDefault("name", null!), baseUri,
                       loadingOptions);
            }
            catch (ValidationException e)
            {
                errors.Add(
                  new ValidationException("the `name` field is not valid because: ", e)
                );
            }
        }

        if (name == null)
        {
            if (docRoot != null)
            {
                name = docRoot;
            }
            else
            {
                throw new ValidationException("Missing name");
            }
        }
        else
        {
            baseUri = (string)name;
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

        object type = default!;
        try
        {
            type = (object)LoaderInstances.typedslunion_of_CWLTypeLoader_or_CommandInputRecordSchemaLoader_or_CommandInputEnumSchemaLoader_or_CommandInputArraySchemaLoader_or_StringInstance_or_array_of_union_of_CWLTypeLoader_or_CommandInputRecordSchemaLoader_or_CommandInputEnumSchemaLoader_or_CommandInputArraySchemaLoader_or_StringInstance2
               .LoadField(doc_.GetValueOrDefault("type", null!), baseUri,
                   loadingOptions);
        }
        catch (ValidationException e)
        {
            errors.Add(
              new ValidationException("the `type` field is not valid because: ", e)
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

        Option<bool> streamable = default!;
        if (doc_.ContainsKey("streamable"))
        {
            try
            {
                streamable = (Option<bool>)LoaderInstances.optional_BooleanInstance
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

        Option<bool> loadContents = default!;
        if (doc_.ContainsKey("loadContents"))
        {
            try
            {
                loadContents = (Option<bool>)LoaderInstances.optional_BooleanInstance
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

        Option<LoadListingEnum> loadListing = default!;
        if (doc_.ContainsKey("loadListing"))
        {
            try
            {
                loadListing = (Option<LoadListingEnum>)LoaderInstances.optional_LoadListingEnumLoader
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

        Option<CommandLineBinding> inputBinding = default!;
        if (doc_.ContainsKey("inputBinding"))
        {
            try
            {
                inputBinding = (Option<CommandLineBinding>)LoaderInstances.optional_CommandLineBindingLoader
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
                        "expected one of `doc`, `name`, `type`, `label`, `secondaryFiles`, `streamable`, `format`, `loadContents`, `loadListing`, `inputBinding`"));
                    break;
                }
            }

        }

        if (errors.Count > 0)
        {
            throw new ValidationException("", errors);
        }

        return new CommandInputRecordField(
          doc: doc,
          name: name,
          type: type,
          label: label,
          secondaryFiles: secondaryFiles,
          streamable: streamable,
          format: format,
          loadContents: loadContents,
          loadListing: loadListing,
          inputBinding: inputBinding,
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

        if(name != null)
        {
            r["name"] = ISavable.SaveRelativeUri(name, true,
                                      relativeUris, null, (string)baseUrl!);
        }
                    
        if(doc != null)
        {
            r["doc"] =
               ISavable.Save(doc, false, (string)this.name!, relativeUris);
        }
                    
        r["type"] =
           ISavable.Save(type, false, (string)this.name!, relativeUris);
        label.IfSome(label =>
        {
            r["label"] =
               ISavable.Save(label, false, (string)this.name!, relativeUris);
        });
                    
        if(secondaryFiles != null)
        {
            r["secondaryFiles"] =
               ISavable.Save(secondaryFiles, false, (string)this.name!, relativeUris);
        }
                    
        streamable.IfSome(streamable =>
        {
            r["streamable"] =
               ISavable.Save(streamable, false, (string)this.name!, relativeUris);
        });
                    
        if(format != null)
        {
            r["format"] = ISavable.SaveRelativeUri(format, true,
                                      relativeUris, null, (string)this.name!);
        }
                    
        loadContents.IfSome(loadContents =>
        {
            r["loadContents"] =
               ISavable.Save(loadContents, false, (string)this.name!, relativeUris);
        });
                    
        loadListing.IfSome(loadListing =>
        {
            r["loadListing"] =
               ISavable.Save(loadListing, false, (string)this.name!, relativeUris);
        });
                    
        inputBinding.IfSome(inputBinding =>
        {
            r["inputBinding"] =
               ISavable.Save(inputBinding, false, (string)this.name!, relativeUris);
        });
                    
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

            
    static readonly System.Collections.Generic.HashSet<string>attr = new() { "doc", "name", "type", "label", "secondaryFiles", "streamable", "format", "loadContents", "loadListing", "inputBinding" };
}

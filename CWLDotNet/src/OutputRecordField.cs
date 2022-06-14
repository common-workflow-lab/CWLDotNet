using System.Collections;

namespace CWLDotNet;

/**
 * Auto-generated class implementation for https://w3id.org/cwl/cwl#OutputRecordField
 */
public class OutputRecordField : IOutputRecordField, ISavable {
    readonly LoadingOptions loadingOptions;

    readonly Dictionary<object, object> extensionFields;

  /**
   * The name of the field
   * 
   */
    public string name { get; set; }

  /**
   * A documentation string for this object, or an array of strings which should be concatenated.
   */
    public object doc { get; set; }

  /**
   * The field type
   * 
   */
    public object type { get; set; }

  /**
   * A short, human-readable label of this object.
   */
    public object? label { get; set; }

  /**
   * Only valid when `type: File` or is an array of `items: File`.
   * 
   * Provides a pattern or expression specifying files or
   * directories that should be included alongside the primary
   * file.  Secondary files may be required or optional.  When not
   * explicitly specified, secondary files specified for `inputs`
   * are required and `outputs` are optional.  An implementation
   * must include matching Files and Directories in the
   * `secondaryFiles` property of the primary file.  These Files
   * and Directories must be transferred and staged alongside the
   * primary file.  An implementation may fail workflow execution
   * if a required secondary file does not exist.
   * 
   * If the value is an expression, the value of `self` in the expression
   * must be the primary input or output File object to which this binding
   * applies.  The `basename`, `nameroot` and `nameext` fields must be
   * present in `self`.  For `CommandLineTool` outputs the `path` field must
   * also be present.  The expression must return a filename string relative
   * to the path to the primary File, a File or Directory object with either
   * `path` or `location` and `basename` fields set, or an array consisting
   * of strings or File or Directory objects.  It is legal to reference an
   * unchanged File or Directory object taken from input as a secondaryFile.
   * The expression may return "null" in which case there is no secondaryFile
   * from that expression.
   * 
   * To work on non-filename-preserving storage systems, portable tool
   * descriptions should avoid constructing new values from `location`, but
   * should construct relative references using `basename` or `nameroot`
   * instead.
   * 
   * If a value in `secondaryFiles` is a string that is not an expression,
   * it specifies that the following pattern should be applied to the path
   * of the primary file to yield a filename relative to the primary File:
   * 
   *   1. If string ends with `?` character, remove the last `?` and mark
   *     the resulting secondary file as optional.
   *   2. If string begins with one or more caret `^` characters, for each
   *     caret, remove the last file extension from the path (the last
   *     period `.` and all following characters).  If there are no file
   *     extensions, the path is unchanged.
   *   3. Append the remainder of the string to the end of the file path.
   * 
   */
    public object secondaryFiles { get; set; }

  /**
   * Only valid when `type: File` or is an array of `items: File`.
   * 
   * A value of `true` indicates that the file is read or written
   * sequentially without seeking.  An implementation may use this flag to
   * indicate whether it is valid to stream file contents using a named
   * pipe.  Default: `false`.
   * 
   */
    public object? streamable { get; set; }

  /**
   * Only valid when `type: File` or is an array of `items: File`.
   * 
   * This is the file format that will be assigned to the output
   * File object.
   * 
   */
    public object format { get; set; }


    public OutputRecordField (string name,object doc,object type,object label,object secondaryFiles,object streamable,object format,LoadingOptions? loadingOptions = null, Dictionary<object, object>? extensionFields = null) {
        this.loadingOptions = loadingOptions ?? new LoadingOptions();
        this.extensionFields = extensionFields ?? new Dictionary<object, object>();
        this.name = name;
        this.doc = doc;
        this.type = type;
        this.label = label;
        this.secondaryFiles = secondaryFiles;
        this.streamable = streamable;
        this.format = format;
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
            type = (object)LoaderInstances.typedslunion_of_CWLTypeLoader_or_OutputRecordSchemaLoader_or_OutputEnumSchemaLoader_or_OutputArraySchemaLoader_or_StringInstance_or_array_of_union_of_CWLTypeLoader_or_OutputRecordSchemaLoader_or_OutputEnumSchemaLoader_or_OutputArraySchemaLoader_or_StringInstance2
               .LoadField(doc_.GetValueOrDefault("type", null!), baseUri,
                   loadingOptions);
        }
        catch (ValidationException e)
        {
            errors.Add(
              new ValidationException("the `type` field is not valid because: ", e)
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

        object format = default!;
        if (doc_.ContainsKey("format"))
        {
            try
            {
                format = (object)LoaderInstances.uriunion_of_NullInstance_or_StringInstance_or_ExpressionLoaderTrueFalseNone
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
                        "expected one of `doc`, `name`, `type`, `label`, `secondaryFiles`, `streamable`, `format`"));
                    break;
                }
            }

        }

        if (errors.Count > 0)
        {
            throw new ValidationException("", errors);
        }

        return new OutputRecordField(
          doc: doc,
          name: name,
          type: type,
          label: label,
          secondaryFiles: secondaryFiles,
          streamable: streamable,
          format: format,
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

        if (this.name != null)
        {
            r["name"] = ISavable.SaveRelativeUri(this.name, true,
                                      relativeUris, null, (string)baseUrl!);

        }
                
        if (this.doc != null)
        {
            r["doc"] =
               ISavable.Save(doc, false, (string)this.name!, relativeUris);
        }
                
        r["type"] =
           ISavable.Save(type, false, (string)this.name!, relativeUris);
        if (this.label != null)
        {
            r["label"] =
               ISavable.Save(label, false, (string)this.name!, relativeUris);
        }
                
        if (this.secondaryFiles != null)
        {
            r["secondaryFiles"] =
               ISavable.Save(secondaryFiles, false, (string)this.name!, relativeUris);
        }
                
        if (this.streamable != null)
        {
            r["streamable"] =
               ISavable.Save(streamable, false, (string)this.name!, relativeUris);
        }
                
        if (this.format != null)
        {
            r["format"] = ISavable.SaveRelativeUri(this.format, true,
                                      relativeUris, null, (string)this.name!);

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

            
    static readonly HashSet<string> attr = new() { "doc", "name", "type", "label", "secondaryFiles", "streamable", "format" };
}

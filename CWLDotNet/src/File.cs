using System.Collections;

namespace CWLDotNet;

/**
 * Auto-generated class implementation for https://w3id.org/cwl/cwl#File
 *
 * Represents a file (or group of files when `secondaryFiles` is provided) that
 * will be accessible by tools using standard POSIX file system call API such as
 * open(2) and read(2).
 * 
 * Files are represented as objects with `class` of `File`.  File objects have
 * a number of properties that provide metadata about the file.
 * 
 * The `location` property of a File is a URI that uniquely identifies the
 * file.  Implementations must support the `file://` URI scheme and may support
 * other schemes such as `http://` and `https://`.  The value of `location` may also be a
 * relative reference, in which case it must be resolved relative to the URI
 * of the document it appears in.  Alternately to `location`, implementations
 * must also accept the `path` property on File, which must be a filesystem
 * path available on the same host as the CWL runner (for inputs) or the
 * runtime environment of a command line tool execution (for command line tool
 * outputs).
 * 
 * If no `location` or `path` is specified, a file object must specify
 * `contents` with the UTF-8 text content of the file.  This is a "file
 * literal".  File literals do not correspond to external resources, but are
 * created on disk with `contents` with when needed for a executing a tool.
 * Where appropriate, expressions can return file literals to define new files
 * on a runtime.  The maximum size of `contents` is 64 kilobytes.
 * 
 * The `basename` property defines the filename on disk where the file is
 * staged.  This may differ from the resource name.  If not provided,
 * `basename` must be computed from the last path part of `location` and made
 * available to expressions.
 * 
 * The `secondaryFiles` property is a list of File or Directory objects that
 * must be staged in the same directory as the primary file.  It is an error
 * for file names to be duplicated in `secondaryFiles`.
 * 
 * The `size` property is the size in bytes of the File.  It must be computed
 * from the resource and made available to expressions.  The `checksum` field
 * contains a cryptographic hash of the file content for use it verifying file
 * contents.  Implementations may, at user option, enable or disable
 * computation of the `checksum` field for performance or other reasons.
 * However, the ability to compute output checksums is required to pass the
 * CWL conformance test suite.
 * 
 * When executing a CommandLineTool, the files and secondary files may be
 * staged to an arbitrary directory, but must use the value of `basename` for
 * the filename.  The `path` property must be file path in the context of the
 * tool execution runtime (local to the compute node, or within the executing
 * container).  All computed properties should be available to expressions.
 * File literals also must be staged and `path` must be set.
 * 
 * When collecting CommandLineTool outputs, `glob` matching returns file paths
 * (with the `path` property) and the derived properties. This can all be
 * modified by `outputEval`.  Alternately, if the file `cwl.output.json` is
 * present in the output, `outputBinding` is ignored.
 * 
 * File objects in the output must provide either a `location` URI or a `path`
 * property in the context of the tool execution runtime (local to the compute
 * node, or within the executing container).
 * 
 * When evaluating an ExpressionTool, file objects must be referenced via
 * `location` (the expression tool does not have access to files on disk so
 * `path` is meaningless) or as file literals.  It is legal to return a file
 * object with an existing `location` but a different `basename`.  The
 * `loadContents` field of ExpressionTool inputs behaves the same as on
 * CommandLineTool inputs, however it is not meaningful on the outputs.
 * 
 * An ExpressionTool may forward file references from input to output by using
 * the same value for `location`.
 * 
 */
public class File : IFile, ISavable {
    readonly LoadingOptions loadingOptions;

    readonly Dictionary<object, object> extensionFields;

  /**
   * Must be `File` to indicate this object describes a file.
   */
    public File_class class_ { get; set; }

  /**
   * An IRI that identifies the file resource.  This may be a relative
   * reference, in which case it must be resolved using the base IRI of the
   * document.  The location may refer to a local or remote resource; the
   * implementation must use the IRI to retrieve file content.  If an
   * implementation is unable to retrieve the file content stored at a
   * remote resource (due to unsupported protocol, access denied, or other
   * issue) it must signal an error.
   * 
   * If the `location` field is not provided, the `contents` field must be
   * provided.  The implementation must assign a unique identifier for
   * the `location` field.
   * 
   * If the `path` field is provided but the `location` field is not, an
   * implementation may assign the value of the `path` field to `location`,
   * then follow the rules above.
   * 
   */
    public object? location { get; set; }

  /**
   * The local host path where the File is available when a CommandLineTool is
   * executed.  This field must be set by the implementation.  The final
   * path component must match the value of `basename`.  This field
   * must not be used in any other context.  The command line tool being
   * executed must be able to to access the file at `path` using the POSIX
   * `open(2)` syscall.
   * 
   * As a special case, if the `path` field is provided but the `location`
   * field is not, an implementation may assign the value of the `path`
   * field to `location`, and remove the `path` field.
   * 
   * If the `path` contains [POSIX shell metacharacters](http://pubs.opengroup.org/onlinepubs/9699919799/utilities/V3_chap02.html#tag_18_02)
   * (`|`,`&`, `;`, `<`, `>`, `(`,`)`, `$`,`` ` ``, `\`, `"`, `'`,
   * `<space>`, `<tab>`, and `<newline>`) or characters
   * [not allowed](http://www.iana.org/assignments/idna-tables-6.3.0/idna-tables-6.3.0.xhtml)
   * for [Internationalized Domain Names for Applications](https://tools.ietf.org/html/rfc6452)
   * then implementations may terminate the process with a
   * `permanentFailure`.
   * 
   */
    public object? path { get; set; }

  /**
   * The base name of the file, that is, the name of the file without any
   * leading directory path.  The base name must not contain a slash `/`.
   * 
   * If not provided, the implementation must set this field based on the
   * `location` field by taking the final path component after parsing
   * `location` as an IRI.  If `basename` is provided, it is not required to
   * match the value from `location`.
   * 
   * When this file is made available to a CommandLineTool, it must be named
   * with `basename`, i.e. the final component of the `path` field must match
   * `basename`.
   * 
   */
    public object? basename { get; set; }

  /**
   * The name of the directory containing file, that is, the path leading up
   * to the final slash in the path such that `dirname + '/' + basename ==
   * path`.
   * 
   * The implementation must set this field based on the value of `path`
   * prior to evaluating parameter references or expressions in a
   * CommandLineTool document.  This field must not be used in any other
   * context.
   * 
   */
    public object? dirname { get; set; }

  /**
   * The basename root such that `nameroot + nameext == basename`, and
   * `nameext` is empty or begins with a period and contains at most one
   * period.  For the purposess of path splitting leading periods on the
   * basename are ignored; a basename of `.cshrc` will have a nameroot of
   * `.cshrc`.
   * 
   * The implementation must set this field automatically based on the value
   * of `basename` prior to evaluating parameter references or expressions.
   * 
   */
    public object? nameroot { get; set; }

  /**
   * The basename extension such that `nameroot + nameext == basename`, and
   * `nameext` is empty or begins with a period and contains at most one
   * period.  Leading periods on the basename are ignored; a basename of
   * `.cshrc` will have an empty `nameext`.
   * 
   * The implementation must set this field automatically based on the value
   * of `basename` prior to evaluating parameter references or expressions.
   * 
   */
    public object? nameext { get; set; }

  /**
   * Optional hash code for validating file integrity.  Currently must be in the form
   * "sha1$ + hexadecimal string" using the SHA-1 algorithm.
   * 
   */
    public object? checksum { get; set; }

  /**
   * Optional file size (in bytes)
   */
    public object size { get; set; }

  /**
   * A list of additional files or directories that are associated with the
   * primary file and must be transferred alongside the primary file.
   * Examples include indexes of the primary file, or external references
   * which must be included when loading primary document.  A file object
   * listed in `secondaryFiles` may itself include `secondaryFiles` for
   * which the same rules apply.
   * 
   */
    public object? secondaryFiles { get; set; }

  /**
   * The format of the file: this must be an IRI of a concept node that
   * represents the file format, preferrably defined within an ontology.
   * If no ontology is available, file formats may be tested by exact match.
   * 
   * Reasoning about format compatibility must be done by checking that an
   * input file format is the same, `owl:equivalentClass` or
   * `rdfs:subClassOf` the format required by the input parameter.
   * `owl:equivalentClass` is transitive with `rdfs:subClassOf`, e.g. if
   * `<B> owl:equivalentClass <C>` and `<B> owl:subclassOf <A>` then infer
   * `<C> owl:subclassOf <A>`.
   * 
   * File format ontologies may be provided in the "$schemas" metadata at the
   * root of the document.  If no ontologies are specified in `$schemas`, the
   * runtime may perform exact file format matches.
   * 
   */
    public object? format { get; set; }

  /**
   * File contents literal.
   * 
   * If neither `location` nor `path` is provided, `contents` must be
   * non-null.  The implementation must assign a unique identifier for the
   * `location` field.  When the file is staged as input to CommandLineTool,
   * the value of `contents` must be written to a file.
   * 
   * If `contents` is set as a result of an Javascript expression,
   * an `entry` in `InitialWorkDirRequirement`, or read in from
   * `cwl.output.json`, there is no specified upper limit on the
   * size of `contents`.  Implementations may have practical limits
   * on the size of `contents` based on memory and storage
   * available to the workflow runner or other factors.
   * 
   * If the `loadContents` field of an `InputParameter` or
   * `OutputParameter` is true, and the input or output File object
   * `location` is valid, the file must be a UTF-8 text file 64 KiB
   * or smaller, and the implementation must read the entire
   * contents of the file and place it in the `contents` field.  If
   * the size of the file is greater than 64 KiB, the
   * implementation must raise a fatal error.
   * 
   */
    public object? contents { get; set; }


    public File (File_class class_,object location,object path,object basename,object dirname,object nameroot,object nameext,object checksum,object size,object secondaryFiles,object format,object contents,LoadingOptions? loadingOptions = null, Dictionary<object, object>? extensionFields = null) {
        this.loadingOptions = loadingOptions ?? new LoadingOptions();
        this.extensionFields = extensionFields ?? new Dictionary<object, object>();
        this.class_ = class_;
        this.location = location;
        this.path = path;
        this.basename = basename;
        this.dirname = dirname;
        this.nameroot = nameroot;
        this.nameext = nameext;
        this.checksum = checksum;
        this.size = size;
        this.secondaryFiles = secondaryFiles;
        this.format = format;
        this.contents = contents;
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
            
        File_class class_ = default!;
        try
        {
            class_ = (File_class)LoaderInstances.uriFile_classLoaderFalseTrueNone
               .LoadField(doc_.GetValueOrDefault("class", null!), baseUri,
                   loadingOptions);
        }
        catch (ValidationException e)
        {
            errors.Add(
              new ValidationException("the `class` field is not valid because: ", e)
            );
        }

        object location = default!;
        if (doc_.ContainsKey("location"))
        {
            try
            {
                location = (object)LoaderInstances.urioptional_StringInstanceFalseFalseNone
                   .LoadField(doc_.GetValueOrDefault("location", null!), baseUri,
                       loadingOptions);
            }
            catch (ValidationException e)
            {
                errors.Add(
                  new ValidationException("the `location` field is not valid because: ", e)
                );
            }
        }

        object path = default!;
        if (doc_.ContainsKey("path"))
        {
            try
            {
                path = (object)LoaderInstances.urioptional_StringInstanceFalseFalseNone
                   .LoadField(doc_.GetValueOrDefault("path", null!), baseUri,
                       loadingOptions);
            }
            catch (ValidationException e)
            {
                errors.Add(
                  new ValidationException("the `path` field is not valid because: ", e)
                );
            }
        }

        object basename = default!;
        if (doc_.ContainsKey("basename"))
        {
            try
            {
                basename = (object)LoaderInstances.optional_StringInstance
                   .LoadField(doc_.GetValueOrDefault("basename", null!), baseUri,
                       loadingOptions);
            }
            catch (ValidationException e)
            {
                errors.Add(
                  new ValidationException("the `basename` field is not valid because: ", e)
                );
            }
        }

        object dirname = default!;
        if (doc_.ContainsKey("dirname"))
        {
            try
            {
                dirname = (object)LoaderInstances.optional_StringInstance
                   .LoadField(doc_.GetValueOrDefault("dirname", null!), baseUri,
                       loadingOptions);
            }
            catch (ValidationException e)
            {
                errors.Add(
                  new ValidationException("the `dirname` field is not valid because: ", e)
                );
            }
        }

        object nameroot = default!;
        if (doc_.ContainsKey("nameroot"))
        {
            try
            {
                nameroot = (object)LoaderInstances.optional_StringInstance
                   .LoadField(doc_.GetValueOrDefault("nameroot", null!), baseUri,
                       loadingOptions);
            }
            catch (ValidationException e)
            {
                errors.Add(
                  new ValidationException("the `nameroot` field is not valid because: ", e)
                );
            }
        }

        object nameext = default!;
        if (doc_.ContainsKey("nameext"))
        {
            try
            {
                nameext = (object)LoaderInstances.optional_StringInstance
                   .LoadField(doc_.GetValueOrDefault("nameext", null!), baseUri,
                       loadingOptions);
            }
            catch (ValidationException e)
            {
                errors.Add(
                  new ValidationException("the `nameext` field is not valid because: ", e)
                );
            }
        }

        object checksum = default!;
        if (doc_.ContainsKey("checksum"))
        {
            try
            {
                checksum = (object)LoaderInstances.optional_StringInstance
                   .LoadField(doc_.GetValueOrDefault("checksum", null!), baseUri,
                       loadingOptions);
            }
            catch (ValidationException e)
            {
                errors.Add(
                  new ValidationException("the `checksum` field is not valid because: ", e)
                );
            }
        }

        object size = default!;
        if (doc_.ContainsKey("size"))
        {
            try
            {
                size = (object)LoaderInstances.union_of_NullInstance_or_IntegerInstance_or_LongInstance
                   .LoadField(doc_.GetValueOrDefault("size", null!), baseUri,
                       loadingOptions);
            }
            catch (ValidationException e)
            {
                errors.Add(
                  new ValidationException("the `size` field is not valid because: ", e)
                );
            }
        }

        object secondaryFiles = default!;
        if (doc_.ContainsKey("secondaryFiles"))
        {
            try
            {
                secondaryFiles = (object)LoaderInstances.secondaryfilesdsloptional_array_of_union_of_FileLoader_or_DirectoryLoader
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

        object format = default!;
        if (doc_.ContainsKey("format"))
        {
            try
            {
                format = (object)LoaderInstances.urioptional_StringInstanceTrueFalseNone
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

        object contents = default!;
        if (doc_.ContainsKey("contents"))
        {
            try
            {
                contents = (object)LoaderInstances.optional_StringInstance
                   .LoadField(doc_.GetValueOrDefault("contents", null!), baseUri,
                       loadingOptions);
            }
            catch (ValidationException e)
            {
                errors.Add(
                  new ValidationException("the `contents` field is not valid because: ", e)
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
                        "expected one of `class`, `location`, `path`, `basename`, `dirname`, `nameroot`, `nameext`, `checksum`, `size`, `secondaryFiles`, `format`, `contents`"));
                    break;
                }
            }

        }

        if (errors.Count > 0)
        {
            throw new ValidationException("", errors);
        }

        return new File(
          class_: class_,
          location: location,
          path: path,
          basename: basename,
          dirname: dirname,
          nameroot: nameroot,
          nameext: nameext,
          checksum: checksum,
          size: size,
          secondaryFiles: secondaryFiles,
          format: format,
          contents: contents,
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

        if (this.location != null)
        {
            r["location"] = ISavable.SaveRelativeUri(this.location, false,
                                      relativeUris, null, (string)baseUrl!);

        }
                
        if (this.path != null)
        {
            r["path"] = ISavable.SaveRelativeUri(this.path, false,
                                      relativeUris, null, (string)baseUrl!);

        }
                
        if (this.basename != null)
        {
            r["basename"] =
               ISavable.Save(basename, false, (string)baseUrl!, relativeUris);
        }
                
        if (this.dirname != null)
        {
            r["dirname"] =
               ISavable.Save(dirname, false, (string)baseUrl!, relativeUris);
        }
                
        if (this.nameroot != null)
        {
            r["nameroot"] =
               ISavable.Save(nameroot, false, (string)baseUrl!, relativeUris);
        }
                
        if (this.nameext != null)
        {
            r["nameext"] =
               ISavable.Save(nameext, false, (string)baseUrl!, relativeUris);
        }
                
        if (this.checksum != null)
        {
            r["checksum"] =
               ISavable.Save(checksum, false, (string)baseUrl!, relativeUris);
        }
                
        if (this.size != null)
        {
            r["size"] =
               ISavable.Save(size, false, (string)baseUrl!, relativeUris);
        }
                
        if (this.secondaryFiles != null)
        {
            r["secondaryFiles"] =
               ISavable.Save(secondaryFiles, false, (string)baseUrl!, relativeUris);
        }
                
        if (this.format != null)
        {
            r["format"] = ISavable.SaveRelativeUri(this.format, true,
                                      relativeUris, null, (string)baseUrl!);

        }
                
        if (this.contents != null)
        {
            r["contents"] =
               ISavable.Save(contents, false, (string)baseUrl!, relativeUris);
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

            
    static readonly HashSet<string> attr = new() { "class", "location", "path", "basename", "dirname", "nameroot", "nameext", "checksum", "size", "secondaryFiles", "format", "contents" };
}

using System.Collections;
using LanguageExt;

namespace CWLDotNet;

/// <summary>
/// Auto-generated class implementation for https://w3id.org/cwl/cwl#CommandLineBinding
///
/// 
/// When listed under `inputBinding` in the input schema, the term
/// "value" refers to the the corresponding value in the input object.  For
/// binding objects listed in `CommandLineTool.arguments`, the term "value"
/// refers to the effective value after evaluating `valueFrom`.
/// 
/// The binding behavior when building the command line depends on the data
/// type of the value.  If there is a mismatch between the type described by
/// the input schema and the effective value, such as resulting from an
/// expression evaluation, an implementation must use the data type of the
/// effective value.
/// 
///   - **string**: Add `prefix` and the string to the command line.
/// 
///   - **number**: Add `prefix` and decimal representation to command line.
/// 
///   - **boolean**: If true, add `prefix` to the command line.  If false, add
///       nothing.
/// 
///   - **File**: Add `prefix` and the value of
///     [`File.path`](#File) to the command line.
/// 
///   - **Directory**: Add `prefix` and the value of
///     [`Directory.path`](#Directory) to the command line.
/// 
///   - **array**: If `itemSeparator` is specified, add `prefix` and the join
///       the array into a single string with `itemSeparator` separating the
///       items.  Otherwise first add `prefix`, then recursively process
///       individual elements.
///       If the array is empty, it does not add anything to command line.
/// 
///   - **object**: Add `prefix` only, and recursively add object fields for
///       which `inputBinding` is specified.
/// 
///   - **null**: Add nothing.
/// 
/// </summary>
public class CommandLineBinding : ICommandLineBinding, ISavable {
    readonly LoadingOptions loadingOptions;

    readonly Dictionary<object, object> extensionFields;

    /// <summary>
    /// Use of `loadContents` in `InputBinding` is deprecated.
    /// Preserved for v1.0 backwards compatibility.  Will be removed in
    /// CWL v2.0.  Use `InputParameter.loadContents` instead.
    /// 
    /// </summary>
    public Option<bool> loadContents { get; set; }

    /// <summary>
    /// The sorting key.  Default position is 0. If a [CWL Parameter Reference](#Parameter_references)
    /// or [CWL Expression](#Expressions_(Optional)) is used and if the
    /// inputBinding is associated with an input parameter, then the value of
    /// `self` will be the value of the input parameter.  Input parameter
    /// defaults (as specified by the `InputParameter.default` field) must be
    /// applied before evaluating the expression. Expressions must return a
    /// single value of type int or a null.
    /// 
    /// </summary>
    public object position { get; set; }

    /// <summary>
    /// Command line prefix to add before the value.
    /// </summary>
    public Option<string> prefix { get; set; }

    /// <summary>
    /// If true (default), then the prefix and value must be added as separate
    /// command line arguments; if false, prefix and value must be concatenated
    /// into a single command line argument.
    /// 
    /// </summary>
    public Option<bool> separate { get; set; }

    /// <summary>
    /// Join the array elements into a single string with the elements
    /// separated by by `itemSeparator`.
    /// 
    /// </summary>
    public Option<string> itemSeparator { get; set; }

    /// <summary>
    /// If `valueFrom` is a constant string value, use this as the value and
    /// apply the binding rules above.
    /// 
    /// If `valueFrom` is an expression, evaluate the expression to yield the
    /// actual value to use to build the command line and apply the binding
    /// rules above.  If the inputBinding is associated with an input
    /// parameter, the value of `self` in the expression will be the value of
    /// the input parameter.  Input parameter defaults (as specified by the
    /// `InputParameter.default` field) must be applied before evaluating the
    /// expression.
    /// 
    /// If the value of the associated input parameter is `null`, `valueFrom` is
    /// not evaluated and nothing is added to the command line.
    /// 
    /// When a binding is part of the `CommandLineTool.arguments` field,
    /// the `valueFrom` field is required.
    /// 
    /// </summary>
    public object valueFrom { get; set; }

    /// <summary>
    /// If `ShellCommandRequirement` is in the requirements for the current command,
    /// this controls whether the value is quoted on the command line (default is true).
    /// Use `shellQuote: false` to inject metacharacters for operations such as pipes.
    /// 
    /// If `shellQuote` is true or not provided, the implementation must not
    /// permit interpretation of any shell metacharacters or directives.
    /// 
    /// </summary>
    public Option<bool> shellQuote { get; set; }


    public CommandLineBinding (Option<bool> loadContents,object position,Option<string> prefix,Option<bool> separate,Option<string> itemSeparator,object valueFrom,Option<bool> shellQuote,LoadingOptions? loadingOptions = null, Dictionary<object, object>? extensionFields = null) {
        this.loadingOptions = loadingOptions ?? new LoadingOptions();
        this.extensionFields = extensionFields ?? new Dictionary<object, object>();
        this.loadContents = loadContents;
        this.position = position;
        this.prefix = prefix;
        this.separate = separate;
        this.itemSeparator = itemSeparator;
        this.valueFrom = valueFrom;
        this.shellQuote = shellQuote;
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

        object position = default!;
        if (doc_.ContainsKey("position"))
        {
            try
            {
                position = (object)LoaderInstances.union_of_NullInstance_or_IntegerInstance_or_ExpressionLoader
                   .LoadField(doc_.GetValueOrDefault("position", null!), baseUri,
                       loadingOptions);
            }
            catch (ValidationException e)
            {
                errors.Add(
                  new ValidationException("the `position` field is not valid because: ", e)
                );
            }
        }

        Option<string> prefix = default!;
        if (doc_.ContainsKey("prefix"))
        {
            try
            {
                prefix = (Option<string>)LoaderInstances.optional_StringInstance
                   .LoadField(doc_.GetValueOrDefault("prefix", null!), baseUri,
                       loadingOptions);
            }
            catch (ValidationException e)
            {
                errors.Add(
                  new ValidationException("the `prefix` field is not valid because: ", e)
                );
            }
        }

        Option<bool> separate = default!;
        if (doc_.ContainsKey("separate"))
        {
            try
            {
                separate = (Option<bool>)LoaderInstances.optional_BooleanInstance
                   .LoadField(doc_.GetValueOrDefault("separate", null!), baseUri,
                       loadingOptions);
            }
            catch (ValidationException e)
            {
                errors.Add(
                  new ValidationException("the `separate` field is not valid because: ", e)
                );
            }
        }

        Option<string> itemSeparator = default!;
        if (doc_.ContainsKey("itemSeparator"))
        {
            try
            {
                itemSeparator = (Option<string>)LoaderInstances.optional_StringInstance
                   .LoadField(doc_.GetValueOrDefault("itemSeparator", null!), baseUri,
                       loadingOptions);
            }
            catch (ValidationException e)
            {
                errors.Add(
                  new ValidationException("the `itemSeparator` field is not valid because: ", e)
                );
            }
        }

        object valueFrom = default!;
        if (doc_.ContainsKey("valueFrom"))
        {
            try
            {
                valueFrom = (object)LoaderInstances.union_of_NullInstance_or_StringInstance_or_ExpressionLoader
                   .LoadField(doc_.GetValueOrDefault("valueFrom", null!), baseUri,
                       loadingOptions);
            }
            catch (ValidationException e)
            {
                errors.Add(
                  new ValidationException("the `valueFrom` field is not valid because: ", e)
                );
            }
        }

        Option<bool> shellQuote = default!;
        if (doc_.ContainsKey("shellQuote"))
        {
            try
            {
                shellQuote = (Option<bool>)LoaderInstances.optional_BooleanInstance
                   .LoadField(doc_.GetValueOrDefault("shellQuote", null!), baseUri,
                       loadingOptions);
            }
            catch (ValidationException e)
            {
                errors.Add(
                  new ValidationException("the `shellQuote` field is not valid because: ", e)
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
                        "expected one of `loadContents`, `position`, `prefix`, `separate`, `itemSeparator`, `valueFrom`, `shellQuote`"));
                    break;
                }
            }

        }

        if (errors.Count > 0)
        {
            throw new ValidationException("", errors);
        }

        return new CommandLineBinding(
          loadContents: loadContents,
          position: position,
          prefix: prefix,
          separate: separate,
          itemSeparator: itemSeparator,
          valueFrom: valueFrom,
          shellQuote: shellQuote,
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

        loadContents.IfSome(loadContents =>
        {
            r["loadContents"] =
               ISavable.Save(loadContents, false, (string)baseUrl!, relativeUris);
        });
                    
        if(position != null)
        {
            r["position"] =
               ISavable.Save(position, false, (string)baseUrl!, relativeUris);
        }
                    
        prefix.IfSome(prefix =>
        {
            r["prefix"] =
               ISavable.Save(prefix, false, (string)baseUrl!, relativeUris);
        });
                    
        separate.IfSome(separate =>
        {
            r["separate"] =
               ISavable.Save(separate, false, (string)baseUrl!, relativeUris);
        });
                    
        itemSeparator.IfSome(itemSeparator =>
        {
            r["itemSeparator"] =
               ISavable.Save(itemSeparator, false, (string)baseUrl!, relativeUris);
        });
                    
        if(valueFrom != null)
        {
            r["valueFrom"] =
               ISavable.Save(valueFrom, false, (string)baseUrl!, relativeUris);
        }
                    
        shellQuote.IfSome(shellQuote =>
        {
            r["shellQuote"] =
               ISavable.Save(shellQuote, false, (string)baseUrl!, relativeUris);
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

            
    static readonly System.Collections.Generic.HashSet<string>attr = new() { "loadContents", "position", "prefix", "separate", "itemSeparator", "valueFrom", "shellQuote" };
}

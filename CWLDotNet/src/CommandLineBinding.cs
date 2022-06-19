using System.Collections;
using OneOf;
using OneOf.Types;
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
    public OneOf<None , bool> loadContents { get; set; }

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
    public OneOf<None , int , string> position { get; set; }

    /// <summary>
    /// Command line prefix to add before the value.
    /// </summary>
    public OneOf<None , string> prefix { get; set; }

    /// <summary>
    /// If true (default), then the prefix and value must be added as separate
    /// command line arguments; if false, prefix and value must be concatenated
    /// into a single command line argument.
    /// 
    /// </summary>
    public OneOf<None , bool> separate { get; set; }

    /// <summary>
    /// Join the array elements into a single string with the elements
    /// separated by by `itemSeparator`.
    /// 
    /// </summary>
    public OneOf<None , string> itemSeparator { get; set; }

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
    public OneOf<None , string> valueFrom { get; set; }

    /// <summary>
    /// If `ShellCommandRequirement` is in the requirements for the current command,
    /// this controls whether the value is quoted on the command line (default is true).
    /// Use `shellQuote: false` to inject metacharacters for operations such as pipes.
    /// 
    /// If `shellQuote` is true or not provided, the implementation must not
    /// permit interpretation of any shell metacharacters or directives.
    /// 
    /// </summary>
    public OneOf<None , bool> shellQuote { get; set; }


    public CommandLineBinding (OneOf<None , bool> loadContents = default, OneOf<None , int , string> position = default, OneOf<None , string> prefix = default, OneOf<None , bool> separate = default, OneOf<None , string> itemSeparator = default, OneOf<None , string> valueFrom = default, OneOf<None , bool> shellQuote = default, LoadingOptions? loadingOptions = null, Dictionary<object, object>? extensionFields = null) {
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

        dynamic position = default!;
        if (doc_.ContainsKey("position"))
        {
            try
            {
                position = LoaderInstances.union_of_NullInstance_or_IntegerInstance_or_ExpressionLoader
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

        dynamic prefix = default!;
        if (doc_.ContainsKey("prefix"))
        {
            try
            {
                prefix = LoaderInstances.union_of_NullInstance_or_StringInstance
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

        dynamic separate = default!;
        if (doc_.ContainsKey("separate"))
        {
            try
            {
                separate = LoaderInstances.union_of_NullInstance_or_BooleanInstance
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

        dynamic itemSeparator = default!;
        if (doc_.ContainsKey("itemSeparator"))
        {
            try
            {
                itemSeparator = LoaderInstances.union_of_NullInstance_or_StringInstance
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

        dynamic valueFrom = default!;
        if (doc_.ContainsKey("valueFrom"))
        {
            try
            {
                valueFrom = LoaderInstances.union_of_NullInstance_or_StringInstance_or_ExpressionLoader
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

        dynamic shellQuote = default!;
        if (doc_.ContainsKey("shellQuote"))
        {
            try
            {
                shellQuote = LoaderInstances.union_of_NullInstance_or_BooleanInstance
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

        var res__ = new CommandLineBinding(
          loadingOptions: loadingOptions
        );

        if(loadContents != null) 
        {
            res__.loadContents = loadContents;
        }                      
        
        if(position != null) 
        {
            res__.position = position;
        }                      
        
        if(prefix != null) 
        {
            res__.prefix = prefix;
        }                      
        
        if(separate != null) 
        {
            res__.separate = separate;
        }                      
        
        if(itemSeparator != null) 
        {
            res__.itemSeparator = itemSeparator;
        }                      
        
        if(valueFrom != null) 
        {
            res__.valueFrom = valueFrom;
        }                      
        
        if(shellQuote != null) 
        {
            res__.shellQuote = shellQuote;
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

        var loadContentsVal = ISavable.Save(loadContents, false, (string)baseUrl!, relativeUris);
        if(loadContentsVal is not None) {
            r["loadContents"] = loadContentsVal;
        }

        var positionVal = ISavable.Save(position, false, (string)baseUrl!, relativeUris);
        if(positionVal is not None) {
            r["position"] = positionVal;
        }

        var prefixVal = ISavable.Save(prefix, false, (string)baseUrl!, relativeUris);
        if(prefixVal is not None) {
            r["prefix"] = prefixVal;
        }

        var separateVal = ISavable.Save(separate, false, (string)baseUrl!, relativeUris);
        if(separateVal is not None) {
            r["separate"] = separateVal;
        }

        var itemSeparatorVal = ISavable.Save(itemSeparator, false, (string)baseUrl!, relativeUris);
        if(itemSeparatorVal is not None) {
            r["itemSeparator"] = itemSeparatorVal;
        }

        var valueFromVal = ISavable.Save(valueFrom, false, (string)baseUrl!, relativeUris);
        if(valueFromVal is not None) {
            r["valueFrom"] = valueFromVal;
        }

        var shellQuoteVal = ISavable.Save(shellQuote, false, (string)baseUrl!, relativeUris);
        if(shellQuoteVal is not None) {
            r["shellQuote"] = shellQuoteVal;
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

    static readonly System.Collections.Generic.HashSet<string>attr = new() { "loadContents", "position", "prefix", "separate", "itemSeparator", "valueFrom", "shellQuote" };
}

using System.Collections;

namespace CWLDotNet;

public class SimpleSchema : ISavable
{
    readonly LoadingOptions loadingOptions;

    public string id;

    public string? labelField;

    public int numberField;

    public SimpleEnum enumField;
    readonly Dictionary<object, object> extensionFields;

    public SimpleSchema(string id, string? labelField, int numberField, SimpleEnum enumField, LoadingOptions? loadingOptions = null, Dictionary<object, object>? extensionFields = null)
    {
        this.loadingOptions = loadingOptions ?? new LoadingOptions();
        this.extensionFields = extensionFields ?? new Dictionary<object, object>();
        this.id = id;
        this.labelField = labelField;
        this.numberField = numberField;
        this.enumField = enumField;
    }

    public static ISavable FromDoc(object doc, string baseUri, LoadingOptions loadingOptions, string? docRoot = null)
    {
        List<ValidationException> errors = new();

        if (doc is not IDictionary)
        {
            throw new ValidationException("Document has to be of type map");
        }

        Dictionary<object, object> doc_ = (Dictionary<object, object>)doc;

        string? id = null;
        if (doc_.ContainsKey("id"))
        {
            try
            {
                id = (string)((ILoader<object>)LoaderInstnaces.uriunionOfundefinedtypeOrstrtypeTrueFalseNone).LoadField(doc_["id"], baseUri, loadingOptions);
            }
            catch (ValidationException e)
            {
                errors.Add(new ValidationException("The `id` field ist not valid because: ", e));
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
            baseUri = id;
        }

        string? labelField = null;
        if (doc_.ContainsKey("labelField"))
        {
            try
            {
                labelField = ((ILoader<string>)LoaderInstnaces.stringLoader).LoadField(doc_["labelField"], baseUri, loadingOptions);
            }
            catch (ValidationException e)
            {
                errors.Add(new ValidationException("The `labelField` field ist not valid because: ", e));
            }
        }

        int numberField = 0;
        try
        {
            numberField = ((ILoader<int>)LoaderInstnaces.intLoader).LoadField(doc_["numberField"], baseUri, loadingOptions);
        }
        catch (ValidationException e)
        {
            errors.Add(new ValidationException("The `numberField` field ist not valid because: ", e));
        }

        SimpleEnum enumField = SimpleEnum.A;
        try
        {
            enumField = ((ILoader<SimpleEnum>)LoaderInstnaces.simpleEnumLoader).LoadField(doc_["enumField"], baseUri, loadingOptions);
        }
        catch (ValidationException e)
        {
            errors.Add(new ValidationException("The `enumField` field ist not valid because: ", e));
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
                    errors.Add(new ValidationException($"invalid field {v.Key}, expected one of 'id', 'labelField', 'enumField', 'numberField'"));
                    break;
                }
            }

        }

        if (errors.Count > 0)
        {
            throw new ValidationException("", errors);
        }

        return new SimpleSchema(id, labelField, numberField, enumField, loadingOptions);
    }

    public Dictionary<object, object> Save(bool top = false, string baseUrl = "", bool relativeUris = true)
    {
        Dictionary<object, object> r = new();
        foreach (KeyValuePair<object, object> _ in extensionFields)
        {
            // Todo prefixURL
        }

        if (id != null)
        {
            object u = ISavable.SaveRelativeUri(this.id, true, relativeUris, null, baseUrl);
            if (u != null)
            {
                r["id"] = u;
            }
        }

        if (this.labelField != null)
        {
            r["labelField"] = ISavable.Save(this.labelField, false, this.id!, relativeUris);
        }

        r["numberField"] = ISavable.Save(this.numberField, false, this.id!, relativeUris);

        r["enumField"] = ISavable.Save(this.enumField, false, this.id!, relativeUris);


        if (top)
        {
            if (this.loadingOptions.namespaces != null)
            {
                r["$namespaces"] = this.loadingOptions.namespaces;
            }
            if (this.loadingOptions.schemas != null)
            {
                r["$schemas"] = this.loadingOptions.schemas;
            }
        }

        return r;
    }

    static readonly HashSet<string> attr = new() { "id", "labelField", "numberField", "enumField" };
}

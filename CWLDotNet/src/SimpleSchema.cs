using System.Collections;

namespace CWLDotNet;

public class SimpleSchema : Savable
{

    LoadingOptions loadingOptions;

    public string id;

    public string? labelField;

    public int numberField;

    public SimpleEnum enumField;

    public SimpleSchema(string id, string? labelField, int numberField, SimpleEnum enumField, LoadingOptions? loadingOptions = null)
    {
        this.loadingOptions = loadingOptions ?? new LoadingOptions();
        this.id = id;
        this.labelField = labelField;
        this.numberField = numberField;
        this.enumField = enumField;
    }

    public static Savable fromDoc(object doc, string baseUri, LoadingOptions loadingOptions, string? docRoot = null)
    {
        List<ValidationException> errors = new();

        if (!(doc is IDictionary))
        {
            throw new ValidationException("Document has to be of type map");
        }

        Dictionary<object, object> doc_ = (Dictionary<object, object>)doc;

        string? id = null;
        if (doc_.ContainsKey("id"))
        {
            try
            {
                id = ((Loader<string>)LoaderInstnaces.stringLoader).LoadField(doc_["id"], baseUri, loadingOptions);
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

        string? label = null;
        if (doc_.ContainsKey("id"))
        {
            try
            {
                label = ((Loader<string>)LoaderInstnaces.stringLoader).LoadField(doc_["labelField"], baseUri, loadingOptions);
            }
            catch (ValidationException e)
            {
                errors.Add(new ValidationException("The `labelField` field ist not valid because: ", e));
            }
        }

        int number = 0;
        try
        {
            number = ((Loader<int>)LoaderInstnaces.intLoader).LoadField(doc_["numberField"], baseUri, loadingOptions);
        }
        catch (ValidationException e)
        {
            errors.Add(new ValidationException("The `numberField` field ist not valid because: ", e));
        }

        SimpleEnum enumField = SimpleEnum.A;
        try
        {
            enumField = ((Loader<SimpleEnum>)LoaderInstnaces.simpleEnumLoader).LoadField(doc_["enumField"], baseUri, loadingOptions);
        }
        catch (ValidationException e)
        {
            errors.Add(new ValidationException("The `enumField` field ist not valid because: ", e));
        }

        if (errors.Count > 0)
        {
            throw new ValidationException("", errors);
        }

        return new SimpleSchema(id, label, number, enumField, loadingOptions);
    }
}
using System.Collections;

namespace CWLDotNet;
public class ArrayLoader<T> : Loader<List<T>>
{
    private readonly Loader<T> itemLoader;

    public ArrayLoader(in Loader<T> itemLoader)
    {
        this.itemLoader = itemLoader;
    }

    public List<T> Load(in object doc, in string baseuri, in LoadingOptions loadingOptions, in string? docRoot = null)
    {
        if(doc == null) {
            throw new ValidationException("Expected non null");
        }
        
        if (!(doc is IList))
        {
            throw new ValidationException("Expected list");
        }

        IList docList = (IList)doc;
        List<T> returnValue = new List<T>();
        List<Loader> loaders = new List<Loader>();
        loaders.Add(this);
        loaders.Add(itemLoader);
        UnionLoader unionLoader = new UnionLoader(loaders);
        List<ValidationException> errors = new List<ValidationException>();

        foreach (object e1 in docList)
        {
            try
            {
                var loadedField = unionLoader.Load(e1, baseuri, loadingOptions, docRoot);
                if (loadedField is IList)
                {
                    returnValue.AddRange((List<T>)loadedField);
                }
                else
                {
                    returnValue.Add((T)loadedField);
                }
            }
            catch (ValidationException e)
            {
                errors.Add(e);
            }
        }

        if (errors.Count > 0)
        {
            throw new ValidationException("", errors);
        }

        return returnValue;
    }

    object Loader.Load(in object doc, in string baseuri, in LoadingOptions loadingOptions, in string? docRoot)
    {
        return Load(doc, baseuri, loadingOptions, docRoot);
    }
}
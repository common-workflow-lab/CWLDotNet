namespace CWLDotNet;
public class PrimitiveLoader<T> : Loader<T>
{
    public T Load(in object doc, in string baseuri, in LoadingOptions loadingOptions, in string? docRoot = null) 
    {
        if(doc == null) {
            throw new ValidationException("Expected non null");
        }

        if(!(doc is T)) {
            throw new ValidationException($"Expected object with type of {typeof(T)} but got {doc.GetType()}");
        }
        
        return (T) doc;
    }

    object Loader.Load(in object doc, in string baseuri, in LoadingOptions loadingOptions, in string? docRoot)
    {
        return Load(doc,
                    baseuri,
                    loadingOptions,
                    docRoot)!;
    }
}


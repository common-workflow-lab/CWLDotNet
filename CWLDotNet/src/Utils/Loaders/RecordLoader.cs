using System.Collections;

namespace CWLDotNet;
public class RecordLoader<T> : Loader<T> where T: Savable
{
    public T Load(in object doc, in string baseUri, in LoadingOptions loadingOptions, in string? docRoot = null)
    {
        if(!(doc is IDictionary)) {
            throw new ValidationException($"Expected object with type of Dictionary but got {doc.GetType()}");
        }
        return (T)T.FromDoc(doc, baseUri, loadingOptions, docRoot);
    }

    object Loader.Load(in object doc, in string baseuri, in LoadingOptions loadingOptions, in string? docRoot)
    {
        return Load(doc,
                    baseuri,
                    loadingOptions,
                    docRoot)!;
    }
}


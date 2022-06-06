using System.Collections;

namespace CWLDotNet;

public class UriLoader<T> : Loader<T>
{
    Loader<T> inner;
    bool scopedID;
    bool vocabTerm;
    int? scopedRef;

    public UriLoader(in Loader<T> inner, in bool scopedID, in bool vocabTerm, in int? scopedRef)
    {
        this.inner = inner;
        this.scopedID = scopedID;
        this.vocabTerm = vocabTerm;
        this.scopedRef = scopedRef;
    }

    public T Load(in object doc_, in string baseuri, in LoadingOptions loadingOptions, in string? docRoot = null)
    {
        object doc = doc_;
        if(doc is IList) {
            var docList = (List<object>) doc_;
            var docWithExpansion = new List<object>();
            foreach(var val in docList) {
                if(val is string) {
                    docWithExpansion.Add(loadingOptions.ExpandUrl((string)val, baseuri, scopedID, vocabTerm, scopedRef));
                } else {
                    docWithExpansion.Add(val);
                }
            }
            doc = docWithExpansion;
        } else if(doc is string) {
            doc = loadingOptions.ExpandUrl((string) doc, baseuri, scopedID, vocabTerm, scopedRef);
        }
        return this.inner.Load(doc, baseuri, loadingOptions);
    }

    object Loader.Load(in object doc, in string baseuri, in LoadingOptions loadingOptions, in string? docRoot)
    {
        return Load(doc,
                    baseuri,
                    loadingOptions,
                    docRoot)!;
    }
}

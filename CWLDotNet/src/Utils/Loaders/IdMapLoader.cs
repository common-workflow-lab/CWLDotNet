using System.Collections;

namespace CWLDotNet;

public class IdMapLoader<T> : Loader<T>
{
    Loader<T> inner;
    string mapSubject;
    string? mapPredicate;
    public IdMapLoader(Loader<T> inner, string mapSubject, string? mapPredicate) {
        this.inner = inner;
        this.mapSubject = mapSubject;
        this.mapPredicate = mapPredicate;
    }
    public T Load(in object doc_, in string baseuri, in LoadingOptions loadingOptions, in string? docRoot = null) 
    {
        object doc = doc_;
        if(doc_ is IDictionary) {
            List<object> r = new List<object>();
            foreach(var k in ((Dictionary<string, object>)doc).Keys.OrderBy(p => p)) {
                object val = ((Dictionary<string, object>)doc)[k];
                if(val is IDictionary) {
                    var v2 = new Dictionary<string, object>((Dictionary<string, object>)val);
                    r.Add(v2);
                }else {
                    if(mapPredicate != null) {
                        var v3 = new Dictionary<string, object>();
                        v3[mapPredicate] = val;
                        v3[mapSubject] = k;
                        r.Add(v3);
                    } else {
                        throw new ValidationException("No mapPredicate was specified");
                    }
                }
            }
            doc = r;
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

using System.Collections;
using System.Text.RegularExpressions;

namespace CWLDotNet;

public class TypeDSLLoader<T> : Loader<T>
{
    Loader<T> inner;
    int refScope;

    private static Regex TYPE_DSL_REGEX = new Regex(@"^([^\\[?]+)(\\[\\])?(\\?)?$");
    public TypeDSLLoader(in Loader<T> inner, in int refScope)
    {
        this.inner = inner;
        this.refScope = refScope;
    }

    private object resolve(in string doc_, in string baseuri, in LoadingOptions loadingOptions)
    {
        var m = TYPE_DSL_REGEX.Match(doc_);
        if (m.Success)
        {
            string first = loadingOptions.ExpandUrl(m.Groups[1].ToString(), baseuri, false, true, this.refScope);
            object? second = null;
            object? third = null;
            if (m.Groups.Count >= 3 && m.Groups[2].Length > 0)
            {
                Dictionary<string, object> resolveMap = new();
                resolveMap.Add("type", "array");
                resolveMap.Add("items", first);
                second = resolveMap;
            }
            if (m.Groups.Count >= 4 && m.Groups[3].Length > 0)
            {
                third = new List<object> { "null", second ?? first };
            }
            return third ?? second ?? first;
        }
        return doc_;
    }

    public T Load(in object doc_, in string baseuri, in LoadingOptions loadingOptions, in string? docRoot = null)
    {
        object doc = doc_;
        if (doc is IList)
        {
            List<object> docList = (List<object>)doc;
            List<object> r = new List<object>();
            foreach (var d in docList)
            {
                if (d is string)
                {
                    var resolved = this.resolve((string)d, baseuri, loadingOptions);
                    if (resolved is IList)
                    {
                        var resolvedList = (List<object>)resolved;
                        foreach (var i in resolvedList)
                        {
                            if (!r.Contains(i))
                            {
                                r.Add(i);
                            }
                        }
                    }
                    else
                    {
                        if (!r.Contains(resolved))
                        {
                            r.Add(resolved);
                        }
                    }
                } else {
                    r.Add(d);
                }
            }
            doc = docList;
        }else if(doc is string) {
            doc = this.resolve((string) doc, baseuri, loadingOptions);
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

﻿using System.Collections;

namespace CWLDotNet;

public class IdMapLoader<T> : ILoader<T>
{
    readonly ILoader<T> inner;
    readonly string mapSubject;
    readonly string? mapPredicate;

    public IdMapLoader(ILoader<T> inner, string mapSubject, string? mapPredicate)
    {
        this.inner = inner;
        this.mapSubject = mapSubject;
        this.mapPredicate = mapPredicate;
    }

    public T Load(in object doc_, in string baseuri, in LoadingOptions loadingOptions, in string? docRoot = null)
    {
        object doc = doc_;
        if (doc_ is IDictionary)
        {
            List<object> r = new();
            foreach (string? k in ((Dictionary<string, object>)doc).Keys.OrderBy(p => p))
            {
                object val = ((Dictionary<string, object>)doc)[k];
                if (val is IDictionary)
                {
                    Dictionary<string, object> v2 = new((Dictionary<string, object>)val);
                    r.Add(v2);
                }
                else
                {
                    if (mapPredicate != null)
                    {
                        Dictionary<string, object> v3 = new()
                        {
                            [mapPredicate] = val,
                            [mapSubject] = k
                        };
                        r.Add(v3);
                    }
                    else
                    {
                        throw new ValidationException("No mapPredicate was specified");
                    }
                }
            }
            doc = r;
        }
        return inner.Load(doc, baseuri, loadingOptions);
    }

    object ILoader.Load(in object doc, in string baseuri, in LoadingOptions loadingOptions, in string? docRoot)
    {
        return Load(doc,
                    baseuri,
                    loadingOptions,
                    docRoot)!;
    }
}

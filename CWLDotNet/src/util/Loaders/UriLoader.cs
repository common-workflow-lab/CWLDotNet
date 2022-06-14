﻿using System.Collections;

namespace CWLDotNet;

internal class UriLoader<T> : ILoader<T>
{
    readonly ILoader<T> inner;
    readonly bool scopedID;
    readonly bool vocabTerm;
    readonly int? scopedRef;

    public UriLoader(in ILoader<T> inner, in bool scopedID, in bool vocabTerm, in int? scopedRef)
    {
        this.inner = inner;
        this.scopedID = scopedID;
        this.vocabTerm = vocabTerm;
        this.scopedRef = scopedRef;
    }

    public T Load(in object doc_, in string baseuri, in LoadingOptions loadingOptions, in string? docRoot = null)
    {
        object doc = doc_;
        if (doc is IList)
        {
            List<object> docList = (List<object>)doc_;
            List<object> docWithExpansion = new();
            foreach (object val in docList)
            {
                if (val is string valString)
                {
                    docWithExpansion.Add(loadingOptions.ExpandUrl(valString, baseuri, scopedID, vocabTerm, scopedRef));
                }
                else
                {
                    docWithExpansion.Add(val);
                }
            }

            doc = docWithExpansion;
        }
        else if (doc is string docString)
        {
            doc = loadingOptions.ExpandUrl(docString, baseuri, scopedID, vocabTerm, scopedRef);
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

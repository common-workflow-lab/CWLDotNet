﻿using System.Collections;

namespace CWLDotNet;

internal class ArrayLoader<T> : ILoader<List<T>>
{
    private readonly ILoader itemLoader;

    public ArrayLoader(in ILoader itemLoader)
    {
        this.itemLoader = itemLoader;
    }

    public List<T> Load(in object doc, in string baseuri, in LoadingOptions loadingOptions, in string? docRoot = null)
    {
        if (doc == null)
        {
            throw new ValidationException("Expected non null");
        }

        if (doc is not IList)
        {
            throw new ValidationException("Expected list");
        }

        IList docList = (IList)doc;
        List<T> returnValue = new();
        List<ILoader> loaders = new()
        {
            this,
            itemLoader
        };
        UnionLoader unionLoader = new(loaders);
        List<ValidationException> errors = new();

        foreach (object? e1 in docList)
        {
            try
            {
                object loadedField = unionLoader.Load(e1, baseuri, loadingOptions, docRoot);
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

    object ILoader.Load(in object doc, in string baseuri, in LoadingOptions loadingOptions, in string? docRoot)
    {
        return Load(doc, baseuri, loadingOptions, docRoot);
    }
}

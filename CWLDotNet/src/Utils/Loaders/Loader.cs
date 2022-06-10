﻿using System.Collections;
using YamlDotNet.Serialization;

namespace CWLDotNet;

internal interface ILoader
{
    object Load(in object doc, in string baseUri, in LoadingOptions loadingOptions, in string? docRoot = null);
}

internal interface ILoader<T> : ILoader
{
    new T Load(in object doc, in string baseuri, in LoadingOptions loadingOptions, in string? docRoot = null);

    T LoadField(in object value_, in string baseUri, in LoadingOptions loadingOptions)
    {
        object value = value_;
        if (value is IDictionary)
        {
            Dictionary<object, object> valMap = (Dictionary<object, object>)value;
            if (valMap.ContainsKey("$import"))
            {
                if (loadingOptions.fileUri == null)
                {
                    throw new ValidationException("Cannot load $import without fileuri");
                }

                return DocumentLoadByUrl(loadingOptions.fetcher.Urljoin(loadingOptions.fileUri, (string)valMap["$import"]), loadingOptions);
            }
            else if (valMap.ContainsKey("$include"))
            {
                if (loadingOptions.fileUri == null)
                {
                    throw new ValidationException("Cannot load $import without fileuri");
                }

                value = loadingOptions.fetcher
                    .FetchText(loadingOptions.fetcher.Urljoin(loadingOptions.fileUri, (string)valMap["$include"]));
            }
        }

        return Load(value, baseUri, loadingOptions);
    }

    T DocumentLoad(in string doc, in string baseUri, in LoadingOptions loadingOptions)
    {
        return Load(doc, baseUri, loadingOptions);
    }

    T DocumentLoad(in List<object> doc, in string baseUri, in LoadingOptions loadingOptions)
    {
        return Load(doc, baseUri, loadingOptions);
    }

    T DocumentLoad(in Dictionary<object, object> doc_, in string baseUri_, in LoadingOptions loadingOptions_)
    {
        Dictionary<object, object> doc = doc_;
        LoadingOptions loadingOptions = loadingOptions_;
        if (doc.ContainsKey("$namespaces"))
        {
            Dictionary<string, string> namespaces = (Dictionary<string, string>)doc["$namespaces"];
            loadingOptions = new LoadingOptions(copyFrom: loadingOptions, namespaces: namespaces);
            doc = new Dictionary<object, object>(doc);
            doc.Remove("$namespaces");
        }

        string baseUri = baseUri_;
        if (doc.ContainsKey("$base"))
        {
            baseUri = (string)doc["$base"];
        }

        if (doc.ContainsKey("$graph"))
        {
            return Load(doc["$graph"], baseUri, loadingOptions);
        }
        else
        {
            return Load(doc, baseUri, loadingOptions, baseUri);
        }
    }

    T DocumentLoadByUrl(in string url, in LoadingOptions loadingOptions)
    {
        if (loadingOptions.idx.ContainsKey(url))
        {
            object result = loadingOptions.idx[url];
            if (result is string resultString)
            {
                return DocumentLoad(resultString, url, loadingOptions);
            }
            else if (result is IDictionary)
            {
                return DocumentLoad((Dictionary<object, object>)result, url, loadingOptions);
            }

            return Load(result, url, loadingOptions);
        }

        string text = loadingOptions.fetcher.FetchText(url);
        IDeserializer deserializer = new DeserializerBuilder().WithNodeTypeResolver(new ScalarNodeTypeResolver()).Build();
        object? yamlObject = deserializer.Deserialize(new StringReader(text));
        if (yamlObject is IDictionary)
        {
            return DocumentLoad((Dictionary<object, object>)yamlObject, url, new LoadingOptions(copyFrom: loadingOptions, fileUri: url));
        }
        else if (yamlObject is IList)
        {
            return DocumentLoad((List<object>)yamlObject, url, new LoadingOptions(copyFrom: loadingOptions, fileUri: url));
        }

        throw new NotImplementedException();
    }
}


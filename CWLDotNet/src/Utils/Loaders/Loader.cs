using System.Collections;
using YamlDotNet.Serialization;

namespace CWLDotNet;

public interface Loader
{
    object Load(in object doc, in string baseUri, in LoadingOptions loadingOptions, in string? docRoot = null);
}
public interface Loader<T> : Loader
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
                return documentLoadByUrl(loadingOptions.fetcher.Urljoin(loadingOptions.fileUri, (string)valMap["$import"]), loadingOptions);
            }
            else if (valMap.ContainsKey("$include"))
            {
                if (loadingOptions.fileUri == null)
                {
                    throw new ValidationException("Cannot load $import without fileuri");
                }
                value = loadingOptions.fetcher.FetchText(loadingOptions.fetcher.Urljoin(loadingOptions.fileUri, (string)valMap["$include"]));
            }
        }
        return Load(value, baseUri, loadingOptions);
    }

    T documentLoad(in string doc, in string baseUri, in LoadingOptions loadingOptions)
    {
        return Load(doc, baseUri, loadingOptions);
    }

    T documentLoad(in List<object> doc, in string baseUri, in LoadingOptions loadingOptions)
    {
        return Load(doc, baseUri, loadingOptions);
    }

    T documentLoad(in Dictionary<object, object> doc_, in string baseUri_, in LoadingOptions loadingOptions_)
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

    T documentLoadByUrl(in string url, in LoadingOptions loadingOptions)
    {
        if (loadingOptions.idx.ContainsKey(url))
        {
            var result = loadingOptions.idx[url];
            if (result is string)
            {
                return documentLoad((string)result, url, loadingOptions);
            }
            else if (result is IDictionary)
            {
                return documentLoad((Dictionary<object, object>)result, url, loadingOptions);
            }
            return Load(result, url, loadingOptions);
        }
        string text = loadingOptions.fetcher.FetchText(url);
        var deserializer = new DeserializerBuilder().WithNodeTypeResolver(new ScalarNodeTypeResolver()).Build();
        var yamlObject = deserializer.Deserialize(new StringReader(text));
        if (yamlObject is IDictionary)
        {
            return documentLoad((Dictionary<object, object>)yamlObject, url, new LoadingOptions(copyFrom: loadingOptions, fileUri: url));
        }
        else if (yamlObject is IList)
        {
            return documentLoad((List<object>)yamlObject, url, new LoadingOptions(copyFrom: loadingOptions, fileUri: url));
        }
        throw new NotImplementedException();

    }
}


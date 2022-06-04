using System.Collections;

namespace CWLDotNet;

public class SecondaryDSLLoader<T> : Loader<T>
{
    Loader<T> inner;

    public SecondaryDSLLoader(Loader<T> inner)
    {
        this.inner = inner;
    }
    public T Load(in object doc_, in string baseuri, in LoadingOptions loadingOptions, in string? docRoot = null)
    {
        var r = new List<Dictionary<string, object>>();
        var doc = doc_;
        if (doc is IList)
        {
            var docList = (List<object>)doc;
            foreach (var d in docList)
            {
                Dictionary<string, object> entry = new();
                if (d is string)
                {

                    var dString = (string)d;
                    if (dString.EndsWith("?"))
                    {
                        entry.Add("pattern", dString.Substring(0, dString.Length - 1));
                        entry.Add("required", false);

                    }
                    else
                    {
                        entry.Add("pattern", dString);
                    }
                    r.Add(entry);
                }
                else if (d is IDictionary)
                {
                    Dictionary<string, object> dMap = new Dictionary<string, object>((Dictionary<string, object>)d);
                    if (dMap.ContainsKey("pattern"))
                    {
                        entry.Add("pattern", dMap["pattern"]);
                        dMap.Remove("pattern");
                    }
                    else
                    {
                        throw new ValidationException("Missing 'pattern' in secondaryFiles specification entry.");
                    }

                    if (dMap.ContainsKey("required"))
                    {
                        entry.Add("required", dMap["required"]);
                        dMap.Remove("required");
                    }

                    if (dMap.Count > 0)
                    {
                        throw new ValidationException("Unallowed values in secondaryFiles specification entry");
                    }
                    r.Add(entry);
                }
                else
                {
                    throw new ValidationException("Expected a string or sequence of (strings or mappings).");
                }
            }
        }
        else if (doc is IDictionary)
        {
            Dictionary<string, object> entry = new Dictionary<string, object>();
            Dictionary<string, object> dMap = new Dictionary<string, object>((Dictionary<string, object>)doc);
            if (dMap.ContainsKey("pattern"))
            {
                entry.Add("pattern", dMap["pattern"]);
                dMap.Remove("pattern");
            }
            else
            {
                throw new ValidationException("Missing 'pattern' in secondaryFiles specification entry.");
            }
            if (dMap.ContainsKey("required"))
            {
                entry.Add("required", dMap["required"]);
                dMap.Remove("required");
            }
            if (dMap.Count > 0)
            {
                throw new ValidationException("Unallowed values in secondaryFiles specification entry.");
            }
            r.Add(entry);
        }
        else if (doc is String)
        {
            string dString = (string)doc;
            Dictionary<string, object> entry = new Dictionary<string, object>();
            if (dString.EndsWith("?"))
            {
                entry.Add("pattern", dString.Substring(0, dString.Length - 1));
                entry.Add("required", false);
            }
            else
            {
                entry.Add("pattern", dString);
            }
            r.Add(entry);
        }
        else
        {
            throw new ValidationException("Expected a string or sequence of (strings or mappings).");
        }
        return this.inner.Load(r, baseuri, loadingOptions, docRoot);
    }

    object Loader.Load(in object doc, in string baseuri, in LoadingOptions loadingOptions, in string? docRoot)
    {
        return Load(doc,
                    baseuri,
                    loadingOptions,
                    docRoot)!;
    }
}

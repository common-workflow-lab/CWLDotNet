using System.Collections;

public interface Savable
{
    public abstract static Savable FromDoc(object doc, string baseUri, LoadingOptions loadingOptions, string? docRoot = null);
    public abstract Dictionary<object, object> Save(bool top, string baseUrl, bool relativeUris);

    public static object Save(object val, bool top = true, string baseurl = "", bool relativeUris = true)
    {
        if (val is Savable)
        {
            var valSaveable = (Savable)val;
            return (valSaveable).Save(top, baseurl, relativeUris);
        }

        if (val is IList)
        {
            var r = new List<object>();
            var valList = (List<object>)val;
            foreach (var v in valList)
            {
                r.Add(Save(v, false, baseurl, relativeUris));
            }
            return r;
        }

        if (val is IDictionary)
        {
            var valDict = (Dictionary<object, object>)val;
            var newDict = new Dictionary<object, object>();
            foreach (var entry in valDict)
            {
                newDict[entry.Key] = Save(entry.Value, false, baseurl, relativeUris);
            }
            return newDict;
        }
        return val;
    }

    public static object SaveRelativeUri(object uri, bool scopedId, bool relativeUris, int? refScope, string baseUrl = "")
    {
        if (relativeUris == false || (uri is string && (string)uri == baseUrl))
        {
            return uri;
        }

        if (uri is IList)
        {
            var uriList = (List<object>)uri;
            var r = new List<object>();
            foreach (var v in uriList)
            {
                r.Add(SaveRelativeUri(v, scopedId, relativeUris, refScope, baseUrl));
            }
            return r;
        }
        else if (uri is string)
        {
            var uriString = (string)uri;
            var uriSplit = new Uri(uriString, UriKind.RelativeOrAbsolute);
            var baseSplit = new Uri(baseUrl, UriKind.RelativeOrAbsolute);
            if ((!uriSplit.IsAbsoluteUri && !baseSplit.IsAbsoluteUri) || (uriSplit.IsAbsoluteUri && uriSplit.AbsolutePath.Length < 1) || (baseSplit.IsAbsoluteUri && baseSplit.AbsolutePath.Length < 1))
            {
                throw new ValidationException("Uri or baseurl need to contain a path");
            }

            if (uriSplit.IsAbsoluteUri && baseSplit.IsAbsoluteUri)
            {
                if (uriSplit.Scheme == baseSplit.Scheme && uriSplit.Host == baseSplit.Host)
                {
                    if (uriSplit.AbsolutePath != baseSplit.AbsolutePath)
                    {
                        var p = Path.GetRelativePath(Path.GetDirectoryName(baseSplit.AbsolutePath)!, uriSplit.AbsolutePath);
                        if (uriSplit.Fragment.Length > 0)
                        {
                            p = p + "#" + uriSplit.Fragment;
                        }
                        return p;
                    }
                }
            }

            if (baseSplit.IsAbsoluteUri)
            {
                var baseFrag = baseSplit.Fragment + "/";
                if (refScope != null)
                {
                    var sp = baseFrag.Split('/').ToList();
                    var i = 0;
                    while (i < refScope)
                    {
                        sp.RemoveAt(sp.Count - 1);
                        i += 1;
                    }
                    baseFrag = string.Join('/', sp);
                }
                string f = "";
                if (uriSplit.IsAbsoluteUri && uriSplit.Fragment.StartsWith(baseFrag))
                {
                    return uriSplit.Fragment.Substring(baseFrag.Length);
                }
                else if (uriSplit.IsAbsoluteUri)
                {
                    return uriSplit.Fragment;
                } else {
                    return String.Empty;
                }
            }

            throw new ValidationException("BaseUrl needs to be absolute");
        }
        else
        {
            return Save(uri, false, baseUrl);
        }
    }
}
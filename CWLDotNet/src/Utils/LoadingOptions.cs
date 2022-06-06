public class LoadingOptions
{
    public Fetcher fetcher;
    public string? fileUri;
    public Dictionary<string, string>? namespaces;
    public List<string>? schemas;
    public Dictionary<string, object> idx;
    public Dictionary<string, string> vocab;
    public Dictionary<string, string> rvocab;


    public LoadingOptions(in Fetcher? fetcher = null, in string? fileUri = null, in Dictionary<string, string>? namespaces = null, in List<string>? schemas = null, in Dictionary<string, object>? idx = null, LoadingOptions? copyFrom = null)
    {
        this.fileUri = fileUri;
        this.namespaces = namespaces;
        this.schemas = schemas;
        this.idx = idx ?? new Dictionary<string, object>();

        if (copyFrom != null)
        {
            this.idx = copyFrom.idx;
            if (fetcher == null)
            {
                this.fetcher = copyFrom.fetcher;
            }

            if (fileUri == null)
            {
                this.fileUri = copyFrom.fileUri;
            }

            if (namespaces == null)
            {
                this.namespaces = copyFrom.namespaces;
            }

            if (schemas == null)
            {
                this.schemas = copyFrom.schemas;
            }
        }

        if (fetcher != null)
        {
            this.fetcher = fetcher;
        }
        else
        {
            this.fetcher = new DefaultFetcher();
        }

        this.vocab = Vocabs.vocab;
        this.rvocab = Vocabs.rvocab;

        if (namespaces != null)
        {
            this.vocab = new Dictionary<string, string>(Vocabs.vocab);
            this.rvocab = new Dictionary<string, string>(Vocabs.rvocab);
            foreach (var namespaceEntry in namespaces)
            {
                this.vocab.Add(namespaceEntry.Key, namespaceEntry.Value);
                this.rvocab.Add(namespaceEntry.Value, namespaceEntry.Key);
            }
        }
    }

    public string ExpandUrl(in string url_, string baseUrl, bool scopeId, bool vocabTerm, int? scopedRef)
    {
        string url = url_;
        if (url.Equals("@id") || url.Equals("@type"))
        {
            return url;
        }

        if (vocabTerm && this.vocab.ContainsKey(url))
        {
            return url;
        }

        if (this.vocab.Count > 0 && url.Contains(":"))
        {
            string prefix = url.Split(":", 1)[0];
            if (this.vocab.ContainsKey(prefix))
            {
                url = this.vocab[prefix] + url.Substring(prefix.Length + 1);
            }
        }

        var split = new Uri(url);
        string scheme = split.Scheme;
        bool hasFragment = split.Fragment != "";
        if ((scheme.Length > 0 && (scheme.Equals("http") || scheme.Equals("https") || scheme.Equals("file"))) || url.StartsWith("$(") || url.StartsWith("${"))
        {
            // Do nothing
        }
        else if (scopeId && !hasFragment)
        {
            var splitbase = new Uri(baseUrl);
            string frg = "";
            if (splitbase.Fragment.Length > 0)
            {
                frg = splitbase.Fragment + "/" + split.AbsolutePath;
            }
            else
            {
                frg = split.AbsolutePath;
            }
            string pt;
            if (!splitbase.AbsolutePath.Equals(""))
            {
                pt = splitbase.AbsolutePath;
            }
            else
            {
                pt = "/";
            }

            var builder = new UriBuilder();
            builder.Scheme = splitbase.Scheme;
            builder.Host = splitbase.Host;
            builder.Path = pt;
            builder.Fragment = frg;

            url = builder.ToString();
        }
        else if (scopedRef != null && !hasFragment)
        {
            var splitbase = new Uri(baseUrl);
            List<string> sp = new List<string>(splitbase.Fragment.Split("/").ToList());
            int? n = scopedRef;
            while (n > 0 && sp.Count > 0)
            {
                sp.RemoveAt(sp.Count - 1);
                n = n - 1;
            }
            sp.Add(url);
            string fragment = string.Join("/", sp);

            var builder = new UriBuilder();
            builder.Scheme = splitbase.Scheme;
            builder.Host = splitbase.Host;
            builder.Path = splitbase.AbsolutePath;
            builder.Query = splitbase.Query;
            builder.Fragment = fragment;

            url = builder.ToString();
        } else {
            url = this.fetcher.Urljoin(baseUrl, url);
        }

        if(vocabTerm) {
            split = new Uri(url);
            if(split.Scheme.Length > 0) {
                if(this.rvocab.ContainsKey(url)) {
                    return this.rvocab[url];
                }
            }
        } else {
            throw new ValidationException($"Term '{url}' not in vocabulary");
        }
        
        return url;
    }
}
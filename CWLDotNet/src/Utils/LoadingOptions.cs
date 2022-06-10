﻿namespace CWLDotNet;

public class LoadingOptions
{
    public IFetcher fetcher;
    public string? fileUri;
    public Dictionary<string, string>? namespaces;
    public List<string>? schemas;
    public Dictionary<string, object> idx;
    public Dictionary<string, string> vocab;
    public Dictionary<string, string> rvocab;


    public LoadingOptions(
        in IFetcher? fetcher = null,
        in string? fileUri = null,
        in Dictionary<string, string>? namespaces = null,
        in List<string>? schemas = null,
        in Dictionary<string, object>? idx = null,
        LoadingOptions? copyFrom = null)
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

        this.vocab = Vocabs.Vocab;
        this.rvocab = Vocabs.Rvocab;

        if (namespaces != null)
        {
            this.vocab = new Dictionary<string, string>(Vocabs.Vocab);
            this.rvocab = new Dictionary<string, string>(Vocabs.Rvocab);
            foreach (KeyValuePair<string, string> namespaceEntry in namespaces)
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

        if (vocab.Count > 0 && url.Contains(':'))
        {
            string prefix = url.Split(":", 1)[0];
            if (vocab.ContainsKey(prefix))
            {
                url = string.Concat(vocab[prefix], url.AsSpan(prefix.Length + 1));
            }
        }

        Uri split = new(url, UriKind.RelativeOrAbsolute);
        bool hasFragment = split.IsAbsoluteUri && split.Fragment != "";
        if ((split.IsAbsoluteUri && (split.Scheme.Equals("http") || split.Scheme.Equals("https") || split.Scheme.Equals("file")))
            || url.StartsWith("$(")
            || url.StartsWith("${"))
        {
            // Do nothing
        }
        else if (scopeId && !hasFragment)
        {
            Uri splitbase = new(baseUrl);
            string frg;
            if (splitbase.Fragment.Length > 0)
            {
                frg = splitbase.FragmentWithoutFragmentation() + "/" + split.AbsolutePath;
            }
            else
            {
                frg = split.IsAbsoluteUri ? split.AbsolutePath : split.OriginalString;
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

            UriBuilder builder = new()
            {
                Scheme = splitbase.Scheme,
                Host = splitbase.Host,
                Path = pt,
                Fragment = frg
            };

            url = builder.ToString();
        }
        else if (scopedRef != null && !hasFragment)
        {
            Uri splitbase = new(baseUrl);
            List<string> sp = new(splitbase.FragmentWithoutFragmentation().Split("/").ToList());
            int? n = scopedRef;
            while (n > 0 && sp.Count > 0)
            {
                sp.RemoveAt(sp.Count - 1);
                n--;
            }

            sp.Add(url);
            string fragment = string.Join("/", sp);

            UriBuilder builder = new()
            {
                Scheme = splitbase.Scheme,
                Host = splitbase.Host,
                Path = splitbase.AbsolutePath,
                Query = splitbase.Query,
                Fragment = fragment
            };

            url = builder.ToString();
        }
        else
        {
            url = fetcher.Urljoin(baseUrl, url);
        }

        if (vocabTerm)
        {
            split = new Uri(url, UriKind.RelativeOrAbsolute);
            if (split.IsAbsoluteUri && split.Scheme.Length > 0)
            {
                if (rvocab.ContainsKey(url))
                {
                    return rvocab[url];
                }
                else
                {
                    throw new ValidationException($"Term '{url}' not in vocabulary");
                }
            }
        }

        return url;
    }
}

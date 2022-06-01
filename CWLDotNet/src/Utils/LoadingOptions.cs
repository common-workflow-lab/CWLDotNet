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

        if(copyFrom != null) {
            this.idx = copyFrom.idx;
            if(fetcher == null) {
                this.fetcher = copyFrom.fetcher;
            }
            
            if(fileUri == null) {
                this.fileUri = copyFrom.fileUri;
            }

            if(namespaces == null) {
                this.namespaces = copyFrom.namespaces;
            }

            if(schemas == null) {
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
}
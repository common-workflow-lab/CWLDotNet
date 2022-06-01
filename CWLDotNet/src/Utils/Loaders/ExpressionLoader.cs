namespace CWLDotNet;
public class ExpressionLoader : Loader<string>
{
    public string Load(in object doc, in string baseuri, in LoadingOptions loadingOptions, in string? docRoot = null)
    {
        if(doc is string) {
            return (string) doc;
        } else {
            throw new ValidationException("Expected a string");
        }
    }

    object Loader.Load(in object doc, in string baseuri, in LoadingOptions loadingOptions, in string? docRoot)
    {
        return Load(doc,
                    baseuri,
                    loadingOptions,
                    docRoot)!;
    }
}


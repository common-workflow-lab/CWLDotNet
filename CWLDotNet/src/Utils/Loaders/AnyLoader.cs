namespace CWLDotNet;
public class AnyLoader : Loader<object>
{
    public object Load(in object doc, in string baseuri, in LoadingOptions loadingOptions, in string? docRoot = null)
    {
        if(doc == null) {
            throw new ValidationException("Expected non null");
        }
        return doc;
    }
}
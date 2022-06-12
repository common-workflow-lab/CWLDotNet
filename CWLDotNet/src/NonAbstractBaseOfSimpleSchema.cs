namespace CWLDotNet;

public class NonAbstractBaseOfSimpleSchema : INonAbstractBaseOfSimpleSchema, ISavable
{
    public int someIntProperty { get; set; }

    public static ISavable FromDoc(object doc, string baseUri, LoadingOptions loadingOptions, string? docRoot = null)
    {
        throw new NotImplementedException("Just for inheritance structure demonstration");
    }

    public Dictionary<object, object> Save(bool top, string baseUrl, bool relativeUris)
    {
        throw new NotImplementedException("Just for inheritance structure demonstration");
    }
}

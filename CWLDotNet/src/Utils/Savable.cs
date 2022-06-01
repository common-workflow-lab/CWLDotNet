public interface Savable {    
     public abstract static Savable fromDoc(object doc, string baseUri, LoadingOptions loadingOptions, string? docRoot = null);
}
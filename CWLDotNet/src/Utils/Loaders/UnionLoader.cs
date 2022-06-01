namespace CWLDotNet;

public class UnionLoader : Loader<object>
{
    private readonly List<Loader> alternatives;

    public UnionLoader(in List<Loader> alternatives) {
        this.alternatives = alternatives;
    }

    public object Load(in object doc, in string baseuri, in LoadingOptions loadingOptions, in string? docRoot = null)
    {
        List<ValidationException> errors = new();

        foreach(var loader in this.alternatives) {
            try {
                return loader.Load(doc, baseuri, loadingOptions, docRoot);
            } catch (ValidationException e) {
                errors.Add(e);
            }
        }
        throw new ValidationException("Failed to match union type", errors);
    }
}
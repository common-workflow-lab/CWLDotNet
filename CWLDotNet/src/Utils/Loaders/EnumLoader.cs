namespace CWLDotNet;
public class EnumLoader<T> : ILoader<T> where T : struct, Enum
{
    public T Load(in object doc, in string baseuri, in LoadingOptions loadingOptions, in string? docRoot = null)
    {
        if (doc is not string)
        {
            throw new ValidationException("Expected a string");
        }

        if (Enum.IsDefined(typeof(T), doc))
        {
            T val = Enum.Parse<T>((string)doc);
            return val;
        }
        else
        {
            throw new ValidationException(
                $"Symbol not contained in {typeof(T).Name} Enum, expected one of {string.Join(", ", Enum.GetNames(typeof(T)))}");
        }
    }

    object ILoader.Load(in object doc, in string baseuri, in LoadingOptions loadingOptions, in string? docRoot)
    {
        return Load(doc,
                    baseuri,
                    loadingOptions,
                    docRoot)!;
    }
}


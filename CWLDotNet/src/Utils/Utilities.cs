namespace CWLDotNet;

public static class Utilities
{
    /**
     * Compute the shortname of a fully qualified identifer.
     * See https://w3id.org/cwl/v1.2/SchemaSalad.html#Short_names. 
     *
     */
    public static string Shortname(string inputId)
    {
        var parsedId = new Uri(inputId);
        if (parsedId.IsAbsoluteUri && parsedId.Fragment != "")
        {
            var fragmentSplit = parsedId.FragmentWithoutFragmentation().Split('/');
            return fragmentSplit[fragmentSplit.Length - 1];
        }
        else if (parsedId.IsAbsoluteUri && parsedId.AbsolutePath != null)
        {
            var pathSplit = parsedId.AbsolutePath.Split('/');
            return pathSplit[pathSplit.Length - 1];
        }
        else
        {
            return inputId;
        }
    }
}

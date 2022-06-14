namespace CWLDotNet;

public class LoadListingRequirement_class : IEnumClass<LoadListingRequirement_class>
{
    private string _Name;
    private static readonly List<LoadListingRequirement_class> members = new();
    public static readonly LoadListingRequirement_class LOADLISTINGREQUIREMENT =
                            new("LoadListingRequirement");

    public string Name
    {
        get { return _Name; }
        private set { _Name = value; }
    }

    public static IList<LoadListingRequirement_class> Members
    {
        get { return members; }
    }

    private LoadListingRequirement_class(string name)
    {
        _Name = name;
        members.Add(this);
    }

    public static LoadListingRequirement_class Parse(string toParse)
    {
        foreach (LoadListingRequirement_class s in Members)
        {
            if (toParse == s.Name)
                return s;
        }

        throw new FormatException("Could not parse string.");
    }

    public static bool Contains(string value)
    {
        bool contains = false;
        foreach (LoadListingRequirement_class s in Members)
        {
            if (value == s.Name)
            {
                contains = true;
                return contains;
            }

        }

        return contains;
    }

    public static List<string> Symbols()
    {
        return members.Select(m => m.Name).ToList();
    }

    public override string ToString()
    {
        return _Name;
    }
}

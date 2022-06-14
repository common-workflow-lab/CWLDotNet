namespace CWLDotNet;

public class LoadListingEnum : IEnumClass<LoadListingEnum>
{
    private string _Name;
    private static readonly List<LoadListingEnum> members = new();
    public static readonly LoadListingEnum NO_LISTING =
                            new("no_listing");
    public static readonly LoadListingEnum SHALLOW_LISTING =
                            new("shallow_listing");
    public static readonly LoadListingEnum DEEP_LISTING =
                            new("deep_listing");

    public string Name
    {
        get { return _Name; }
        private set { _Name = value; }
    }

    public static IList<LoadListingEnum> Members
    {
        get { return members; }
    }

    private LoadListingEnum(string name)
    {
        _Name = name;
        members.Add(this);
    }

    public static LoadListingEnum Parse(string toParse)
    {
        foreach (LoadListingEnum s in Members)
        {
            if (toParse == s.Name)
                return s;
        }

        throw new FormatException("Could not parse string.");
    }

    public static bool Contains(string value)
    {
        bool contains = false;
        foreach (LoadListingEnum s in Members)
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

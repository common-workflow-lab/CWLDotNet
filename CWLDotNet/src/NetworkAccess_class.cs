namespace CWLDotNet;

public class NetworkAccess_class : IEnumClass<NetworkAccess_class>
{
    private string _Name;
    private static readonly List<NetworkAccess_class> members = new();

    public static readonly NetworkAccess_class NETWORKACCESS =
                            new("NetworkAccess");

    public string Name
    {
        get { return _Name; }
        private set { _Name = value; }
    }

    public static IList<NetworkAccess_class> Members
    {
        get { return members; }
    }

    private NetworkAccess_class(string name)
    {
        _Name = name;
        members.Add(this);
    }

    public static NetworkAccess_class Parse(string toParse)
    {
        foreach (NetworkAccess_class s in Members)
        {
            if (toParse == s.Name)
                return s;
        }

        throw new FormatException("Could not parse string.");
    }

    public static bool Contains(string value)
    {
        bool contains = false;
        foreach (NetworkAccess_class s in Members)
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

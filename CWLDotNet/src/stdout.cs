namespace CWLDotNet;

public class stdout : IEnumClass<stdout>
{
    private string _Name;
    private static readonly List<stdout> members = new();
    public static readonly stdout STDOUT =
                            new("stdout");

    public string Name
    {
        get { return _Name; }
        private set { _Name = value; }
    }

    public static IList<stdout> Members
    {
        get { return members; }
    }

    private stdout(string name)
    {
        _Name = name;
        members.Add(this);
    }

    public static stdout Parse(string toParse)
    {
        foreach (stdout s in Members)
        {
            if (toParse == s.Name)
                return s;
        }

        throw new FormatException("Could not parse string.");
    }

    public static bool Contains(string value)
    {
        bool contains = false;
        foreach (stdout s in Members)
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

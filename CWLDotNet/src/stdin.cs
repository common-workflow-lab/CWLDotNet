namespace CWLDotNet;

public class stdin : IEnumClass<stdin>
{
    private string _Name;
    private static readonly List<stdin> members = new();
    public static readonly stdin STDIN =
                            new("stdin");

    public string Name
    {
        get { return _Name; }
        private set { _Name = value; }
    }

    public static IList<stdin> Members
    {
        get { return members; }
    }

    private stdin(string name)
    {
        _Name = name;
        members.Add(this);
    }

    public static stdin Parse(string toParse)
    {
        foreach (stdin s in Members)
        {
            if (toParse == s.Name)
                return s;
        }

        throw new FormatException("Could not parse string.");
    }

    public static bool Contains(string value)
    {
        bool contains = false;
        foreach (stdin s in Members)
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

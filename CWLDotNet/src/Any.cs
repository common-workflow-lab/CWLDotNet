namespace CWLDotNet;

public class Any : IEnumClass<Any>
{
    private string _Name;
    private static readonly List<Any> members = new();
    public static readonly Any ANY =
                            new("Any");

    public string Name
    {
        get { return _Name; }
        private set { _Name = value; }
    }

    public static IList<Any> Members
    {
        get { return members; }
    }

    private Any(string name)
    {
        _Name = name;
        members.Add(this);
    }

    public static Any Parse(string toParse)
    {
        foreach (Any s in Members)
        {
            if (toParse == s.Name)
                return s;
        }

        throw new FormatException("Could not parse string.");
    }

    public static bool Contains(string value)
    {
        bool contains = false;
        foreach (Any s in Members)
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

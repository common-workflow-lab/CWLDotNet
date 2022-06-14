namespace CWLDotNet;

public class ToolTimeLimit_class : IEnumClass<ToolTimeLimit_class>
{
    private string _Name;
    private static readonly List<ToolTimeLimit_class> members = new();
    public static readonly ToolTimeLimit_class TOOLTIMELIMIT =
                            new("ToolTimeLimit");

    public string Name
    {
        get { return _Name; }
        private set { _Name = value; }
    }

    public static IList<ToolTimeLimit_class> Members
    {
        get { return members; }
    }

    private ToolTimeLimit_class(string name)
    {
        _Name = name;
        members.Add(this);
    }

    public static ToolTimeLimit_class Parse(string toParse)
    {
        foreach (ToolTimeLimit_class s in Members)
        {
            if (toParse == s.Name)
                return s;
        }

        throw new FormatException("Could not parse string.");
    }

    public static bool Contains(string value)
    {
        bool contains = false;
        foreach (ToolTimeLimit_class s in Members)
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

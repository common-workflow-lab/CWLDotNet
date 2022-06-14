namespace CWLDotNet;

public class CWLType : IEnumClass<CWLType>
{
    private string _Name;
    private static readonly List<CWLType> members = new();
    public static readonly CWLType FILE =
                            new("File");
    public static readonly CWLType DIRECTORY =
                            new("Directory");

    public string Name
    {
        get { return _Name; }
        private set { _Name = value; }
    }

    public static IList<CWLType> Members
    {
        get { return members; }
    }

    private CWLType(string name)
    {
        _Name = name;
        members.Add(this);
    }

    public static CWLType Parse(string toParse)
    {
        foreach (CWLType s in Members)
        {
            if (toParse == s.Name)
                return s;
        }

        throw new FormatException("Could not parse string.");
    }

    public static bool Contains(string value)
    {
        bool contains = false;
        foreach (CWLType s in Members)
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

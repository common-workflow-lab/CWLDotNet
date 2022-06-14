namespace CWLDotNet;

public class ScatterMethod : IEnumClass<ScatterMethod>
{
    private string _Name;
    private static readonly List<ScatterMethod> members = new();
    public static readonly ScatterMethod DOTPRODUCT =
                            new("dotproduct");
    public static readonly ScatterMethod NESTED_CROSSPRODUCT =
                            new("nested_crossproduct");
    public static readonly ScatterMethod FLAT_CROSSPRODUCT =
                            new("flat_crossproduct");

    public string Name
    {
        get { return _Name; }
        private set { _Name = value; }
    }

    public static IList<ScatterMethod> Members
    {
        get { return members; }
    }

    private ScatterMethod(string name)
    {
        _Name = name;
        members.Add(this);
    }

    public static ScatterMethod Parse(string toParse)
    {
        foreach (ScatterMethod s in Members)
        {
            if (toParse == s.Name)
                return s;
        }

        throw new FormatException("Could not parse string.");
    }

    public static bool Contains(string value)
    {
        bool contains = false;
        foreach (ScatterMethod s in Members)
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

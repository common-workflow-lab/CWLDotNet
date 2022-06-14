namespace CWLDotNet;

public class Directory_class : IEnumClass<Directory_class>
{
    private string _Name;
    private static readonly List<Directory_class> members = new();
    public static readonly Directory_class DIRECTORY =
                            new("Directory");

    public string Name
    {
        get { return _Name; }
        private set { _Name = value; }
    }

    public static IList<Directory_class> Members
    {
        get { return members; }
    }

    private Directory_class(string name)
    {
        _Name = name;
        members.Add(this);
    }

    public static Directory_class Parse(string toParse)
    {
        foreach (Directory_class s in Members)
        {
            if (toParse == s.Name)
                return s;
        }

        throw new FormatException("Could not parse string.");
    }

    public static bool Contains(string value)
    {
        bool contains = false;
        foreach (Directory_class s in Members)
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

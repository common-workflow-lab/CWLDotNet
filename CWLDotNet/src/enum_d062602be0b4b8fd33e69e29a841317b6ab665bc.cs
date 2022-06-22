namespace CWLDotNet;

public class enum_d062602be0b4b8fd33e69e29a841317b6ab665bc : IEnumClass<enum_d062602be0b4b8fd33e69e29a841317b6ab665bc>
{
    private string _Name;
    private static readonly List<enum_d062602be0b4b8fd33e69e29a841317b6ab665bc> members = new();

    public static readonly enum_d062602be0b4b8fd33e69e29a841317b6ab665bc ARRAY =
                            new("array");

    public string Name
    {
        get { return _Name; }
        private set { _Name = value; }
    }

    public static IList<enum_d062602be0b4b8fd33e69e29a841317b6ab665bc> Members
    {
        get { return members; }
    }

    private enum_d062602be0b4b8fd33e69e29a841317b6ab665bc(string name)
    {
        _Name = name;
        members.Add(this);
    }

    public static enum_d062602be0b4b8fd33e69e29a841317b6ab665bc Parse(string toParse)
    {
        foreach (enum_d062602be0b4b8fd33e69e29a841317b6ab665bc s in Members)
        {
            if (toParse == s.Name)
                return s;
        }

        throw new FormatException("Could not parse string.");
    }

    public static bool Contains(string value)
    {
        bool contains = false;
        foreach (enum_d062602be0b4b8fd33e69e29a841317b6ab665bc s in Members)
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

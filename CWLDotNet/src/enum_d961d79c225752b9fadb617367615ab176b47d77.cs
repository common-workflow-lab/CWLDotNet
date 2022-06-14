namespace CWLDotNet;

public class enum_d961d79c225752b9fadb617367615ab176b47d77 : IEnumClass<enum_d961d79c225752b9fadb617367615ab176b47d77>
{
    private string _Name;
    private static readonly List<enum_d961d79c225752b9fadb617367615ab176b47d77> members = new();
    public static readonly enum_d961d79c225752b9fadb617367615ab176b47d77 ENUM =
                            new("enum");

    public string Name
    {
        get { return _Name; }
        private set { _Name = value; }
    }

    public static IList<enum_d961d79c225752b9fadb617367615ab176b47d77> Members
    {
        get { return members; }
    }

    private enum_d961d79c225752b9fadb617367615ab176b47d77(string name)
    {
        _Name = name;
        members.Add(this);
    }

    public static enum_d961d79c225752b9fadb617367615ab176b47d77 Parse(string toParse)
    {
        foreach (enum_d961d79c225752b9fadb617367615ab176b47d77 s in Members)
        {
            if (toParse == s.Name)
                return s;
        }

        throw new FormatException("Could not parse string.");
    }

    public static bool Contains(string value)
    {
        bool contains = false;
        foreach (enum_d961d79c225752b9fadb617367615ab176b47d77 s in Members)
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

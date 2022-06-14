namespace CWLDotNet;

public class SoftwareRequirement_class : IEnumClass<SoftwareRequirement_class>
{
    private string _Name;
    private static readonly List<SoftwareRequirement_class> members = new();
    public static readonly SoftwareRequirement_class SOFTWAREREQUIREMENT =
                            new("SoftwareRequirement");

    public string Name
    {
        get { return _Name; }
        private set { _Name = value; }
    }

    public static IList<SoftwareRequirement_class> Members
    {
        get { return members; }
    }

    private SoftwareRequirement_class(string name)
    {
        _Name = name;
        members.Add(this);
    }

    public static SoftwareRequirement_class Parse(string toParse)
    {
        foreach (SoftwareRequirement_class s in Members)
        {
            if (toParse == s.Name)
                return s;
        }

        throw new FormatException("Could not parse string.");
    }

    public static bool Contains(string value)
    {
        bool contains = false;
        foreach (SoftwareRequirement_class s in Members)
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

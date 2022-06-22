namespace CWLDotNet;

public class EnvVarRequirement_class : IEnumClass<EnvVarRequirement_class>
{
    private string _Name;
    private static readonly List<EnvVarRequirement_class> members = new();

    public static readonly EnvVarRequirement_class ENVVARREQUIREMENT =
                            new("EnvVarRequirement");

    public string Name
    {
        get { return _Name; }
        private set { _Name = value; }
    }

    public static IList<EnvVarRequirement_class> Members
    {
        get { return members; }
    }

    private EnvVarRequirement_class(string name)
    {
        _Name = name;
        members.Add(this);
    }

    public static EnvVarRequirement_class Parse(string toParse)
    {
        foreach (EnvVarRequirement_class s in Members)
        {
            if (toParse == s.Name)
                return s;
        }

        throw new FormatException("Could not parse string.");
    }

    public static bool Contains(string value)
    {
        bool contains = false;
        foreach (EnvVarRequirement_class s in Members)
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

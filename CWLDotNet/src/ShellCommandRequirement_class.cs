namespace CWLDotNet;

public class ShellCommandRequirement_class : IEnumClass<ShellCommandRequirement_class>
{
    private string _Name;
    private static readonly List<ShellCommandRequirement_class> members = new();

    public static readonly ShellCommandRequirement_class SHELLCOMMANDREQUIREMENT =
                            new("ShellCommandRequirement");

    public string Name
    {
        get { return _Name; }
        private set { _Name = value; }
    }

    public static IList<ShellCommandRequirement_class> Members
    {
        get { return members; }
    }

    private ShellCommandRequirement_class(string name)
    {
        _Name = name;
        members.Add(this);
    }

    public static ShellCommandRequirement_class Parse(string toParse)
    {
        foreach (ShellCommandRequirement_class s in Members)
        {
            if (toParse == s.Name)
                return s;
        }

        throw new FormatException("Could not parse string.");
    }

    public static bool Contains(string value)
    {
        bool contains = false;
        foreach (ShellCommandRequirement_class s in Members)
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

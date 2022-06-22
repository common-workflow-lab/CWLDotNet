namespace CWLDotNet;

public class InitialWorkDirRequirement_class : IEnumClass<InitialWorkDirRequirement_class>
{
    private string _Name;
    private static readonly List<InitialWorkDirRequirement_class> members = new();

    public static readonly InitialWorkDirRequirement_class INITIALWORKDIRREQUIREMENT =
                            new("InitialWorkDirRequirement");

    public string Name
    {
        get { return _Name; }
        private set { _Name = value; }
    }

    public static IList<InitialWorkDirRequirement_class> Members
    {
        get { return members; }
    }

    private InitialWorkDirRequirement_class(string name)
    {
        _Name = name;
        members.Add(this);
    }

    public static InitialWorkDirRequirement_class Parse(string toParse)
    {
        foreach (InitialWorkDirRequirement_class s in Members)
        {
            if (toParse == s.Name)
                return s;
        }

        throw new FormatException("Could not parse string.");
    }

    public static bool Contains(string value)
    {
        bool contains = false;
        foreach (InitialWorkDirRequirement_class s in Members)
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

namespace CWLDotNet;

public class ResourceRequirement_class : IEnumClass<ResourceRequirement_class>
{
    private string _Name;
    private static readonly List<ResourceRequirement_class> members = new();
    public static readonly ResourceRequirement_class RESOURCEREQUIREMENT =
                            new("ResourceRequirement");

    public string Name
    {
        get { return _Name; }
        private set { _Name = value; }
    }

    public static IList<ResourceRequirement_class> Members
    {
        get { return members; }
    }

    private ResourceRequirement_class(string name)
    {
        _Name = name;
        members.Add(this);
    }

    public static ResourceRequirement_class Parse(string toParse)
    {
        foreach (ResourceRequirement_class s in Members)
        {
            if (toParse == s.Name)
                return s;
        }

        throw new FormatException("Could not parse string.");
    }

    public static bool Contains(string value)
    {
        bool contains = false;
        foreach (ResourceRequirement_class s in Members)
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

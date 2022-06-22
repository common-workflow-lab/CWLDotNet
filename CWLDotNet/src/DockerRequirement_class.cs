namespace CWLDotNet;

public class DockerRequirement_class : IEnumClass<DockerRequirement_class>
{
    private string _Name;
    private static readonly List<DockerRequirement_class> members = new();

    public static readonly DockerRequirement_class DOCKERREQUIREMENT =
                            new("DockerRequirement");

    public string Name
    {
        get { return _Name; }
        private set { _Name = value; }
    }

    public static IList<DockerRequirement_class> Members
    {
        get { return members; }
    }

    private DockerRequirement_class(string name)
    {
        _Name = name;
        members.Add(this);
    }

    public static DockerRequirement_class Parse(string toParse)
    {
        foreach (DockerRequirement_class s in Members)
        {
            if (toParse == s.Name)
                return s;
        }

        throw new FormatException("Could not parse string.");
    }

    public static bool Contains(string value)
    {
        bool contains = false;
        foreach (DockerRequirement_class s in Members)
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

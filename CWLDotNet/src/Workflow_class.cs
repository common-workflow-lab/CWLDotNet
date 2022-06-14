namespace CWLDotNet;

public class Workflow_class : IEnumClass<Workflow_class>
{
    private string _Name;
    private static readonly List<Workflow_class> members = new();
    public static readonly Workflow_class WORKFLOW =
                            new("Workflow");

    public string Name
    {
        get { return _Name; }
        private set { _Name = value; }
    }

    public static IList<Workflow_class> Members
    {
        get { return members; }
    }

    private Workflow_class(string name)
    {
        _Name = name;
        members.Add(this);
    }

    public static Workflow_class Parse(string toParse)
    {
        foreach (Workflow_class s in Members)
        {
            if (toParse == s.Name)
                return s;
        }

        throw new FormatException("Could not parse string.");
    }

    public static bool Contains(string value)
    {
        bool contains = false;
        foreach (Workflow_class s in Members)
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

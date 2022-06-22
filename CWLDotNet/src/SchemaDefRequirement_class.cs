namespace CWLDotNet;

public class SchemaDefRequirement_class : IEnumClass<SchemaDefRequirement_class>
{
    private string _Name;
    private static readonly List<SchemaDefRequirement_class> members = new();

    public static readonly SchemaDefRequirement_class SCHEMADEFREQUIREMENT =
                            new("SchemaDefRequirement");

    public string Name
    {
        get { return _Name; }
        private set { _Name = value; }
    }

    public static IList<SchemaDefRequirement_class> Members
    {
        get { return members; }
    }

    private SchemaDefRequirement_class(string name)
    {
        _Name = name;
        members.Add(this);
    }

    public static SchemaDefRequirement_class Parse(string toParse)
    {
        foreach (SchemaDefRequirement_class s in Members)
        {
            if (toParse == s.Name)
                return s;
        }

        throw new FormatException("Could not parse string.");
    }

    public static bool Contains(string value)
    {
        bool contains = false;
        foreach (SchemaDefRequirement_class s in Members)
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

namespace CWLDotNet;

public class SubworkflowFeatureRequirement_class : IEnumClass<SubworkflowFeatureRequirement_class>
{
    private string _Name;
    private static readonly List<SubworkflowFeatureRequirement_class> members = new();
    public static readonly SubworkflowFeatureRequirement_class SUBWORKFLOWFEATUREREQUIREMENT =
                            new("SubworkflowFeatureRequirement");

    public string Name
    {
        get { return _Name; }
        private set { _Name = value; }
    }

    public static IList<SubworkflowFeatureRequirement_class> Members
    {
        get { return members; }
    }

    private SubworkflowFeatureRequirement_class(string name)
    {
        _Name = name;
        members.Add(this);
    }

    public static SubworkflowFeatureRequirement_class Parse(string toParse)
    {
        foreach (SubworkflowFeatureRequirement_class s in Members)
        {
            if (toParse == s.Name)
                return s;
        }

        throw new FormatException("Could not parse string.");
    }

    public static bool Contains(string value)
    {
        bool contains = false;
        foreach (SubworkflowFeatureRequirement_class s in Members)
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

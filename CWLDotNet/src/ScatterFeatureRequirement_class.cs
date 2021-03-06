namespace CWLDotNet;

public class ScatterFeatureRequirement_class : IEnumClass<ScatterFeatureRequirement_class>
{
    private string _Name;
    private static readonly List<ScatterFeatureRequirement_class> members = new();

    public static readonly ScatterFeatureRequirement_class SCATTERFEATUREREQUIREMENT =
                            new("ScatterFeatureRequirement");

    public string Name
    {
        get { return _Name; }
        private set { _Name = value; }
    }

    public static IList<ScatterFeatureRequirement_class> Members
    {
        get { return members; }
    }

    private ScatterFeatureRequirement_class(string name)
    {
        _Name = name;
        members.Add(this);
    }

    public static ScatterFeatureRequirement_class Parse(string toParse)
    {
        foreach (ScatterFeatureRequirement_class s in Members)
        {
            if (toParse == s.Name)
                return s;
        }

        throw new FormatException("Could not parse string.");
    }

    public static bool Contains(string value)
    {
        bool contains = false;
        foreach (ScatterFeatureRequirement_class s in Members)
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

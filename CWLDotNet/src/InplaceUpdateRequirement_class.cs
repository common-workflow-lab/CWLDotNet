namespace CWLDotNet;

public class InplaceUpdateRequirement_class : IEnumClass<InplaceUpdateRequirement_class>
{
    private string _Name;
    private static readonly List<InplaceUpdateRequirement_class> members = new();

    public static readonly InplaceUpdateRequirement_class INPLACEUPDATEREQUIREMENT =
                            new("InplaceUpdateRequirement");

    public string Name
    {
        get { return _Name; }
        private set { _Name = value; }
    }

    public static IList<InplaceUpdateRequirement_class> Members
    {
        get { return members; }
    }

    private InplaceUpdateRequirement_class(string name)
    {
        _Name = name;
        members.Add(this);
    }

    public static InplaceUpdateRequirement_class Parse(string toParse)
    {
        foreach (InplaceUpdateRequirement_class s in Members)
        {
            if (toParse == s.Name)
                return s;
        }

        throw new FormatException("Could not parse string.");
    }

    public static bool Contains(string value)
    {
        bool contains = false;
        foreach (InplaceUpdateRequirement_class s in Members)
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

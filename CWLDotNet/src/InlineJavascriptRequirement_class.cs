namespace CWLDotNet;

public class InlineJavascriptRequirement_class : IEnumClass<InlineJavascriptRequirement_class>
{
    private string _Name;
    private static readonly List<InlineJavascriptRequirement_class> members = new();

    public static readonly InlineJavascriptRequirement_class INLINEJAVASCRIPTREQUIREMENT =
                            new("InlineJavascriptRequirement");

    public string Name
    {
        get { return _Name; }
        private set { _Name = value; }
    }

    public static IList<InlineJavascriptRequirement_class> Members
    {
        get { return members; }
    }

    private InlineJavascriptRequirement_class(string name)
    {
        _Name = name;
        members.Add(this);
    }

    public static InlineJavascriptRequirement_class Parse(string toParse)
    {
        foreach (InlineJavascriptRequirement_class s in Members)
        {
            if (toParse == s.Name)
                return s;
        }

        throw new FormatException("Could not parse string.");
    }

    public static bool Contains(string value)
    {
        bool contains = false;
        foreach (InlineJavascriptRequirement_class s in Members)
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

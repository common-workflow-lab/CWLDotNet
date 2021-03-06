namespace CWLDotNet;

public class ExpressionTool_class : IEnumClass<ExpressionTool_class>
{
    private string _Name;
    private static readonly List<ExpressionTool_class> members = new();

    public static readonly ExpressionTool_class EXPRESSIONTOOL =
                            new("ExpressionTool");

    public string Name
    {
        get { return _Name; }
        private set { _Name = value; }
    }

    public static IList<ExpressionTool_class> Members
    {
        get { return members; }
    }

    private ExpressionTool_class(string name)
    {
        _Name = name;
        members.Add(this);
    }

    public static ExpressionTool_class Parse(string toParse)
    {
        foreach (ExpressionTool_class s in Members)
        {
            if (toParse == s.Name)
                return s;
        }

        throw new FormatException("Could not parse string.");
    }

    public static bool Contains(string value)
    {
        bool contains = false;
        foreach (ExpressionTool_class s in Members)
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

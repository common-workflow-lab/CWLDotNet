namespace CWLDotNet;

public class Expression : IEnumClass<Expression>
{
    private string _Name;
    private static readonly List<Expression> members = new();
    public static readonly Expression EXPRESSIONPLACEHOLDER =
                            new("ExpressionPlaceholder");

    public string Name
    {
        get { return _Name; }
        private set { _Name = value; }
    }

    public static IList<Expression> Members
    {
        get { return members; }
    }

    private Expression(string name)
    {
        _Name = name;
        members.Add(this);
    }

    public static Expression Parse(string toParse)
    {
        foreach (Expression s in Members)
        {
            if (toParse == s.Name)
                return s;
        }

        throw new FormatException("Could not parse string.");
    }

    public static bool Contains(string value)
    {
        bool contains = false;
        foreach (Expression s in Members)
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

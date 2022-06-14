namespace CWLDotNet;

public class PrimitiveType : IEnumClass<PrimitiveType>
{
    private string _Name;
    private static readonly List<PrimitiveType> members = new();
    public static readonly PrimitiveType NULL =
                            new("null");
    public static readonly PrimitiveType BOOLEAN =
                            new("boolean");
    public static readonly PrimitiveType INT =
                            new("int");
    public static readonly PrimitiveType LONG =
                            new("long");
    public static readonly PrimitiveType FLOAT =
                            new("float");
    public static readonly PrimitiveType DOUBLE =
                            new("double");
    public static readonly PrimitiveType STRING =
                            new("string");

    public string Name
    {
        get { return _Name; }
        private set { _Name = value; }
    }

    public static IList<PrimitiveType> Members
    {
        get { return members; }
    }

    private PrimitiveType(string name)
    {
        _Name = name;
        members.Add(this);
    }

    public static PrimitiveType Parse(string toParse)
    {
        foreach (PrimitiveType s in Members)
        {
            if (toParse == s.Name)
                return s;
        }

        throw new FormatException("Could not parse string.");
    }

    public static bool Contains(string value)
    {
        bool contains = false;
        foreach (PrimitiveType s in Members)
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

namespace CWLDotNet;

public class Operation_class : IEnumClass<Operation_class>
{
    private string _Name;
    private static readonly List<Operation_class> members = new();
    public static readonly Operation_class OPERATION =
                            new("Operation");

    public string Name
    {
        get { return _Name; }
        private set { _Name = value; }
    }

    public static IList<Operation_class> Members
    {
        get { return members; }
    }

    private Operation_class(string name)
    {
        _Name = name;
        members.Add(this);
    }

    public static Operation_class Parse(string toParse)
    {
        foreach (Operation_class s in Members)
        {
            if (toParse == s.Name)
                return s;
        }

        throw new FormatException("Could not parse string.");
    }

    public static bool Contains(string value)
    {
        bool contains = false;
        foreach (Operation_class s in Members)
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

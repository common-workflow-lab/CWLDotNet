namespace CWLDotNet;

public class LinkMergeMethod : IEnumClass<LinkMergeMethod>
{
    private string _Name;
    private static readonly List<LinkMergeMethod> members = new();
    public static readonly LinkMergeMethod MERGE_NESTED =
                            new("merge_nested");
    public static readonly LinkMergeMethod MERGE_FLATTENED =
                            new("merge_flattened");

    public string Name
    {
        get { return _Name; }
        private set { _Name = value; }
    }

    public static IList<LinkMergeMethod> Members
    {
        get { return members; }
    }

    private LinkMergeMethod(string name)
    {
        _Name = name;
        members.Add(this);
    }

    public static LinkMergeMethod Parse(string toParse)
    {
        foreach (LinkMergeMethod s in Members)
        {
            if (toParse == s.Name)
                return s;
        }

        throw new FormatException("Could not parse string.");
    }

    public static bool Contains(string value)
    {
        bool contains = false;
        foreach (LinkMergeMethod s in Members)
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

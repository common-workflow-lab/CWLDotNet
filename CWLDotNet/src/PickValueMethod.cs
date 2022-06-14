namespace CWLDotNet;

public class PickValueMethod : IEnumClass<PickValueMethod>
{
    private string _Name;
    private static readonly List<PickValueMethod> members = new();
    public static readonly PickValueMethod FIRST_NON_NULL =
                            new("first_non_null");
    public static readonly PickValueMethod THE_ONLY_NON_NULL =
                            new("the_only_non_null");
    public static readonly PickValueMethod ALL_NON_NULL =
                            new("all_non_null");

    public string Name
    {
        get { return _Name; }
        private set { _Name = value; }
    }

    public static IList<PickValueMethod> Members
    {
        get { return members; }
    }

    private PickValueMethod(string name)
    {
        _Name = name;
        members.Add(this);
    }

    public static PickValueMethod Parse(string toParse)
    {
        foreach (PickValueMethod s in Members)
        {
            if (toParse == s.Name)
                return s;
        }

        throw new FormatException("Could not parse string.");
    }

    public static bool Contains(string value)
    {
        bool contains = false;
        foreach (PickValueMethod s in Members)
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

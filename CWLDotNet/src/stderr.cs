namespace CWLDotNet;

public class stderr : IEnumClass<stderr>
{
    private string _Name;
    private static readonly List<stderr> members = new();
    public static readonly stderr STDERR =
                            new("stderr");

    public string Name
    {
        get { return _Name; }
        private set { _Name = value; }
    }

    public static IList<stderr> Members
    {
        get { return members; }
    }

    private stderr(string name)
    {
        _Name = name;
        members.Add(this);
    }

    public static stderr Parse(string toParse)
    {
        foreach (stderr s in Members)
        {
            if (toParse == s.Name)
                return s;
        }

        throw new FormatException("Could not parse string.");
    }

    public static bool Contains(string value)
    {
        bool contains = false;
        foreach (stderr s in Members)
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

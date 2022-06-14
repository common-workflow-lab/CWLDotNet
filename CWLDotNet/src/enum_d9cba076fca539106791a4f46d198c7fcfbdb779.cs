namespace CWLDotNet;

public class enum_d9cba076fca539106791a4f46d198c7fcfbdb779 : IEnumClass<enum_d9cba076fca539106791a4f46d198c7fcfbdb779>
{
    private string _Name;
    private static readonly List<enum_d9cba076fca539106791a4f46d198c7fcfbdb779> members = new();
    public static readonly enum_d9cba076fca539106791a4f46d198c7fcfbdb779 RECORD =
                            new("record");

    public string Name
    {
        get { return _Name; }
        private set { _Name = value; }
    }

    public static IList<enum_d9cba076fca539106791a4f46d198c7fcfbdb779> Members
    {
        get { return members; }
    }

    private enum_d9cba076fca539106791a4f46d198c7fcfbdb779(string name)
    {
        _Name = name;
        members.Add(this);
    }

    public static enum_d9cba076fca539106791a4f46d198c7fcfbdb779 Parse(string toParse)
    {
        foreach (enum_d9cba076fca539106791a4f46d198c7fcfbdb779 s in Members)
        {
            if (toParse == s.Name)
                return s;
        }

        throw new FormatException("Could not parse string.");
    }

    public static bool Contains(string value)
    {
        bool contains = false;
        foreach (enum_d9cba076fca539106791a4f46d198c7fcfbdb779 s in Members)
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

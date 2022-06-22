namespace CWLDotNet;

public class File_class : IEnumClass<File_class>
{
    private string _Name;
    private static readonly List<File_class> members = new();

    public static readonly File_class FILE =
                            new("File");

    public string Name
    {
        get { return _Name; }
        private set { _Name = value; }
    }

    public static IList<File_class> Members
    {
        get { return members; }
    }

    private File_class(string name)
    {
        _Name = name;
        members.Add(this);
    }

    public static File_class Parse(string toParse)
    {
        foreach (File_class s in Members)
        {
            if (toParse == s.Name)
                return s;
        }

        throw new FormatException("Could not parse string.");
    }

    public static bool Contains(string value)
    {
        bool contains = false;
        foreach (File_class s in Members)
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

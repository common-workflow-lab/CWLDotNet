namespace CWLDotNet;

public class CommandLineTool_class : IEnumClass<CommandLineTool_class>
{
    private string _Name;
    private static readonly List<CommandLineTool_class> members = new();
    public static readonly CommandLineTool_class COMMANDLINETOOL =
                            new("CommandLineTool");

    public string Name
    {
        get { return _Name; }
        private set { _Name = value; }
    }

    public static IList<CommandLineTool_class> Members
    {
        get { return members; }
    }

    private CommandLineTool_class(string name)
    {
        _Name = name;
        members.Add(this);
    }

    public static CommandLineTool_class Parse(string toParse)
    {
        foreach (CommandLineTool_class s in Members)
        {
            if (toParse == s.Name)
                return s;
        }

        throw new FormatException("Could not parse string.");
    }

    public static bool Contains(string value)
    {
        bool contains = false;
        foreach (CommandLineTool_class s in Members)
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

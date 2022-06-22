namespace CWLDotNet;

public class CWLVersion : IEnumClass<CWLVersion>
{
    private string _Name;
    private static readonly List<CWLVersion> members = new();

    public static readonly CWLVersion DRAFT_2 =
                            new("draft-2");
    public static readonly CWLVersion DRAFT_3_DEV1 =
                            new("draft-3.dev1");
    public static readonly CWLVersion DRAFT_3_DEV2 =
                            new("draft-3.dev2");
    public static readonly CWLVersion DRAFT_3_DEV3 =
                            new("draft-3.dev3");
    public static readonly CWLVersion DRAFT_3_DEV4 =
                            new("draft-3.dev4");
    public static readonly CWLVersion DRAFT_3_DEV5 =
                            new("draft-3.dev5");
    public static readonly CWLVersion DRAFT_3 =
                            new("draft-3");
    public static readonly CWLVersion DRAFT_4_DEV1 =
                            new("draft-4.dev1");
    public static readonly CWLVersion DRAFT_4_DEV2 =
                            new("draft-4.dev2");
    public static readonly CWLVersion DRAFT_4_DEV3 =
                            new("draft-4.dev3");
    public static readonly CWLVersion V1_0_DEV4 =
                            new("v1.0.dev4");
    public static readonly CWLVersion V1_0 =
                            new("v1.0");
    public static readonly CWLVersion V1_1_0_DEV1 =
                            new("v1.1.0-dev1");
    public static readonly CWLVersion V1_1 =
                            new("v1.1");
    public static readonly CWLVersion V1_2_0_DEV1 =
                            new("v1.2.0-dev1");
    public static readonly CWLVersion V1_2_0_DEV2 =
                            new("v1.2.0-dev2");
    public static readonly CWLVersion V1_2_0_DEV3 =
                            new("v1.2.0-dev3");
    public static readonly CWLVersion V1_2_0_DEV4 =
                            new("v1.2.0-dev4");
    public static readonly CWLVersion V1_2_0_DEV5 =
                            new("v1.2.0-dev5");
    public static readonly CWLVersion V1_2 =
                            new("v1.2");

    public string Name
    {
        get { return _Name; }
        private set { _Name = value; }
    }

    public static IList<CWLVersion> Members
    {
        get { return members; }
    }

    private CWLVersion(string name)
    {
        _Name = name;
        members.Add(this);
    }

    public static CWLVersion Parse(string toParse)
    {
        foreach (CWLVersion s in Members)
        {
            if (toParse == s.Name)
                return s;
        }

        throw new FormatException("Could not parse string.");
    }

    public static bool Contains(string value)
    {
        bool contains = false;
        foreach (CWLVersion s in Members)
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

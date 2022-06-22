namespace CWLDotNet;

public class StepInputExpressionRequirement_class : IEnumClass<StepInputExpressionRequirement_class>
{
    private string _Name;
    private static readonly List<StepInputExpressionRequirement_class> members = new();

    public static readonly StepInputExpressionRequirement_class STEPINPUTEXPRESSIONREQUIREMENT =
                            new("StepInputExpressionRequirement");

    public string Name
    {
        get { return _Name; }
        private set { _Name = value; }
    }

    public static IList<StepInputExpressionRequirement_class> Members
    {
        get { return members; }
    }

    private StepInputExpressionRequirement_class(string name)
    {
        _Name = name;
        members.Add(this);
    }

    public static StepInputExpressionRequirement_class Parse(string toParse)
    {
        foreach (StepInputExpressionRequirement_class s in Members)
        {
            if (toParse == s.Name)
                return s;
        }

        throw new FormatException("Could not parse string.");
    }

    public static bool Contains(string value)
    {
        bool contains = false;
        foreach (StepInputExpressionRequirement_class s in Members)
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

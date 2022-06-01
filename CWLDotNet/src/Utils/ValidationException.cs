public class ValidationException : Exception
{
    static int indentPerLevel = 2;
    string bullet = "";
    private List<ValidationException> children = new List<ValidationException>();

    public ValidationException() : this("")
    {
    }

    public ValidationException(string message)
        : this(message, new List<ValidationException>())
    {
    }

    public ValidationException(string message, ValidationException child)
        : this(message, new List<ValidationException>{child})
    {
    }
    public ValidationException(string message, List<ValidationException> children) : base(message)
    {
        foreach(var child in children) {
            this.children.AddRange(child.Simplify());
        }
    }

    private String Summary(int level) {
        string spaces = new string(' ',  level * indentPerLevel);
        return spaces + bullet + this.Message;
    }

    public ValidationException WithBullet(string bullet) {
        this.bullet = bullet;
        return this;
    }

    List<ValidationException> Simplify() {
        if(this.ToString().Length > 0){
            return new List<ValidationException>{this};
        }
        else return this.children;
    }

    private String PrettyString(int level = 0) {
        List<string> parts = new List<string>();
        var nextlevel = level;
        if(this.Message.Length > 0) {
            parts.Add(this.Summary(level));
            nextlevel++;
        }

        foreach(var child in children) {
            parts.Add(child.PrettyString(nextlevel));
        }
        return string.Join('\n', parts);
    }

    public override string ToString()
    {
        return this.PrettyString();
    }
}
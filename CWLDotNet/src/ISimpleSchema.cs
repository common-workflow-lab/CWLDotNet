namespace CWLDotNet;

public interface ISimpleSchema : IAbstractBaseOfSimpleSchema, INonAbstractBaseOfSimpleSchema
{
    public string id { get; set; }

    public string? labelField { get; set; }

    public int numberField { get; set; }

    public SimpleEnum enumField { get; set; }
}

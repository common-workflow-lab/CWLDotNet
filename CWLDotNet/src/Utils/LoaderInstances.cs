#pragma warning disable IDE1006, IDE0090
namespace CWLDotNet;

public static class LoaderInstnaces
{
    public static readonly ILoader<object> undefinedLoader = new NullLoader();
    public static readonly PrimitiveLoader<int> intLoader = new PrimitiveLoader<int>();
    public static readonly PrimitiveLoader<string> stringLoader = new PrimitiveLoader<string>();
    public static readonly RecordLoader<SimpleSchema> simpleSchemaLoader = new RecordLoader<SimpleSchema>();
    public static readonly EnumLoader<SimpleEnum> simpleEnumLoader = new EnumLoader<SimpleEnum>();
    public static readonly ILoader<List<SimpleSchema>> arrayOfSimpleSchemaLoader = new ArrayLoader<SimpleSchema>(simpleSchemaLoader);

    public static readonly ILoader<object> unionOfArrayOfSimpleSchemaLoader = new UnionLoader(
        new List<ILoader> { arrayOfSimpleSchemaLoader });

    public static readonly ILoader<object> unionOfSimpleSchemaLoader = new UnionLoader(
        new List<ILoader> { simpleSchemaLoader, arrayOfSimpleSchemaLoader });


    public static readonly ILoader<object> unionOfundefinedtypeOrstrtype = new UnionLoader(
        new List<ILoader> { undefinedLoader, stringLoader });

    public static readonly ILoader<object> uriunionOfundefinedtypeOrstrtypeTrueFalseNone = new UriLoader<object>(
        unionOfundefinedtypeOrstrtype,
        true,
        false,
        null);
}

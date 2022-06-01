namespace CWLDotNet;

public static class LoaderInstnaces {

    public static readonly PrimitiveLoader<int> intLoader = new PrimitiveLoader<int>();
    public static readonly PrimitiveLoader<string> stringLoader = new PrimitiveLoader<string>();
    public static readonly RecordLoader<SimpleSchema> simpleSchemaLoader = new RecordLoader<SimpleSchema>();
    public static readonly EnumLoader<SimpleEnum> simpleEnumLoader = new EnumLoader<SimpleEnum>();
    public static readonly Loader<List<SimpleSchema>> arrayOfSimpleSchemaLoader = new ArrayLoader<SimpleSchema>(simpleSchemaLoader);

    public static readonly Loader<object> unionOfArrayOfSimpleSchemaLoader = new UnionLoader(new List<Loader>{arrayOfSimpleSchemaLoader});
    public static readonly Loader<object> unionOfSimpleSchemaLoader = new UnionLoader(new List<Loader>{simpleSchemaLoader, arrayOfSimpleSchemaLoader});
}
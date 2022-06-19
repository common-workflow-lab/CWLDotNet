namespace CWLDotNet;
using YamlDotNet.Serialization;
using OneOf;

public class RootLoader
{
    public static OneOf<CommandLineTool , ExpressionTool , Workflow , Operation , List<OneOf<CommandLineTool , ExpressionTool , Workflow , Operation>>> LoadDocument(in object doc, in string baseUri_, in LoadingOptions loadingOptions_)
    {
        string baseUri = EnsureBaseUri(baseUri_);
        LoadingOptions loadingOptions = loadingOptions_;

        if (loadingOptions == null)
        {
            loadingOptions = new LoadingOptions(fileUri: baseUri);
        }
        dynamic outDoc = LoaderInstances.union_of_CommandLineToolLoader_or_ExpressionToolLoader_or_WorkflowLoader_or_OperationLoader_or_array_of_union_of_CommandLineToolLoader_or_ExpressionToolLoader_or_WorkflowLoader_or_OperationLoader.Load(doc, baseUri, loadingOptions, baseUri);
        return outDoc;
    }

    public static OneOf<CommandLineTool , ExpressionTool , Workflow , Operation , List<OneOf<CommandLineTool , ExpressionTool , Workflow , Operation>>> LoadDocument(in string doc, in string uri_, in LoadingOptions loadingOptions_)
    {
        string uri = EnsureBaseUri(uri_);
        LoadingOptions loadingOptions = loadingOptions_;
        if (loadingOptions == null)
        {
            loadingOptions = new LoadingOptions(fileUri: uri);
        }

        IDeserializer deserializer = new DeserializerBuilder().WithNodeTypeResolver(new ScalarNodeTypeResolver()).Build();
        object? yamlObject = deserializer.Deserialize(new StringReader(doc));
        loadingOptions.idx.Add(uri, yamlObject!);
        return LoadDocument(yamlObject!, uri, loadingOptions);
    }

    static string EnsureBaseUri(in string baseUri_)
    {
        string baseUri = baseUri_;
        if (baseUri == null)
        {
            baseUri = new Uri(Environment.CurrentDirectory).AbsoluteUri;
        }

        return baseUri;
    }
}

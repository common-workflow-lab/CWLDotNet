﻿namespace CWLDotNet;
using YamlDotNet.Serialization;
using OneOf;

public class RootLoader
{
    public static OneOf<CommandLineTool , ExpressionTool , Workflow , Operation , List<OneOf<CommandLineTool , ExpressionTool , Workflow , Operation>>> LoadDocument(in Dictionary<object,object> doc, in string baseUri_, in LoadingOptions? loadingOptions_ = null)
    {
        string baseUri = EnsureBaseUri(baseUri_);
        LoadingOptions loadingOptions;

        if (loadingOptions_ == null)
        {
            loadingOptions = new LoadingOptions(fileUri: baseUri);
        }
        else 
        {
            loadingOptions = loadingOptions_;
        }

        dynamic outDoc = LoaderInstances.union_of_CommandLineToolLoader_or_ExpressionToolLoader_or_WorkflowLoader_or_OperationLoader_or_array_of_union_of_CommandLineToolLoader_or_ExpressionToolLoader_or_WorkflowLoader_or_OperationLoader.DocumentLoad(doc, baseUri, loadingOptions);
        return outDoc;
    }

    public static OneOf<CommandLineTool , ExpressionTool , Workflow , Operation , List<OneOf<CommandLineTool , ExpressionTool , Workflow , Operation>>> LoadDocument(in string doc, in string uri_, in LoadingOptions? loadingOptions_ = null)
    {
        string uri = EnsureBaseUri(uri_);
        LoadingOptions loadingOptions;

        if (loadingOptions_ == null)
        {
            loadingOptions = new LoadingOptions(fileUri: uri);
        } 
        else 
        {
            loadingOptions = loadingOptions_;
        }

        IDeserializer deserializer = new DeserializerBuilder().WithNodeTypeResolver(new ScalarNodeTypeResolver()).Build();
        object? yamlObject = deserializer.Deserialize(new StringReader(doc));
        loadingOptions.idx.Add(uri, yamlObject!);
        return LoadDocument((Dictionary<object,object>) yamlObject!, uri, loadingOptions);
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

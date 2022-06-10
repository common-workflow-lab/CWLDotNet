using CWLDotNet;


string text = File.ReadAllText(@"/home/adrian/simpleInstance.cwl");
object test = RootLoader.LoadDocument(text, null!, null!);
Console.WriteLine(test.GetType());
Dictionary<object, object> _ = ((SimpleSchema)test).Save();

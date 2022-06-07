using CWLDotNet;

class Program
{
    static void Main(string[] args)
    {
        string text = System.IO.File.ReadAllText(@"/home/adrian/simpleInstance.cwl");
        var test = RootLoader.LoadDocument(text, null, null);
        Console.WriteLine(test.GetType());
        var x = ((SimpleSchema)test).Save();
    }
}
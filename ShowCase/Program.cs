using CWLDotNet;

class Program
{
    static void Main(string[] args)
    {
        string text = System.IO.File.ReadAllText(@"C:\simpleInstance.cwl");
        var test = RootLoader.LoadDocument(text, @"C:\simpleInstance", null);
        Console.WriteLine(test.GetType());
    }
}
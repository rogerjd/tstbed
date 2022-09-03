// See https://aka.ms/new-console-template for more information

Console.WriteLine("Hello, World!");

//tstbed.List.Test();

Dictionary<string, int> dict = Enumerable.Range(1, 10).ToDictionary<int, string>(n => n.ToString());
Console.WriteLine(dict.ContainsKey("1"));
Console.WriteLine(dict.ContainsKey("14"));
foreach (var kvp in dict)
{
    Console.WriteLine($"{kvp.Key} {kvp.Value}");
    Console.WriteLine("abc");
    Console.WriteLine("{0} {1}", kvp.Key, kvp.Value);    
}
using System.Runtime.InteropServices.ComTypes;
using Xunit.Abstractions;

namespace All;

public class Template
{
    private readonly ITestOutputHelper _testOutputHelper;

    public Template(ITestOutputHelper testOutputHelper)
    {
        _testOutputHelper = testOutputHelper;
    }

    [Fact]
    public void Test()
    {
        //string array of 1000 items
        //fill it with "nemo"
        var input = new string[1000];
        Array.Fill(input, "nemo");
        for (int i = 0; i < input.Length; i++)
        {
            if (input[i] == "nemo")
            {
               _testOutputHelper.WriteLine("found nemo");
            }
        }
    }
}
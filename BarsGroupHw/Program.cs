// See https://aka.ms/new-console-template for more information
namespace BarsGroupHw;

static class Program
{
	public static void Main()
	{
		var keyChecker = new KeyChecker();
		keyChecker.OnKeyPressed += PrintKey;
		keyChecker.Run();
	}

	static void PrintKey(object? sender, char letter) =>
		Console.WriteLine(letter);
}


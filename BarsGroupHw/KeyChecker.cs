using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BarsGroupHw
{
    public class KeyChecker
    {
        public event EventHandler<char>? OnKeyPressed;

        public void Run()
        {
            while(true)
            {
                var letter = Console.ReadKey();
                if (letter.Key == ConsoleKey.C)
                    break;
                else
                    OnKeyPressed?.Invoke(this, letter.KeyChar);
            }
        }

        public static void KeyCheckerTest()
        {
            var keyChecker = new KeyChecker();
            keyChecker.OnKeyPressed += PrintKey;
            keyChecker.Run();
        }

        static void PrintKey(object? sender, char letter) =>
            Console.WriteLine(letter);
    }
}

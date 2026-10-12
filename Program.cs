using System.Text.RegularExpressions;

namespace final_project
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string text = @"
            Csharp is a programming language.
            Csharp is powerful and C# is useful.
            Programming requires a practice.
            Practice makes programming easier.
        ";
            Console.WriteLine($"In text: ");
            Console.WriteLine(text);

            string[] words = Regex
                .Matches(text.ToLowerInvariant(), @"\b[\w']+\b")
                .Select(match => match.Value)
                .ToArray();

            Dictionary<string, int> frequency = new();

            foreach (string word in words)
            {
                if (frequency.ContainsKey(word))
                {
                    frequency[word]++;
                }
                else
                {
                    frequency[word] = 1;
                }
            }

            Console.WriteLine("\nTop 5 words:");

            foreach (var item in frequency.OrderByDescending(x => x.Value)
                                          .ThenBy(x => x.Key)
                                          .Take(5))
            {
                Console.WriteLine($"{item.Key}: {item.Value}");
            }
        }
    }
}

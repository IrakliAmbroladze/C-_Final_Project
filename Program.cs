namespace final_project
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string[] words = { "eat", "tea", "tan", "ate", "nat", "bat" };
            Console.WriteLine("Array to get anagrams from");
            Console.WriteLine("[ " + string.Join(", ", words) + " ]\n");

            var formattedGroups = words
                .GroupBy(word => new string(word.OrderBy(c => c).ToArray()))
                .Select(group => group.ToArray())
                .Where(group => group.Length >= 2)
                .Select(group => "[" + string.Join(", ", group) + "]");

            Console.WriteLine("Anagrams:");
            Console.Write("[" + string.Join(",", formattedGroups) + "]\n");
        }
    }
}

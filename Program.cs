namespace final_project
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Enter a word: ");

            string word = Console.ReadLine() ?? "";
            char[] chars = word.ToCharArray();
            Array.Reverse(chars);
            string reversed = new string(chars);

            Console.WriteLine($"Reversed: {reversed}");
        }
    }
}

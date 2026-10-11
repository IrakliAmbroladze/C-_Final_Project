namespace final_project
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.Write("In array of: ");
            Console.Write("[ ");
            int[] numbers = { 12, 45, 7, 89, 23 };
            int max = numbers[0];
            for (int i = 0; i < numbers.Length; i++)
            {
                bool isLast = i == numbers.Length - 1;
                Console.Write($"{numbers[i]}");
                Console.Write(isLast ? "" : ", ");
                if (numbers[i] > max)
                {
                    max = numbers[i];
                }
            }
            Console.Write(" ]\n");

            Console.WriteLine($"Maximum element is: {max}");
        }
    }
}

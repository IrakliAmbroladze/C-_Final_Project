namespace final_project
{
    internal class Program
    {
        static void PrintArray(int[] arr)
        {
            Console.Write("[ ");
            for (int i = 0; i < arr.Length; i++)
            {
                bool isLast = i == arr.Length - 1;
                Console.Write($"{arr[i]}");
                Console.Write(isLast ? "" : ", ");
            }
            Console.Write(" ]");

        }
        static int[] TwoSum(int[] nums, int target)
        {
            Dictionary<int, int> seen = new();
            for (int i = 0; i < nums.Length; i++)
            {
                int complement = target - nums[i];
                if (seen.TryGetValue(complement, out int index))
                    return new[] { index, i };
                seen[nums[i]] = i;
            }
            return Array.Empty<int>();
        }
        static void Main(string[] args)
        {
            int[] numbers = { 2, 4, 7, 11, 15 };
            Console.Write("In Array of: ");
            PrintArray(numbers);
            int target = 9;

            int[] result = TwoSum(numbers, target);

            if (result.Length == 2)
            {
                Console.Write($"\nTarget {target} is sum of numbers at ");
                Console.Write(
                    $"indices: {result[0]}, {result[1]}\n");
            }
            else
            {
                Console.WriteLine("No solution found.");
            }
        }
    }
}

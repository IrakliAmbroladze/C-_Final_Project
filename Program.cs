namespace final_project
{
    internal class Program
    {
        static int BinarySearch<T>(T[] arr, T target)
        where T : IComparable<T>
        {
            int left = 0;
            int right = arr.Length - 1;
            while (left <= right)
            {
                int mid = left + (right - left) / 2;
                int comparison = arr[mid].CompareTo(target);
                if (comparison == 0)
                    return mid;
                if (comparison < 0)
                    left = mid + 1;
                else
                    right = mid - 1;
            }
            return -1;
        }
        static void Main(string[] args)
        {
            int[] numbers = { 1, 3, 5, 7, 9, 11 };
            Console.WriteLine($"In [{string.Join(", ", numbers)}]");
            int target1 = 7; int target2 = 4;
            Console.WriteLine($"target {target1} is at index " + BinarySearch(numbers, target1));
            Console.WriteLine($"target {target2} is at index " + BinarySearch(numbers, target2));
            Console.WriteLine();
            string[] names = { "Anna", "David", "John", "Maria" };
            Console.WriteLine($"In [{string.Join(", ", names)}]");
            string target3 = "David";
            Console.WriteLine($"target {target3} is at index " + BinarySearch(names, target3));

        }
    }
}

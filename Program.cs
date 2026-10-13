namespace final_project
{
    internal class Program
    {
        static int[] MergeSortedArrays(int[] a, int[] b)
        {
            int[] result = new int[a.Length + b.Length];

            int i = 0, j = 0, k = 0;

            while (i < a.Length && j < b.Length)
            {
                if (a[i] <= b[j])
                    result[k++] = a[i++];
                else
                    result[k++] = b[j++];
            }

            while (i < a.Length)
                result[k++] = a[i++];

            while (j < b.Length)
                result[k++] = b[j++];

            return result;
        }
        static void Main(string[] args)
        {
            int[] a = { 1, 3, 5, 7 };
            int[] b = { 2, 4, 6, 8 };
            Console.WriteLine("Array 1: [" + string.Join(", ", a) + "]");
            Console.WriteLine("Array 2: [" + string.Join(", ", b) + "]");

            int[] merged = MergeSortedArrays(a, b);
            Console.WriteLine("Merged Array: [" + string.Join(", ", merged) + "]");

        }
    }
}

namespace final_project
{
    internal class Program
    {
        static bool IsPalindrome(string text)
        {
            string cleaned = new string(
                text.Where(char.IsLetterOrDigit)
                    .Select(char.ToLowerInvariant)
                    .ToArray()
            );

            int left = 0;
            int right = cleaned.Length - 1;

            while (left < right)
            {
                if (cleaned[left] != cleaned[right])
                {
                    return false;
                }

                left++;
                right--;
            }

            return true;
        }

        static void Main(string[] args)
        {
            Console.WriteLine("The text: ");
            string text = "A man, a plan, a canal: Panama";

            Console.WriteLine(text);
            Console.WriteLine();
            Console.WriteLine(IsPalindrome(text) ? "Is Palindrome" : "Is not Palindrome");
        }
    }
}

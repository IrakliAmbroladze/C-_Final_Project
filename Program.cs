namespace final_project
{
    internal class Program
    {
        static bool IsBalanced(string text)
        {
            Stack<char> stack = new();
            foreach (char c in text)
            {
                if (c == '(' || c == '[' || c == '{')
                {
                    stack.Push(c);
                }
                else if (c == ')' || c == ']' || c == '}')
                {
                    if (stack.Count == 0)
                        return false;

                    char opening = stack.Pop();

                    if ((c == ')' && opening != '(') ||
                        (c == ']' && opening != '[') ||
                        (c == '}' && opening != '{'))
                    {
                        return false;
                    }
                }
            }

            return stack.Count == 0;
        }
        static void Main(string[] args)
        {
            string example1 = "{[()]}";
            string example2 = "{[(])}";
            string example3 = "((()))";
            Console.WriteLine($"{example1} is {(IsBalanced(example1) ? "balanced" : "not balanced")}");
            Console.WriteLine($"{example2} is {(IsBalanced(example2) ? "balanced" : "not balanced")}");
            Console.WriteLine($"{example3} is {(IsBalanced(example3) ? "balanced" : "not balanced")}");
        }
    }
}

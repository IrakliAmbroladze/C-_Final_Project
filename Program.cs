
string[] Ones ={"zero", "one", "two", "three", "four","five", "six", "seven", "eight", "nine","ten", "eleven",
         "twelve", "thirteen","fourteen", "fifteen", "sixteen","seventeen", "eighteen", "nineteen"};

string[] Tens = { "", "", "twenty", "thirty", "forty", "fifty", "sixty", "seventy", "eighty", "ninety" };

string ConvertBelowThousand(int number)
{
    string result = "";
    if (number >= 100)
    {
        result += Ones[number / 100] + " hundred";
        number %= 100;
        if (number > 0) result += " ";
    }
    if (number >= 20)
    {
        result += Tens[number / 10];
        number %= 10;
        if (number > 0) result += "-" + Ones[number];
    }
    else if (number > 0) result += Ones[number];
    return result;
}
string NumberToWords(int number)
{
    if (number < 0 || number > 999999) throw new ArgumentOutOfRangeException(nameof(number));
    if (number == 0) return "zero";
    string result = "";
    if (number >= 1000)
    {
        result += ConvertBelowThousand(number / 1000) + " thousand";
        number %= 1000;
        if (number > 0) result += " ";
    }
    if (number > 0) result += ConvertBelowThousand(number);
    return result;
}
Console.Write("Enter a number (0-999999): ");
if (int.TryParse(Console.ReadLine(), out int number) && number >= 0 && number <= 999999) Console.WriteLine(NumberToWords(number));
else Console.WriteLine("Invalid number.");

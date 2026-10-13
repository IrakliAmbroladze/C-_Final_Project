class Student
{
    public string Name { get; set; } = "";
    public int Grade { get; set; }
    public double Score { get; set; }
}
class Program
{
    static void Main()
    {
        List<Student> students = new()
        {
            new Student { Name = "Anna", Grade = 10, Score = 85 },
            new Student { Name = "David", Grade = 10, Score = 92 },
            new Student { Name = "Maria", Grade = 10, Score = 78 },
            new Student { Name = "John", Grade = 11, Score = 88 },
            new Student { Name = "Kate", Grade = 11, Score = 96 },
            new Student { Name = "Alex", Grade = 11, Score = 80 }
        };
        Console.WriteLine("Average score per class:");
        var averages = students.GroupBy(s => s.Grade).Select(g => new { Grade = g.Key, Average = g.Average(s => s.Score) });
        foreach (var item in averages) Console.WriteLine($"Grade {item.Grade}: {item.Average:F2}");
        Console.WriteLine("\nBest student per class:");
        var bestStudents = students.GroupBy(s => s.Grade).Select(g => g.OrderByDescending(s => s.Score).First());
        foreach (var student in bestStudents) Console.WriteLine($"Grade {student.Grade}: " + $"{student.Name} ({student.Score})");
        double overallAverage = students.Average(s => s.Score);
        Console.WriteLine($"\nOverall average: {overallAverage:F2}");
        Console.WriteLine("Above overall average:");
        var aboveAverage = students.Where(s => s.Score > overallAverage);
        foreach (var student in aboveAverage) Console.WriteLine($"{student.Name}: {student.Score}");
    }
}
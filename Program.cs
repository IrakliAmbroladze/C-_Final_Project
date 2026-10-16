class Program
{
    static int CountWorkingDays(DateOnly start, DateOnly end, HashSet<DateOnly> holidays)
    {
        if (start > end) throw new ArgumentException("Start date must not be after end date.");
        int count = 0;
        for (DateOnly date = start; date <= end; date = date.AddDays(1))
        {
            bool isWeekend = date.DayOfWeek == DayOfWeek.Saturday || date.DayOfWeek == DayOfWeek.Sunday;
            if (!isWeekend && !holidays.Contains(date)) count++;
        }
        return count;
    }
    static (int Years, int Months, int Days) CalculateAge(DateOnly birthDate, DateOnly asOfDate)
    {
        if (birthDate > asOfDate) throw new ArgumentException("Birth date cannot be in the future.");
        int years = asOfDate.Year - birthDate.Year;
        DateOnly anniversary = birthDate.AddYears(years);
        if (anniversary > asOfDate)
        {
            years--;
            anniversary = birthDate.AddYears(years);
        }
        int months = (asOfDate.Year - anniversary.Year) * 12 + asOfDate.Month - anniversary.Month;
        DateOnly monthAnniversary = anniversary.AddMonths(months);
        if (monthAnniversary > asOfDate)
        {
            months--;
            monthAnniversary = anniversary.AddMonths(months);
        }
        int days = asOfDate.DayNumber - monthAnniversary.DayNumber;
        return (years, months, days);
    }
    static DateOnly LastFriday(int year, int month)
    {
        DateOnly lastDay = new(year, month, DateTime.DaysInMonth(year, month));
        int daysBack = ((int)lastDay.DayOfWeek - (int)DayOfWeek.Friday + 7) % 7;
        return lastDay.AddDays(-daysBack);
    }
    static void Main()
    {
        var holidays = new HashSet<DateOnly> { new DateOnly(2026, 10, 12), new DateOnly(2026, 10, 23) };
        DateOnly start = new(2026, 10, 5);
        DateOnly end = new(2026, 10, 16);
        int workingDays = CountWorkingDays(start, end, holidays);
        Console.WriteLine($"Working days: {workingDays}");
        DateOnly birthDate = new(1991, 01, 28);
        DateOnly today = new(2026, 10, 17);
        var age = CalculateAge(birthDate, today);
        Console.WriteLine($"Age: {age.Years} years, " + $"{age.Months} months, {age.Days} days");
        DateOnly friday = LastFriday(2026, 10);
        Console.WriteLine($"Last Friday: {friday:yyyy-MM-dd}");
    }
}
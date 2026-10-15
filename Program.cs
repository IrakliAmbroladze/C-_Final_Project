int[,] RotateNew(int[,] matrix)
{
    int n = matrix.GetLength(0);
    int[,] rotated = new int[n, n];
    for (int row = 0; row < n; row++)
    {
        for (int col = 0; col < n; col++) rotated[col, n - 1 - row] = matrix[row, col];
    }
    return rotated;
}
void RotateInPlace(int[,] matrix)
{
    int n = matrix.GetLength(0);
    for (int row = 0; row < n; row++)
        for (int col = row + 1; col < n; col++)
            (matrix[row, col], matrix[col, row]) = (matrix[col, row], matrix[row, col]);
    for (int row = 0; row < n; row++)
    {
        int left = 0;
        int right = n - 1;
        while (left < right)
        {
            (matrix[row, left], matrix[row, right]) = (matrix[row, right], matrix[row, left]);
            left++;
            right--;
        }
    }
}
void PrintMatrix(int[,] matrix)
{
    for (int row = 0; row < matrix.GetLength(0); row++)
    {
        for (int col = 0; col < matrix.GetLength(1); col++) Console.Write(matrix[row, col] + "\t");
        Console.WriteLine();
    }
}
int[,] matrix = { { 1, 2, 3 }, { 4, 5, 6 }, { 7, 8, 9 } };
Console.WriteLine("Original:");
PrintMatrix(matrix);
Console.WriteLine("\nRotated into a new matrix:");
int[,] rotated = RotateNew(matrix);
PrintMatrix(rotated);
Console.WriteLine("\nRotated in place:");
RotateInPlace(matrix);
PrintMatrix(matrix);

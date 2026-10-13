class MyStack<T>
{
    private T[] items = new T[4];
    private int count;
    public int Count => count;
    public void Push(T item)
    {
        if (count == items.Length) Array.Resize(ref items, items.Length * 2);
        items[count++] = item;
    }
    public T Pop()
    {
        if (count == 0) throw new InvalidOperationException("Stack is empty.");
        T item = items[--count];
        items[count] = default!;
        return item;
    }
    public T Peek()
    {
        if (count == 0) throw new InvalidOperationException("Stack is empty.");
        return items[count - 1];
    }
}
class Program
{
    static void Main()
    {
        MyStack<int> stack = new();
        stack.Push(10);
        stack.Push(20);
        stack.Push(30);
        stack.Push(40);
        stack.Push(50);
        Console.WriteLine("Count: " + stack.Count);
        Console.WriteLine("Top: " + stack.Peek());
        Console.WriteLine("Removed: " + stack.Pop());
        Console.WriteLine("New top: " + stack.Peek());
        Console.WriteLine("Count: " + stack.Count);
    }
}
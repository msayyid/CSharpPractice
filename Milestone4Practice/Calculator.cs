namespace Milestone4Practice;

public class Calculator
{
    public int Add(int a, int b)
    {
        return a + b;
    }

    public bool isEven(int number)
    {
        return number % 2 == 0;
    }

    public int Divide(int a, int b)
    {
        if (b == 0)
        {
            throw new ArgumentException("Cannot divide by zero.");
        }

        return a / b;
    }
    
    
    // async method
    public async Task<int> GetNumberAsync()
    {
        await Task.Delay(100);
        return 42;
    }
}
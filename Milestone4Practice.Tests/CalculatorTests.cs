namespace Milestone4Practice.Tests;
using Xunit;

public class CalculatorTests
{


    [Fact]
    public void Add_TwoNumber_ReturnsCorrectSum()
    {
        // Arrange
        Calculator calculator = new();

        // Act
        int result = calculator.Add(2, 3);

        // assert

        Assert.Equal(5, result);
    }
    
    [Fact]
    public void IsEven_EvenNumber_ReturnsTrue()
    {
        // arrange 
        Calculator calculator = new();
        
        // act
        bool result = calculator.isEven(4);
        
        // assert
        Assert.True(result);
    }
    
    
    // Assert.False();
    [Fact]
    public void IsEven_OddNumber_ReturnsFalse()
    {
        // arrange
        Calculator calculator = new();
        
        // act
        bool result = calculator.isEven(5);
        
        // assert

        Assert.False(result);
    }

    
    [Fact]
    public void Divide_ByZero_ThrowsException()
    {
        // arrange
        Calculator calculator = new();
        
        // act
        // i m not sure about this, correct or not
        Assert.Throws<ArgumentException>(() =>
        {
            calculator.Divide(10, 0);
        });
        // in here, xUnit is saying:
        // "run this piece of code, and i expect it to throw an ArgumentException."
    }
    
    
    // async test
    [Fact]
    public async Task GetNumberAsync_Returns42()
    {
        // arrange
        Calculator calculator = new();
        
        // act
        int result = await calculator.GetNumberAsync();
        
        // assert
        Assert.Equal(42, result); // problem in here
    }
    
    // normal test:
    // act -> get result -> assert result
    
    // exception test:
    // give xUnit the action -> xUnit runs it -> assert that the action throws
    
}


namespace Milestone4Project.Tests;

public class UnitTest1
{
    [Fact]
    public async Task AddingTodoAsync_AppendsNewTodoAsync()
    {
        // arrange 
        string path = "todo-add-test.txt";
        TodoService service = new(path);
        
        // act
        await service.AddTodoAsync("Learn ASP.NET");

        // act
        // // List<TodoItem> todoItems = await service.GetAllTodosAsync(); // i couldn't do this
        // string[] items = await File.ReadAllLinesAsync(path);
        // // assert
        // Assert.Single(items);
        // Assert.Equal("Learn ASP.NET", items[0]);

        // wait i might be able to do it
        // act
        List<TodoItem> todoItems = await service.GetAllTodosAsync();

        // assert
        Assert.Single(todoItems);
        Assert.Equal(1, todoItems[0].Id);
        Assert.Equal("Learn ASP.NET", todoItems[0].Title);
        Assert.False(todoItems[0].IsCompleted);
        // i think i did it))

        // cleanup
        File.Delete(path);

    }

    [Fact]
    public async Task AddingMultipleTodos_CreatesIncreasingIds()
    {
        // arrange
        string path = "todo-multiple-ids-test.txt";
        TodoService service = new(path);
        await service.AddTodoAsync("First todo");
        await service.AddTodoAsync("Second todo");

        // act
        List<TodoItem> todoItems = await service.GetAllTodosAsync();


        // assert
        Assert.Equal(1, todoItems[0].Id);
        Assert.Equal(2, todoItems[1].Id);
        // i am not sure i did well in here honestly

        // cleanup
        File.Delete(path);
    }

    [Fact]
    public async Task FindingExistingTodo_ReturnsTodoItem()
    {
        // arrange
        string path = "the_file.txt";
        TodoService service = new(path);
        await service.AddTodoAsync("first todo");
        await service.AddTodoAsync("second todo");

        // act
        // List<TodoItem> todoItems = await service.GetAllTodosAsync();
        TodoItem? result = await service.FindTodoByIdAsync(1);
        TodoItem? result1 = await service.FindTodoByIdAsync(2);

        // assert
        Assert.NotNull(result1);
        Assert.NotNull(result);
        Assert.Equal("first todo", result.Title);
        Assert.Equal("second todo", result1.Title);


        // assert
        // Assert.NotNull(todoItems[0]);
        // Assert.NotNull(todoItems[1]);
        //
        // Assert.Equal("first todo", todoItems[0].Title);
        // Assert.Equal("second todo", todoItems[1].Title); shit wrong 
        
        // cleanup
        File.Delete(path);
    }

    [Fact]
    public async Task FindingMissingTodo_ReturnsNull()
    {
        // arrange
        string path = "the_file.txt";
        TodoService service = new(path);
        // no need to add
        
        // act
        // var todoItems = service.GetAllTodosAsync();
        TodoItem? result = await service.FindTodoByIdAsync(1);

        Assert.Null(result);

        File.Delete(path);
        

    }


    [Fact]
    public async Task CompletingTodo_ReturnsTrue()
    {
        // arrange 
        string path = "the_file.txt";
        TodoService service = new(path);
        await service.AddTodoAsync("this is to be completed");
        
        // act
        // var todoItems = service.GetAllTodosAsync();
        bool result = await service.CompleteTodoAsync(1);

        var item = await service.FindTodoByIdAsync(1);
        // assert
        Assert.True(result);
        Assert.Equal(result, item.IsCompleted); // i am not sure this is the right way

        File.Delete(path);
    }

    [Fact]
    public async Task CompletingNonExistentTodo_ReturnsFalse()
    {
        // arrange
        string path = "file.txt";
        TodoService service = new(path);
        
        // act
        bool result = await service.CompleteTodoAsync(1);
        Assert.False(result);

        File.Delete(path);
    }
    
}
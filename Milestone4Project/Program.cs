using System.Globalization;
using Milestone4Project;

Console.WriteLine("Hello, World!");

// Milestone 4 Project
// Async Todo File Manager


// Checkpoint 1 - Model + basic performance

TodoService service = new("todo.txt");

// await service.AddTodoAsync("Learn async");
// await service.AddTodoAsync("Practice testing");
//
// List<TodoItem> todos = await service.GetAllTodosAsync();
// foreach (var todo in todos)
// {
//     Console.WriteLine(todo);
// }
//
// Console.WriteLine("-------------------");
// var allTodoAsync = await service.GetAllTodosAsync();
// foreach (var VARIABLE in allTodoAsync)
// {
//     Console.WriteLine(VARIABLE);
// }


// Checkpoint 2 - find + complete todos
var allTodos = await service.GetAllTodosAsync();
foreach (var VARIABLE in allTodos)
{
    Console.WriteLine(VARIABLE);
}

Console.WriteLine("------------------");
var item1 = await service.FindTodoByIdAsync(1);
Console.WriteLine(item1);

Console.WriteLine("------------------");
var item2 = await service.FindTodoByIdAsync(999);
Console.WriteLine(item2); // null
Console.WriteLine();
Console.WriteLine("------------------");
var result = await service.CompleteTodoAsync(1);
Console.WriteLine(result);

Console.WriteLine("------------------");
await service.CompleteTodoAsync(4);

var allTodos1 = await service.GetAllTodosAsync();
foreach (var VARIABLE in allTodos1)
{
    Console.WriteLine(VARIABLE);
}


// Checkpoint 3 - unit tests for the Todo System

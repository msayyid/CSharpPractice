using Milestone4Project;

Console.WriteLine("Hello, World!");

// Milestone 4 Project
// Async Todo File Manager


// Checkpoint 1 - Model + basic performance

TodoService service = new("todo.txt");

await service.AddTodoAsync("Learn async");
await service.AddTodoAsync("Practice testing");

List<TodoItem> todos = await service.GetAllTodosAsync();
foreach (var todo in todos)
{
    Console.WriteLine(todo);
}

Console.WriteLine("-------------------");
var allTodoAsync = await service.GetAllTodosAsync();
foreach (var VARIABLE in allTodoAsync)
{
    Console.WriteLine(VARIABLE);
}
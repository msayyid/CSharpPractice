namespace Milestone4Project;

public class TodoService
{
    private readonly string _path; 
    // readonly 
    // =
    // this field can be assigned when the object is created,
    // but shouldn't change afterward
    // --------
    // _path is instance field
    // meaning
    // each TodoService object has its own _path

    
    // TodoService isn't one todo
    // it is the thing that manages many todos.
    public TodoService(string path) 
    // question, is path enough as params in constructor? i mean, whenver we create a todoservice only the file itself is gonna be created? or passed i am not sure, 
    // i was thinking we should give like the data as well, as in content of the todo maybe, but i am not sure;
    // --------- answered
    // responsibilities are separated:
    // constructor 
    // -> which file does this service manage
    // AddTodoAsync()
    // -> what todo should i add?
    // GetAllTodosAsync()
    // -> load whatever todos are already stores
    
    {
        _path = path;
    }

    public async Task<List<TodoItem>> GetAllTodosAsync()
    {
        if (!File.Exists(_path))
        {
            return [];
        }

        List<TodoItem> todoItems = new();

        string[] lines = await File.ReadAllLinesAsync(_path);
        foreach (var line in lines)
        {
            string[] parts = line.Split('|');
            
            int id = int.Parse(parts[0]);
            string content = parts[1];
            bool isCompleted = bool.Parse(parts[2]);
            
            TodoItem newItem = new TodoItem(id, content, isCompleted);
            
            todoItems.Add(newItem);
        }

        return todoItems; 
    }

    public async Task AddTodoAsync(string title)
    {
        List<TodoItem> existingTodos = await GetAllTodosAsync();
        int nextId;
        if (existingTodos.Count == 0)
        {
            nextId = 1;
        }
        else
        {
            nextId = existingTodos
                .Max(item => item.Id);
            nextId++;
        }
        
        

        TodoItem newItem = new(nextId, title, IsCompleted: false);
        string line = $"{newItem.Id}|{newItem.Title}|{newItem.IsCompleted}";
        await File.AppendAllLinesAsync(_path, new[] { line }); // this felt right, i mean at least didin't feel like an error, i need you to confirm
        
    }
    
    
}
using System.ComponentModel;

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
        await File.AppendAllLinesAsync(_path, new[] { line }); 
        
    }

    public async Task<TodoItem?> FindTodoByIdAsync(int id)
    {
        // load all todos -> find the todo with matching id
        // return null if not found; LINQ
        List<TodoItem> todoItems = await GetAllTodosAsync();
        // i couldn't remember how to use shortcut in here
        // foreach (var item in todoItems)
        // {
        //     if (item.Id == id)
        //     {
        //         return item;
        //     }
        //
        // }
        // return null;
        
        // now i remembered
        TodoItem? item = todoItems.FirstOrDefault(item => item.Id == id);
        return item;
    }


    public async Task<bool> CompleteTodoAsync(int id)
    {
        // load all todos -> find the matching one
        // if not found, return false
        // if it exists, change that one to isCompleted = true
        // save the entire updated list back to the file
        // return true
        List<TodoItem> todoItems = await GetAllTodosAsync();
        TodoItem? item = todoItems.FirstOrDefault(item => item.Id == id);
        // because TodoItem is a record, we do not mutate it directly in here ||| question why???
        // we create an updated copy
        if (item is null)
        {
            return false;
        }

        TodoItem updatedItem = item with { IsCompleted = true }; 
        // item with creates a new record with changed value,
        // the original item stays unchanged
        
        // now replace the old item with updatedItem
        int index = todoItems.IndexOf(item);
        todoItems[index] = updatedItem; // now we have the updated list in memory
        // we still need to rewrite the file tho

        List<string> lines = new();
        foreach (var todoItem in todoItems)
        {
            string line = $"{todoItem.Id}|{todoItem.Title}|{todoItem.IsCompleted}";
            lines.Add(line);
        }

        await File.WriteAllLinesAsync(_path, lines);
        return true;

    }
    
    
}
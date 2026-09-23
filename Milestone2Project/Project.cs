namespace Milestone2Project;

public class Project
{
    public string Name { get; }
    private readonly List<Worker> _workers = new();
    private readonly List<WorkTask> _tasks = new();
    // private means only the class can access it
    // and readonly means? i forgot, remind please
    public Project(string title)
    {
        Name = title;
    }

    public void AddWorker(Worker worker)
    {
        _workers.Add(worker);
        // what checks other than !null could i have in here?
        // just a question, curious i guess
    }

    public void AddTask(WorkTask task)
    {
        _tasks.Add(task);
    }

    public void ShowWorkers()
    {
        if (_workers.Count < 1)
        {
            Console.WriteLine("No workers exist");
        }
        else
        {
            Console.WriteLine("----- Workers -----");
            foreach (Worker worker in _workers)
            {
                Console.WriteLine(worker.GetRoleInfo());
                
            }
        }

        
    }

    public void ShowTasks()
    {
        if (_tasks.Count < 1)
        {
            Console.WriteLine("No tasks exist");
        }
        else
        {
            Console.WriteLine("----- Tasks -----");
            foreach (WorkTask task in _tasks)
            {
                Console.WriteLine(task);
            }
        }

        
    }

    public Worker? FindWorkerByEmail(string email)
    {
        foreach (Worker worker in _workers)
        {
            if (worker.Email == email)
            {
                return worker;
            }
        }

        return null;
    }

    public WorkTask? FindTaskById(int id)
    {
        foreach (WorkTask task in _tasks)
        {
            if (task.Id == id)
            {
                return task;
            }
        }

        return null;
    }

    public bool AssignTask(int taskId, string workerEmail)
    {
        WorkTask? task = FindTaskById(taskId);
        if (task != null)
        {
            Worker? worker = FindWorkerByEmail(workerEmail);
            if (worker != null)
            {
                task.AssignWorker(worker);
                return true;
            }
        }

        return false;
    }
    
}
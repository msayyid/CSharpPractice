namespace Milestone2Project;

public class Project
{
    public string Name { get; }
    private readonly List<Worker> _workers = new();
    private readonly List<WorkTask> _tasks = new();
    // private means only the class can access it
    // readonly means after initialization, this field cannot be 
    // reassigned to a completely different list
    // readonly List<T> 
    // -> cannot replace the list itself
    // -> CAN still change the contents
    public Project(string title)
    {
        Name = title;
    }

    public bool AddWorker(Worker worker)
    {
        Worker? w = FindWorkerByEmail(worker.Email);
        if (w != null)
        {
            return false;
        }
        // foreach (Worker w in _workers)
        // {
        //     if (w.Email == worker.Email)
        //     {
        //         return false;
        //     }
        // }
        _workers.Add(worker);
        return true;
        // what checks other than !null could i have in here?
        // just a question, curious i guess
        // answered
        // duplicates, empty/invalid inputs, max number of worker (limit)
    }

    public bool AddTask(WorkTask task)
    {
        WorkTask? t = FindTaskById(task.Id);
        if (t != null)
        {
            return false;
        }
        // foreach (WorkTask t in _tasks)
        // {
        //     if (t.Id == task.Id)
        //     {
        //         return false;
        //     }
        // }
        _tasks.Add(task);
        return true;
    }

    public void ShowWorkers()
    {
        if (_workers.Count == 0)
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
        if (_tasks.Count == 0)
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

    public bool StartTask(int taskId)
    {
        WorkTask? t = FindTaskById(taskId);
        if (t == null)
        {
            return false;
        }

        return t.Start();
    }

    public bool CompleteTask(int taskId)
    {
        WorkTask? t = FindTaskById(taskId);
        if (t == null)
        {
            return false;
        }

        return t.Complete();
    }

    public List<TaskSummary> GetTaskSummaries()
    {
        List<TaskSummary> taskSummaries = new();
        foreach (var ts in _tasks)
        {
            taskSummaries.Add(ts.GetSummary());
        }

        return taskSummaries;
    }

    public bool MakeWorkerWork(string email)
    {
        Worker? worker = FindWorkerByEmail(email);
        if (worker == null)
        {
            return false;
        }

        if (worker is IWorkable workable)
        {
            workable.DoWork();
            // i didn't really understand this part, did we just 
            // convert Worker to IWorkable?
            // answered -- 
            // yes, the check basically means:
            // check whether this Worker object also implements
            // IWorkable. If it does, give me an IWorkable
            // reference to it called workable
            
            return true;
        }

        return false;
    }
    
    
}
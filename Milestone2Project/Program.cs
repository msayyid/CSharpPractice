// Milestone 2 project
// Work Management System

using System.Globalization;
using Milestone2Project;

// Checkpoint 1

// Worker d1 = new Developer("Ali", "ali@ali.com", "C#");
// Worker d2 = new Developer("Bek", "bek1@bek.com", "Python");
// Worker m1 = new Manager("Chingiz", "chingiz@mng.com", "Engineering");
//
// List<Worker> workers = new()
// {
//     d1,
//     d2,
//     m1
// };
//
// foreach (Worker worker in workers)
// {
//     Console.WriteLine(worker.GetRoleInfo());
// }
//
// IWorkable di1 = new Developer("Ali", "ali@ali.com", "C#");
// IWorkable di2 = new Developer("Bek", "bek1@bek.com", "Python");
// IWorkable mi1 = new Manager("Chingiz", "chingiz@mng.com", "Engineering");
//
// List<IWorkable> workables = new()
// {
//     di1, 
//     di2,
//     mi1
// };
// foreach (IWorkable iw in workables)
// {
//     iw.DoWork();
// }

// get;
// -> initialize once, then read only
// get; private set;
// -> outside can read it, class itself may change it later
// get; set;
// -> anyone with access to the object may change it
//
// Developer d1 = new Developer("Ali", "ali@ali.com", "C#");
// Developer d2 = new Developer("Bek", "bek1@bek.com", "Python");
// Manager m1 = new Manager("Chingiz", "chingiz@mng.com", "Engineering");

// List<Worker> workers = new()
// {
//     d1, d2, m1
// };
// foreach (Worker worker in workers)
// {
//     Console.WriteLine(worker.GetRoleInfo());
// }

// List<IWorkable> workables = new()
// {
//     d1, 
//     d2,
//     m1
// };
// foreach (IWorkable iw in workables)
// {
//     iw.DoWork();
// }

// Checkpoint 2
// string line = "\n-----------------------------\n";
// WorkTask wt1 = new WorkTask(1, "Brainstorming");
// WorkTask wt2 = new WorkTask(2, "Distribution");

// Console.WriteLine(wt1);
// wt1.AssignWorker(d1);
// Console.WriteLine(wt1.GetAssigneeInfo());
// Console.WriteLine(line);
// Console.WriteLine(wt1);
// Console.WriteLine(line);
// Console.WriteLine(wt2);
// Console.WriteLine(line);
// if (!wt1.Start())
// {
//     Console.WriteLine($"Task {wt1.Id} - start failed");
// }
// else
// {
//     Console.WriteLine($"{wt1.Title} has started");
// }
// Console.WriteLine(wt1);
// Console.WriteLine(line);
// Console.WriteLine(wt2.GetAssigneeInfo());
// wt2.AssignWorker(d2);
// Console.WriteLine(wt2.GetAssigneeInfo());
// wt2.Start();
// // Console.WriteLine(wt2.Start()); // false
// if (!wt2.Complete())
// {
//     Console.WriteLine($"Task {wt2.Id} - completion failed");
// }
// else
// {
//     Console.WriteLine($"Task {wt2.Id} - completed");
//     Console.WriteLine(wt2);
//     // Console.WriteLine(wt2.Complete()); // false;
// }
//
// Console.WriteLine(line);
// Console.WriteLine(wt1);
// Console.WriteLine(wt2);

// checkpoint 3


string line = "\n-----------------------------\n";
WorkTask wt1 = new WorkTask(1, "Brainstorming");
WorkTask wt2 = new WorkTask(2, "Distribution");
WorkTask wt3 = new WorkTask(3, "Design databases");


Developer d1 = new Developer("Ali", "ali@ali.com", "C#");
Developer d2 = new Developer("Bek", "bek1@bek.com", "Python");
Manager m1 = new Manager("Chingiz", "chingiz@mng.com", "Engineering");

Project project = new("Backend API");
project.ShowTasks();
Console.WriteLine(line);

// add tasks
project.AddTask(wt1);
project.AddTask(wt2);
project.AddTask(wt3);
project.ShowTasks();
Console.WriteLine(line);

project.ShowWorkers();
Console.WriteLine(line);
// add workers
project.AddWorker(d1);
project.AddWorker(d2);
project.AddWorker(m1);
project.ShowWorkers();
Console.WriteLine(line);

// find existing/missing worker -- ✅
Worker? worker = project.FindWorkerByEmail("bek1@bek.com");
if (worker != null)
{
    Console.WriteLine("Worker found:");
    Console.WriteLine(worker.GetRoleInfo());
}
else
{
    Console.WriteLine("Worker not found");
}

Console.WriteLine(line);
// find existing/missing task -- ✅
WorkTask? task = project.FindTaskById(1);
if (task != null)
{
    Console.WriteLine("Task found:");
    Console.WriteLine(task);
}
else
{
    Console.WriteLine("task not found");
}

// assign valid worker to task || assign missing worker || assign missing task
Console.WriteLine(line);
var taskAssigned = project.AssignTask(1, "ali@ali.com");
if (taskAssigned)
{
    Console.WriteLine("Task has been assigned");
    Console.WriteLine(project.FindTaskById(1));
}
else
{
    Console.WriteLine("Task assignment failed");
}

Console.WriteLine(line);
// show tasks again
project.ShowTasks();




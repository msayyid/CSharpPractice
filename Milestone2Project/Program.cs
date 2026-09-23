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

/*
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

*/


// Checkpoint 4 record + struct integration

// string line = "\n-----------------------------\n";
// WorkTask wt1 = new WorkTask(1, "Brainstorming", new WorkEstimate(1, 0));
// WorkTask wt2 = new WorkTask(2, "Distribution", new WorkEstimate(2, 30));
// WorkTask wt3 = new WorkTask(3, "Design databases", new WorkEstimate(3, 0));
//
//
// Developer d1 = new Developer("Ali", "ali@ali.com", "C#");
// Developer d2 = new Developer("Bek", "bek1@bek.com", "Python");
// Manager m1 = new Manager("Chingiz", "chingiz@mng.com", "Engineering");
//
// Project project = new("Backend API");
// project.ShowTasks();
// Console.WriteLine(line);

// // add tasks
// project.AddTask(wt1);
// project.AddTask(wt2);
// project.AddTask(wt3);
// project.ShowTasks();
// Console.WriteLine(line);
//
// project.ShowWorkers();
// Console.WriteLine(line);
// // add workers
// project.AddWorker(d1);
// project.AddWorker(d2);
// project.AddWorker(m1);
// project.ShowWorkers();
// Console.WriteLine(line);
//
// TaskSummary s1 = wt1.GetSummary();
// TaskSummary s2 = wt1.GetSummary();
// Console.WriteLine(s1 == s2); // true, because they have the same properties?
// Console.WriteLine(s1);
//
// wt1.Start(); // change status
// // Console.WriteLine(project.FindTaskById(1));
// TaskSummary s3 = wt1.GetSummary();
// Console.WriteLine(s1 == s3); // false, because now s1 and s3 got different values, and since records are not reference focused like classes, both get "different" value based records? is that a good way of saying it?
// Console.WriteLine(s1);
// Console.WriteLine(s3);

// note
// why WorkTask is a class but WorkEstimate is a struct

// WorkTask has an identity and its state changes over time
// if several parts of the program reference Task1, we generally w
// ant them all referring to the same task object and seeing its
// current state. That fits a class

// WorkEstimate is different: 3h 30m
// it behaves more like a value. if i copy 3h 30m,
// i don't particularly care whether it's "the original
// estimate object" or another copy containing 3h 30m

// so
// WorkTask -> object with identity and changing state -> class
// WorkEstimate -> small value -> struct



// Checkpoint 5 - project operations + final integration

string line = "\n-----------------------------\n";
WorkTask wt1 = new WorkTask(1, "Brainstorming", new WorkEstimate(1, 0));
WorkTask wt2 = new WorkTask(2, "Distribution", new WorkEstimate(2, 30));
WorkTask wt3 = new WorkTask(3, "Design databases", new WorkEstimate(3, 0));


Developer d1 = new Developer("Ali", "ali@ali.com", "C#");
Developer d2 = new Developer("Bek", "bek1@bek.com", "Python");
Manager m1 = new Manager("Chingiz", "chingiz@mng.com", "Engineering");

Project project = new("Backend API");
TaskSummary s1 = wt1.GetSummary();


// 1 and 2
Console.WriteLine(project.AddWorker(d1)); // true
Console.WriteLine(project.AddWorker(d1)); // false

Console.WriteLine(project.AddTask(wt1)); // true
Console.WriteLine(project.AddTask(wt1)); // false
Console.WriteLine(line);

// 3 and 4
Console.WriteLine(project.StartTask(wt1.Id)); // true
Console.WriteLine(project.StartTask(wt1.Id)); // false
Console.WriteLine(line);

// 5 and 6
Console.WriteLine(project.CompleteTask(wt1.Id)); // true
Console.WriteLine(project.CompleteTask(wt1.Id)); // false
Console.WriteLine(line);

// 7 and 8
Console.WriteLine(project.StartTask(123)); // false
Console.WriteLine(project.CompleteTask(123)); // false
Console.WriteLine(line);

// 9
project.MakeWorkerWork(d1.Email); // output ✅
Console.WriteLine(line);

// 10
project.AddWorker(m1);
Console.WriteLine(project.MakeWorkerWork(m1.Email)); // output ✅

Console.WriteLine(line);

// 11
Console.WriteLine(project.MakeWorkerWork("fasdf.com")); // false
Console.WriteLine(line);

// 12
// i will add more tasks to see better
project.AddTask(wt2);
project.AddTask(wt3);
foreach (TaskSummary ts in project.GetTaskSummaries())
{
    Console.WriteLine(ts); // i am getting records
    
}

// Checkpoint 6 final cleanup and testing


Console.WriteLine(line);
Console.WriteLine(project.AddWorker(d1)); // false
Console.WriteLine(project.AddTask(wt1)); // false

Console.WriteLine(line);
Worker? worker = project.FindWorkerByEmail("missin@email"); // null
if (worker == null)
{
    Console.WriteLine("not found");
}

Console.WriteLine(line);
WorkTask? task = project.FindTaskById(123);
Console.WriteLine(task); // null
Console.WriteLine(line);

Console.WriteLine(wt2); // pending
project.StartTask(wt2.Id);
Console.WriteLine(wt2); // inprogress
Console.WriteLine(project.StartTask(wt2.Id)); // false

Console.WriteLine(project.CompleteTask(wt2.Id)); // true
Console.WriteLine(project.CompleteTask(wt3.Id)); // false Pending to Complete : false

Console.WriteLine(line);
foreach (TaskSummary ts in project.GetTaskSummaries())
{
    Console.WriteLine(ts); 
    // summaries reflect teh current task state
}

// old tasksummary snapshots before wt1 was changed: // working fine
Console.WriteLine(line);
Console.WriteLine(s1);
Console.WriteLine(line);

project.MakeWorkerWork(d1.Email);
project.MakeWorkerWork(m1.Email); // both are fine

// WorkTask wt4 = new WorkTask(4, "Checking for proper throws", new(-1, 98)); // error
Console.WriteLine(line);
Project project2 = new("Testing for failures");
project2.ShowTasks();
project2.ShowWorkers(); // yep fine






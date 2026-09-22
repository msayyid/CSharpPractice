// Milestone 2 project
// Work Management System

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

Developer d1 = new Developer("Ali", "ali@ali.com", "C#");
Developer d2 = new Developer("Bek", "bek1@bek.com", "Python");
Manager m1 = new Manager("Chingiz", "chingiz@mng.com", "Engineering");

List<Worker> workers = new()
{
    d1, d2, m1
};
foreach (Worker worker in workers)
{
    Console.WriteLine(worker.GetRoleInfo());
}

List<IWorkable> workables = new()
{
    d1, 
    d2,
    m1
};
foreach (IWorkable iw in workables)
{
    iw.DoWork();
}
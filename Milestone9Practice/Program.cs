var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

app.MapGet("/", () => "Hello World!");

app.Run();

// Milestone 9 - SQL + Database Foundations

// lesson 1 - what is a relational database?

/*
select * 
from SupportTickets;

select Title, Category
from SupportTickets;



SQL vs LINQ

-- Database
   -- = stores data in tables.
   
   -- Table
   -- = collection of related records.
   
   -- Row
   -- = one record/item.
   
   -- Column
   -- = one field/property of that record.
   
   -- Primary Key
   -- = uniquely identifies a row.
   
   -- SELECT *
   -- = get all columns.
   
   SELECT *
   FROM SupportTickets;
   
   -- Get only specific columns:
   SELECT Title, Category
   FROM SupportTickets;

*/



// Lesson 2 - Where
/*
select * 
from SupportTickets
where IsClosed = false
and Category = "Billing";


-- WHERE filters rows.
   
   SELECT *
   FROM SupportTickets
   WHERE Category = 'Billing';
   
   -- Multiple conditions:
   SELECT *
   FROM SupportTickets
   WHERE Category = 'Billing'
     AND IsClosed = false;
   
   -- OR:
   SELECT *
   FROM SupportTickets
   WHERE Category = 'Billing'
      OR Category = 'Account';
   
   -- Comparison operators:
   -- =, <>, >, <, >=, <=
   
// Practice
1. Get all unresolved tickets.
select * from SupportTickets where IsClosed = false;

2. Get all Technical tickets.
select * from SupportTickets where Category = 'Technical';

3. Get the ticket with Id = 3.
select * from SupportTickets where id = 3;

4. Get unresolved Billing tickets.
select * from SupportTickets where category = 'Billing' and IsClosed = false;

5. Get Billing OR Account tickets.
select * from SupportTickets where Category = 'Billing' or Category = 'Account';


*/


// Lesson 3 - ORDER BY


/*

select * 
from products
order by price;
-- orders in ascending order by default


select *
from products
order by price desc;
-- order in descending order

// more than one column
select * 
from supporttickets
order by category asc, id desc;
-- meaning: first sort by category, and inside each category sort by id descending


-- ORDER BY sorts rows.
   
   -- Ascending by default:
   SELECT *
   FROM Products
   ORDER BY Price;
   
   -- Explicit ascending:
   SELECT *
   FROM Products
   ORDER BY Price ASC;
   
   -- Descending:
   SELECT *
   FROM Products
   ORDER BY Price DESC;
   
   -- Multiple sort keys:
   SELECT *
   FROM SupportTickets
   ORDER BY Category ASC, Id DESC;
   
   
Quick practice:
   1. Get all tickets ordered by Id ascending.
select * from ST order by Id ASC;
   
   2. Get all tickets ordered by Id descending.
select * from ST order by Id desc;   

   3. Get all tickets ordered alphabetically by Category.
select * from ST order by Category;
    
   4. Get only unresolved tickets, ordered by Id descending.
select * from ST where IsClosed = false order by Id DESC;   

   5. Get all products with Price >= 100, ordered by price from highest to lowest.
select * from products where price >= 100 order by price DESC;

*/


// Lesson 4 - INSERT.
// INSERT is how we add a new row to a table

/* 

to add a new row:
insert into ST (Id, Title, Category, isClosed)
values (5, 'Cannot reset password', 'Account', false);

we can omit some columns sometimes, 
if a column has a default value, or can be null, we may not need to provide it
(it depends on the table definition)

-- INSERT adds a new row.
   
   INSERT INTO SupportTickets (Id, Title, Category, IsClosed)
   VALUES (5, 'Cannot reset password', 'Account', false);
   
   -- Multiple rows:
   INSERT INTO SupportTickets (Id, Title, Category, IsClosed)
   VALUES
       (6, 'Login issue', 'Account', false),
       (7, 'App crashes', 'Technical', true);
       
       

Quick practice:
   1. Insert a ticket with:
      - Id = 10
      - Title = Payment failed
      - Category = Billing
      - IsClosed = false
insert into ST (Id, Title, Category, IsClosed)
values (10, 'Payment Failed', 'Billing', false);
      
      
   2. Insert a product with:
      - Id = 4
      - Name = Webcam
      - Price = 95
insert into products (Id, Name, Price)
values (4, 'Webcam', 95);


   3. Insert two support tickets in one query.
insert into ST (Id, Title, Category, IsClosed)
values
   (10, 'P1', 'C1', false),
   (11, 'P2', 'C2', false);

*/


// Lesson 5 - UPDATE
// it is how we change existing rows

/*

update ST
set IsClosed = true
where Id = 2;

without where, it will mean update every row in the table!!!

// we can change multiple columns
update st
set Title = 'updated payment issue',
    Category = 'Billing',
    IsClosed = True
where id = 2;


-----
update ST
set IsClosed = true
where Category = 'Billing';
-- this updates every Billing ticket
-- so where means update every row that matches this condition.

-- UPDATE changes existing rows.
   
   UPDATE SupportTickets
   SET IsClosed = true
   WHERE Id = 2;
   
   -- Update multiple columns:
   UPDATE SupportTickets
   SET Title = 'Updated title',
       Category = 'Billing'
   WHERE Id = 2;
   
   -- IMPORTANT:
   -- Without WHERE, every row can be updated.
   
   
   
Quick practice:
   1. Change ticket Id = 3 so IsClosed = true.
update st
set IsClosed = true
where Id = 3;
   
   2. Change product Id = 4 price to 120.
update products
set price = 120
where Id = 4;

   3. Change ticket Id = 2 title to Payment issue resolved and IsClosed = true.
update ST
set Title = 'Payment issue resolved',
    IsClosed = true
where Id = 2;


   4. Mark all Technical tickets as closed.
update st
set IsClosed = true
where Category = 'Technical';

   5. What would happen if you ran:
   UPDATE SupportTickets
      SET IsClosed = true;
all the tickets would be marked closed;
      
*/


// Lesson 6 - DELETE
// it removes rows from a table

/*
- to delete a one specific ticket:
delete from ST
where id = 3;

-- without where, it will mean delete every row in the table;

-- DELETE removes rows.
   
   DELETE FROM SupportTickets
   WHERE Id = 3;
   
   -- Can remove multiple matching rows:
   DELETE FROM SupportTickets
   WHERE Category = 'Technical';
   
   -- WARNING:
   -- Without WHERE, every row is deleted.
   
   DELETE FROM SupportTickets;
   
   
Quick practice:
   1. Delete ticket Id = 4.
delete from st
where Id = 4;

   2. Delete product Id = 2.
delete from products
where id = 2;

   3. Delete all closed tickets.
delete from st
where IsClosed = true;

   4. Delete all products with Price < 50.
delete from products
where price < 50;

   5. What happens if you run:
   DELETE FROM SupportTickets;
all the rows will be deleted;


*/


// Lesson 7 - Aggregate functions

// these are functions that calculate something across multiple rows
// the main ones: count, sum, avg, min, max

/*
COUNT --

select count(*)
from products
where something = something;
-- this means how many tickets are there?


SUM --
add values together
select SUM(Price)
from products;


AVG --
select avg(price)
from products;


MIN --
select min(price)
from products;

MAX --
select max(price)
from products;


----
a useful thing, we can calculate multiple aggregates in one query:
select 
   count(*) as productCount,
   avg(price) as avgPrice,
   min(price) as minPrice,
   max(price) as maxPrice
from products;
-- as just gives the returned column a nicer name;


-- Aggregate functions calculate values across rows.
   
   SELECT COUNT(*) FROM Products;
   SELECT SUM(Price) FROM Products;
   SELECT AVG(Price) FROM Products;
   SELECT MIN(Price) FROM Products;
   SELECT MAX(Price) FROM Products;
   
   -- Can combine with WHERE:
   SELECT COUNT(*)
   FROM SupportTickets
   WHERE IsClosed = false;
   
   
Quick practice:
   1. Count all support tickets.
select count(*) from st;

   2. Count only unresolved support tickets.
select count(*) from st where IsClosed = false;

   3. Find the average product price.
select avg(price) as avgPrice from products;

   4. Find the cheapest product price.
select min(price) as minPrice from products;

   5. Find the most expensive product price.
select max(price) as maxPrice from products;

   6. Find the total price of all products with Price >= 50.
select sum(price) from products where price >= 50;

*/


// Lesson 8 - GROUP BY

// if we want to count how many tickets are in each category:
// select Category, COUNT(*)
// FROM ST
// GROUP BY Category;


/*

read it as:
GROUP BY Category
-> make groups based on category

COUNT(*)
-> count rows inside each group


select Category, avg(price)
from products
group by category;
// meaning:
for each product category, calculate the average price;


select category, sum(price)
from products
group by category;
-- meaning:
for each category calculate total price;


// we can use where
select category, count(*)
from st
where IsClosed = false
group by category;
-- this means:
keep only unresolved tickets
-- then:
group them by category
-- then:
count each group;

-- order matters conceptually:
where -> filters rows first
group by -> groups remaining rows
aggregate -> calculates per group;


-- GROUP BY groups rows that have the same value.
   
   SELECT Category, COUNT(*)
   FROM SupportTickets
   GROUP BY Category;
   
   -- With alias:
   SELECT
       Category,
       COUNT(*) AS TicketCount
   FROM SupportTickets
   GROUP BY Category;
   
   -- Filter first, then group:
   SELECT
       Category,
       COUNT(*) AS TicketCount
   FROM SupportTickets
   WHERE IsClosed = false
   GROUP BY Category;
   
   
   
Quick practice:
   1. Count tickets in each Category.
select category, count(*) as countInCategory
from st
group by category;


   2. Count unresolved tickets in each Category.
select category, count(*) as countInCategory
from st
where IsClosed = false
group by category;


   3. Find average product price for each product Category.
select category, avg(price) as avgPerCategory
from products
group by category;


   4. Find total product price for each product Category.
select category, sum(price) as totalPricePerCategory
from products
group by category;


   5. Find the maximum product price in each product Category.
select category, max(price) as maxPriceInCategor
from products
group by category;

*/




// Lesson 9 - foreign keys + relationships

/*
foreign key means:
-- this value refers to a row in another table


One-to-many relationship
-- one user can have many tickets


create table st (
   id int primary key,
   title varchar(200),
   UserId int,
   foreign key (UserId) references Users(Id)
);

-- ST.UserId must refer to an Id in the Users table



-- Primary Key
   -- = uniquely identifies a row in its own table.
   
   -- Foreign Key
   -- = points to a row in another table.
   
   -- Example:
   -- Users.Id            -> Primary Key
   -- SupportTickets.UserId -> Foreign Key
   
   -- One-to-many:
   -- one User can have many SupportTickets.
   
   
Quick practice:
   1. In:
      Customers(Id, Name)
      Orders(Id, Total, CustomerId)
      
      which column is the primary key of Customers?
Id in Customers is the primary key

   2. Which column is the foreign key in Orders?
CustomerId


   3. What relationship is this?
      one Customer → many Orders
one-to-many

   4. If Orders.CustomerId = 5, what does that mean?
if foreign key is 5, referring to the customer 5?
   5. Give me one more real-world one-to-many example.
one student could have many courses?


*/



// Lesson 10 - JOINs 

/*

INNER JOIN
- use a relationship between two tables to cobmine their data

-- we want:
show each order together with the customer's name:

select Orders.Id, Orders.Total, Customers.Name
from orders
inner join Customers
   on orders.customerId = customer.id;
   
-- what is happening?
-- join orders with customers where the order's customerId matches the customer's id

INNER JOIN only returns rows where there is a match in both tables

-- Shorter aliases

select o.id, o.total, c.name
from orders as o
inner join customers as c
   on o.customerid = c.id;
   


// where can still be used
... join ...
where c.name = 'Alice';
JOIN -> combine related rows
Where -> filter the combined result


-- JOIN combines related data from multiple tables.
   
   -- INNER JOIN
   -- = return only rows that have a match in both tables.
   
   SELECT o.Id, o.Total, c.Name
   FROM Orders AS o
   INNER JOIN Customers AS c
       ON o.CustomerId = c.Id;
   
   -- ON describes how the tables are related:
   -- Orders.CustomerId = Customers.Id
   
   -- Aliases:
   -- o = Orders
   -- c = Customers
   
   
   
Quick practice
   Assume:
   Authors(Id, Name)
   
   Books(Id, Title, AuthorId)
   
   Write SQL for:
   1. Get each book title together with its author's name.
   
select b.title, a.name
from books as b
inner join authors as a
   on b.authorid = a.id;


   2. Get Book.Id, Book.Title, and author name.
   
select b.id, b.title, a.name
from books as b
inner join authors as a
   on b.authorid = a.id;
   

   3. Get only books written by an author named 'George'.
   
select b.id, b.title, a.name
from books as b
inner join authors as a
   on b.authorid = a.id
where a.name = 'George';

   4. What does this mean?
   ON Books.AuthorId = Authors.Id
   this means join them on where they actually match, like, authorid matching id in authors table
   
   5. With an INNER JOIN, would an author with zero books appear in the result?
   nope, only the existing rows would appear
   
*/



// Lesson 11 - LEFT JOIN

/*
INNER JOIN - only rows with matches

LEFT JOIN - keep ALL rows from the LEFT table
            even if there is no match on the right
            
from authors as a
left join books as b
-- authors is on the left
-- so sql says:
-- keep every author


-- INNER JOIN
   -- = only rows that have a match in both tables.
   
   -- LEFT JOIN
   -- = keep ALL rows from the left table,
   -- even if there is no matching row on the right.
   
   SELECT a.Name, b.Title
   FROM Authors AS a
   LEFT JOIN Books AS b
       ON a.Id = b.AuthorId;
   
   -- If an author has no books,
   -- the book columns will contain NULL.
   
   
   
Quick practice
   Assume:
   Customers(Id, Name)
   
   Orders(Id, Total, CustomerId)
   
   1. Get every customer together with their orders, including customers with no orders.
   
select o.id, o.total, c.name
from customers as c -- question? if we want all the customers to appear, do we have to use them first? in from rather than on join part? answered, yes keep waht you want to keep first
left join orders as o
   on c.id = o.customerid;
   
   
   2. Get customer name and order total, again including customers with no orders.
   
select c.name, o.total
from customers as c
left join orders as o
   on c.id = o.customerid;
   

   3. Which table must be on the left if we want to guarantee that every customer appears?
   
customer must be on the left


   4. What would the Order.Total value look like for a customer with no orders?

null


   5. In one sentence: what is the difference between INNER JOIN and LEFT JOIN?
-- inner lefts out the rows where there's no match/null
-- left keeps everything from the left table


*/




// Lesson 12 - many-to-many relationships + junction tables

/*
students <-> courses

many-to-many:
one student -> can take many courses

once course -> can have many students

simplified setup could look like:
create table StudentCourses (
   StudentId int,
   CourseId int,
   
   foreign key (studentId) references Students(id),
   foreign key (courseId) references Courses(id)
   );
   
-- junction table = table that connects two tables in a many-to-many relationship


// we can join through the junction table
// if we want: all courses alice is enrolled in:

select c.name
from students as s
inner join studentcourses as sc
   on s.id = sc.studentid
inner join courses as c
   on sc.courseid = c.id
where s.name = 'Alice';



-- Many-to-many:
   -- one row from table A can relate to many rows from table B,
   -- and one row from table B can relate to many rows from table A.
   
   -- We usually solve this with a junction table.
   
   -- Example:
   -- Students
   -- Courses
   -- StudentCourses
   
   -- StudentCourses contains:
   -- StudentId -> FK to Students.Id
   -- CourseId  -> FK to Courses.Id



Quick practice:
   
   Assume:
   Users(Id, Name)
   
   Roles(Id, Name)
   
   UserRoles(UserId, RoleId)
   
   1. What type of relationship exists between Users and Roles?
   
many to many, both can have many of each other

   2. What is UserRoles called?

it is a junction table

   3. Which columns in UserRoles are foreign keys?

both, UserId, RoleId

   4. If UserRoles contains:
      UserId = 3
      RoleId = 2
      
      what does that row mean?

that means user 3 has role 2 or the other way around, role 2 has user 3
   
   5. Give me one more real-world many-to-many example.
students - courses
players - clubs (like one player could have played for many clubs, and one club could have many players)
   
*/



// Lesson 13 - NULL + Basic Constraints


/*

NULL means there's no value, it is not 0 or false



Constraints 
A constraint is basically a rule the database enforces


create table users (
    id int primary key, // required it is primary key
    name varchar(100) not null, // required because it is not null
    phoneNumber varchar(30) // may be null
);

UNIQUE
it means no duplicates are allowed in this column


DEFAULT 
if no value provided, use this value automatically
ex:
isClosed BOOLEAN DEFAULT false


CHECK
Price DECIMAL CHECK (Price >= 0)
-- meaning: do not allow negative prices


ex:
create table products (
   id int primary key,  // must uniquely identify product
   name varchar(100) not null, // cannot be missing
   price decimal not null check (price >= 0), // cannot be missing; cannot be negative
   isavailable boolean default true); // defaults to true
   



-- NULL = no value / missing value
   
   WHERE PhoneNumber IS NULL;
   
   WHERE PhoneNumber IS NOT NULL;
   
   
   -- Common constraints:
   
   -- PRIMARY KEY
   -- uniquely identifies each row
   
   -- FOREIGN KEY
   -- points to a row in another table
   
   -- NOT NULL
   -- value is required
   
   -- UNIQUE
   -- duplicate values are not allowed
   
   -- DEFAULT
   -- use a default value if none is provided
   
   -- CHECK
   -- value must satisfy a condition
   
   
   
   
Quick practice
   Assume:
   Users(
       Id,
       Name,
       Email,
       PhoneNumber
   )
   
   1. Write SQL to get users whose PhoneNumber is missing.
   
select * from users where PhoneNumber is null;

   2. Write SQL to get users who do have a phone number.
   
select * from users where PhoneNumber is not null;


   3. Which constraint would you use if Name must always have a value?
not null

   4. Which constraint would you use if every Email must be different?
unique

   5. Which constraint would you use to prevent:
   Price = -50
check (price >= 0)
   
   6. If:
   IsActive BOOLEAN DEFAULT true
   
   and no IsActive value is provided during insert, what value would normally be used?   
it will by default be true




*/



// Mixed Practice SQL

// set 1
/*
Questions
1. Get all products that cost more than 100.

select * 
from products
where price > 100;

2. Get all unpaid orders, ordered by Total from highest to lowest.

select *
from orders
where IsPaid = false
order by total desc;

3. Count how many products exist.

select count(*) 
from products;

4. Find the average price of all products in the 'Electronics' category.

select avg(price)
from products
where category = 'Electronics';

5. Show each product category together with the number of products in that category.

select category, count(*)
from products
group by category;

6. Show each customer name together with their order Id and Total.

select c.name, o.id, o.total
from customers as c
left join orders as o
   on c.id = o.customerid;

7. Show all customers, including customers who have never placed an order.

select *
from customers; 

// another way:
select c.name
from customers as c
left join orders as o
   on c.id = o.customerid;
   

8. Find the total value of all paid orders.

select sum(total)
from orders
where ispaid = true;

9. Show each customer name together with the number of orders they have placed.
   For #9, think carefully: if you want customers with zero orders 
   to appear too, which kind of join would make sense?

select c.name, count(o.id)
from customers as c
left join orders as o
   on c.id = o.customerid
group by c.name;


10. Get the names of all products that appear in OrderItems.
You’ll have to go:
Products
↔ OrderItems

select p.name
from products as p
inner join orderitems as oi
   on p.id = oi.productid;  

11. Get the customer's name, order ID, and product name for every ordered product.
   This one requires connecting:
Customers
   → Orders
   → OrderItems
   → Products
   
select c.name, o.id, p.name
from customers as c
left join orders as o
   on c.id = o.customerid
inner join orderitems as oi
   on oi.orderid = o.id
inner join products as p
   on p.id = oi.productid;
   // i m very much not sure aobut this one either

12. Update order Id = 15 so that IsPaid = true.

update orders
set ispaid = true
where id = 15;

13. Delete the product whose Id = 8.

delete from products
where id = 8;

14. Insert this customer:
Id: 7
Name: 'Sarah'
Email: 'sarah@email.com'

insert into customers (id, name, email)
values (7, 'Sarah', 'sarah@email.com');

*/


// set 2

/*

1. Get all courses in the 'Computer Science' department.

select *
from courses
where department = "computer science";

2. Get all assignments with MaxScore >= 70, ordered from highest MaxScore to lowest.

select * 
from assignments
where maxscore >= 70
order by maxscore desc;

3. Count how many students exist.

select count(*)
from students;

4. Count how many courses exist in each department.

select department, count(id)
from courses
group by department; 

5. Show each student's name together with the name of every course they are enrolled in.

select s.name, c.name
from students as s
inner join enrollments as e on e.studentid = s.id
inner join courses as c on e.courseid = c.id;

6. Show the names of all students who are enrolled in the course with CourseId = 5.

select s.name
from students as s
inner join enrollments as e on e.studentid = s.id
where e.courseid = 5;


7. Show every course together with its assignments. Courses with zero assignments must still appear.

select c.name, c.id, a.id as assignmentId, a.title
from courses as c
left join assignments as a on a.courseid = c.id;


8. Show each course name together with the number of 
assignments it has. Courses with zero assignments must show 0.
Be careful here with:
COUNT(*)
vs
COUNT(something from Assignments)

select c.name, count(a.id)
from courses as c
left join assignments as a on a.courseid = c.id
group by c.name;
// 90 percnet sure

9. Show each student's name together with the number 
of courses they are enrolled in. Students with zero courses must still appear.

select s.name, count(e.courseid)
from students as s
left join enrollments as e on e.studentid = s.id
group by s.name;
// 60 percent sure in here

10. Get:
Student name
Course name
Assignment title

for assignments belonging to courses the student is enrolled in.

Think through the path:
Students
→ Enrollments
→ Courses
→ Assignments

select s.name, c.name, a.title
form students as s
inner join enrollments as e on e.studentid = s.id
inner join courses as c on e.courseid = c.id
inner join assignments as a on a.courseid = c.id;
// 75% sure

11. Update assignment Id = 12 so that:
MaxScore = 100

update assignments
set maxscore = 100
where id = 12;

12. Delete the enrollment where:
StudentId = 4
CourseId = 7

delete from enrollments
where studentid = 4 and courseid = 7; // quesoitn, can we actually do this? i mean
// won't the constarint get triggered or something?? because enrollments ahs only foreign keys


This one is worth noticing: both conditions matter.
13. Insert this course:
Id = 20
Name = 'Cloud Computing'
Department = 'Computer Science'

insert into courses (id, name, department)
values(20, 'cloud computing', 'computer science');

14. A student's Email may be missing.
Write a query that gets only students whose email is missing.

select *
from students
where email is null;

15. Suppose we are designing Students.
Which constraint would you choose for each requirement?

id - int primary key -- meaning it will be unique and must
name - varchar not null -- must have name
email - varchar not null unique -- must have email, must be unique
address - varchar -- could be null
phone - varchar not null -- must have phone number
isDisabled - boolean default false -- something like this as well?
Id must uniquely identify the student
Name must always exist
Email must not be duplicated

*/



// set 3

/*


Yep — next is **Mixed SQL Practice, Set 3**, and I’d make this the **final mixed set before the Milestone 9 project**.
   
   This one will be a bit more realistic and combine almost everything.
   
   Assume:
   
   ```text
   Users(
       Id,
       Name,
       Email
   )
   
   Projects(
       Id,
       Name,
       OwnerId,
       IsActive
   )
   
   Tasks(
       Id,
       ProjectId,
       Title,
       Status,
       EstimatedHours
   )
   
   Tags(
       Id,
       Name
   )
   
   TaskTags(
       TaskId,
       TagId
   )
   ```
   
   Relationships:
   
   ```text
   Projects.OwnerId → Users.Id
   
   Tasks.ProjectId → Projects.Id
   
   TaskTags.TaskId → Tasks.Id
   TaskTags.TagId  → Tags.Id
   ```
   
   And:
   
   ```text
   Tasks ↔ Tags
   ```
   
   is many-to-many through `TaskTags`.
   
### Set 3

1. Get all active projects.

select * from projects where isactive = true;

2. Get all tasks with `EstimatedHours > 5`, ordered from highest to lowest estimated hours.

select * from tasks where estimatedhours > 5 order by estimatedhours desc;

3. Count how many projects exist.

select count(*) from projects;

4. Find the average `EstimatedHours` of all tasks.

select avg(esitamtedhours) from tasks;

5. Show each task `Status` together with the number of tasks in that status.

select status, count(id)
from tasks
group by status; 

6. Show each project name together with the name of its owner.

select p.name, u.name
from projects as p
inner join users as u on u.id = p.ownerid;

7. Show all users together with their projects, including users who own **zero projects**.

select u.name, p.name
from users as u
left join projects as p on p.ownerid = u.id;


8. Show each project name together with the number of tasks it has. 
Projects with zero tasks must show `0`.

select p.name, count(t.id)
from projects as p
left join tasks as t on t.projectid = p.id
group by p.name; // more confident than not

9. Show each user name together with the number of projects they own. 
Users with zero projects must appear.

select u.name, count(p.id)
from users as u
left join projects as p on p.ownerid = u.id
group by u.name;

10. Show:

```text
User name
Project name
Task title
```

for every task.

Think through:

```text
Users
→ Projects
→ Tasks
```

select u.name, p.name, t.title
from users as u
inner join projects as p on p.ownerid = u.id
inner join tasks as t on t.projectid = p.id; // more sure than not

11. Show every task together with all of its tags.

Think through:

```text
Tasks
→ TaskTags
→ Tags
```

select t.title, tags.name
from tasks as t
inner join tasktags as tg on tg.taskid = t.id
inner join tags on tg.tagid = tags.id; // more sure as well

12. Show the names of all tasks that have the tag `'Backend'`.

select t.title
from tasks as t 
inner join tasktags as tg on tg.taskid = t.id
inner join tags on tg.tagid = tags.id
where tags.name = 'backend';

13. Show each tag name together with the number of tasks using 
that tag. Tags that are not used by any task must still show `0`.

select tags.name, count(tg.taskid)
from tags
left join tasktags as tg on tg.tagid = tags.id
group by tags.name; // in here itis 50-50 honestly

14. Update task `Id = 20`:

```text
Status = 'Completed'
EstimatedHours = 8
```

update tasks
set status = 'completed', estimatedhours = 8
where id = 20;

15. Delete the relationship:

```text
TaskId = 5
TagId = 3
```

from `TaskTags`.

delete from tasktags
where taskid = 5 and tagid = 3;

16. Insert:

```text
Id = 9
Name = 'Authentication'
```

into `Tags`.

insert into tags (id, name)
values (9, 'authentication');

17. Get users whose `Email` is missing.

select * from users where email is null;

18. Suppose we are designing `Projects`.

Choose suitable constraints for:

```text
Id must uniquely identify the project -- primary key id
Name must always exist -- not null
OwnerId must refer to an existing User -- foreign key references (users.id)
IsActive should default to true -- boolean default true
```


19. One conceptual question:

If you delete this row:

```text
TaskTags:
TaskId = 5
TagId = 3
```

are you deleting the task, deleting the tag, or something else?

we are deleting the tasktag relationship, we are not deleting the task or tag themselves

20. One more conceptual question:

Why would this potentially be wrong?

```sql
SELECT p.Name, COUNT(*)
FROM Projects AS p
LEFT JOIN Tasks AS t
 ON p.Id = t.ProjectId
GROUP BY p.Name;
```

Specifically think about a project with **zero tasks**.

i think because of count(*) even the non existents would be added i guess? 
we would need to do something more like count(t.id)??


*/
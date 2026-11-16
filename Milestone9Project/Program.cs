var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

app.MapGet("/", () => "Hello World!");

app.Run();

// Milestone 9 project; Support Ticket Database

// database.sql => creates the structure
// seed.sql => inserts initial/sample data

/*
Part 3 — Basic Queries
Write SQL for these:
1. Get all unresolved support tickets.
2. Get all tickets in the 'Billing' category.
3. Get all tickets ordered by Id descending.
4. Get the user whose Id = 3.
5. Get all users whose email is missing.
6. Count how many support tickets exist.
7. Count how many unresolved tickets exist.
8. Find how many tickets exist in each category.


---
---
---


sqlite> select * from supporttickets where isClosed = false;
   Id  Title                  Category  IsClosed  UserId
   --  ---------------------  --------  --------  ------
   1   Cannot log in          Account   0         1     
   2   Payment failed         Billing   0         2     
   4   Cannot reset password  Account   0         3     
   sqlite> select * from supporttickets where category = 'Billing';
   Id  Title              Category  IsClosed  UserId
   --  -----------------  --------  --------  ------
   2   Payment failed     Billing   0         2     
   5   Incorrect invoice  Billing   1         2     
   sqlite> select * 
      ...> from supporttickets
      ...> order by id desc;
   Id  Title                  Category   IsClosed  UserId
   --  ---------------------  ---------  --------  ------
   5   Incorrect invoice      Billing    1         2     
   4   Cannot reset password  Account    0         3     
   3   Application crashes    Technical  1         1     
   2   Payment failed         Billing    0         2     
   1   Cannot log in          Account    0         1     
   sqlite> select * from users where id = 3;
   Id  Name     Email
   --  -------  -----
   3   Charlie       
   sqlite> select * form users where email is null;
   Parse error: near "form": syntax error
     select * form users where email is null;
              ^--- error here
   sqlite> select * from users where email is null;
   Id  Name     Email
   --  -------  -----
   3   Charlie       
   sqlite> select count(*) from supporttickets;
   count(*)
   --------
   5       
   sqlite> select count(*) from supporttickets where isclosed = false;
   count(*)
   --------
   3       
   sqlite> select category, count(id)
      ...> from supporttickets
      ...> group by Category;
   Category   count(id)
   ---------  ---------
   Account    2        
   Billing    2        
   Technical  1        
   sqlite> 
   

*/


// part 4
/*

Great — Part 4: Aggregates + GROUP BY using your real database.
   
   We’ll keep it practical.
   
   Use the same tables you already created.
   Tasks
   1. Count how many tickets each user has.
   Expected shape:
   UserId | TicketCount
   
   2. Count how many tickets exist in each category.
   You already did this once, but do it again as part of the project.
   3. Count how many unresolved tickets exist in each category.
   4. Find the total number of tags.
   5. Count how many tags are attached to each ticket.
   Hint: this uses TicketTags.
   
   Expected shape:
   TicketId | TagCount
   
   6. Find the maximum TicketId in SupportTickets.
   7. Find the minimum TicketId.
   8. Count how many tickets each user has, but this time include the user's name.
   That means you’ll need:
   Users
   → SupportTickets
   
   
   
   
   0000000
   -------
   1111111
   
   
sqlite> clear
      ...> ;
   Parse error: near "clear": syntax error
     clear ;
     ^--- error here
   sqlite> .quit
   Milestone9Project $ clear
   
   Milestone9Project $ sqlite3 support-tickets.db 
   SQLite version 3.51.0 2025-06-12 13:14:41
   Enter ".help" for usage hints.
   sqlite> .headers on
   sqlite> .mode 
   current output mode: list --escape ascii
   sqlite> .mode on
   Error: mode should be one of: ascii box column csv html insert json line list markdown qbox quote table tabs tcl
   sqlite> .modeon
   Error: unknown command or invalid arguments:  "modeon". Enter ".help" for help
   sqlite> .modes on
   Error: unknown command or invalid arguments:  "modes". Enter ".help" for help
   sqlite> .mode column
   sqlite> select u.id, count(t.id) as TicketCount
      ...> from users as u 
      ...> inner join supporttickets as t
      ...> group by u.id;
   Id  TicketCount
   --  -----------
   1   5          
   2   5          
   3   5          
   4   5          
   sqlite> select category, count(st.id) as ticketcount
      ...> select category, count(id) as ticketcount
      ...> from supportticket 
      ...> group by category;
   Parse error: near "select": syntax error
     select category, count(st.id) as ticketcount select category, count(id) as tic
                                    error here ---^
   sqlite> select category, count(id) as ticketcount
      ...> from supportticket
      ...> group by category;
   Parse error: no such table: supportticket
   sqlite> select category, count(id) as ticketcount
      ...> from supporttickets
      ...> group by category;
   Category   ticketcount
   ---------  -----------
   Account    2          
   Billing    2          
   Technical  1          
   sqlite> select category, count(id) as unresolvedTickets
      ...> from supporttickets
      ...> where isclosed = false
      ...> group by category;
   Category  unresolvedTickets
   --------  -----------------
   Account   2                
   Billing   1                
   sqlite> select count(*) from tags;
   count(*)
   --------
   5       
   sqlite> select st.id as ticketId, count(tt.tagid) as tagcount
      ...> from supporttickets as st
      ...> inner join tickettags as tt on tt.ticketid = st.id
      ...> group by st.id;
   ticketId  tagcount
   --------  --------
   1         2       
   2         2       
   3         2       
   4         1       
   5         1       
   sqlite> select max(id) from supporttickets;
   max(id)
   -------
   5      
   sqlite> select min(id) from SupportTickets;
   min(id)
   -------
   1      
   sqlite> select u.id, count(st.id) as ticketcount
      ...> from users as u
      ...> inner join supporttickets as st on st.id = u.id
      ...> group by u.id;
   Id  ticketcount
   --  -----------
   1   1          
   2   1          
   3   1          
   4   1          
   sqlite> -- this one is wrong
   sqlite> select u.name, count(st.id) as ticketcount
      ...> from users as u
      ...> inner join supporttickets as st on st.id = u.id
      ...> group by u.name;
   Name     ticketcount
   -------  -----------
   Alice    1          
   Bob      1          
   Charlie  1          
   Sarah    1          
   sqlite> -- yep this one does seem wrong
   sqlite> select u.name, count(st.ownerid) as ticketcount
      ...> from users as u
      ...> inner join supporttickets as st on st.owner;
   ;
   Parse error: no such column: st.ownerid
     select u.name, count(st.ownerid) as ticketcount from users as u inner join sup
                          ^--- error here
   sqlite> select u.name, count(st.id) as ticketcount
      ...> from users as u 
      ...> inner join supporttickets as st on st.ownerid = u.id
      ...> group by u.name;
   Parse error: no such column: st.ownerid
   sqlite> select u.name, count(st.id) as ticketcount
      ...> from users as u
      ...> inner join supporttickets as st on st.userid = u.id
      ...> group by u.name;
   Name     ticketcount
   -------  -----------
   Alice    2          
   Bob      2          
   Charlie  1          
   sqlite> -- now it seems good
   sqlite> select u.id, count(t.id) as ticketcount
      ...> from users as u
      ...> inner join supporttickets as t on t.userid = u.id
      ...> group by u.id;
   Id  ticketcount
   --  -----------
   1   2          
   2   2          
   3   1          
   sqlite> select u.name, count(st.id) as ticketcount
      ...> from users as u
      ...> left join supporttickets as st on st.userid = u.id
      ...> group by u.name;
   Name     ticketcount
   -------  -----------
   Alice    2          
   Bob      2          
   Charlie  1          
   Sarah    0          
   sqlite> 
   
   

*/


// part 5

/*
Great — **Part 5: JOIN Queries**.
   
   Now we’re going to use the relationships in the real database and actually pull useful combined data.
   
   You have:
   
   ```text
   Users
   → SupportTickets
   → TicketTags
   → Tags
   ```
   
   Relationships:
   
   ```text
   SupportTickets.UserId → Users.Id
   TicketTags.TicketId   → SupportTickets.Id
   TicketTags.TagId      → Tags.Id
   ```
   
   Try these directly in SQLite.
   
   ### Part 5 Tasks
   
   1. Show each ticket title together with the name of the user who created it.
   
   Expected shape:
   
   ```text
   Title                  UserName
   ---------------------  --------
   Cannot log in          Alice
   Payment failed         Bob
   ...
   ```
   
   2. Show:
   
   ```text
   Ticket Id
   Ticket Title
   User Name
   Category
   ```
   
   for every ticket.
   
   3. Show all users together with their tickets, including users with **zero tickets**.
   
   Sarah should appear.
   
   4. Show every ticket together with each of its tags.
   
   Think:
   
   ```text
   SupportTickets
   → TicketTags
   → Tags
   ```
   
   A ticket with two tags should appear twice, once for each tag.
   
   5. Show only the tickets that have the tag:
   
   ```text
   'Urgent'
   ```
   
   Return:
   
   ```text
   Ticket Title
   Tag Name
   ```
   
   6. Show:
   
   ```text
   User Name
   Ticket Title
   Tag Name
   ```
   
   for every ticket/tag relationship.
   
   This one goes through all four tables:
   
   ```text
   Users
   → SupportTickets
   → TicketTags
   → Tags
   ```
   
   7. Show each tag together with the number of tickets using that tag.
   
   Expected idea:
   
   ```text
   Urgent   2
   Bug      1
   Login    2
   ...
   ```
   
   8. Show **all tags**, even tags that are attached to zero tickets, together with their ticket count.
   
   Your current data happens to use every tag, but write the query so that unused tags would still show `0`.
   
   9. Show the number of tickets created by each user, including Sarah with `0`.
   
   You already did something very similar, so this should be a confidence check.
   
   10. Show only unresolved tickets, together with the user’s name.
   
   This one combines:
   
   ```text
   JOIN + WHERE
   ```
   
   Send me your queries and the actual SQLite results again. If something looks strange, leave your comment next to it like you’ve been doing.



sqlite> -- this is the beginning of the part 5
   sqlite> select st.title, u.name
      ...> from supporttickets as st
      ...> inner join users as u on u.id = st.userid
      ...> ;
   Title                  Name   
   ---------------------  -------
   Cannot log in          Alice  
   Payment failed         Bob    
   Application crashes    Alice  
   Cannot reset password  Charlie
   Incorrect invoice      Bob    
   sqlite> select * from supporttickets;
   Id  Title                  Category   IsClosed  UserId
   --  ---------------------  ---------  --------  ------
   1   Cannot log in          Account    0         1     
   2   Payment failed         Billing    0         2     
   3   Application crashes    Technical  1         1     
   4   Cannot reset password  Account    0         3     
   5   Incorrect invoice      Billing    1         2     
   sqlite> -- 2.
   sqlite> select st.id, st.title, u.name, st.category
      ...> from supporttickets as st
      ...> inner join users as u on u.id = st.userid;
   Id  Title                  Name     Category 
   --  ---------------------  -------  ---------
   1   Cannot log in          Alice    Account  
   2   Payment failed         Bob      Billing  
   3   Application crashes    Alice    Technical
   4   Cannot reset password  Charlie  Account  
   5   Incorrect invoice      Bob      Billing  
   sqlite> -- 3.
   sqlite> select u.id, u.name, st.id as ticketid, st.title
      ...> from users as u
      ...> inner join supporttickets as st on st.userid = u.id;
   Id  Name     ticketid  Title                
   --  -------  --------  ---------------------
   1   Alice    1         Cannot log in        
   2   Bob      2         Payment failed       
   1   Alice    3         Application crashes  
   3   Charlie  4         Cannot reset password
   2   Bob      5         Incorrect invoice    
   sqlite> select u.id, u.name, st.id as ticketid, st.title
      ...> from users as u
      ...> left join supporttickets as st on st.userid = u.id;
   Id  Name     ticketid  Title                
   --  -------  --------  ---------------------
   1   Alice    1         Cannot log in        
   1   Alice    3         Application crashes  
   2   Bob      2         Payment failed       
   2   Bob      5         Incorrect invoice    
   3   Charlie  4         Cannot reset password
   4   Sarah                                   
   sqlite> -- 4.
   sqlite> select st.id, st.title, t.id, t.name
      ...> from supporttickets as st 
      ...> inner join tickettags as tt on st.id = tt.ticketid
      ...> inner join tags as t on t.id = tt.tagid;
   Id  Title                  Id  Name   
   --  ---------------------  --  -------
   1   Cannot log in          1   Urgent 
   1   Cannot log in          3   Login  
   2   Payment failed         4   Payment
   2   Payment failed         1   Urgent 
   3   Application crashes    2   Bug    
   3   Application crashes    5   Backend
   4   Cannot reset password  3   Login  
   5   Incorrect invoice      4   Payment
   sqlite> -- 5.
   sqlite> select st.id, st.title, t.name
      ...> from SupportTickets as st
      ...> inner join TicketTags as tt on tt.ticketid = st.id
      ...> inner join Tags as t on t.id = tt.tagid
      ...> where t.name = 'Urgent';
   Id  Title           Name  
   --  --------------  ------
   1   Cannot log in   Urgent
   2   Payment failed  Urgent
   sqlite> -- 6.
   sqlite> select u.name, st.title, t.name
      ...> from users as u
      ...> inner join supporttickets as st on st.userid = u.id
      ...> inner join TicketTags as tt on tt.ticketid = st.id
      ...> inner join tags as t on t.id = tt.tagid;
   Name     Title                  Name   
   -------  ---------------------  -------
   Alice    Cannot log in          Urgent 
   Alice    Cannot log in          Login  
   Bob      Payment failed         Payment
   Bob      Payment failed         Urgent 
   Alice    Application crashes    Bug    
   Alice    Application crashes    Backend
   Charlie  Cannot reset password  Login  
   Bob      Incorrect invoice      Payment
   sqlite> -- 7.
   sqlite> select t.name as tagName, count(st.id) as ticketCount
      ...> from tags as t
      ...> inner join TicketTags as tt on tt.tagid = t.id
      ...> inner join SupportTickets as st on st.id = tt.ticketid
      ...> group by t.name;
   tagName  ticketCount
   -------  -----------
   Backend  1          
   Bug      1          
   Login    2          
   Payment  2          
   Urgent   2          
   sqlite> -- 8.
   sqlite> select t.id, t.name, count(st.id) as ticketcount
      ...> from tags as t 
      ...> left join TicketTags as tt on tt.tagid = t.id
      ...> inner join SupportTickets as st on st.id = tt.ticketid
      ...> group by t.id;
   Id  Name     ticketcount
   --  -------  -----------
   1   Urgent   2          
   2   Bug      1          
   3   Login    2          
   4   Payment  2          
   5   Backend  1          
   sqlite> select * from tags;
   Id  Name   
   --  -------
   1   Urgent 
   2   Bug    
   3   Login  
   4   Payment
   5   Backend
   sqlite> -- i think all cool, in here, all tags are used
   sqlite> -- 9.
   sqlite> select u.id, u.name, count(st.id) as ticketCount
      ...> from users as u
      ...> left join SupportTickets as st on st.userid = u.id
      ...> group by u.id;
   Id  Name     ticketCount
   --  -------  -----------
   1   Alice    2          
   2   Bob      2          
   3   Charlie  1          
   4   Sarah    0          
   sqlite> select st.id, st.title, u.name
      ...> from SupportTickets as st 
      ...> inner join Users as u on u.id = st.userid
      ...> where st.isclosed = false;
   Id  Title                  Name   
   --  ---------------------  -------
   1   Cannot log in          Alice  
   2   Payment failed         Bob    
   4   Cannot reset password  Charlie
   sqlite> -- 8....
   sqlite> -- 8 fixed
   sqlite> select t.id, t.name, count(tt.ticketid) as ticketcount
      ...> from tags as t
      ...> inner join TicketTags as tt on tt.tagid = t.id
      ...> group by t.id;
   Id  Name     ticketcount
   --  -------  -----------
   1   Urgent   2          
   2   Bug      1          
   3   Login    2          
   4   Payment  2          
   5   Backend  1          
   sqlite> select t.id, t.name, count(tt.ticketid) as ticketcount
      ...> left join TicketTags as tt on tt.tagid = t.id
      ...> group by t.id;
   Parse error: near "left": syntax error
     t t.id, t.name, count(tt.ticketid) as ticketcount left join TicketTags as tt o
                                         error here ---^
   sqlite> select t.id, t.name, count(tt.ticketid) as ticketcount
      ...> from tags as t
      ...> left join TicketTags as tt on tt.tagid = t.id
      ...> group by t.id;
   Id  Name     ticketcount
   --  -------  -----------
   1   Urgent   2          
   2   Bug      1          
   3   Login    2          
   4   Payment  2          
   5   Backend  1          
   sqlite> 
   

*/


// part 6 - harder multi table queries

/*

Part 6 Tasks
   1. Show each user name together with the number of unresolved tickets they have.
   Include users with 0 unresolved tickets.
   2. Show each category together with the number of tickets in that category.
   Only include categories with at least one unresolved ticket.
   3. Show each user name together with the number of tags attached across all of their tickets.
   For example, if Alice has:
   - ticket 1 with 2 tags
   - ticket 3 with 2 tags
   then Alice should have:
   4
   
   Think through:
   Users
   → SupportTickets
   → TicketTags
   
   4. Show each ticket title together with the number of tags it has.
   Include tickets with zero tags.
   5. Show all users who have at least one ticket tagged 'Urgent'.
   You’ll need:
   Users
   → SupportTickets
   → TicketTags
   → Tags
   
   6. Show all tags used by tickets in the 'Billing' category.
   Return:
   Tag Name
   
   7. Show each user together with the number of different tags used across their tickets.
   This one is slightly harder.
   
   Think about whether:
   COUNT(...)
   
   might count the same tag more than once if it appears on multiple tickets.
   8. Show the ticket title, user name, and tag name for all unresolved tickets.
   9. Show all users, and for each user show:
      - total number of tickets
      - number of unresolved tickets
   Expected shape:
   Name     TotalTickets   UnresolvedTickets
   Alice    2              1
   Bob      2              1
   Charlie  1              1
   Sarah    0              0
   
   This one is the hardest in this section.
   10. Conceptual question:
   If you write:
   FROM Users AS u
   LEFT JOIN SupportTickets AS st
       ON st.UserId = u.Id
   WHERE st.IsClosed = false
   
   what potential problem does that create for users with zero tickets?
   






*/

// ============================================================
// MILESTONE 9 - PART 6
// HARDER MULTI-TABLE QUERIES
// ============================================================
//
// TABLES:
//
// Users
// SupportTickets
// Tags
// TicketTags
//
// RELATIONSHIPS:
//
// SupportTickets.UserId -> Users.Id
// TicketTags.TicketId   -> SupportTickets.Id
// TicketTags.TagId      -> Tags.Id
//
//
// ============================================================
// 1. SHOW EACH USER + NUMBER OF UNRESOLVED TICKETS
// INCLUDE USERS WITH 0 UNRESOLVED TICKETS
// ============================================================
//
// select u.name, count(st.id) as unresolvedTicketCount
// from users as u
// left join SupportTickets as st
//     on st.userid = u.id
//     and st.isclosed = false
// group by u.id, u.name;
//
// RESULT:
//
// Alice    1
// Bob      1
// Charlie  1
// Sarah    0
//
//
// IMPORTANT NEW PATTERN:
//
// LEFT JOIN + condition inside ON
// -> preserves left-side rows
//
// LEFT JOIN + condition on right table inside WHERE
// -> can remove the NULL rows again
//
//
// For example:
//
// from users as u
// left join SupportTickets as st
//     on st.userid = u.id
// where st.isclosed = false;
//
// Sarah has no tickets:
//
// Sarah | NULL
//
// Then:
//
// where st.isclosed = false
//
// removes Sarah completely.
//
// If we want Sarah to stay:
//
// left join SupportTickets as st
//     on st.userid = u.id
//     and st.isclosed = false
//
//
// ============================================================
// 2. COUNT UNRESOLVED TICKETS IN EACH CATEGORY
// ============================================================
//
// select category, count(id) as ticketCount
// from SupportTickets
// where isclosed = false
// group by category;
//
// RESULT:
//
// Account  2
// Billing  1
//
//
// PATTERN:
//
// WHERE
// -> filters the rows first
//
// GROUP BY
// -> groups the remaining rows
//
// COUNT
// -> counts rows inside each group
//
//
// ============================================================
// 3. NUMBER OF TAGS ATTACHED ACROSS EACH USER'S TICKETS
// ============================================================
//
// select u.name, count(t.id) as numberOfTagsAttached
// from users as u
// inner join SupportTickets as st
//     on st.userid = u.id
// inner join TicketTags as tt
//     on tt.ticketid = st.id
// inner join Tags as t
//     on t.id = tt.tagid
// group by u.id, u.name;
//
// RESULT:
//
// Alice    4
// Bob      3
// Charlie  1
//
//
// This counts ALL tag attachments.
//
// Example for Bob:
//
// Payment
// Urgent
// Payment
//
// count = 3
//
//
// ============================================================
// 4. SHOW EACH TICKET + NUMBER OF TAGS
// INCLUDE TICKETS WITH 0 TAGS
// ============================================================
//
// select st.title, count(t.id) as tagCount
// from SupportTickets as st
// left join TicketTags as tt
//     on tt.ticketid = st.id
// left join Tags as t
//     on t.id = tt.tagid
// group by st.id, st.title;
//
//
// WHY LEFT JOIN?
//
// A ticket with no tags must still appear.
//
// WHY count(t.id) INSTEAD OF count(*)?
//
// count(*) counts rows.
//
// count(t.id) counts only non-NULL tag IDs.
//
// Therefore:
//
// ticket with no tags
// -> t.id = NULL
// -> count(t.id) = 0
//
//
// ============================================================
// 5. SHOW USERS WHO HAVE AT LEAST ONE 'URGENT' TICKET
// ============================================================
//
// select distinct u.id, u.name
// from users as u
// inner join SupportTickets as st
//     on st.userid = u.id
// inner join TicketTags as tt
//     on tt.ticketid = st.id
// inner join Tags as t
//     on t.id = tt.tagid
// where t.name = 'Urgent';
//
// RESULT:
//
// Alice
// Bob
//
//
// DISTINCT is useful here because a user could have multiple
// tickets with the Urgent tag.
//
// Without DISTINCT, the same user could appear multiple times.
//
//
// ============================================================
// 6. SHOW ALL DIFFERENT TAGS USED BY BILLING TICKETS
// ============================================================
//
// select distinct t.name as tag
// from Tags as t
// inner join TicketTags as tt
//     on tt.tagid = t.id
// inner join SupportTickets as st
//     on st.id = tt.ticketid
// where st.category = 'Billing';
//
// RESULT:
//
// Payment
// Urgent
//
//
// DISTINCT
// --------
//
// DISTINCT goes directly after SELECT:
//
// select distinct ...
//
//
// Example:
//
// Without DISTINCT:
//
// Payment
// Urgent
// Payment
//
// With:
//
// select distinct t.name
//
// RESULT:
//
// Payment
// Urgent
//
//
// IMPORTANT:
//
// DISTINCT applies to the whole selected row.
//
// select distinct t.name
//
// -> unique tag names
//
//
// select distinct t.name, st.title
//
// -> unique combinations of:
//
// tag name + ticket title
//
//
// So these are DIFFERENT rows:
//
// Payment | Payment failed
// Payment | Incorrect invoice
//
//
// ============================================================
// 7. SHOW EACH USER + NUMBER OF DIFFERENT TAGS THEY USE
// INCLUDE USERS WITH 0
// ============================================================
//
// select u.name,
//        count(distinct tt.tagid) as differentTagCount
// from users as u
// left join SupportTickets as st
//     on st.userid = u.id
// left join TicketTags as tt
//     on tt.ticketid = st.id
// group by u.id, u.name;
//
// RESULT:
//
// Alice    4
// Bob      2
// Charlie  1
// Sarah    0
//
//
// NEW PATTERN:
//
// count(distinct column)
//
// -> counts different non-NULL values
//
//
// Example:
//
// Payment
// Urgent
// Payment
//
// count(tagid)
// -> 3
//
// count(distinct tagid)
// -> 2
//
//
// REMEMBER:
//
// count(*)
// -> counts rows
//
// count(column)
// -> counts non-NULL values
//
// count(distinct column)
// -> counts different non-NULL values
//
//
// ============================================================
// 8. SHOW UNRESOLVED TICKETS + USER + TAG
// ============================================================
//
// select st.title,
//        u.name as userName,
//        t.name as tagName
// from SupportTickets as st
// inner join Users as u
//     on u.id = st.userid
// inner join TicketTags as tt
//     on tt.ticketid = st.id
// inner join Tags as t
//     on t.id = tt.tagid
// where st.isclosed = false;
//
//
// RELATIONSHIP PATH:
//
// Users
// -> SupportTickets
// -> TicketTags
// -> Tags
//
//
// ============================================================
// 9. SHOW EACH USER:
// TOTAL TICKETS + UNRESOLVED TICKETS
// ============================================================
//
// select u.name,
//        count(st.id) as totalTickets,
//        sum(
//            case
//                when st.isclosed = false then 1
//                else 0
//            end
//        ) as unresolvedTickets
// from users as u
// left join SupportTickets as st
//     on st.userid = u.id
// group by u.id, u.name;
//
// RESULT:
//
// Alice    2    1
// Bob      2    1
// Charlie  1    1
// Sarah    0    0
//
//
// NEW CONCEPT: CONDITIONAL AGGREGATION
//
// sum(
//     case
//         when condition then 1
//         else 0
//     end
// )
//
//
// Mental model in C#:
//
// if (condition)
// {
//     count += 1;
// }
// else
// {
//     count += 0;
// }
//
//
// So:
//
// count(st.id)
// -> counts ALL tickets
//
// sum(case ...)
// -> counts only tickets matching a condition
//
//
// This is called:
//
// CONDITIONAL AGGREGATION
//
//
// ============================================================
// 10. IMPORTANT LEFT JOIN + WHERE PROBLEM
// ============================================================
//
// Example:
//
// from Users as u
// left join SupportTickets as st
//     on st.userid = u.id
// where st.isclosed = false;
//
//
// Sarah has zero tickets.
//
// LEFT JOIN first produces:
//
// Sarah | NULL
//
//
// But then:
//
// where st.isclosed = false
//
// removes the Sarah row.
//
//
// If the requirement says:
//
// "include users with zero matching tickets"
//
// consider:
//
// left join SupportTickets as st
//     on st.userid = u.id
//     and st.isclosed = false
//
//
// ============================================================
// KEY PATTERNS FROM PART 6
// ============================================================
//
// Need only matching rows:
// -> INNER JOIN
//
//
// Need all rows from the left side even if no match:
// -> LEFT JOIN
//
//
// Need one result per group:
// -> GROUP BY
//
//
// Need only unique result rows:
// -> DISTINCT
//
//
// Need number of unique values:
// -> COUNT(DISTINCT column)
//
//
// Need count based on a condition:
// -> SUM(CASE WHEN ... THEN 1 ELSE 0 END)
//
//
// Need LEFT JOIN rows to survive a filter:
// -> consider putting the condition inside ON
//
//
// ============================================================
// RELATIONSHIP RECOGNITION
// ============================================================
//
// Users -> SupportTickets
//
// SupportTickets.UserId = Users.Id
//
//
// SupportTickets -> TicketTags
//
// TicketTags.TicketId = SupportTickets.Id
//
//
// TicketTags -> Tags
//
// TicketTags.TagId = Tags.Id
//
//
// Full path:
//
// Users
// -> SupportTickets
// -> TicketTags
// -> Tags
//
//
// When writing a multi-table query:
// follow one foreign-key relationship at a time.
// ============================================================




// part 7 


/*

Part 7 Tasks
   1. Change ticket Id = 4 so that:
   IsClosed = true
   
   2. Change ticket Id = 2:
   Category = 'Technical'
   IsClosed = true
   
   3. Change user Id = 3 email to:
   charlie@email.com
   
   4. Delete this relationship from TicketTags:
   TicketId = 3
   TagId = 5
   
   That means ticket 3 should no longer have the Backend tag.
   5. Delete the tag:
   Id = 5
   
   Think carefully here: because of foreign keys, whether this succeeds depends on whether something still references that tag.
   6. Try to delete:
   User Id = 1
   
   Think before you run it:
   Alice owns tickets 1 and 3
   
   What do you expect the foreign-key constraint to do?
   7. After the updates/deletes, verify the data with:
   SELECT * FROM SupportTickets;
   SELECT * FROM Users;
   SELECT * FROM Tags;
   SELECT * FROM TicketTags;
   
   
   
=================================================================================
Before UPDATE or DELETE:
   always check exactly what the WHERE matches.
   
!!!!!!!!!
!!!!!!!!!
!!!!!!!!!
SQLite's foreign_keys setting is connection-specific
run this to turn it on:
PRAGMA foreign_keys;
   
   

sqlite> PRAGMA FOREIGN_keys
      ...> ;
   foreign_keys
   ------------
   0           
   sqlite> .quit
   Milestone9Project $ rm support-tickets.db 
   Milestone9Project $ sqlite3 support-tickets.db
   SQLite version 3.51.0 2025-06-12 13:14:41
   Enter ".help" for usage hints.
   sqlite> PRAGMA foreign_keys = ON;
   sqlite> .read database.sql
   sqlite> .read seed.sql
   sqlite> PRAGMA foreign_keys;
   1
   sqlite> select * from users;
   1|Alice|alice@email.com
   2|Bob|bob@email.com
   3|Charlie|
   4|Sarah|sarah@email.com
   sqlite> 
   
   




sqlite> -- ===================================================================
   sqlite> part 7 
      ...> ;
   Parse error: near "part": syntax error
     part 7  ;
     ^--- error here
   sqlite> -- part 7
   sqlite> update SupportTickets 
      ...> set isclosed = true
      ...> where id = 4;
   sqlite> select * from SupportTickets where id = 4;
   Id  Title                  Category  IsClosed  UserId
   --  ---------------------  --------  --------  ------
   4   Cannot reset password  Account   1         3     
   sqlite> -- 2.
   sqlite> update SupportTickets 
      ...> set category = 'Technical',
      ...> isclosed = true
      ...> where id = 2;
   sqlite> -- 3.
   sqlite> update users 
      ...> set email = 'charlie@email.com'
      ...> where id = 2;
   sqlite> 4. 
      ...> ;
   Parse error: near "4.": syntax error
     4.  ;
     ^--- error here
   sqlite> -- 4.
   sqlite> delete from TicketTags 
      ...> where ticketid = 3;
   sqlite> select * from TicketTags ;
   TicketId  TagId
   --------  -----
   1         1    
   1         3    
   2         4    
   2         1    
   4         3    
   5         4    
   sqlite> -- i might have deleted every ticket3
   sqlite> -- correct way would have been:
   sqlite> delete from TicketTags 
      ...> where ticketid = 3 and tagid = 5;
   sqlite> -- 5.
   sqlite> select * from tags;
   Id  Name   
   --  -------
   1   Urgent 
   2   Bug    
   3   Login  
   4   Payment
   5   Backend
   sqlite> delete from tags where id = 5;
   sqlite> select * from tags;
   Id  Name   
   --  -------
   1   Urgent 
   2   Bug    
   3   Login  
   4   Payment
   sqlite> -- working i guess;
   sqlite> -- 6. -- foreign key constraint should not let us delete it
   sqlite> delete from users 
      ...> where id = 1;
   sqlite> select * from users;
   Id  Name     Email            
   --  -------  -----------------
   2   Bob      charlie@email.com
   3   Charlie                   
   4   Sarah    sarah@email.com  
   sqlite> -- it deleted it
   sqlite> PRAGMA 
      ...> ;
   Parse error: near ";": syntax error
     PRAGMA  ;
             ^--- error here
   sqlite> select * from SupportTickets;
   Id  Title                  Category   IsClosed  UserId
   --  ---------------------  ---------  --------  ------
   1   Cannot log in          Account    0         1     
   2   Payment failed         Technical  1         2     
   3   Application crashes    Technical  1         1     
   4   Cannot reset password  Account    1         3     
   5   Incorrect invoice      Billing    1         2     
   sqlite> select * from User
   UserId Users 
   sqlite> select * from Users;
   Id  Name     Email            
   --  -------  -----------------
   2   Bob      charlie@email.com
   3   Charlie                   
   4   Sarah    sarah@email.com  
   sqlite> select * from Tags ;
   Id  Name   
   --  -------
   1   Urgent 
   2   Bug    
   3   Login  
   4   Payment
   sqlite> select * from TicketTags ;
   TicketId  TagId
   --------  -----
   1         1    
   1         3    
   2         4    
   2         1    
   4         3    
   5         4    
   sqlite> PRAGMA FOREIGN_keys
      ...> ;
   foreign_keys
   ------------
   0       
   */
   
   
   
   
// part final review
// ===========================
// ===========================
// ===========================

/*


Assume the same database:
   Users(
       Id,
       Name,
       Email
   )
   
   SupportTickets(
       Id,
       Title,
       Category,
       IsClosed,
       UserId
   )
   
   Tags(
       Id,
       Name
   )
   
   TicketTags(
       TicketId,
       TagId
   )
   
   Relationships:
   SupportTickets.UserId -> Users.Id
   
   TicketTags.TicketId -> SupportTickets.Id
   
   TicketTags.TagId -> Tags.Id
   
   Final Review
   1. Get all unresolved support tickets.
   2. Get all tickets in the 'Billing' category, ordered by Id descending.
   3. Count how many tickets exist in each category.
   4. Count how many unresolved tickets exist in each category.
   5. Show each ticket title together with the name of the user who created it.
   6. Show all users together with the number of tickets they have. Users with zero tickets must show 0.
   7. Show every ticket together with its tags.
   8. Show every ticket together with the number of tags it has. Tickets with zero tags must still appear with 0.
   9. Show all different tags used by tickets in the 'Account' category.
   Do not return duplicate tag names.
   10. Show every user together with the number of different tags used across all of their tickets.
   Users with zero tickets must show 0.
   11. Show:
   User Name
   Ticket Title
   Tag Name
   
   for all unresolved tickets.
   12. Show each user together with:
   TotalTickets
   ClosedTickets
   UnresolvedTickets
   
   Users with zero tickets must still appear.
   
   This one will require conditional aggregation.
   13. Update ticket Id = 1 so that:
   Category = 'Technical'
   IsClosed = true
   
   14. Remove this relationship:
   TicketId = 2
   TagId = 1
   
   from TicketTags.
   15. Before deleting user Id = 1, what should happen if foreign-key enforcement is ON and that user still has support tickets?
   16. What is the difference between:
   COUNT(*)
   
   and:
   COUNT(st.Id)
   
   when st comes from a LEFT JOIN?
   17. Why can this be dangerous?
   FROM Users AS u
   LEFT JOIN SupportTickets AS st
       ON st.UserId = u.Id
   WHERE st.IsClosed = false
   
   18. What is the difference between:
   COUNT(tt.TagId)
   
   and:
   COUNT(DISTINCT tt.TagId)
   
   19. What does this mean?
   PRIMARY KEY (TicketId, TagId)
   
   20. What kind of relationship exists between:
   SupportTickets <-> Tags
   
   and why do we need TicketTags?
   
   Run the SQL ones against SQLite where possible.
   
   For #13 and #14, because this is the final review and they mutate the data, you can either run them and reset afterward, or just write the correct SQL without executing them.
   
   
   
   
   
   ------------
   ============
   

   sqlite> -- ================================
   sqlite> -- final review
   sqlite> -- 1. select * from SupportTickets where isclosed = false;
   sqlite> select * from SupportTickets where isclosed = false;
   Id  Title                  Category  IsClosed  UserId
   --  ---------------------  --------  --------  ------
   1   Cannot log in          Account   0         1     
   2   Payment failed         Billing   0         2     
   4   Cannot reset password  Account   0         3     
   sqlite> -- 2.
   sqlite> select * from SupportTickets 
      ...> where Category = 'Billing'
      ...> order by id desc;
   Id  Title              Category  IsClosed  UserId
   --  -----------------  --------  --------  ------
   5   Incorrect invoice  Billing   1         2     
   2   Payment failed     Billing   0         2     
   sqlite> select category, count(id) as ticketcount
      ...> from SupportTickets 
      ...> group by Category ;
   Category   ticketcount
   ---------  -----------
   Account    2          
   Billing    2          
   Technical  1          
   sqlite> -- 4
   sqlite> -- 4.
   sqlite> select category, count(id) as unresolvedCategory
      ...> from SupportTickets 
      ...> where isclosed = false
      ...> group by Category ;
   Category  unresolvedCategory
   --------  ------------------
   Account   2                 
   Billing   1                 
   sqlite> -- 5.
   sqlite> select st.title, u.name as user_name
      ...> from SupportTickets as st 
      ...> inner join users as u on u.id = st.userid;
   Title                  user_name
   ---------------------  ---------
   Cannot log in          Alice    
   Payment failed         Bob      
   Application crashes    Alice    
   Cannot reset password  Charlie  
   Incorrect invoice      Bob      
   sqlite> -- 6.
   sqlite> select u.id, u.name, count(st.id) as ticket_count
      ...> from users as u
      ...> left join SupportTickets as st on st.userid = u.id
      ...> group by u.id, u.name;
   Id  Name     ticket_count
   --  -------  ------------
   1   Alice    2           
   2   Bob      2           
   3   Charlie  1           
   4   Sarah    0           
   sqlite> -- 7.
   sqlite> select st.id, st.title, t.name as tag_name
      ...> from SupportTickets as st 
      ...> inner join TicketTags as tt on tt.ticketid = st.id
      ...> inner join tags as t on t.id = tt.tagid;
   Id  Title                  tag_name
   --  ---------------------  --------
   1   Cannot log in          Urgent  
   1   Cannot log in          Login   
   2   Payment failed         Payment 
   2   Payment failed         Urgent  
   3   Application crashes    Bug     
   3   Application crashes    Backend 
   4   Cannot reset password  Login   
   5   Incorrect invoice      Payment 
   sqlite> -- 8.
   sqlite> select st.id, st.title, count(t.id) as tag_count
      ...> from SupportTickets as st
      ...> left join TicketTags as tt on tt.ticketid = st.id
      ...> left join tags as t on t.id = tt.tagid
      ...> group by st.id, st.title;
   Id  Title                  tag_count
   --  ---------------------  ---------
   1   Cannot log in          2        
   2   Payment failed         2        
   3   Application crashes    2        
   4   Cannot reset password  1        
   5   Incorrect invoice      1        
   sqlite> -- 9
   sqlite> -- 9.
   sqlite> select DISTINCT t.id
      ...> from tags as t
      ...> inner join TicketTags as tt on tt.tagid = t.id
      ...> inner join SupportTickets as st on st.id = tt.ticketid
      ...> where st.category = 'Account';
   Id
   --
   1 
   3 
   sqlite> -- 10.
   sqlite> select u.id, u.name, count(DISTINCT t.id)
      ...> from users as u
      ...> left join SupportTickets as st on st.userid = u.id
      ...> left join TicketTags as tt on tt.ticketid = st.id
      ...> left join tags as t on t.id = tt.tagid
      ...> group by u.id, u.name;
   Id  Name     count(DISTINCT t.id)
   --  -------  --------------------
   1   Alice    4                   
   2   Bob      2                   
   3   Charlie  1                   
   4   Sarah    0                   
   sqlite> -- i m not sure abot this one
   sqlite> select u.name, st.title, t.name as tag_name
      ...> from users as u
      ...> inner join SupportTickets as st on st.userid = u.id
      ...> inner join TicketTags as tt on tt.ticketid = st.id
      ...> inner join tags as t on t.id = tt.tagid;
   Name     Title                  tag_name
   -------  ---------------------  --------
   Alice    Cannot log in          Urgent  
   Alice    Cannot log in          Login   
   Bob      Payment failed         Payment 
   Bob      Payment failed         Urgent  
   Alice    Application crashes    Bug     
   Alice    Application crashes    Backend 
   Charlie  Cannot reset password  Login   
   Bob      Incorrect invoice      Payment 
   sqlite> -- 12
   sqlite> -- 12.
   sqlite> select u.id, u.name, count(st.id) as total_tickets, 
      ...> sum( 
   (x1...> case 
   (x1...> when st.isclosed = true then 1
   (x1...> else 1
   (x1...> end) as closed_tickets,
      ...> sum(
   (x1...> case
   (x1...> when st.isclosed = false then 1 else 0
   (x1...> ;
   Parse error: near ";": syntax error
      sum( case when st.isclosed = false then 1 else 0 ;
                                         error here ---^
   sqlite> -- i made a mistake i will try again
   sqlite> select u.id, u.name, count(st.id) as total_tickets,
      ...> sum( case when st.isclosed = true then 1 else 0 end ) as closed_tickets,
      ...> sum( case when st.isclosed = false then 1 else 0 end ) as unresolved_tickets
      ...> from users as u
      ...> left join SupportTickets as st on st.userid = u.id
      ...> group by u.id, u.name;
   Id  Name     total_tickets  closed_tickets  unresolved_tickets
   --  -------  -------------  --------------  ------------------
   1   Alice    2              1               1                 
   2   Bob      2              1               1                 
   3   Charlie  1              0               1                 
   4   Sarah    0              0               0                 
   sqlite> -- i am kidna sure in here, i looked at what we did earlier
   sqlite> -- 13.
   sqlite> update SupportTickets 
      ...> set Category = 'Technical', 
      ...> IsClosed = true
      ...> where id = 1;
   sqlite> -- 14.
   sqlite> delete from TicketTags 
      ...> where TicketId = 2 and Tag
   TagId Tags 
      ...> where TicketId = 2 and TagId = 1;
   sqlite> -- 15.
   sqlite> -- contraints wont' let us delete
   sqlite> -- 16.
   sqlite> count(*) will include even the empty rows (nulls), count(st.id) will make sure only exisitng oens are counted
      ...> ;
   Parse error: near "count": syntax error
     count(*) will include even the empty rows (nulls), count(st.id) will make sure
     ^--- error here
   sqlite> --
   sqlite> -- 17.
   sqlite> -- there could be users with no tickets , and therefore they may just be lost wont 'be show i guess??
   sqlite> -- 18.
   sqlite> -- distinct one will make sure duplicates are not counted menaing if certian tag is used more htan once it will be counted only once, the other will will count even if the tag is repeated
   sqlite> -- 19.
   sqlite> -- composite primary key, it is used for junction tables mostly iif i m not wrong
   sqlite> -- 20.
   sqlite> -- many to many, junction table, tickettags is an example
   sqlite> 
   
   
   
   ========
   =======
   =======
   =======
   #16
   COUNT(*) = count result rows
   COUNT(column) = count non-NULL values
   
   #15
   Foreign-key constraints are what protect the relationship
   (and SQLite must actually enforce them)
   
   #2 from the previous JOIN exercise
   Always double-check:
   foreign key = primary key
   
   */
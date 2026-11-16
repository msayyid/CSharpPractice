INSERT INTO Users (Id, Name, Email)
VALUES
    (1, 'Alice', 'alice@email.com'),
    (2, 'Bob', 'bob@email.com'),
    (3, 'Charlie', NULL),
    (4, 'Sarah', 'sarah@email.com');

INSERT INTO SupportTickets (Id, Title, Category, IsClosed, Userid)
VALUES 
    (1, 'Cannot log in', 'Account', false, 1),
    (2, 'Payment failed', 'Billing', false, 2),
    (3, 'Application crashes', 'Technical', true, 1),
    (4, 'Cannot reset password', 'Account', false, 3),
    (5, 'Incorrect invoice', 'Billing', true, 2); 

INSERT INTO Tags (Id, Name)
VALUES 
    (1, 'Urgent'),
    (2, 'Bug'),
    (3, 'Login'),
    (4, 'Payment'),
    (5, 'Backend');

INSERT INTO TicketTags (TicketId, TagId)
VALUES 
    (1, 1),
    (1, 3),
    (2, 4),
    (2, 1),
    (3, 2),
    (3, 5),
    (4, 3),
    (5, 4);
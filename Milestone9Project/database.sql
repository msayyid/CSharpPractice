CREATE TABLE Users (
    Id INT PRIMARY KEY,
    Name VARCHAR(100) NOT NULL,
    Email VARCHAR(200) UNIQUE 
);

CREATE TABLE SupportTickets (
    Id INT PRIMARY KEY,
    Title VARCHAR(200) NOT NULL,
    Category VARCHAR(100) NOT NULL,
    IsClosed BOOLEAN DEFAULT false,
    UserId INT NOT NULL,
    FOREIGN KEY (UserId) REFERENCES Users(Id)
);

CREATE TABLE Tags (
    Id INT PRIMARY KEY,
    Name VARCHAR(100) NOT NULL UNIQUE
);


CREATE TABLE TicketTags(
    TicketId INT NOT NULL,
    TagId INT NOT NULL,
    
    PRIMARY KEY (TicketId, TagId), -- composite primary key: multiple columns together uniquely identify one row

    FOREIGN KEY (TicketId) REFERENCES SupportTickets(Id),
    FOREIGN KEY (TagId) REFERENCES Tags(Id)
);
       


       



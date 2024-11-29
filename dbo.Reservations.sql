CREATE TABLE reservation (
    Id INT PRIMARY KEY IDENTITY(1,1),
    Seat VARCHAR(10),
    Username VARCHAR(50),
    Date DATE,
    Time TIME, 
    [Time] NCHAR(10) NULL
);


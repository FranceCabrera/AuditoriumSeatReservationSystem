CREATE TABLE [dbo].[Reservations] (
    [Id]       INT            IDENTITY (1, 1) NOT NULL,
    [Seat]     NVARCHAR (100) NULL,
    [Name] NVARCHAR (100) NULL,
    [Date] DATE NULL, 
    [Time] TIME NULL, 
    PRIMARY KEY CLUSTERED ([Id] ASC)
);

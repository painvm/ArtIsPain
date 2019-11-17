CREATE TABLE [dbo].[Writer]
(
	[Id] UNIQUEIDENTIFIER NOT NULL PRIMARY KEY DEFAULT NEWID(), 
    [FirstName] NVARCHAR(50) NULL, 
    [LastName] NVARCHAR(50) NOT NULL, 
    [Biography] NVARCHAR(MAX) NULL, 
    [AvatarId] UNIQUEIDENTIFIER NULL FOREIGN KEY REFERENCES [Image](Id), 
    [StartActivityDate] DATE NOT NULL, 
    [EndActivityDate] DATE NULL, 
    [IsDeceased] BIT NULL, 
    [ObjectTypeId] INT NOT NULL
)

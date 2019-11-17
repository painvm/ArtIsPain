CREATE TABLE [dbo].[User]
(
	[Id] UNIQUEIDENTIFIER NOT NULL PRIMARY KEY DEFAULT NEWID(), 
    [FirstName] NVARCHAR(50) NULL, 
    [LastName] NVARCHAR(50) NOT NULL, 
    [LastLoginDate] DATETIME NULL, 
    [RegistrationDate] DATETIME NULL, 
    [Username] NVARCHAR(255) NOT NULL, 
    [ObjectTypeId] INT NOT NULL, 
    [IsActive] BIT NULL, 
    [AvatarId] UNIQUEIDENTIFIER NULL FOREIGN KEY REFERENCES [Image](Id), 
    [Summary] NVARCHAR(MAX) NULL, 
)

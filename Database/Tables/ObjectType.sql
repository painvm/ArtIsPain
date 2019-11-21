CREATE TABLE [dbo].[ObjectType]
(
	[Id] INT NOT NULL, 
    [ParentObjectTypeId] INT NULL, 
    [Code] NVARCHAR(50) NOT NULL UNIQUE, 
    [Name] NVARCHAR(64) NOT NULL UNIQUE

	CONSTRAINT PK_ObjectType PRIMARY KEY([Id])
)

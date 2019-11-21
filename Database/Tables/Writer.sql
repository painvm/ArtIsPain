CREATE TABLE [dbo].[Writer]
(
	[Id] UNIQUEIDENTIFIER NOT NULL PRIMARY KEY DEFAULT NEWID(), 
    [FirstName] NVARCHAR(50) NULL, 
    [LastName] NVARCHAR(50) NOT NULL, 
    [Biography] NVARCHAR(MAX) NULL, 
    [AvatarId] UNIQUEIDENTIFIER NULL,
    [StartActivityDate] DATE NOT NULL, 
    [EndActivityDate] DATE NULL, 
    [IsDeceased] BIT NOT NULL DEFAULT 0, 
    [ObjectTypeId] INT NOT NULL

	CONSTRAINT FK_Writer_Image FOREIGN KEY([AvatarId] ) REFERENCES dbo.[Image]([Id]),
	CONSTRAINT FK_Writer_ObjectType FOREIGN KEY([ObjectTypeId]) REFERENCES dbo.[ObjectType]([Id]),
	CONSTRAINT CHK_Writer_CapturedDate CHECK([EndActivityDate] > [StartActivityDate])
)
CREATE TABLE [dbo].[User]
(
	[Id] UNIQUEIDENTIFIER NOT NULL DEFAULT NEWID(), 
    [FirstName] NVARCHAR(50) NULL, 
    [LastName] NVARCHAR(50) NOT NULL, 
    [LastLoginDate] DATETIME NULL, 
    [RegistrationDate] DATETIME NULL, 
    [Username] NVARCHAR(64) NOT NULL UNIQUE, 
    [ObjectTypeId] INT NOT NULL, 
    [AvatarId] UNIQUEIDENTIFIER NULL,
    [Summary] NVARCHAR(MAX) NULL,

	CONSTRAINT PK_User PRIMARY KEY([Id]),
	CONSTRAINT FK_User_Image FOREIGN KEY([AvatarId]) REFERENCES dbo.[Image]([Id]),
	CONSTRAINT FK_User_ObjectType FOREIGN KEY([ObjectTypeId]) REFERENCES dbo.[ObjectType]([Id]),
)

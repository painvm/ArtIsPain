CREATE TABLE [dbo].[Photographer]
(
	[Id] UNIQUEIDENTIFIER NOT NULL PRIMARY KEY DEFAULT NEWID(), 
    [FirstName] NVARCHAR(50) NULL, 
    [LastName] NVARCHAR(50) NOT NULL, 
    [ObjectTypeId] INT NOT NULL, 
    [AvatarId] UNIQUEIDENTIFIER NULL,
    [Summary] NVARCHAR(MAX) NULL,

	CONSTRAINT FK_Photographer_Image FOREIGN KEY([AvatarId]) REFERENCES dbo.[Image]([Id]),
	CONSTRAINT FK_Photographer_ObjectType FOREIGN KEY([ObjectTypeId]) REFERENCES dbo.[ObjectType]([Id])
)

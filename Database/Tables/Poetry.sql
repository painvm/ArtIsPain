CREATE TABLE [dbo].[Poetry]
(
	[Id] UNIQUEIDENTIFIER NOT NULL PRIMARY KEY DEFAULT NEWID(), 
    [ObjectTypeId] INT NOT NULL, 
    [Title] NVARCHAR(50) NOT NULL, 
    [Content] NVARCHAR(MAX) NOT NULL, 
    [VolumeId] UNIQUEIDENTIFIER NOT NULL, 
    [Order] INT NULL

	CONSTRAINT FK_Poetry_PoetryVolume FOREIGN KEY ([VolumeId]) REFERENCES dbo.[PoetryVolume]([Id]),
	CONSTRAINT FK_Poetry_ObjectType FOREIGN KEY ([ObjectTypeId]) REFERENCES dbo.[ObjectType]([Id])
)

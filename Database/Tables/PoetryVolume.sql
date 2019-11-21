CREATE TABLE [dbo].[PoetryVolume]
(
	[Id] UNIQUEIDENTIFIER NOT NULL PRIMARY KEY DEFAULT NEWID(), 
    [Name] NVARCHAR(50) NOT NULL, 
    [AuthorId] UNIQUEIDENTIFIER NULL,
    [ObjectTypeId] INT NOT NULL, 
    [Description] NVARCHAR(MAX) NULL, 
    [WrittenFromDate] DATE NULL, 
    [WrittenToDate] DATE NOT NULL, 
    [CoverId] UNIQUEIDENTIFIER NULL

	CONSTRAINT FK_PoetryVolume_Image FOREIGN KEY ([CoverId]) REFERENCES dbo.[Image]([Id]),
	CONSTRAINT FK_PoetryVolume_Author FOREIGN KEY ([AuthorId]) REFERENCES dbo.[Writer]([Id]),
	CONSTRAINT FK_PoetryVolume_ObjectType FOREIGN KEY ([ObjectTypeId]) REFERENCES dbo.[ObjectType]([Id])
)

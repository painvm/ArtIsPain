CREATE TABLE [dbo].[PhotoAlbum]
(
	[Id] UNIQUEIDENTIFIER NOT NULL PRIMARY KEY DEFAULT NEWID(), 
    [Title] NVARCHAR(50) NOT NULL, 
    [AuthorId] UNIQUEIDENTIFIER NOT NULL,
    [CoverId] UNIQUEIDENTIFIER NULL,
    [ObjectTypeId] INT NOT NULL, 
    [Description] NVARCHAR(MAX) NOT NULL, 
    [CapturedFromDate] DATE NULL, 
    [CapturedToDate] DATE NOT NULL 

	CONSTRAINT FK_PhotoAlbum_Image FOREIGN KEY([CoverId]) REFERENCES dbo.[Image]([Id]),
	CONSTRAINT FK_PhotoAlbum_Photographer FOREIGN KEY([AuthorId]) REFERENCES dbo.[Photographer]([Id]),
	CONSTRAINT FK_PhotoAlbum_ObjectType FOREIGN KEY([ObjectTypeId]) REFERENCES dbo.[ObjectType]([Id]),
	CONSTRAINT CHK_PhotoAlbum_CapturedDate CHECK([CapturedToDate] > [CapturedFromDate])
)

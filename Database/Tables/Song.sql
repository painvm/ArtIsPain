CREATE TABLE [dbo].[Song]
(
	[Id] UNIQUEIDENTIFIER NOT NULL DEFAULT NEWID(), 
    [Title] NVARCHAR(50) NOT NULL, 
    [ObjectTypeId] INT NOT NULL, 
    [AlbumId] UNIQUEIDENTIFIER NOT NULL,
    [Length] TIME NOT NULL, 
    [Order] INT NULL, 
    [IsBonusTrack] BIT NULL, 

	CONSTRAINT PK_Song PRIMARY KEY ([Id]),
	CONSTRAINT FK_Song_MusicalAlbum FOREIGN KEY ([AlbumId]) REFERENCES dbo.[MusicalAlbum] ([Id]),
	CONSTRAINT FK_Song_ObjectType FOREIGN KEY([ObjectTypeId]) REFERENCES dbo.[ObjectType]([Id]),
)

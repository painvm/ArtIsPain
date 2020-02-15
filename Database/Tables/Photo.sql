﻿CREATE TABLE [dbo].[Photo]
(
	[Id] UNIQUEIDENTIFIER NOT NULL DEFAULT NEWID(), 
    [ImageId] UNIQUEIDENTIFIER NOT NULL, 
    [Title] NVARCHAR(255) NULL, 
    [AlbumId] UNIQUEIDENTIFIER NOT NULL, 
    [Order] INT NULL

	CONSTRAINT PK_Photo PRIMARY KEY([Id]),
	CONSTRAINT FK_Photo FOREIGN KEY([ImageId]) REFERENCES dbo.[Image] ([Id]),
						FOREIGN KEY([AlbumId]) REFERENCES dbo.[PhotoAlbum](Id),
)
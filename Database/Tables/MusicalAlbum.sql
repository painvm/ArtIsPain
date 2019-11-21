CREATE TABLE dbo.MusicalAlbum
([Id]              uniqueidentifier NOT NULL PRIMARY KEY
                                             DEFAULT NEWID(), 
 [ObjectTypeId]    int NOT NULL, 
 [Title]           nvarchar(50) NOT NULL, 
 [Url]             nvarchar(max) NULL, 
 [BandId]          uniqueidentifier NULL, 
 [CoverId]         uniqueidentifier NULL, 
 [Description]     nvarchar(max) NULL, 
 [StartRecordDate] date NULL, 
 [ReleaseDate]     date NOT NULL, 
 CONSTRAINT FK_MusicalAlbum_Image FOREIGN KEY([CoverId]) REFERENCES dbo.Image([Id]), 
 CONSTRAINT FK_MusicalAlbum_Band FOREIGN KEY([BandId]) REFERENCES dbo.Band([Id]), 
CONSTRAINT FK_MusicalAlbum_ObjectType FOREIGN KEY ([ObjectTypeId]) REFERENCES dbo.[ObjectType]([Id]),
 CONSTRAINT CHK_MusicalAlbum_ReleaseDate CHECK([ReleaseDate] >= [StartRecordDate])
);
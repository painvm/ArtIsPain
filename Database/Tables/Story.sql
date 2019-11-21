CREATE TABLE [dbo].[Story]
(
	[Id] UNIQUEIDENTIFIER NOT NULL PRIMARY KEY DEFAULT NEWID(), 
    [Content] NVARCHAR(MAX) NOT NULL, 
    [Title] NVARCHAR(MAX) NOT NULL,
    [CoverId] UNIQUEIDENTIFIER NULL,
    [ObjectTypeId] INT NOT NULL, 
    [AuthorId] UNIQUEIDENTIFIER, 
    [Description] NVARCHAR(MAX) NULL,

	CONSTRAINT FK_Story_Image FOREIGN KEY([CoverId]) REFERENCES dbo.[Image]([Id]),
	CONSTRAINT FK_Story_ObjectType FOREIGN KEY([ObjectTypeId]) REFERENCES dbo.[ObjectType]([Id]),
	CONSTRAINT FK_Story_Writer FOREIGN KEY([AuthorId]) REFERENCES dbo.[Writer]([Id])
)

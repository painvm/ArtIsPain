CREATE TABLE [dbo].[Image]
(
	[Id] UNIQUEIDENTIFIER NOT NULL PRIMARY KEY DEFAULT NEWID(), 
    [ObjectTypeId] INT NOT NULL, 
    [Content] IMAGE NOT NULL,

	CONSTRAINT FK_Image_ObjectType FOREIGN KEY([ObjectTypeId]) REFERENCES dbo.[ObjectType]([Id]),
)

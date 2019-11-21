CREATE TABLE [dbo].[Band]
(
	[Id] UNIQUEIDENTIFIER NOT NULL PRIMARY KEY DEFAULT NEWID(), 
    [ObjectTypeId] int NOT NULL, 
    [FormationDate] DATE NOT NULL, 
    [EndDate] DATE NULL, 
    [Biography] NVARCHAR(MAX) NULL, 
    [ImageId] UNIQUEIDENTIFIER NULL

	CONSTRAINT FK_Band_ObjectType FOREIGN KEY([ObjectTypeId]) REFERENCES dbo.[ObjectType]([Id]),
	CONSTRAINT FK_Band_Image FOREIGN KEY([ImageId]) REFERENCES dbo.[Image]([Id]),
	CONSTRAINT CHK_Band_FormationDate CHECK([FormationDate] < [EndDate])
)

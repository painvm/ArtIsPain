﻿CREATE TABLE [dbo].[ImageType]
(
	[Id] UNIQUEIDENTIFIER NOT NULL PRIMARY KEY DEFAULT NEWID(), 
    [Name] NVARCHAR(50) NOT NULL PRIMARY KEY
)

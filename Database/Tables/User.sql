﻿CREATE TABLE [dbo].[User]
(
	[Id] UNIQUEIDENTIFIER NOT NULL PRIMARY KEY DEFAULT NEWID(), 
    [FirstName] NVARCHAR(50) NULL, 
    [LastName] NVARCHAR(50) NOT NULL, 
    [LastLoginDate] DATETIME NULL, 
    [RegistrationDate] DATETIME NULL, 
    [Username] NVARCHAR(64) NOT NULL, 
    [ObjectTypeId] INT NOT NULL, 
    [AvatarId] UNIQUEIDENTIFIER NULL FOREIGN KEY REFERENCES [Image](Id), 
    [Summary] NVARCHAR(MAX) NULL, 
)

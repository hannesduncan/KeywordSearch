CREATE DATABASE KeywordSearch;
GO


CREATE TABLE [KeywordSearch].[dbo].[SearchRecords] (
ID uniqueidentifier primary key,
DateCreated DATETIME NOT NULL,
Positions nvarchar(200),
NumberOfResults int
);
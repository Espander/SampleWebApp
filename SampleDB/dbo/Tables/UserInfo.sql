CREATE TABLE [dbo].[UserInfo]
(
	[Id] INT NOT NULL PRIMARY KEY IDENTITY, 
    [NickName] NVARCHAR(100) NULL, 
    [FavoriteNumber] REAL NULL, 
    [FavoriteDayOfWeekId] INT NOT NULL, 
    [FavoriteDateTime] DATETIME2 NULL, 
    CONSTRAINT [FK_UserInfo_ToDaysOfWeek] FOREIGN KEY ([FavoriteDayOfWeekId]) REFERENCES [DaysOfWeek]([Id]) ON Update Cascade On delete cascade
)

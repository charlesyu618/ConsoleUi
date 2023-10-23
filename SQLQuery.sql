-- Create Gamer table
CREATE TABLE [leaderboard].[dbo].[Score]
(
    [gamer_id] INT IDENTITY(1, 1) NOT NULL,
    [gamer_name] varchar(50) NOT NULL,
    [password] varchar(255) NOT NULL,
    [highest_score] int NULL
);

-- Create Score table
CREATE TABLE [leaderboard].[dbo].[AnotherScore]
(
    [score_id] INT IDENTITY(1, 1) NOT NULL,
    [gamer_id] INT NOT NULL,
    [date] DATETIME NOT NULL,
    [score] INT NOT NULL
);

-- Insert fake data into Score table
-- (Code for inserting data remains the same)
-- Set the number of records you want to insert
DECLARE @NumberOfRecords INT = 100;
DECLARE @Counter INT = 1;

-- Loop to insert fake data
WHILE @Counter <= @NumberOfRecords
BEGIN
    INSERT INTO [leaderboard].[dbo].[Score] ([gamer_id], [date], [score])
    VALUES (FLOOR(RAND() * 20) + 1, DATEADD(day, -FLOOR(RAND() * 365), GETDATE()), FLOOR(RAND() * 100) + 1);

    SET @Counter = @Counter + 1;
END

CREATE TABLE [dbo].[Classes] (
    [Id]        INT IDENTITY NOT NULL PRIMARY KEY,
    [studentId] INT NOT NULL,
    [lessonId]  INT NOT NULL,
    CONSTRAINT [FK_Students] FOREIGN KEY (studentId) REFERENCES [dbo].[Students] (Id),
    CONSTRAINT [FK_Lessons] FOREIGN KEY (lessonId) REFERENCES [dbo].[Lessons] (Id)
);
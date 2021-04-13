CREATE TABLE [dbo].[Grades]
(
	[studentId] INT NOT NULL, 
    [shortName] NCHAR(10) NOT NULL, 
    [gradeValue] FLOAT NOT NULL, 
    [dateOfGrade] DATE NOT NULL, 
    CONSTRAINT [PK_key] PRIMARY KEY (studentId,shortName)
)

CREATE VIEW [dbo].[ClassesView] AS 
	SELECT Classes.lessonId, COUNT(Classes.lessonId) as StudentCount, Lessons.name, Lessons.shortName 
		FROM Classes
	JOIN Lessons ON Classes.lessonId = Lessons.Id
	GROUP BY lessonId,shortName,name;


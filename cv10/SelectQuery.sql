/* ukol 8 vybere vsechny studenty s jejich premdety*/
SELECT * FROM Students LEFT OUTER JOIN Classes ON Students.Id = Classes.studentId LEFT OUTER JOIN Lessons ON Classes.lessonId = Lessons.Id
/* ukol 9 vybere prijmeni studentu podle poctu*/
SELECT surname,COUNT(surname) AS countName FROM Students GROUP BY surname ORDER BY countName DESC
/* ukol 10 vybere Id predmetu kde je pocet studentu mensi nez 3 a podle poctu seradi - nefungoval mi z nejakeho duvodu alias, tak jsem ty County vypsal*/
SELECT lessonId,COUNT(DISTINCT studentId) AS studentCount FROM Classes GROUP BY lessonId HAVING  COUNT(DISTINCT studentId) < 3  
/* ukol 11 vybere vsechny predmety-jejich max, min a avg hodnoceni a pocet studentu*/
SELECT shortName AS Lesson, AVG(gradeValue) AS Average, MIN(gradeValue) AS Best, MAX(gradeValue) AS Worst,COUNT(studentId) AS AlreadyGradedStudents FROM Grades GROUP BY shortName 
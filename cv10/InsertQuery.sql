/* Omlouvam se za neprehlednost v ID studentu, musel sem ozkouset a nejake mazat, proto nesedi ID linearita */

INSERT INTO Students(name,surname,birthday) VALUES ('Jan','Peterka','1980-05-25')
INSERT INTO Students(name,surname,birthday) VALUES ('Pavel','Masa','1990-03-18')
INSERT INTO Students(name,surname,birthday) VALUES ('Jiri','Novak','1987-02-05')
INSERT INTO Students(name,surname,birthday) VALUES ('Petr','Bohac','1985-06-16')
INSERT INTO Students(name,surname,birthday) VALUES ('Jindra','Bohac','1985-06-16')

INSERT INTO Grades(studentId,shortName,gradeValue,dateOfGrade) VALUES (1,'ASI',2.5,'2020-12-05')
INSERT INTO Grades(studentId,shortName,gradeValue,dateOfGrade) VALUES (2,'ANA',3,'2020-02-29')
INSERT INTO Grades(studentId,shortName,gradeValue,dateOfGrade) VALUES (3,'AN4',1.5,'2020-11-25')
INSERT INTO Grades(studentId,shortName,gradeValue,dateOfGrade) VALUES (4,'AUD',1,'2020-10-06')

INSERT INTO Lessons(name,shortName) VALUES ('AnalyzaSignalu','ASI')
INSERT INTO Lessons(name,shortName) VALUES ('AnalogovaTechnika','ANA')
INSERT INTO Lessons(name,shortName) VALUES ('AnglictinaBakalarska','AN4')
INSERT INTO Lessons(name,shortName) VALUES ('AudioElektronika','AUD')

INSERT INTO Classes(lessonId,studentId) VALUES (1,1)
INSERT INTO Classes(studentId,lessonId) VALUES (2,2)
INSERT INTO Classes(studentId,lessonId) VALUES (3,3)
INSERT INTO Classes(studentId,lessonId) VALUES (4,4)
INSERT INTO Classes(studentId,lessonId) VALUES (10,1)

/*pro kontrolu*/
SELECT * FROM Grades
SELECT * FROM Lessons
SELECT * FROM Classes
SELECT * FROM Students

/*mazani studentu*/
DELETE FROM Students 





using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cv11
{
    class Program
    {
        static DataClasses1DataContext db = new DataClasses1DataContext();
        static void Main(string[] args)
        {
            Program p = new Program();

            //ukol 4 a 7
            p.InsertSqlData();


            //ukol 5 a 7
            p.PrintClassesView();

            //ukol 6 a 7
            IEnumerable<Students>  students = p.StudentiPredmetu("ANA");
            //Tested, works
            /*foreach (var student in students)
            {
                Console.WriteLine("student Id: " + student.Id + " Jmeno: "+ student.name + "  " + student.surname);
            }*/
            
            IEnumerable<Lessons>  lessons = p.PredmetyStudenta(10);
            //Tested, also works
            /*
            foreach (var lesson in lessons)
            {
                Console.WriteLine("lesson Id: " + lesson.Id + " Jmeno: "+ lesson.name + "  Zkratka: " + lesson.shortName);
            }
            */

            //ukol 8
            p.PrintLessons();
            Console.ReadLine();
        }
        private void PrintLessons() {
            var lesons = (from l in db.Lessons 
                       join g in db.Grades on l.shortName equals g.shortName
                       group new { g, l } by new { l.name, l.shortName} into grouper
                       select new { grouper.Key.name, shortName = grouper.Key.shortName, averageGrade = grouper.Average(x => x.g.gradeValue)}
                       ).OrderBy(x=>x.averageGrade);

            foreach (var lesson in lesons)
            {
                Console.WriteLine("Predmet: "+ lesson.name+"-"+lesson.shortName+" prumer: "+lesson.averageGrade);
            }
        }
        private void PrintClassesView() {
            var classesView = (from cv in db.ClassesView
                              select new { cv.lessonId,cv.name,cv.shortName,cv.StudentCount}
                              ).OrderByDescending( x => x.StudentCount);

            foreach (var item in classesView) {
                Console.WriteLine("Predmet: "+item);
            }
        }

        private void InsertSqlData()
        {
            String[] studentName = { "Adam", "Petr", "Ondra", "Tereza", "Lucie" };
            String[] studentSurname = { "Adamovsky", "Petovskyr", "Ondrovsky", "Terezovska", "Luciovska" };
            DateTime[] studentBirthday = { new DateTime(2001, 12, 02), new DateTime(2002, 02, 03), new DateTime(1994, 04, 03), new DateTime(1995, 01, 05), new DateTime(1991, 01, 01) };

            String[] lessonName = { "anglictina pro it", "objektove orientovane programovani", "cislicove zpracovani signalu" };
            String[] lessonShortname = { "AIT","OOP","CZS"};

            var lessons = from l in db.Lessons select l;

            for (int i = 0; i < lessonName.Length; i++)
            {
                if (lessons.Any(x => x.name == lessonName[i]) && lessons.Any(x => x.shortName == lessonShortname[i]))
                {
                    Console.WriteLine("trida " + lessonName[i] + " jiz existuje");
                }
                else
                {
                    Lessons lesson = new Lessons() { name = lessonName[i], shortName = lessonShortname[i] };
                    db.Lessons.InsertOnSubmit(lesson);
                    db.SubmitChanges();
                    Console.WriteLine("vytvorena trida " + lessonName[i]);
                } 
            }


            var students = from a in db.Students select a;

            for (int i = 0; i < studentName.Length; i++)
            {
                if (students.Any(x => x.name == studentName[i]) && students.Any(x => x.surname == studentSurname[i]) && students.Any(x => x.birthday == studentBirthday[i]))
                {
                    Console.WriteLine("uzivatel " + studentName[i] + " jiz existuje");
                }
                else
                {
                    Students student = new Students() { name = studentName[i], surname = studentSurname[i], birthday = studentBirthday[i] };
                    db.Students.InsertOnSubmit(student);
                    db.SubmitChanges();
                    Console.WriteLine("vytvoren uzivatel " + studentName[i]);

                    //povinne predmety
                    int aitId = (from a in db.Lessons
                                 where a.shortName =="AIT"
                                 select a.Id).SingleOrDefault();                              
                    Classes classAit = new Classes() { studentId = student.Id, lessonId = aitId };
                    db.Classes.InsertOnSubmit(classAit);



                    int czsId = (from a in db.Lessons
                                 where a.shortName == "CZS"
                                 select a.Id).SingleOrDefault();
                    Classes classCzs = new Classes() { studentId = student.Id, lessonId = czsId };
                    db.Classes.InsertOnSubmit(classCzs);
                    db.SubmitChanges();

                }
                //individualni hodnota uzivatele
                int oopId = (from a in db.Lessons
                             where a.shortName == "OOP"
                             select a.Id).SingleOrDefault();

                int studentId = (from s in db.Students
                                 where s.name == "Adam"
                                 select s.Id).SingleOrDefault();

                Classes classOop = new Classes() { studentId = studentId, lessonId = oopId };
                db.Classes.InsertOnSubmit(classOop);
                db.SubmitChanges();
            }
        }

        //List implementuje IEnumerable, takze naplnim ten a vratim jej jako Enumerable
        IEnumerable<Students> StudentiPredmetu(string lessonShortname) {
            int lessonId = (from l in db.Lessons
                            where l.shortName == lessonShortname
                            select l.Id).SingleOrDefault();

            var students = (  from c in db.Classes
                                    join s in db.Students  on c.studentId equals s.Id
                                    where c.lessonId == lessonId
                                    select new {s.Id, s.name, s.surname, s.birthday }
                        );
            List<Students> studentsList = new List<Students>();

            foreach (var student in students)
            {
                studentsList.Add(new Students() { Id = student.Id, name = student.name, surname = student.surname, birthday = student.birthday });
            }
            
            return studentsList;
        }
        IEnumerable <Lessons> PredmetyStudenta(int studentId) {
            var lessons = (from c in db.Classes
                           join l in db.Lessons on c.lessonId equals l.Id
                           where c.studentId == studentId
                           select new { l.Id, l.name, l.shortName }

                        );

            List<Lessons> lessonsList = new List<Lessons>();



            foreach (var lesson in lessons)
            {
                lessonsList.Add(new Lessons() { Id = lesson.Id, name = lesson.name, shortName = lesson.shortName});
            }

            return lessonsList;
        }
    }
    
}

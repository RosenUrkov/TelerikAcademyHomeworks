namespace StudentsAndWorkers
{
    using System.Collections.Generic;
    using System.Linq;
    public class MainClass
    {
        public static void Main(string[] args)
        {
            var studentList = new List<Students>();
            studentList.Add(new Students("Pesho", "Peshev", 2.56));
            studentList.Add(new Students("Ivan", "Ivanov", 5.86));
            studentList.Add(new Students("Kalina", "Komarova", 4.63));
            studentList.Add(new Students("Rosen", "Marinov", 3.71));
            studentList.Add(new Students("Petko", "Korkov", 5.42));
            studentList.Add(new Students("Mariq", "Borisova", 3.70));
            studentList.Add(new Students("Boris", "Marinov", 3.15));
            studentList.Add(new Students("Konstantin", "Ivanov", 4.54));
            studentList.Add(new Students("Kristiqn", "Dimitrov", 2.26));
            studentList.Add(new Students("Gergana", "Kostova", 4.93));

            var orderedbyGrade = studentList.OrderBy(student => student.Grade);

            var workerList = new List<Worker>();
            workerList.Add(new Worker("Pesho", "Peshev", 5.8412m, 7));
            workerList.Add(new Worker("Ivan", "Ivanov", 7.5124m, 8));
            workerList.Add(new Worker("Kalina", "Komarova", 2.9418m, 4));
            workerList.Add(new Worker("Rosen", "Marinov", 10.1124m, 10));
            workerList.Add(new Worker("Petko", "Korkov", 6.6452m, 7));
            workerList.Add(new Worker("Mariq", "Borisova", 12.4184m, 12));
            workerList.Add(new Worker("Boris", "Marinov", 4.9921m, 7));
            workerList.Add(new Worker("Konstantin", "Ivanov", 1.1114m, 2));
            workerList.Add(new Worker("Kristiqn", "Peshev", 5.0051m, 7));
            workerList.Add(new Worker("Gergana", "Kostova", 6.5321m, 8));

            var orderByMoneyPerHour = workerList.OrderByDescending(worker => worker.WorkHoursPerDay);

            var humanList = new List<Human>();
            humanList.AddRange(studentList);
            humanList.AddRange(workerList);

            var orderedHumans = humanList.OrderBy(human => human.FirstName).ThenBy(human => human.LastName);
        }
    }
}

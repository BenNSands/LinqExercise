using System;
using System.Collections.Generic;
using System.Linq;

namespace LinqExercise
{
    class Program
    {
        //Static array of integers
        private static int[] numbers = { 1, 2, 3, 4, 5, 6, 7, 8, 9, 0 };

        static void Main(string[] args)
        {
            /*
             * 
             * Complete every task using Method OR Query syntax.
             *
             * HINT: Use the List of Methods defined in the Lecture Material Google Doc ***********
             *
             * You may find that Method syntax is easier to use since it is most like C#
             * Every one of these can be completed using Linq and then printing with a foreach loop.
             * Push to your github when completed!
             * 
             */

            //DONE Print the Sum and Average of numbers
            var av = numbers.Average();
            var sum = numbers.Sum();
            Console.WriteLine("Average");
            Console.WriteLine(av);
            Console.WriteLine("Sum");
            Console.WriteLine(sum);
            //DONE Order numbers in ascending order and decsending order. Print each to console.
            var ascend = numbers.OrderBy(num => num);
            Console.WriteLine("ascending order");
            foreach (var num in ascend)
            {
                Console.WriteLine(num);
            }

            var descend = numbers.OrderByDescending(x => x);
            Console.WriteLine("decending order");
            foreach (var x in descend)
            {
                Console.WriteLine(x);
            }

            //DONE Print to the console only the numbers greater than 6
            var biggerThan6 = numbers.Where(num => num > 6);
            Console.WriteLine("Greater than 6");
            foreach (var num in biggerThan6)
            {
                Console.WriteLine(num);
            }
            //DONE Order numbers in any order (acsending or desc) but only print 4 of them **foreach loop only!**
            Console.WriteLine("only 4 nums");
            foreach (var asc in ascend.Take(4))
            {
                Console.WriteLine(asc);
            }
            //DONE Change the value at index 4 to your age, then print the numbers in decsending order
            numbers[4] = 22;
            Console.WriteLine("age decending");
            foreach (var item in numbers.OrderByDescending(num => num))
            {
                Console.WriteLine(item);
            }
            // List of employees ***Do not remove this***
            var employees = CreateEmployees();


            //DONE Print all the employees' FullName properties to the console only if their FirstName starts with a C OR an S.
            var filterNames = employees.Where(cha => cha.FirstName.StartsWith('S') || cha.FirstName.StartsWith('C')).OrderBy(person => person.FirstName);
            //DONE Order this in acesnding order by FirstName.
            Console.WriteLine("FirstName starts w/ S or C");
            foreach (var names in filterNames)
            {
                Console.WriteLine(names.FullName);
            }

            //DONE Print all the employees' FullName and Age who are over the age 26 to the console.
            //DONE Order this by Age first and then by FirstName in the same result.
            var ageOver26 = employees.Where(emp => emp.Age > 26).OrderBy(emp => emp.Age).ThenBy(emp => emp.FirstName);
            Console.WriteLine("Age over 26");
            foreach (var nameAge in ageOver26)
            {
                Console.WriteLine($"Age: {nameAge.Age}  Name: {nameAge.FullName}");


            }

            //Print the Sum and then the Average of the employees' YearsOfExperience
            //if their YOE is less than or equal to 10 AND Age is greater than 35
            var years = employees.Where(num => num.YearsOfExperience >= 10 && num.Age > 35);
            var sumOfEXP = years.Sum(totalSum => totalSum.YearsOfExperience);
            var avgEXP = years.Average(avg => avg.YearsOfExperience);
                Console.WriteLine($"Total Sum: {sumOfEXP}  Average Years: {avgEXP}");


            //Add an employee to the end of the list without using employees.Add()
            employees = employees.Append(new Employee("Ben", "Sands", 22, 1)).ToList();

            Console.WriteLine();

            Console.ReadLine();
        }

        #region CreateEmployeesMethod
        private static List<Employee> CreateEmployees()
        {
            List<Employee> employees = new List<Employee>();
            employees.Add(new Employee("Cruz", "Sanchez", 25, 10));
            employees.Add(new Employee("Steven", "Bustamento", 56, 5));
            employees.Add(new Employee("Micheal", "Doyle", 36, 8));
            employees.Add(new Employee("Daniel", "Walsh", 72, 22));
            employees.Add(new Employee("Jill", "Valentine", 32, 43));
            employees.Add(new Employee("Yusuke", "Urameshi", 14, 1));
            employees.Add(new Employee("Big", "Boss", 23, 14));
            employees.Add(new Employee("Solid", "Snake", 18, 3));
            employees.Add(new Employee("Chris", "Redfield", 44, 7));
            employees.Add(new Employee("Faye", "Valentine", 32, 10));

            return employees;
        }
        #endregion
    }
}

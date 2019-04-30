using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Employees
{
    class Program
    {
        static void Main(string[] args)
        {
            var employees = new[] {
                new { Name="Andras", Salary=420},
                new { Name="Bela", Salary=400},
                new { Name="Csaba", Salary=250},
                new { Name="David", Salary=300},
                new { Name="Endre", Salary=620},
                new { Name="Ferenc", Salary=350},
                new { Name="Gabor", Salary=410},
                new { Name="Hunor", Salary=500},
                new { Name="Imre", Salary=900},
                new { Name="Janos", Salary=600},
                new { Name="Karoly", Salary=700},
                new { Name="Laszlo", Salary=400},
                new { Name="Marton", Salary=500}
            };

            // 1.
            Console.WriteLine($"{employees.OrderByDescending(e => e.Salary).First().Name}");
            Console.WriteLine();

            // 2.
            var avg = employees.Average(e => e.Salary);
            foreach (var emp in employees.Where(e => e.Salary < avg).Select(e => e.Name))
            {
                Console.WriteLine($"{emp}");
            }
            Console.WriteLine();

            // 3.
            foreach (var emp in employees.OrderBy(e => e.Salary))
            {
                Console.WriteLine($"{emp.Name}");
            }
            Console.WriteLine();

            // 4.
            var dict = new Dictionary<int, List<string>>();
            var ordered = employees.GroupBy(e => e.Salary, e => e.Name, (s, n) => new { Salary = s, Names = n })
                                   .OrderBy(e => e.Salary)
                                   .ThenBy(e => e.Names)
                                   .Where(e => e.Names.Count() > 1);

            foreach (var o in ordered)
            {
                Console.WriteLine($"{o.Salary}");
                foreach (var item in o.Names)
                {
                    Console.WriteLine($"\t{item}");
                }
            }

            Console.ReadKey();
        }
    }
}

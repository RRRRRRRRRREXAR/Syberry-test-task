using Microsoft.EntityFrameworkCore;
using SyberyCIStestask.DAL.Context;
using SyberyCIStestask.DAL.Entities;
using System;
using System.Linq;

namespace SyberyCIStestask
{
    class Program
    {
        static void Main(string[] args)
        {
            using(SyberryContext db = new SyberryContext())
            {
                var reports = db.TimeReports.Include("Emploee").ToList().GroupBy(t => t.Date);
                foreach (IGrouping<DateTime,TimeReport> group in reports)
                {
                    string grouppedString = "";
                    grouppedString = String.Concat(" | ",group.Key.DayOfWeek," | ");
                    Console.Write(grouppedString);
                    foreach (var report in group)
                    {
                        Console.Write(String.Concat( report.Emploee.Name, "(", Math.Round(report.Hours,2), ")", ", "));
                    }
                    Console.Write("|");
                    Console.WriteLine();
                }
            }
            Console.ReadKey();
        }
    }
}

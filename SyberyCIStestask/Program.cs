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
                    var grouppedReports = group.OrderByDescending(t => t.Hours).ToList();
                    int reportCounter = 0;
                    foreach (var report in grouppedReports)
                    {
                        Console.Write(String.Concat( report.Emploee.Name, "(", Math.Round(report.Hours,2), ")", ", "));
                        reportCounter++;
                        if(reportCounter == 3)
                        {
                            break;
                        }
                    }
                    Console.Write("|");
                    Console.WriteLine();
                }
            }
            Console.ReadKey();
        }
    }
}

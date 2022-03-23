using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace calendar
{
    public class Event:IDisposable
    {
        public string User {   get; private set; }
        public DateTime Start {  get; private set; }
        public DateTime End { get; private set; }
        public string Description { get; private set; }

        public Event()
        {
            User = null;
            Start = DateTime.MinValue;
            End = DateTime.MinValue;
            Description = null;

        }
        public Event(string user,DateTime start,DateTime end,string description)
        {
            User = user;
            Start = start;
            End = end;
            Description = description;
        }

        public void SetDateTime(string type)
        {
            int yearresult = 1900;
            int monthresult = 1;
            int dayresult = 1;
            int hourresult = 1;
            int minuteresult = 0;

            Console.WriteLine($"Set date {type} event");
            Console.WriteLine($"\nWhat is {type} year event?");
            bool year = true;
            do
            {
                if (!year || yearresult < 1900 || yearresult > 2050)
                {
                    Console.WriteLine("Sorry, bad value, try again");
                }
                year = int.TryParse(Console.ReadLine(), out yearresult);
            }while(!year || yearresult<1900 || yearresult>2050);

            Console.WriteLine($"What is {type} month event?");
            bool month = true;
            do
            {
                if (!month || monthresult < 1 || monthresult > 12)
                {
                    Console.WriteLine("Sorry, bad value, try again");
                }
                month = int.TryParse(Console.ReadLine(), out monthresult);
            } while (!month || monthresult < 1 || monthresult > 12);

            Console.WriteLine($"What is {type} day event?");
            bool day = true;
            int daysin = DateTime.DaysInMonth(yearresult, monthresult);
            do
            {
                if (!day || dayresult < 1 || dayresult > daysin)
                {
                    Console.WriteLine("Sorry, bad value, try again");
                }
                day = int.TryParse(Console.ReadLine(), out dayresult);
            } while (!day || dayresult < 1 || dayresult > daysin);

            Console.WriteLine($"What is {type} hour event?");
            bool hour = true;
            do
            {
                if (!hour || hourresult < 1 || hourresult > 24)
                {
                    Console.WriteLine("Sorry, bad value, try again");
                }
                hour = int.TryParse(Console.ReadLine(), out hourresult);
            } while (!hour || hourresult < 1 || hourresult > 24);

            Console.WriteLine($"What is {type} minute event?");
            bool minute = true;
            do
            {
                if (!minute || minuteresult < 0 || minuteresult > 60)
                {
                    Console.WriteLine("Sorry, bad value, try again");
                }
                minute = int.TryParse(Console.ReadLine(), out minuteresult);
            } while (!minute || minuteresult < 0 || minuteresult > 60);

            if (type == "start")
            {
                Start = new DateTime(yearresult, monthresult, dayresult, hourresult, minuteresult, 0);
            }
            else
            {
                End = new DateTime(yearresult, monthresult, dayresult, hourresult, minuteresult, 0);
            }
        }
        public void SetUser(string user)
        {
            User = user;
        }
        public void SetDescription()
        {
            Console.WriteLine("\nWrite description for this event:");
            Description = Console.ReadLine();
        }

        public void Dispose()
        {
            //Czy jak bedzie pusta ta metoda to user itak zostanie zniszczony???
        }
    }
}

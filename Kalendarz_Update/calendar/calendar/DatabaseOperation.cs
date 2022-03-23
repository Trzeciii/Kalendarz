using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace calendar
{
    internal static class DatabaseOperation
    {
        public static Take take;
        public static Changer changer;
        public static bool SearchUser(List<User> List, string username)
        {
            var user = List.FirstOrDefault(c => c.Username == username);
            if (user == null)
            {
                return false;
            }
            else
            {
                return true;
            }
        }
 
        public static void DeleteUser(ref List<User> List, User user)
        {
            var searchuser = List.FirstOrDefault(c => c.Username == user.Username);
            List.Remove(searchuser);
        }
        public static void Changer(ref List<User> List, User user)
        {
            DeleteUser(ref List, user);
            changer();
            List.Add(user);
        }
        public static void ChangerColorText(ref List<User> UsersList,User nowuser)
        {
            DeleteUser(ref UsersList,nowuser);
            nowuser.SetColorText();
            UsersList.Add(nowuser);
        }

        public static bool CompareDate(DateTime one, DateTime two)
        {
            var Time = new TimeSpan();
            Time = two - one;
            return (Time.TotalMinutes < 0);
        }
        public static List<Event> MyEventsList(List<Event> AllEventList, User nowuser)
        {
            var MyEvents = new List<Event>();
            foreach (var e in AllEventList)
            {
                if (e.User == nowuser.Username)
                {
                    MyEvents.Add(e);
                }
            }
            MyEvents = SortListDate(MyEvents);
            return MyEvents;
        }
        public static void AddEvent( List<Event> List, User user,Event newevent,string eventsfile)
        {
            Console.Clear();
            newevent.SetUser(user.Username);
            newevent.SetDateTime("start");
            newevent.SetDateTime("end");
            if (CompareDate(newevent.Start,newevent.End))
            {
                Console.WriteLine("Sorry end date is before start date");
                Console.ReadLine();
            }
            else
            {
                newevent.SetDescription();
                List.Add(newevent);
                FileWriter.WriteEvent(newevent, eventsfile);
            }
            
        }
        static int i;
        public static void DisplayEvents(List<Event> List,string Usercolor)
        {
            
            i = 1;
            foreach (var e in List)
            {
                UserStettings.SetColor(e);
                Console.WriteLine($"{i}. Event {e.Description} starts on {e.Start} and ends on {e.End}");
                i++;
            }
            UserStettings.SetColor(Usercolor);
        }
        public static void DisplayEvents(List<Event> List, string Usercolor,ref int i)
        {
            i = 1;
            foreach (var e in List)
            {
                UserStettings.SetColor(e);
                Console.WriteLine($"{i}. Event {e.Description} starts on {e.Start} and ends on {e.End}");
                i++;
            }
            i--;
            UserStettings.SetColor(Usercolor);
        }
        public static List<Event> SortListDate(List<Event> List)
        {
            List = List.OrderBy(x => x.Start)
                        .ThenBy(x => x.End)
                        .ToList();
            return List;
        }
  

        public static void SearchEvent(List<Event> List,string pharase,User nowuser)
        {
            var okpharase = List.Where(c=>c.Description.Contains(pharase)).ToList();
            DisplayEvents(okpharase, nowuser.ColorText);
            Console.ReadLine();
        }
        public static void RemoveEvent(ref List<Event> AllEventsList, List<Event> UserEventsList,int ii)
        {
            int i = 1;
            Event @event= new Event();
            foreach (var e in UserEventsList)
            {
                if (i == ii)
                {
                    @event = e;
                    break;
                }
                i++;
            }
            foreach (var e in AllEventsList)
            {
                if (e == @event)
                {
                    AllEventsList.Remove(e);
                    break;
                }
            }
        }
        public static bool Whichnumber(ref string phrase, string text)
        {
            Console.WriteLine($"{text}");
            Console.WriteLine("If you would back, write 'BACK'");
            phrase = take(); 
            if (phrase != "BACK") return true;
            else return false;
        }
    }
}

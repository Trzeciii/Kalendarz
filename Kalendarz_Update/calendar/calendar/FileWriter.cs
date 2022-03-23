using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace calendar
{
    internal class FileWriter
    {
        public static void WriterUser(User user,string usersfile)
        {
            using(var sw =new StreamWriter(usersfile,true))
            {
                sw.WriteLine($"{user.Username}\n{user.Password}\n{user.ColorText}");
                sw.Close(); //potrzebne ?
            }
        }
        public static void WriteUsersList(List<User> UsersList, string usersfile)
        {
            using (var sw = new StreamWriter(usersfile, false))
            {
                foreach (var user in UsersList)
                {
                    sw.WriteLine($"{user.Username}\n{user.Password}\n{user.ColorText}");
                }
                sw.Close(); //potrzebne ?
            }
        }

        public static void WriteEvent(Event @event,string eventsfile)
        {
            using (var sw = new StreamWriter(eventsfile, true))
            {
                sw.WriteLine($"{@event.User}\n{@event.Start}\n{@event.End}\n{@event.Description}");
                sw.Close(); //potrzebne ?
            }
        }
        public static void WriteEventsList(List<Event> List, string eventsfile)
        {
            using (var sw = new StreamWriter(eventsfile, false))
            {
                foreach (var @event in List)
                {
                    sw.WriteLine($"{@event.User}\n{@event.Start}\n{@event.End}\n{@event.Description}");
                }
                sw.Close(); //potrzebne ?
            }
        }
    }
}

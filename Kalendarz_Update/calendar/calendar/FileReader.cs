using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace calendar
{
    public static class FileReader 
    {

        public static void ReaderUsers(List<User> UsersList ,string ReadingFile)
        {
            UsersList.Clear();
            using (StreamReader file = File.OpenText(ReadingFile)) 
            {
                string user;
                while ((user=file.ReadLine()) != null)
                {
                    string pass = file.ReadLine();
                    string coltext = file.ReadLine();

                    UsersList.Add( new User(user,pass,coltext));
                }
            }
                

        }
        public static void ReaderEvents(List<Event> AllEventsList, string ReadingFile)
        {
            AllEventsList.Clear();
            using (StreamReader file = File.OpenText(ReadingFile))
            {
                string user;
                while ((user = file.ReadLine()) != null)
                {
                    DateTime start = DateTime.Parse(file.ReadLine());
                    DateTime end = DateTime.Parse(file.ReadLine());
                    string description = file.ReadLine();


                    AllEventsList.Add(new Event(user, start,end,description));
                }
            }


        }
    }
}

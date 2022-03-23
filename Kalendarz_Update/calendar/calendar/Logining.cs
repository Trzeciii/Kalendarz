using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace calendar
{
    internal static class Logining
    {
        public static void fulllogin(User nowuser,List<User> UsersList, List<Event> AllEventsList ,ref List<Event> UserEventsList ,string usersfile,string eventsfile)
        {
            FileReader.ReaderUsers(UsersList, usersfile);
            UserStettings.SetColor(nowuser.ColorText);
            while (true)
            {
                login(nowuser);
                if (IsNewUser(nowuser.Username))
                {
                    using (var newuser = new User())
                    {
                        Console.Clear();
                        if (newuser.CreateNewUser(UsersList, usersfile))
                        {
                            UsersList.Add(newuser);
                            FileWriter.WriterUser(newuser, usersfile);
                        }
                    }
                }
                else
                {
                    if (Correctlogin(nowuser, UsersList))
                    {
                        FileReader.ReaderEvents(AllEventsList, eventsfile);
                        UserEventsList = DatabaseOperation.MyEventsList(AllEventsList, nowuser);
                        break;
                    }
                    else
                    {
                        Console.WriteLine("Sorry, no correct username or password :(");
                        Console.ReadLine();
                    }
                }
            }
        }
        public static void login(User user)
        {
            Console.Clear();
            Console.WriteLine("Your username: \n\n\n\n\n\n\n\nIf would you create new user, write:NEWUSER");
            Console.SetCursorPosition(0, 1);
            user.TakeUsername();
            if (!IsNewUser(user.Username))
            {
                Console.WriteLine("Your password:");
                user.TakePassword();
            }
        }

        public static bool Correctlogin(User User, List<User> UsersList)
        {
            foreach (var user in UsersList)
            {
                if(User.Username==user.Username && User.Password==user.Password)
                {
                    User.ColorText=user.ColorText;
                    return true;
                }
            }
            return false;
        }

        public static bool IsNewUser(string name)
        {
            if (name == "NEWUSER") return true;

            return false;

        }

      

    }
}

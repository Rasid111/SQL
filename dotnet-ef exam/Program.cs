using dotnet_ef_exam.EntityFramework;
using dotnet_ef_exam.Repositories;
using dotnet_ef_exam.Services;

namespace dotnet_ef_exam
{
    internal class Program
    {
        static void invokeFromService(int num, ExamServices services)
        {
            switch (num)
            {
                case 0:
                    services.InsertUser();
                    break;
                case 1:
                    services.InsertCommunity();
                    break;
                case 2:
                    services.GetUsers();
                    break;
                case 3:
                    services.GetCommunities();
                    break;
                case 4:
                    services.UpdateUser();
                    break;
                case 5:
                    services.UpdateCommunity();
                    break;
                case 6:
                    services.DeleteUser();
                    break;
                case 7:
                    services.DeleteCommunity();
                    break;
                default:
                    break;
            }
        }
        static void Main(string[] args)
        {
            ExamRepository repository = new EntityFrameworkExamRepository();
            ExamServices services = new ExamServices();
            int cursorPos = 0;
            string[] menuOptions = new string[8] {
                "add new user",
                "add new community",
                "get all users",
                "get all communities",
                "update user",
                "update community",
                "delete user",
                "delete community"
            };
            while (true)
            {
                Console.Clear();
                for (int i = 0; i < menuOptions.Length; i++)
                {
                    if (i == cursorPos)
                        Console.BackgroundColor = ConsoleColor.DarkGreen;
                    else
                        Console.BackgroundColor = ConsoleColor.Black;
                    Console.WriteLine(menuOptions[i]);
                }
                ConsoleKey pressedKey = Console.ReadKey().Key;
                switch (pressedKey)
                {
                    case ConsoleKey.DownArrow:
                        if (cursorPos < menuOptions.Length - 1)
                        {
                            cursorPos++;
                            break;
                        }
                        cursorPos = 0;
                        break;
                    case ConsoleKey.UpArrow:
                        if (cursorPos > 0)
                        {
                            cursorPos--;
                            break;
                        }
                        cursorPos = menuOptions.Length - 1;
                        break;
                    case ConsoleKey.Enter:
                        invokeFromService(cursorPos, services); break;
                    default:
                        break;
                }
            }
        }
    }
}

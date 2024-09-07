using Diary.Repositories;
using Diary.Repositories.Base;
using Diary.Services;
using System.Data.SqlClient;

namespace Diary
{
    internal class Program
    {
        static void invokeFromService(int num, DiaryServices services)
        {
            switch (num)
            {
                case 0:
                    services.InsertGroup();
                    break;
                case 1:
                    services.InsertStudent();
                    break;
                case 2:
                    services.InsertMark();
                    break;
                case 3:
                    services.GetGroups();
                    break;
                case 4:
                    services.GetStudents();
                    break;
                case 5:
                    services.GetMarks();
                    break;
                case 6:
                    services.UpdateGroup();
                    break;
                case 7:
                    services.UpdateStudent();
                    break;
                case 8:
                    services.UpdateMark();
                    break;
                case 9:
                    services.DeleteGroup();
                    break;
                case 10:
                    services.DeleteStudent();
                    break;
                case 11:
                    services.DeleteMark();
                    break;
                default:
                    break;
            }
        }
        static void Main(string[] args)
        {
            DiaryRepository repository = new DapperDiaryRepository();
            DiaryServices diaryServices = new DiaryServices(repository);
            int cursorPos = 0;
            string[] menuOptions = new string[12] {
                "add new group",
                "add new student",
                "add new mark",
                "see all groups",
                "see all students",
                "see one student's marks",
                "update group",
                "update student",
                "change mark",
                "delete group",
                "delete student",
                "delete mark"

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
                        invokeFromService(cursorPos, diaryServices); break;
                    default:
                        break;
                }
            }
        }
    }
}

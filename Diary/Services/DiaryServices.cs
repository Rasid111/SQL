using Diary.Entities;
using Diary.Repositories.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Diary.Services
{
    internal class DiaryServices
    {
        DiaryRepository diaryRepository {  get; set; }
        public void InsertGroup() {
            Console.Clear();
            Console.Write("Group's name: ");
            string? name = Console.ReadLine();
            if (String.IsNullOrEmpty(name) || name.Length > 50)
                throw new ArgumentException("Name");
            Group group = new Group(name);
            if (diaryRepository.InsertGroup(group))
                Console.WriteLine("Group was added successful!");
            Console.ReadKey();
        }
        public void InsertStudent() {
            Console.Clear();
            Console.Write("Student's name: ");
            string? name = Console.ReadLine();
            if (String.IsNullOrEmpty(name) || name.Length > 50)
                throw new ArgumentException("Name");
            Console.Write("Group's id: ");
            int groupId = int.Parse(Console.ReadLine() ?? throw new ArgumentException("Invalid group id"));
            Student student = new Student(name, groupId);
            if (diaryRepository.InsertStudent(student))
                Console.WriteLine("Student was added successful!");
            else
                Console.WriteLine("Something went wrong");
            Console.ReadKey();
        }
        public void InsertMark()
        {
            Console.Clear();
            Console.Write("Student's id: ");
            int studentId = int.Parse(Console.ReadLine() ?? throw new ArgumentException("Invalid student id"));
            Console.Write("Value: ");
            int value = int.Parse(Console.ReadLine() ?? throw new Exception("Invalid value"));
            Mark mark = new Mark(value);
            if (diaryRepository.InsertMark(studentId, mark.Value))
                Console.WriteLine("Mark was added successful!");
            else
                Console.WriteLine("Something went wrong");
            Console.ReadKey();
        }
        public void GetStudents() {
            Console.Clear();
            List<Student> list = diaryRepository.GetStudents().ToList();
            foreach (Student student in list)
            {
                Console.WriteLine($"{student.Id}\t{student.Name}\t{student.GroupId}");
            }
            Console.ReadKey();
        }
        public void GetGroups()
        {
            Console.Clear();
            List<Group> list = diaryRepository.GetGroups().ToList();
            foreach (Group group in list)
            {
                Console.WriteLine($"{group.Id}\t{group.Name}");
            }
            Console.ReadKey();
        }
        public void GetMarks()
        {
            Console.Clear();
            Console.Write("Student's id: ");
            int studentId = int.Parse(Console.ReadLine() ?? throw new ArgumentException("Invalid student id"));
            List<Mark> list = diaryRepository.GetMarks(studentId).ToList();
            foreach (Mark mark in list)
            {
                Console.WriteLine($"{mark.Id}\t{mark.Value}\t{mark.StudentId}");
            }
            Console.ReadKey();
        }
        public void UpdateStudent() {
            Console.Clear();
            Console.WriteLine("Student's id: ");
            int studentId = int.Parse(Console.ReadLine() ?? throw new ArgumentException("Invalid student id"));
            Console.Write("Student's new name: ");
            string? name = Console.ReadLine();
            if (String.IsNullOrEmpty(name) || name.Length > 50)
                throw new ArgumentException("Name");
            Console.Write("New group's id: ");
            int groupId = int.Parse(Console.ReadLine() ?? throw new ArgumentException("Invalid group id"));
            Student student = new Student(name, groupId);
            if (diaryRepository.UpdateStudent(studentId, student))
                Console.WriteLine("Student was updated successful");
            else
                Console.WriteLine("Something went wrong");
            Console.ReadKey();
        }
        public void UpdateGroup() {
            Console.Clear();
            Console.Write("Student's id: ");
            int groupId = int.Parse(Console.ReadLine() ?? throw new ArgumentException("Invalid group id"));
            Console.Write("Group's new name: ");
            string? name = Console.ReadLine();
            if (String.IsNullOrEmpty(name) || name.Length > 50)
                throw new ArgumentException("Name");
            Group group = new Group(name);
            if (diaryRepository.UpdateGroup(groupId, group))
                Console.WriteLine("Group was updated successful");
            else
                Console.WriteLine("Something went wrong");
        }
        public void UpdateMark() {
            Console.Clear();
            Console.Write("Mark's id: ");
            int markId = int.Parse(Console.ReadLine() ?? throw new ArgumentException("Invalid group id"));
            int value = int.Parse(Console.ReadLine() ?? throw new ArgumentException("Invalid value"));
            Mark mark = new Mark(value);
            if (diaryRepository.UpdateMark(markId, mark))
                Console.WriteLine("Mark was updated successful");
            else
                Console.WriteLine("Something went wrong");
        }
        public void DeleteStudent() {
            Console.Clear();
            Console.Write("Student's id: ");
            int studentId = int.Parse(Console.ReadLine() ?? throw new ArgumentException("Invalid student id"));
            if (diaryRepository.DeleteStudent(studentId))
                Console.WriteLine("Student was deleted successfull");
            else
                Console.WriteLine("Something went wrong");
        }
        public void DeleteGroup()
        {
            Console.Clear();
            Console.Write("Group's id: ");
            int groupId = int.Parse(Console.ReadLine() ?? throw new ArgumentException("Invalid group id"));
            if (diaryRepository.DeleteGroup(groupId))
                Console.WriteLine("Group was deleted successfull");
            else
                Console.WriteLine("Something went wrong");
        }
        public void DeleteMark()
        {
            Console.Clear();
            Console.Write("Mark's id: ");
            int markId = int.Parse(Console.ReadLine() ?? throw new ArgumentException("Invalid mark id"));
            if (diaryRepository.DeleteMark(markId))
                Console.WriteLine("Mark was deleted successfull");
            else
                Console.WriteLine("Something went wrong");
        }
        public DiaryServices(DiaryRepository repository)
        {
            this.diaryRepository = repository;
        }
    }
}
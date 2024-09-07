using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Diary.Entities
{
    internal class Student
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int GroupId { get; set; }
        public Student(int Id, string Name, int GroupId)
        {
            this.Id = Id;
            this.Name = Name;
            this.GroupId = GroupId;
        }
        public Student(string Name, int GroupId)
        {
            this.Name = Name;
            this.GroupId = GroupId;
        }
    }
}

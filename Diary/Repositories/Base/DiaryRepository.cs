using Diary.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Diary.Repositories.Base
{
    internal abstract class DiaryRepository
    {
        public abstract bool InsertGroup(Entities.Group group);
        public abstract bool InsertStudent(Student student);
        public abstract bool InsertMark(int StudentId, int value);
        public abstract IEnumerable<Student> GetStudents();
        public abstract IEnumerable<Entities.Group> GetGroups();
        public abstract IEnumerable<Mark> GetMarks(int StudentId);
        public abstract bool UpdateStudent(int StudentId, Student newStudentInfo);
        public abstract bool UpdateGroup(int GroupId, Entities.Group newGroupInfo);
        public abstract bool UpdateMark(int MarkId, Mark newMarkInfo);
        public abstract bool DeleteStudent(int studentId);
        public abstract bool DeleteGroup(int GroupId);
        public abstract bool DeleteMark(int MarkId);
    }
}

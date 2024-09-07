using Diary.Entities;
using Diary.Repositories.Base;
using System.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dapper;
using System.Text.RegularExpressions;

namespace Diary.Repositories
{
    internal class DapperDiaryRepository : DiaryRepository
    {
        public override bool InsertGroup(Entities.Group group) {
            var connectionString = File.ReadAllText("connectionstring.txt");
            var connection = new SqlConnection(connectionString);
            connection.Open();
            bool success = connection.Execute(
                sql: @"insert into Groups ([Name])
values(@name)",
                param: new
                {
                    name = group.Name,
                }) > 0;
            connection.Close();
            return success;
        }
        public override bool InsertStudent(Student student)
        {
            var connectionString = File.ReadAllText("connectionstring.txt");
            var connection = new SqlConnection(connectionString);
            connection.Open();
            bool success = connection.Execute(
                sql :@"insert into Students ([Name], GroupId)
values(@name, @groupId)",
                param: new
                {
                    name = student.Name,
                    groupId = student.GroupId,
                }) > 0;
            connection.Close();
            return success;
        }
        public override bool InsertMark(int StudentId, int value) {
            var connectionString = File.ReadAllText("connectionstring.txt");
            var connection = new SqlConnection(connectionString);
            connection.Open();
            bool success = connection.Execute(
                sql: @"insert into Marks (Value, StudentId)
values(@value, @studentId)",
                param: new
                {
                    value = value,
                    studentId = StudentId,
                }) > 0;
            connection.Close();
            return success;
        }
        public override IEnumerable<Student> GetStudents() {
            var connectionString = File.ReadAllText("connectionstring.txt");
            var connection = new SqlConnection(connectionString);
            connection.Open();
            var Students = connection.Query<Student>("select * from Students");
            connection.Close();
            return Students;
        }
        public override IEnumerable<Entities.Group> GetGroups() {
            var connectionString = File.ReadAllText("connectionstring.txt");
            var connection = new SqlConnection(connectionString);
            connection.Open();
            var Groups = connection.Query<Entities.Group>("select * from Groups");
            connection.Close();
            return Groups;
        }
        public override IEnumerable<Mark> GetMarks(int StudentId)
        {
            var connectionString = File.ReadAllText("connectionstring.txt");
            var connection = new SqlConnection(connectionString);
            connection.Open();
            var Marks = connection.Query<Mark>("select * from Marks");
            connection.Close();
            return Marks;
        }
        public override bool UpdateStudent(int StudentId, Student newStudentInfo) {
            var connectionString = File.ReadAllText("connectionstring.txt");
            var connection = new SqlConnection(connectionString);
            connection.Open();
            var success = connection.Execute(
                sql:
                @"update Students
set [Name] = @newName, GroupId = @newGroupId
WHERE Id = @studentId;",
                param: new
                {
                    newName = newStudentInfo.Name,
                    newGroupId = newStudentInfo.GroupId,
                    studentId = StudentId,
                }) > 0;
            connection.Close();
            return success;
        }
        public override bool UpdateGroup(int GroupId, Entities.Group newGroupInfo)
        {
            var connectionString = File.ReadAllText("connectionstring.txt");
            var connection = new SqlConnection(connectionString);
            connection.Open();
            var success = connection.Execute(
                sql:
                @"update Groups
set [Name] = @newName
WHERE Id = @groupId;",
                param: new
                {
                    newName = newGroupInfo.Name,
                    groupId = GroupId,
                }) > 0;
            connection.Close();
            return success;
        }
        public override bool UpdateMark(int MarkId, Mark newMarkInfo)
        {
            var connectionString = File.ReadAllText("connectionstring.txt");
            var connection = new SqlConnection(connectionString);
            connection.Open();
            var success = connection.Execute(
                sql:
                @"update Marks
set Value = @newValue
WHERE Id = @markId;",
                param: new
                {
                    value = newMarkInfo.Value,
                    markId = MarkId,
                }) > 0;
            connection.Close();
            return success;
        }
        public override bool DeleteStudent(int studentId)
        {
            var connectionString = File.ReadAllText("connectionstring.txt");
            var connection = new SqlConnection(connectionString);
            connection.Open();
            connection.Execute(
                sql: @"delete from Marks
where StudentId = @studentId",
                param: new
                {
                    studentId
                });
            var success = connection.Execute(
                sql:
                @"delete from Students
WHERE Id = @studentId;",
                param: new
                {
                    studentId
                }) > 0;
            connection.Close();
            return success;
        }
        public override bool DeleteGroup(int GroupId)
        {
            var connectionString = File.ReadAllText("connectionstring.txt");
            var connection = new SqlConnection(connectionString);
            connection.Open();
            if (connection.Query<Student>(
                sql: @"select * from students
where GroupId = @groupId",
                param: new
                {
                    groupId = GroupId
                }).Count() > 0)
            {
                throw new Exception("You cannot delete a group with students");
            }
            var success = connection.Execute(
                sql:
                @"delete from Groups
WHERE Id = @GroupId;",
                param: new
                {
                    GroupId
                }) > 0;
            connection.Close();
            return success;
        }
        public override bool DeleteMark(int MarkId)
        {
            var connectionString = File.ReadAllText("connectionstring.txt");
            var connection = new SqlConnection(connectionString);
            connection.Open();
            var success = connection.Execute(
                sql:
                @"delete from Marks
where Id = @markId",
                param: new
                {
                    markId = MarkId
                }) > 0;
            connection.Close();
            return success;
        }
    }
}

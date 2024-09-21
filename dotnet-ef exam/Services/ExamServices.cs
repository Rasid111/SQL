using dotnet_ef_exam.Entities;
using dotnet_ef_exam.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace dotnet_ef_exam.Services
{
    internal class ExamServices
    {
        public void InsertUser()
        {
            var repository = new EntityFrameworkExamRepository();
            Console.Clear();
            Console.Write("User's name: ");
            string? name = Console.ReadLine();
            if (String.IsNullOrEmpty(name) || name.Length > 50)
                throw new ArgumentException("Name");
            Console.Write("User's age: ");
            int age = int.Parse(Console.ReadLine() ?? throw new ArgumentException("Invalid age"));
            Console.Write("Country Id: ");
            int countryId = int.Parse(Console.ReadLine() ?? throw new ArgumentException("Invalid country id"));
            User user = new User
            {
                Name = name,
                Age = age,
            };
            IEnumerable<int> communitiesId = new List<int>();
            while (true)
            {
                Console.WriteLine("Add community? y/any key");
                if (Console.ReadLine() == "y")
                {
                    Console.Write("Community's id: ");
                    int communityId = int.Parse(Console.ReadLine() ?? throw new ArgumentException("Invalid id"));
                    communitiesId = communitiesId.Append(communityId);
                }
                else
                    break;
            }
            if (repository.InsertUser(user, countryId, communitiesId))
                Console.WriteLine("User was added successful!");
            Console.ReadKey();
        }

        public void InsertCommunity()
        {
            var repository = new EntityFrameworkExamRepository();
            Console.Clear();
            Console.Write("Community's name: ");
            string? name = Console.ReadLine();
            if (String.IsNullOrEmpty(name) || name.Length > 50)
                throw new ArgumentException("Name");
            Community community = new Community
            {
                Name = name,
            };
            IEnumerable<int> usersId = new List<int>();
            while (true)
            {
                Console.WriteLine("Add user? y/any key");
                if (Console.ReadLine() == "y")
                {
                    Console.Write("User's id: ");
                    int userId = int.Parse(Console.ReadLine() ?? throw new ArgumentException("Invalid id"));
                    usersId = usersId.Append(userId);
                }
                else
                    break;
            }
            if (repository.InsertCommunity(community, usersId))
                Console.WriteLine("Community was added successful!");
            Console.ReadKey();
        }

        public void UpdateUser()
        {
            var repository = new EntityFrameworkExamRepository();
            Console.Clear();
            Console.Write("User's id: ");
            int id = int.Parse(Console.ReadLine() ?? throw new ArgumentException("Invalid id"));
            Console.Write("User's name: ");
            string? name = Console.ReadLine();
            if (String.IsNullOrEmpty(name) || name.Length > 50)
                throw new ArgumentException("Name");
            Console.Write("User's age: ");
            int age = int.Parse(Console.ReadLine() ?? throw new ArgumentException("Invalid age"));
            Console.Write("Country Id: ");
            int countryId = int.Parse(Console.ReadLine() ?? throw new ArgumentException("Invalid country id"));
            User user = new User
            {
                Id = id,
                Name = name,
                Age = age,
            };
            IEnumerable<int> communitiesId = new List<int>();
            while (true)
            {
                Console.WriteLine("Add community? y/any key");
                if (Console.ReadLine() == "y")
                {
                    Console.Write("Community's id: ");
                    int communityId = int.Parse(Console.ReadLine() ?? throw new ArgumentException("Invalid id"));
                    communitiesId = communitiesId.Append(communityId);
                }
                else
                    break;
            }
            if (repository.UpdateUser(user, countryId, communitiesId))
                Console.WriteLine("User was updated successful!");
            Console.ReadKey();
        }

        public void UpdateCommunity()
        {
            var repository = new EntityFrameworkExamRepository();
            Console.Clear();
            Console.Write("Community's id: ");
            int id = int.Parse(Console.ReadLine() ?? throw new ArgumentException("Invalid id"));
            Console.Write("Community's name: ");
            string? name = Console.ReadLine();
            if (String.IsNullOrEmpty(name) || name.Length > 50)
                throw new ArgumentException("Name");
            Community community = new Community
            {
                Id = id,
                Name = name
            };
            IEnumerable<int> usersId = new List<int>();
            while (true)
            {
                Console.WriteLine("Add user? y/any key");
                if (Console.ReadLine() == "y")
                {
                    Console.Write("User's id: ");
                    int userId = int.Parse(Console.ReadLine() ?? throw new ArgumentException("Invalid id"));
                    usersId = usersId.Append(userId);
                }
                else
                    break;
            }
            if (repository.UpdateCommunity(community, usersId))
                Console.WriteLine("Community was updated successful!");
            Console.ReadKey();
        }

        public void GetUsers()
        {
            var repository = new EntityFrameworkExamRepository();
            Console.Clear();
            IEnumerable<User> users = repository.GetUsers();
            foreach (var user in users)
            {
                Console.WriteLine($"Id: {user.Id}\nName: {user.Name}\nCommunities count: {user.Communities.Count()}\nCountry: {user.Country.Name}");
            }
            Console.ReadKey();
        }

        public void GetCommunities()
        {
            var repository = new EntityFrameworkExamRepository();
            Console.Clear();
            IEnumerable<Community> communities = repository.GetCommunities();
            foreach (var community in communities)
            {
                Console.WriteLine($"Id: {community.Id}\nName: {community.Name}\nUser's count: {community.Users.Count()}");
            }
            Console.ReadKey();
        }

        public void DeleteUser()
        {
            var repository = new EntityFrameworkExamRepository();
            Console.Clear();
            Console.Write("User's id: ");
            int id = int.Parse(Console.ReadLine() ?? throw new ArgumentException("Invalid id"));
            if (repository.DeleteUser(id))
                Console.WriteLine("User was deleted succesful");
            Console.ReadKey();
        }

        public void DeleteCommunity()
        {
            var repository = new EntityFrameworkExamRepository();
            Console.Clear();
            Console.Write("Community's id: ");
            int id = int.Parse(Console.ReadLine() ?? throw new ArgumentException("Invalid id"));
            if (repository.DeleteCommunity(id))
                Console.WriteLine("Community was deleted succesful");
            Console.ReadKey();
        }
    }
}

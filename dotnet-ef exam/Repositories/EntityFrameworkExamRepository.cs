using dotnet_ef_exam.Entities;
using dotnet_ef_exam.EntityFramework;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dotnet_ef_exam.Repositories
{
    internal class EntityFrameworkExamRepository : ExamRepository
    {
        public override bool InsertUser(Entities.User user, int countryId, IEnumerable<int> communitiesId)
        {
            var dbContext = new ExamDbContext();
            dbContext.Database.EnsureCreated();
            user.Country = new Country { Id = countryId };
            foreach (var communityId in communitiesId)
            {
                user.Communities = user.Communities.Append(new Community { Id = communityId }).ToList();
            }
            dbContext.Entry(user.Country).State = EntityState.Unchanged;
            foreach (var community in user.Communities)
            {
                dbContext.Entry(community).State = EntityState.Unchanged;
            }
            dbContext.Users.Add(user);
            return dbContext.SaveChanges() > 0;
        }
        public override bool InsertCommunity(Entities.Community community, IEnumerable<int> usersId)
        {
            var dbContext = new ExamDbContext();
            dbContext.Database.EnsureCreated();
            foreach(var userId in usersId)
            {
                community.Users = community.Users.Append(new User { Id = userId }).ToList();
            }
            foreach (var user in community.Users)
            {
                dbContext.Entry(user).State = EntityState.Unchanged;
            }
            dbContext.Communities.Add(community);
            return dbContext.SaveChanges() > 0;
        }
        public override ICollection<Entities.User> GetUsers()
        {
            var dbContext = new ExamDbContext();
            dbContext.Database.EnsureCreated();
            return dbContext.Users.Include(u => u.Communities).Include(u => u.Country).ToList();
        }
        public override ICollection<Entities.Community> GetCommunities()
        {
            var dbContext = new ExamDbContext();
            dbContext.Database.EnsureCreated();
            return dbContext.Communities.Include(c => c.Users).ToList();
        }
        public override bool UpdateUser(Entities.User newUserInfo, int countryId, IEnumerable<int> communitiesId)
        {
            var dbContext = new ExamDbContext();
            dbContext.Database.EnsureCreated();
            var user = dbContext
                .Users
                .Include(u => u.Communities)
                .Include(u => u.Country)
                .Single(u => u.Id == newUserInfo.Id);
            user.Name = newUserInfo.Name;
            user.Age = newUserInfo.Age;
            user.Communities = new List<Community>();
            foreach (var communityId in communitiesId)
            {
                user.Communities.Add(dbContext.Communities.Find(communityId));
            }
            user.Country = dbContext.Countries.Find(countryId);
            dbContext.Users.Update(user);
            return dbContext.SaveChanges() > 0;
        }
        public override bool UpdateCommunity(Entities.Community newCommunityInfo, IEnumerable<int> usersId)
        {
            var dbContext = new ExamDbContext();
            dbContext.Database.EnsureCreated();
            var community = dbContext
                .Communities
                .Include(c => c.Users)
                .Single(c => c.Id == newCommunityInfo.Id);
            community.Name = newCommunityInfo.Name;
            community.Users = new List<User>();
            foreach (var userId in usersId)
            {
                community.Users.Add(dbContext.Users.Find(userId));
            }
            dbContext.Communities.Update(community);
            return dbContext.SaveChanges() > 0;
        }
        public override bool DeleteUser(int userId)
        {
            var dbContext = new ExamDbContext();
            dbContext.Database.EnsureCreated();
            dbContext.Users.Remove(dbContext.Users.Find(userId));
            return dbContext.SaveChanges() > 0;
        }
        public override bool DeleteCommunity(int communityId)
        {
            var dbContext = new ExamDbContext();
            dbContext.Database.EnsureCreated();
            dbContext.Communities.Remove(dbContext.Communities.Find(communityId));
            return dbContext.SaveChanges() > 0;
        }
    }
}

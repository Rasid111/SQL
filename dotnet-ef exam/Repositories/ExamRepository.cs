using dotnet_ef_exam.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dotnet_ef_exam.Repositories
{
    internal abstract class ExamRepository
    {
        public abstract bool InsertUser(Entities.User user, int countryId, IEnumerable<int> communitiesId);
        public abstract bool InsertCommunity(Entities.Community community, IEnumerable<int> usersId);
        public abstract ICollection<Entities.User> GetUsers();
        public abstract ICollection<Entities.Community> GetCommunities();
        public abstract bool UpdateUser(Entities.User user, int countryId, IEnumerable<int> communitiesId);
        public abstract bool UpdateCommunity(Entities.Community newCommunityInfo, IEnumerable<int> usersId);
        public abstract bool DeleteUser(int userId);
        public abstract bool DeleteCommunity(int communityId);
    }
}

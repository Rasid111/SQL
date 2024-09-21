using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dotnet_ef_exam.Entities
{
    internal class Country
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Code { get; set; }
        public ICollection<User>? Users { get; set; } = new List<User>();
    }
}

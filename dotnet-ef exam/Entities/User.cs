using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dotnet_ef_exam.Entities
{
    internal class User
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Age { get; set; }
        public ICollection<Community>? Communities { get; set; } = new List<Community>();
        public Country Country { get; set; }
    }
}

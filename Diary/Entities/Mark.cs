using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Diary.Entities
{
    internal class Mark
    {
        public int Id {  get; set; }
        public int Value { get; set; }
        public int StudentId { get; set; }
        public Mark(int Id, int Value)
        {
            this.Id = Id;
            this.Value = Value;
        }
        public Mark(int Value)
        {
            this.Value = Value;
        }
    }
}

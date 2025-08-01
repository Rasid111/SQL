﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace Diary.Entities
{
    internal class Group
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public Group(int Id, string Name)
        {
            this.Id = Id;
            this.Name = Name;
        }
        public Group(string Name)
        {
            this.Name = Name;
        }
    }
}

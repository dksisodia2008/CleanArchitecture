using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClearnArchitecture.Domain.Entities
{
    public class Student
    {
        public int Id{ get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public int RollNumber { get; set; }
        public string? Grade { get; set; }

    }
}

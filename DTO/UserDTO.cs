using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class UserDTO
    {
        public int UserId { get; set; }

        public int Email { get; set; }

        public string? FirstName { get; set; }

        public string? LastName { get; set; }

        public string? Password { get; set; }

        //public int OrderId { get; set; }

       // public string? OrderDate { get; set; }

      //  public int? OrderSum { get; set; }
    }
}

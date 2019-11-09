using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.DataAnnotations;

namespace Entities
{
  public  class User
    {
        [Key]
        public int UserId { get; set; }

        [Required]
        public string Name { get; set; }

        public string Gender { get; set; }

        public string PhoneNo { get; set; }

        public string Role { get; set; }

        public string Previlliges { get; set; }


    }
}

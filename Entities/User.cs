using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.DataAnnotations;

namespace Entities
{
    public class User
    {
        public virtual ICollection<UserRole> UserRoles { get; set; }

        [Key]
        public int UserId { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public string Password { get; set; }
        public string Gender { get; set; }

        public string Email { get; set; }



    
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Entities
{
   public class Role
    {
        [Key]
        public int RoleId { get; set; }
        [Required]
        public string roleCode { get; set; }
        [Required]
        public string roleName { get; set; }

        public string roleDescription { get; set; }


    }
}

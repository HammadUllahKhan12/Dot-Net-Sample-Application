using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Entities
{
    public class Privilege
    {
        [Key]
        public int PrevlegeId { get; set; }

        [Required]
        public string PrevlegeCode { get; set; }

        public string PrevlegeName { get; set; }

        public string PrevlegeDescription { get; set; }

        public virtual ICollection<RolePrivilege> RolePrivilege { get; set; }


    }
}

using System.ComponentModel.DataAnnotations;

namespace CnG.Domain.Model
{
    public class User : Entity
    {
        [Required]
        [MaxLength(250)]
        public virtual string FirstName { get; set; }

        [Required]
        [MaxLength(250)]
        public virtual string LastName { get; set; }

        [Required]
        public virtual Membership Membership { get; set; }
    }
}

using System.ComponentModel.DataAnnotations;

namespace CnG.Domain.Model
{
    public class User : Entity
    {
        [Required]
        [MaxLength(250)]
        public virtual string Name { get; set; }

        [Required]
        public virtual Membership Membership { get; set; }
    }

    public class Membership : Entity
    {
        [Required]
        [MaxLength(100)]
        public virtual string  UserName { get; set; }
        
        [Required]
        [MaxLength(15)]
        public virtual string Password { get; set; }

        [Required]
        public virtual User User { get; set; }
    }
}

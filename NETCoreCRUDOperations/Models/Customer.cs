using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace NETCoreCRUDOperations.Models
{
    [Table("tblCustomer")]
    public class Customer
    {
        [Key]
        [Required]
        public int ID { get; set; }

        [StringLength(50)]
        [Required]
        public string Name { get; set; }

        [StringLength(50)]
        [Required]
        public string Country { get; set; }

        [StringLength(50)]
        [Required]
        public string Email { get; set; }

        [StringLength(6)]
        [Required]
        public string Gender { get; set; }
    }
}

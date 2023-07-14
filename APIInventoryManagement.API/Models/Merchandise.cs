using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace APIInventoryManagement.API.Models
{
    [Table("Merchandises")]
    public class Merchandise : Base
    {
        [Required]
        [StringLength(30)]
        public string? Name { get; set; }

        [Required]
        public int? RegisterNumber { get; set; }

        [Required]
        [StringLength(40)]
        public string? Manufacturer { get; set; }

        [Required]
        [StringLength(20)]
        public string? Type { get; set; }

        [Required]
        [StringLength(200)]
        public string? Description { get; set; }
    }
}

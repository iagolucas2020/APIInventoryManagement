using System.ComponentModel.DataAnnotations;

namespace APIInventoryManagement.API.Models
{
    public class Base
    {
        [Key]
        public int Id { get; set; }
    }
}

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace APIInventoryManagement.API.Models
{
    [Table("Stocks")]
    public class Stock : Base
    {
        [Required]
        public int Quantity { get; set; }

        [Required]
        public DateTime Date { get; set; }

        [Required]
        [StringLength(40)]
        public string Location { get; set; }

        [Required]
        public bool Receipt { get; set; }

        [Required]
        public int MerchandiseId { get; set; }

        [JsonIgnore]
        public Merchandise Merchandise { get; set; }
    }
}

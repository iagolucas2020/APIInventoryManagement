using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace APIInventoryManagement.API.Models
{
    [Table("Logs")]
    public class Logs : Base
    {
        [Required]
        [StringLength(300)]
        public string DescriptionError { get; set; }

        [Required]
        public DateTime Date { get; set; }

        public Logs(string descriptionError, DateTime date)
        {
            DescriptionError = descriptionError;
            Date = date;
        }
    }
}

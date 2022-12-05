using System.ComponentModel.DataAnnotations;

namespace Agenda_NetRazorP.Models
{
    public class Category
    {
        [Required]
        [Key]
        public int Id { get; set; }
        [Required, StringLength(50)]
        [Display(Name = "Nombre")]
        public string Name { get; set; } = String.Empty;

        [Required]
        [DataType(DataType.Date)]
        [Display(Name = "Fecha de creación")]
        public DateTime CreationDate { get; set; }
    }
}

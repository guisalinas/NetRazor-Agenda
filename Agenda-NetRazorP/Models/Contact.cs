using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Xml.Linq;

namespace Agenda_NetRazorP.Models
{
    public class Contact
    {
        [Required]
        [Key]
        public int Id { get; set; }

        [Required, StringLength(50)]
        [Display(Name = "Nombre")]
        public string Name { get; set; } = String.Empty;

        [Required]
        [Display(Name = "Teléfono")]
        public string PhoneNumber { get; set; } = String.Empty;
        public string Email { get; set; } = String.Empty;

        [Required]
        [DataType(DataType.Date)]
        [Display(Name = "Fecha de creación")]
        public DateTime CreationDate { get; set; }


        [Required(ErrorMessage = "Por favor, ingrese la categoria")]
        [Display(Name = "Categoria")]
        public int CategoryId { get; set; }
        public Category Category { get; set; }
    }
}

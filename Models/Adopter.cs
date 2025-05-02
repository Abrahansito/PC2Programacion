using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PC2Programacion.Models
{
     [Table("t_Adopters")]
    public class Adopter
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required(ErrorMessage = "El nombre completo del adoptante es obligatorio.")]
        [StringLength(100, ErrorMessage = "El nombre completo no puede tener más de 100 caracteres.")]
        public string NombreCompleto { get; set; }

        [Required(ErrorMessage = "El contacto del adoptante es obligatorio.")]
        [StringLength(100, ErrorMessage = "El contacto no puede tener más de 100 caracteres.")]
        public string Contacto { get; set; }
    }
}
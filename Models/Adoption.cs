using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PC2Programacion.Models
{
    [Table("t_Adoptions")]
    public class Adoption
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required(ErrorMessage = "La mascota es obligatoria para la adopción.")]
        public int PetId { get; set; } 

        [Required(ErrorMessage = "El adoptante es obligatorio para la adopción.")]
        public int AdopterId { get; set; }

        [Required(ErrorMessage = "La fecha de adopción es obligatoria.")]
        public DateTime AdoptionDate { get; set; }

        [ForeignKey("PetId")]
        public virtual Pet Pet { get; set; }

        [ForeignKey("AdopterId")]
        public virtual Adopter Adopter { get; set; }
    }
}

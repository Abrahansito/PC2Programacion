using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PC2Programacion.Models
{
    [Table("t_Pets")]
    public class Pet
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required(ErrorMessage = "El nombre de la mascota es obligatorio.")]
        [StringLength(100, ErrorMessage = "El nombre de la mascota no puede tener más de 100 caracteres.")]
        public string Nombre { get; set; }

        [Required(ErrorMessage = "La edad de la mascota es obligatoria.")]
        [Range(0, 100, ErrorMessage = "La edad debe estar entre 0 y 100 años.")]
        public int Edad { get; set; }

        [Required(ErrorMessage = "El tipo de mascota es obligatorio.")]
        [StringLength(50, ErrorMessage = "El tipo de mascota no puede tener más de 50 caracteres.")]
        public string Tipo { get; set; } 

        [Required(ErrorMessage = "El estado de adopción es obligatorio.")]
        public bool EstadoAdopcion { get; set; } 

        // Relación uno a uno con Adopción
        public int? AdoptionId { get; set; } 

        [ForeignKey("AdoptionId")]
        public virtual Adoption Adopcion { get; set; } 
    }
}

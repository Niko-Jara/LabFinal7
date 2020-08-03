using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace CapaDatos
{
    public class GestionPrestamos
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int idprestamo { get; set; }

        [Required]
        public int Habitantes { get; set; }

        [Required]
        public decimal PIB { get; set; }

        [Required]
        public int Superficie { get; set; }


        [Required]
        public string Riesgo { get; set; }

        [Required]
        public bool Prestamo { get; set; }

        [ForeignKey("Pais")]
        [Required]
        public int idPais { get; set; }


        [ForeignKey("Idioma")]
        [Required]
        public int idIdioma { get; set; }


        public virtual Pais Pais { get; set; }

        public virtual Idiomas Idioma { get; set; }
    }
}


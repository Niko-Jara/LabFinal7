using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace CapaDatos
{
    public class Idiomas
    {
        public Idiomas()
        {
            this.GestionPrestamos = new HashSet<GestionPrestamos>();
        }

        [Key]
        public int IdIdioma { get; set; }

        [StringLength(45)]
        [Required]
        public string DescIdioma { get; set; }

        public virtual ICollection<GestionPrestamos> GestionPrestamos { get; set; }
    }
}

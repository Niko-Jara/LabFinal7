using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace CapaDatos
{
    public class Pais
    {
        public Pais()
        {
            this.GestionPrestamos = new HashSet<GestionPrestamos>();
        }

        [Key]
        public int idPais { get; set; }

        [Required]
        public string DescPais { get; set; }

        public virtual ICollection<GestionPrestamos> GestionPrestamos { get; set; }
    }
}


using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;

namespace CapaDatos
{
    public class ModeloFMI : DbContext
    {
        public ModeloFMI() : base("name=bdFondos")
        {

        }

        public virtual DbSet<Idiomas> Idioma { get; set; }
        public virtual DbSet<Pais> Pais { get; set; }
        public virtual DbSet<GestionPrestamos> GestionPrestamoes { get; set; }
    }
}

using System;
using System.Collections.Generic;

namespace WSUniversidad.Models
{
    public partial class Profesores
    {
        public Profesores()
        {
            Notas = new HashSet<Notas>();
            RelMateriaProfesor = new HashSet<RelMateriaProfesor>();
        }

        public long CodProfesor { get; set; }
        public string Nombres { get; set; }
        public string Apellidos { get; set; }

        public virtual ICollection<Notas> Notas { get; set; }
        public virtual ICollection<RelMateriaProfesor> RelMateriaProfesor { get; set; }
    }
}

using System;
using System.Collections.Generic;

namespace WSUniversidad.Models
{
    public partial class Alumnos
    {
        public Alumnos()
        {
            Notas = new HashSet<Notas>();
            RelMateriaAlumno = new HashSet<RelMateriaAlumno>();
        }

        public long CodigoAlumno { get; set; }
        public string Nombres { get; set; }
        public string Apellidos { get; set; }
        public DateTime FechaIngreso { get; set; }
        public int Carrera { get; set; }
        public string EstadoAlumno { get; set; }

        public virtual ICollection<Notas> Notas { get; set; }
        public virtual ICollection<RelMateriaAlumno> RelMateriaAlumno { get; set; }
    }
}

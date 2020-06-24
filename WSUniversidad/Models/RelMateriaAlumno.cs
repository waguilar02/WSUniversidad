using System;
using System.Collections.Generic;

namespace WSUniversidad.Models
{
    public partial class RelMateriaAlumno
    {
        public long Id { get; set; }
        public int CodMateria2 { get; set; }
        public long CodAlumno1 { get; set; }

        public virtual Alumnos CodAlumno1Navigation { get; set; }
        public virtual Materias CodMateria2Navigation { get; set; }
    }
}

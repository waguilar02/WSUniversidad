using System;
using System.Collections.Generic;

namespace WSUniversidad.Models
{
    public partial class Notas
    {
        public long Id { get; set; }
        public int CodMateria1 { get; set; }
        public long CodAlumno1 { get; set; }
        public long CodProfesor1 { get; set; }
        public decimal Nota { get; set; }
        public int Periodo { get; set; }

        public virtual Alumnos CodAlumno1Navigation { get; set; }
        public virtual Materias CodMateria1Navigation { get; set; }
        public virtual Profesores CodProfesor1Navigation { get; set; }
    }
}

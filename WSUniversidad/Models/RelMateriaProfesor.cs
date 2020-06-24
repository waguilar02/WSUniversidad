using System;
using System.Collections.Generic;

namespace WSUniversidad.Models
{
    public partial class RelMateriaProfesor
    {
        public long Id { get; set; }
        public int CodigoMateria3 { get; set; }
        public long CodigoProfesor1 { get; set; }

        public virtual Materias CodigoMateria3Navigation { get; set; }
        public virtual Profesores CodigoProfesor1Navigation { get; set; }
    }
}

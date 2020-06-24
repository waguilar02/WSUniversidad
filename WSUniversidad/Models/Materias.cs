using System;
using System.Collections.Generic;

namespace WSUniversidad.Models
{
    public partial class Materias
    {
        public Materias()
        {
            Notas = new HashSet<Notas>();
            RelMateriaAlumno = new HashSet<RelMateriaAlumno>();
            RelMateriaProfesor = new HashSet<RelMateriaProfesor>();
            RelMateriaSalon = new HashSet<RelMateriaSalon>();
        }

        public int CodigoMateria { get; set; }
        public string NombreMateria { get; set; }
        public int CreditosMateria { get; set; }

        public virtual ICollection<Notas> Notas { get; set; }
        public virtual ICollection<RelMateriaAlumno> RelMateriaAlumno { get; set; }
        public virtual ICollection<RelMateriaProfesor> RelMateriaProfesor { get; set; }
        public virtual ICollection<RelMateriaSalon> RelMateriaSalon { get; set; }
    }
}

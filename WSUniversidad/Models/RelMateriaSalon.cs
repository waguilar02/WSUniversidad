using System;
using System.Collections.Generic;

namespace WSUniversidad.Models
{
    public partial class RelMateriaSalon
    {
        public int Id { get; set; }
        public int CodigoMateria4 { get; set; }
        public int NroSalon1 { get; set; }

        public virtual Materias CodigoMateria4Navigation { get; set; }
        public virtual Salones NroSalon1Navigation { get; set; }
    }
}

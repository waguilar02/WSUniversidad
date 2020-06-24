using System;
using System.Collections.Generic;

namespace WSUniversidad.Models
{
    public partial class Salones
    {
        public Salones()
        {
            RelMateriaSalon = new HashSet<RelMateriaSalon>();
        }

        public int NumSalon { get; set; }
        public string Descripcion { get; set; }

        public virtual ICollection<RelMateriaSalon> RelMateriaSalon { get; set; }
    }
}

using System;
using System.Collections.Generic;

namespace WSUniversidad.Models
{
    public partial class LogEventos
    {
        public long Id { get; set; }
        public DateTime FechaEvento { get; set; }
        public string Usuario { get; set; }
        public string DescripcionEvento { get; set; }
        public string ValorAnterior { get; set; }
        public string ValorActual { get; set; }
    }
}

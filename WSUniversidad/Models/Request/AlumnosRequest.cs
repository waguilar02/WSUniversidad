using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WSUniversidad.Models.Request
{
    public class AlumnosRequest
    {
        public int tiposolicitud { get; set; }
        public long CodigoAlumno { get; set; }
        public string Nombres { get; set; }
        public string Apellidos { get; set; }
        public DateTime FechaIngreso { get; set; }
        public int Carrera { get; set; }
        public string EstadoAlumno { get; set; }
        public int AccionARealizar { get; set; }

    }



}

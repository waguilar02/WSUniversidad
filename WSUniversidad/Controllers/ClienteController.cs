using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WSUniversidad.Models;
using WSUniversidad.Models.Response;
using WSUniversidad.Models.Request;


namespace WSUniversidad.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClienteController : ControllerBase
    {
        [HttpGet]
        public IActionResult Get() /* interface para consulta*/
        {

            Respuesta oRespuesta = new Respuesta();
           
            try
            {


                using (UniversidadContext db = new UniversidadContext())
                {   /*Creacion del contexto*/
                    //var lst = db.Alumnos.ToList();
                    var lst = db.Alumnos.OrderBy(l => l.FechaIngreso).ToList();

                    oRespuesta.Exito = 1;
                    oRespuesta.Data = lst;
                }
            }
            catch (Exception ex)
            {
                oRespuesta.Mensaje = ex.Message;
            }
            return Ok(oRespuesta);
        }

        [HttpPost]
        public IActionResult Add(ClienteRequest oModel) /* interface para inserción de datos*/
        {

            Respuesta oRespuesta = new Respuesta();

            try 
            {
                using (UniversidadContext db = new UniversidadContext()) {

                    Alumnos oAlumnos = new Alumnos(); /*Creamos un objeto de la (clase-Tabla) Alumnos */
                    oAlumnos.CodigoAlumno = oModel.CodigoAlumno;
                    oAlumnos.Nombres = oModel.Nombres;
                    oAlumnos.Apellidos = oModel.Apellidos;
                    oAlumnos.FechaIngreso = oModel.FechaIngreso;
                    oAlumnos.Carrera = oModel.Carrera;
                    oAlumnos.EstadoAlumno = oModel.EstadoAlumno;

                    db.Alumnos.Add(oAlumnos); /*agregamos el objeto oAlumnos a la Base de datos*/
                    db.SaveChanges(); /*Guardamos los cambios realizados*/
                    oRespuesta.Exito = 1;
                }


                    
            }
            catch (Exception ex)
            {
                oRespuesta.Mensaje = ex.Message;
            }
            return Ok(oRespuesta);
        }





    }
}
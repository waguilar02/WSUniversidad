using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WSUniversidad.Models.Response;
using WSUniversidad.Models.Request;
using WSUniversidad.Models;
using System.Linq.Expressions;

namespace WSUniversidad.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AlumnosController : ControllerBase /*Controlador para CRUD Alumnos*/
    {

        [HttpGet]
        public IActionResult Get() /* interface para consulta*/
        {

            Respuesta oRespuesta = new Respuesta();

            try
            {


                using (UniversidadContext db = new UniversidadContext())
                {   /*Creacion del contexto*/
                    var lst = db.Alumnos.ToList();
                    //var lst = db.Alumnos.OrderBy(l => l.FechaIngreso).ToList();

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
        public IActionResult GetAdd(AlumnosRequest oModel ) /* interface para consulta parametrizada  e inserción de datos nuevos*/
        {
           
            Respuesta oRespuesta = new Respuesta();

            try
            {


                using (UniversidadContext db = new UniversidadContext())
                {   /*Creacion del contexto*/
                    var lst = db.Alumnos.ToList(); //
                    lst = null;



                    switch (oModel.tiposolicitud)
                    {
                        case 1:

                            lst = db.Alumnos.ToList();
                            oRespuesta.Mensaje = "Lista sin ordenar";
                            break;
                        case 2:
                            lst = db.Alumnos.OrderBy(l => l.FechaIngreso).ToList();
                            oRespuesta.Mensaje = "Lista de alumnos ordenada por fecha de ingreso.";
                            break;
                        case 3:
                            
                            Alumnos oAlumnos = new Alumnos(); /*Creamos un objeto de la (clase-Tabla) Alumnos */
                            oAlumnos.CodigoAlumno = oModel.CodigoAlumno;
                            oAlumnos.Nombres = oModel.Nombres;
                            oAlumnos.Apellidos = oModel.Apellidos;
                            oAlumnos.FechaIngreso = oModel.FechaIngreso;
                            oAlumnos.Carrera = oModel.Carrera;
                            oAlumnos.EstadoAlumno = oModel.EstadoAlumno;
                            db.Alumnos.Add(oAlumnos); /*agregamos el objeto oAlumnos a la Base de datos*/
                            db.SaveChanges(); /*Guardamos los cambios realizados*/
                            oRespuesta.Mensaje = "Registro ingresado correctamente";
                            break;

                        default:
                            oRespuesta.Mensaje = "tiposolicitud Inválido";
                            break;

                    }
                                        
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

        [HttpPut]
        public IActionResult Edit(AlumnosRequest oModel) /* interface para actualización de registros*/
        {

            Respuesta oRespuesta = new Respuesta();

            try
            {


                using (UniversidadContext db = new UniversidadContext())
                {   /*Creacion del contexto*/

                    /*Creacion del contexto*/
                    var lst = db.Alumnos.ToList(); //
                    lst = null;
                    // oAlumnos = db.Alumnos.Find(oModel.CodigoAlumno);



                    switch (oModel.tiposolicitud)
                    {


                         
                        case 1:

                            Alumnos oAlumnos = db.Alumnos.Find(oModel.CodigoAlumno);
                            oAlumnos.CodigoAlumno = oModel.CodigoAlumno;
                            oAlumnos.Nombres = oModel.Nombres;
                            oAlumnos.Apellidos = oModel.Apellidos;
                            oAlumnos.FechaIngreso = oModel.FechaIngreso;
                            oAlumnos.Carrera = oModel.Carrera;
                            oAlumnos.EstadoAlumno = oModel.EstadoAlumno;
                            db.Entry(oAlumnos).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                            db.SaveChanges(); /*Guardamos los cambios realizados en la BD*/
                            oRespuesta.Mensaje = "Registro Modificado correctamente";
                            oRespuesta.Exito = 1;

                            break;
                        case 2:
                            Alumnos oAlumnos1 = db.Alumnos.Find(oModel.CodigoAlumno);
                            oAlumnos1.EstadoAlumno = "BORRADO";
                            db.Entry(oAlumnos1).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                            db.SaveChanges(); /*Guardamos los cambios realizados en la BD*/
                            oRespuesta.Mensaje = "Registro Borrado correctamente";
                            oRespuesta.Exito = 1;

                            break;
                       
                        default:
                            oRespuesta.Mensaje = "tiposolicitud Inválido";
                            break;

                    }

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



    }
}
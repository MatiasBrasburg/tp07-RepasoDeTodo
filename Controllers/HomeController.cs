using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Tp07RepasoTodo_Urquizo_Brasburg.Models;

namespace Tp07RepasoTodo_Urquizo_Brasburg.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;

    public HomeController(ILogger<HomeController> logger)
    {
        _logger = logger;
    }

    public IActionResult Index()
    {
        return RedirectToAction ("Index" , "Account" );
    }

       public IActionResult CrearTarea( string Descripcion, DateTime Fecha)
    {
        int id  =  int.Parse(HttpContext.Session.GetString("ID"));
      bool Finalizado = false;
      Tareas TareaNueva = new Tareas(Descripcion, Fecha, Finalizado, id );
      
      if(BD.TraerTarea(id) != TareaNueva)
      {
         int seCreo = BD.CrearTarea(TareaNueva);
       
        if (seCreo >= 1)
        {
           ViewBag.MensajeCrear = "Se creo la tarea correctamente";
        }
      }
      else
      {
         ViewBag.MensajeCrear = "Ya existe esta tarea";
      }
      
      return View("PagPrincipal");
    }


  public IActionResult EliminarTarea( int Id)
    {

      if(BD.EliminarTarea(Id) >= 1 )
      {
        
           ViewBag.Mensaje = "Se Elimino la tarea correctamente";

      }
      else
      {
         ViewBag.Mensaje= "No se pudo eliminar esta tare";
      }
      
      return View("PagPrincipal");
    }

  public IActionResult FinalizarTarea( int Id)
    {

      if(BD.FinalizarTarea(Id) >= 1)
      {
        
           ViewBag.Mensaje = "Se finalizar la tarea correctamente";

      }
      else
      {
         ViewBag.Mensaje = "No se pudo finalizar esta tare";
      }
      
      return View("PagPrincipal");
    }

     public IActionResult TraerTareas()
    {
      int id  =  int.Parse(HttpContext.Session.GetString("ID"));
     List <Tareas> TareasList = BD.TraerTareas(id);
    ViewBag.Tareas = TareasList;

     return View("PagPrincipal");

    }

    
  public IActionResult TraerTarea()
    {
        int id  =  int.Parse(HttpContext.Session.GetString("ID"));
     Tareas Tarea = BD.TraerTarea(id);
    ViewBag.Tarea = Tarea;

     return View("PagPrincipal");

    }

 public IActionResult ActualizarTarea( string Descripcion, DateTime Fecha, bool Finalizado, int idTarea)
    {
      int id  =  int.Parse(HttpContext.Session.GetString("ID"));

      Tareas TareaAActualizar = new Tareas (Descripcion, Fecha, Finalizado, idTarea);
      
      if(BD.TraerTarea(id) == TareaAActualizar)
      {
         int seActualizo = BD.ActualizarTareas(TareaAActualizar);
       
        if (seActualizo >= 1)
        {
           ViewBag.MensajeCrear = "Se actualizo la tarea correctamente";
        }
      }
      else
      {
         ViewBag.MensajeCrear = "no se pudo actualizar esta tarea, ya que no existe";
      }
      
      return View("PagPrincipal");
    }
    
}

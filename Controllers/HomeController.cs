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
        
        return RedirectToAction ("Index" , "AccountController" );
    }

       public IActionResult CrearTarea( string Descripcion, DateTime Fecha)
    {
       HttpContext.Session.GetString("ID", UsuarioLogin.id);
      int Finalizado = 0;
      Tareas TareaNueva = (Descripcion, Fecha, Finalizado,  UsuarioLogin.id );
      
      if(BD.TraerTarea() != TareaNueva)
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

      if(BD.EliminarTarea(Id) => 1 )
      {
        
           ViewBag.MensajeEliminar = "Se Elimino la tarea correctamente";

      }
      else
      {
         ViewBag.MensajeEliminar = "No se pudo eliminar esta tare";
      }
      
      return View("PagPrincipal");
    }

  public IActionResult FinalizarTarea( int Id)
    {

      if(BD.FinalizarTarea(Id) => 1 )
      {
        
           ViewBag.MensajeEliminar = "Se finalizar la tarea correctamente";

      }
      else
      {
         ViewBag.MensajeEliminar = "No se pudo finalizar esta tare";
      }
      
      return View("PagPrincipal");
    }

     public IActionResult TraerTareas()
    {
       HttpContext.Session.GetString("ID", UsuarioLogin.id);
     List<Tareas> TareasList = BD.TraerTareas(UsuarioLogin.id);
    ViewBag.Tareas = TareasList;

     return View("PagPrincipal");

    }

    
  public IActionResult TraerTarea()
    {
       HttpContext.Session.GetString("ID", UsuarioLogin.id);
     Tareas Tarea = BD.TraerTarea(UsuarioLogin.id);
    ViewBag.Tarea = Tarea;

     return View("PagPrincipal");

    }

 public IActionResult ActualizarTarea( string Descripcion, DateTime Fecha, int Finalizado, int idTarea)
    {
       HttpContext.Session.GetString("ID", UsuarioLogin.id);

      Tareas TareaAActualizar = (Descripcion, Fecha, Finalizado, idTarea,  UsuarioLogin.id );
      
      if(BD.TraerTarea() == TareaAActualizar)
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

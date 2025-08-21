using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Tp07RepasoTodo_Urquizo_Brasburg.Models;

namespace Tp07RepasoTodo_Urquizo_Brasburg.Controllers;

public class AccountController : Controller
{
    private readonly ILogger<AccountController> _logger;

    public AccountController(ILogger<AccountController> logger)
    {
        _logger = logger;
    }

    public IActionResult Index()
    {
        return View("Index");
    }
[HttpPost]
     public IActionResult LogIn2( string UserName, string Contraseña)
    {
       Usuario UsuarioLogin = BD.Login(UserName,Contraseña);

        string DONDE = "PagPrincipal";
        ViewBag.Existe = UsuarioLogin;
        if(ViewBag.Existe == null){
          DONDE = "Index";
           ViewBag.MensajeLogin = "Usuario o contraseña incorrectos";
        } 
        else
        {
            BD.ActualizarFecahLogIn(UsuarioLogin.Id);
        HttpContext.Session.SetString("ID", UsuarioLogin.Id.ToString());

        }

        return View(DONDE);
    }
[HttpPost]
   public IActionResult Registrarse2(string UserName, string Contraseña, string Nombre, string Apellido, string Foto)
    {
        bool Sepudo = false;
      string DONDE = "Index";
       DateTime fechaHoy = DateTime.Now;

     Usuario UsuarioRegistrar  = new Usuario ( UserName, Contraseña, Nombre, Apellido, Foto);
   


        Sepudo = BD.Resgistro(UsuarioRegistrar);
         ViewBag.Existe = Sepudo;
       
        if(ViewBag.Existe == false)
        {
               DONDE = "Registrar";
                HttpContext.Session.SetString("ID", UsuarioRegistrar.Id.ToString());
        }
        else
        {
           ViewBag.Mensaje = "Ya tienes un usuario existente en esta plataforma";

        }
        

        return View(DONDE);
    }
[HttpPost]
     public IActionResult CerrarSesion ()
    {
            HttpContext.Session.Clear();
        return View("Index");
    }
   
     public IActionResult Registrarse1()
    {
    
        return View("Registrar");
    }
    public IActionResult LogIn1()
    {
    
        return View("Index");
    }

}


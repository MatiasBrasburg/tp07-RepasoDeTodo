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


         UsuarioLogin = BD.Login(UserName,Contraseña);
        string DONDE = "PagPrincipal";
        ViewBag.Existe = UsuarioLogin;
        if(ViewBag.Existe == null){
          DONDE = "Index";
           ViewBag.MensajeLogin = "Usuario o contraseña incorrectos";
        } 
        else
        {
            BD.ActualizarFecahLogIn(UsuarioLogin.id);
        HttpContext.Session.SetString("ID", UsuarioLogin.id);

        }

        return View(DONDE);
    }
[HttpPost]
   public IActionResult Registrarse2(Usuario UsuarioRegistrar)
    {
        bool Sepudo = false;
      string DONDE = "Index";


   


        Sepudo = BD.Resgistro(UsuarioRegistrar);
         ViewBag.Existe = Sepudo;
       
        if(ViewBag.Existe == false)
        {
               DONDE = "Registrar";
                HttpContext.Session.SetString("ID", Resgistro.id);
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
        HttpContext.Session.SetString();
        return View("Index");
    }
   
     public IActionResult Registrarse1()
    {
    
        return View("Registrarse");
    }
    public IActionResult LogIn1()
    {
    
        return View("Index");
    }

}


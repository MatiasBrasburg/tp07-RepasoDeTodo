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
          
   //poner despues ek session con el id del chabon 

        return View("LogIn");
    }
[HttpPost]
     public IActionResult LogIn( string UserName, string Contraseña)
    {
        Usuario Inicializar = Objeto.StringToObject<Usuario>(HttpContext.Session.GetString("BD"));
        Usuario UsuarioLogin = BD.Login(UserName,Contraseña);
        string DONDE = "HomeTareas";
        ViewBag.Existe = UsuarioLogin;
        if(ViewBag.Existe == null){
          DONDE = "Index";
           ViewBag.Mensaje = "Usuario o contraseña incorrectos";
        }

        return View(DONDE);
    }
[HttpPost]
   public IActionResult Registrarse(Usuario UsuarioRegistrar)
    {
        bool Sepudo = false;
      string DONDE = "index";

//poner lo de httpost para guardar el id en session
        Usuario Inicializar = Objeto.StringToObject<Usuario>(HttpContext.Session.GetString("BD"));

        Sepudo = BD.Resgistro(UsuarioRegistrar);
         ViewBag.Existe = Sepudo;
       
        if(ViewBag.Existe == false)
        {
               DONDE = "Registrar";
        }
        else
        {
           ViewBag.Mensaje = "Ya tienes un usuario existente en esta plataforma";

        }
        

        return View(DONDE);
    }

    [HttpPost]
     public IActionResult LogIn( string UserName, string Contraseña)
    {
        Usuario Inicializar = Objeto.StringToObject<Usuario>(HttpContext.Session.GetString("BD"));
        Usuario UsuarioLogin = BD.Login(UserName,Contraseña);
        string DONDE = "HomeTareas";
        ViewBag.Existe = UsuarioLogin;
        if(ViewBag.Existe == null){
          DONDE = "Index";
           ViewBag.Mensaje = "Usuario o contraseña incorrectos";
        }

        return View(DONDE);
    }
}


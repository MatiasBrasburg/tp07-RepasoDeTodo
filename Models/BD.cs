using Microsoft.Data.SqlClient;
using Dapper;



public static class BD
{

private static string _connectionString = @"Server=localhost;
DataBase=ProgTP6BaseDeDatos;Integrated Security=True;TrustServerCertificate=True;";



public static Usuario Login (string Username, string Contraseña)
{
Usuario User = null;
    using (SqlConnection connection = new SqlConnection(_connectionString))
    {
        string query = "SELECT * FROM Usuarios where Username = @pUsername AND Contraseña = @pContraseña ";
        User = connection.QueryFirstOrDefault<Usuario>(query, new {pUsername = Username, pContraseña = Contraseña});
    }
    Console.WriteLine(User);
    return User;
}

public static bool  Resgistro (Usuario user)
{
bool existe;
    using (SqlConnection connection = new SqlConnection(_connectionString))
    {
        string query = "INSERT INTO Usuarios (UserName, Contraseña, Nombre,Apellido,Foto,UltimoInicio) VALUES (@pUsername,  @pContraseña, @pNombre,  @pApellido, @pFoto,  @pUltimoInicio)";
        existe = connection.QueryFirstOrDefault<bool>(query, new {Username= user.Username,  Contraseña=user.Contraseña , Nombre = user.Nombre  ,  Apellido = user.Apellido,  Foto  = user.Foto,   UltimoInicio =  user.UltimoInicio});
    }
 
    return existe;
}

public static List<Tareas> TraerTareas( int Id )
{
    List<Tareas> TareasList = new List<Tareas>();
     using (SqlConnection connection = new SqlConnection(_connectionString))
     {
        string query = "SELECT * FROM Tareas WHERE Id = @pId";
        TareasList= connection.Query<Tareas>(query, new { pId= Id}).ToList();
     }
     return TareasList;
}

public static  void CrearTarea(Tareas TareaNueva)
{

    string query = "INSERT INTO Tareas (Descripcion, Fecha, Finalizado, IdUsuario) VALUES ( @pDescripcion, @pFecha,  @pFinalizado,  @pIdUsuario)";
    int TareasAgregadas= 0;

    using (SqlConnection connection = new SqlConnection(_connectionString))
    {
        TareasAgregadas= connection.Execute(query, new { @pDescripcion = TareaNueva.Descripcion, @pFecha = TareaNueva.Fecha,  @pFinalizado = TareaNueva.Finalizado,  @pIdUsuario = TareaNueva.IdUsuario});
    }
}

public static void EliminarTarea(int Id){
    string query = "DELETE * FROM Tareas WHERE Tareas.Id = @pId";
    int TereasEliminadas =0;

    using (SqlConnection connection = new SqlConnection(_connectionString)){
        TereasEliminadas = connection.Execute(query, new{pId=Id});
    }
}

public static Tareas TrerTarea(int Id){
    Tareas TareaDevuelta = null;

     using (SqlConnection connection = new SqlConnection(_connectionString))
     {
        string query ="SELECT * FROM Tareas WHERE Id = @pId";
        TareaDevuelta = connection.QueryFirstOrDefault<Tareas>(query, new  {pId = Id});
     }
     return TareaDevuelta;
}

public static void ActualizarTareas(Tareas TareaActualizar)
{
    string query ="UPDATE Tareas SET Descripcion = @pDescripcion ,Fecha = @pFecha , Finalizado = @pFinalizado , IdUsuario= @pIdUsuario WHERE Descripcion = @pDescripcion AND Fecha = @pFecha AND Finalizado = @pFinalizado AND IdUsuario= @pIdUsuario ";
     int TareasActualizadas = 0;

  using (SqlConnection connection = new SqlConnection(_connectionString))
  {
   TareasActualizadas = connection.Execute(query, new{pDescripcion = TareaActualizar.Descripcion, pFecha = TareaActualizar.Fecha, pFinalizado = TareaActualizar.Finalizado, pIdUsuario = TareaActualizar.IdUsuario });
  } 


}

public static void FinalizarTarea(int Id)
{
 string query = "UPDATE Tareas SET Finalizado = 1 WHERE Id = @pId ";
 int TareaFinalizada=0;

  using (SqlConnection connection = new SqlConnection(_connectionString))
  {
    TareaFinalizada=connection.Execute(query, new{pId = Id});
  }

}




public static void ActualizarFecahLogIn(int Id){
    
string query = "UPDATE Usuarios SET UltimoInicio = Getday() WHERE Id = @pId";
int UsuarioActualizado =0;

using (SqlConnection connection = new SqlConnection(_connectionString))
  {
    UsuarioActualizado = connection.Execute(query, new{pId = Id});
  }

}






}











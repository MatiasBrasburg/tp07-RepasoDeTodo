using Microsoft.Data.SqlClient;
using Dapper;



public static class BD
{

private static string _connectionString = @"Server=localhost;
DataBase=ProgTP6BaseDeDatos;Integrated Security=True;TrustServerCertificate=True;";



public static Usuario Login (string Username, string Contraseña)
{
Usuario existe = null;
    using (SqlConnection connection = new SqlConnection(_connectionString))
    {
        string query = "SELECT * FROM Usuarios where Username = @pUsername AND Contraseña = @pContraseña ";
        existe = connection.QueryFirstOrDefault<Usuario>(query, new {pUsername = Username, pContraseña = Contraseña});
    }
    Console.WriteLine(existe);
    return existe;
}

public static bool  Resgistro (Usuario user)
{
bool existe;
    using (SqlConnection connection = new SqlConnection(_connectionString))
    {
        string query = "INSERT INTO Usuarios (UserName, Contraseña, Nombre,Apellido,Foto,UltimoInicio) VALUES (user.Username = Username, user.Contraseña = Contraseña, user.Nombre = Nombre, user.Apellido = Apellido, user.Foto = Foto, user.UltimoInicio = UltimoInicio)";
        existe = connection.QueryFirstOrDefault<bool>(query, new {user.Username = Username, user.Contraseña = Contraseña, user.Nombre = Nombre, user.Apellido = Apellido, user.Foto = Foto, user.UltimoInicio = UltimoInicio});
    }
 
    return existe;
}



















public static List<Usuario> Registro (Usuario existe)
{
List<Usuario> ListIntegrantes = new List<Usuario>();
    using (SqlConnection connection = new SqlConnection(_connectionString))
    {
        string query = "SELECT * FROM Integrantes Where NombreGrupo = @PNombreGrupo";
        ListIntegrantes = connection.Query<Usuario>(query, new {PNombreGrupo = NombreGrupo}).ToList();
    }
    return ListIntegrantes;
}
}




using Newtonsoft.Json;
public class Usuario 
{
    [JsonProperty]
public string Username {get; private set;}

    [JsonProperty]
    public string Contraseña{get; private set;}


    [JsonProperty]
public string Nombre {get; private set;}
 
    [JsonProperty]
public string Apellido{get; private set;}


    [JsonProperty]
public string Foto{get; private set;}

    [JsonProperty]
public DateTime UltimoInicio {get; private set;}
 
 [JsonProperty]
public int Id {get; private set;}

 public Usuario()
 {

 }

 public Usuario(string Username, string Nombre, string Apellido , string Foto, DateTime UltimoInicio,int Id  )
 {

 }
}
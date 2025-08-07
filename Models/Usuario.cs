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
public Datetime UltimoInicio {get; private set;}
 
}
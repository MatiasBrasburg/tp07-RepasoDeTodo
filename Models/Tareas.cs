using Newtonsoft.Json;
public class Usuario 
{
    [JsonProperty]
public int Id {get; private set;}

    [JsonProperty]
    public string Descripcion{get; private set;}

    [JsonProperty]
public Datetime Fecha {get; private set;}

    [JsonProperty]
public bool Finalizado {get; private set;}
 
    [JsonProperty]
public int IdUsuario {get; private set;}





 
}
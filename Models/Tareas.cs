using Newtonsoft.Json;
public class Tareas 
{
    [JsonProperty]
public int Id {get; private set;}

    [JsonProperty]
    public string Descripcion{get; private set;}

    [JsonProperty]
public DateTime Fecha {get; private set;}

    [JsonProperty]
public bool Finalizado {get; private set;}
 
    [JsonProperty]
public int IdUsuario {get; private set;}


public Tareas()
{

}


 
}
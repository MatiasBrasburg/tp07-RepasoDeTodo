using Newtonsoft.Json;
public class Tareas 
{
    [JsonProperty]
    public int Id { get; private set; }

 [JsonProperty]
    public string Titulo { get; private set; }

    [JsonProperty]
    public string Descripcion{get; private set;}

    [JsonProperty]
public DateTime? Fecha { get; set; }

    [JsonProperty]
public DateTime? Finalizado { get; set; }
 
    [JsonProperty]
public int IdUsuario {get; private set;}


public Tareas(string Titulo ,string Descripcion, DateTime Fecha, bool Finalizado, int id)
{

}

public Tareas()
{

}

 
}
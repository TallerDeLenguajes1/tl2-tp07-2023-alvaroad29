using System.Text.Json;

namespace tl2_tp07_2023_alvaroad29;
public class AccesoADatos
{
    private string ruta = "infoTareas.json";
    public List<Tarea> Obtener()
    {
        if (File.Exists(ruta))
        {
            List<Tarea> tareas = new List<Tarea>();
            string tareasString = File.ReadAllText(ruta);

            if(new FileInfo(ruta).Length > 0)
            {
                tareas = JsonSerializer.Deserialize<List<Tarea>>(tareasString);
            }
            return tareas;
        }else
        {
            return null;
        }
    }

    public void Guardar(List<Tarea> tareas)
    {
        string tareasGuardar = JsonSerializer.Serialize(tareas);
        File.WriteAllText(ruta, tareasGuardar);
    }
}
using Microsoft.AspNetCore.Mvc;

namespace tl2_tp07_2023_alvaroad29.Controllers;

[ApiController]
[Route("[controller]")]
public class TareasController : ControllerBase
{
    private readonly ILogger<TareasController> _logger;
    private ManejoTareas manejoTareas;
    public TareasController(ILogger<TareasController> logger)
    {
        _logger = logger;
        var accesoTareas = new AccesoADatos(); //instancio accesoADatos
        manejoTareas = new ManejoTareas(accesoTareas);
    }

    [HttpPost("CrearTarea")]
    public ActionResult<Tarea> CrearTarea(Tarea tarea)
    {
        // var accesoTareas = new AccesoDatos();
        // var manejoTareas = new ManejoTareas(accesoTareas);
        var nuevaTarea = manejoTareas.AddTarea(tarea);
        if (nuevaTarea != null)
        {
            return Ok(tarea); //Created("/tareas/",tarea);
        }else
        {
            return BadRequest(null);
        }
    }

    [HttpGet("ObtenerTarea")]
    public ActionResult<Tarea> GetTarea(int idTarea)
    {
        var tarea = manejoTareas.ObtenerTarea(idTarea);
        if (tarea != null) // la encontro
        {
            return Ok(tarea);
        }else
        {
            return NotFound("Tarea no encontrada, reingrese el id");
        }
    }

    [HttpPut("ActualizarTarea")]
    public ActionResult<Tarea> ActualizarTarea(Tarea tarea)
    {
        var tareaActualizada = manejoTareas.ActualizarTarea(tarea);
        if (tareaActualizada != null)
        {
            return Ok(tareaActualizada);
        }else
        {
            return BadRequest("Tarea a actualizar no encontrada");
        }
    }


    [HttpDelete("DeleteTarea")]
    public ActionResult DeleteTarea(int idTarea)
    {
        var exito = manejoTareas.DeleteTarea(idTarea);
        if (exito) return Ok("Tarea eliminada");
        return BadRequest("Tarea a eliminar no encontrada");
    }

    [HttpGet("ListarTareas")]
    public ActionResult<List<Tarea>> GetTareas()
    {
        var tareas = manejoTareas.GetTareas();
        return Ok(tareas);
    }

    [HttpGet("ListarTareasCompletadas")]
    public ActionResult<List<Tarea>> GetTareasCompletadas()
    {
        var tareasCompletadas = manejoTareas.GetTareasCompletadas();
        return Ok(tareasCompletadas);
    }

}
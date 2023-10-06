namespace tl2_tp07_2023_alvaroad29
{
    public class ManejoTareas
    {
        private AccesoADatos accesoTareas;
        public ManejoTareas(AccesoADatos accesoTareas) // constructor de ManejoTareas
        {
            this.accesoTareas = accesoTareas;
        }
        public Tarea AddTarea(Tarea tarea)
        {
            var tareas = accesoTareas.Obtener();
            tareas.Add(tarea);
            tarea.Id = tareas.Count();
            accesoTareas.Guardar(tareas);
            return tarea;
        }

        public Tarea ObtenerTarea(int idTarea)
        {
            var tareas = accesoTareas.Obtener();
            var tarea = tareas.FirstOrDefault(tarea => tarea.Id == idTarea);
            return tarea;
        }

        public Tarea ActualizarTarea(Tarea tarea)
        {
            var tareas = accesoTareas.Obtener();
            var tareaActualizar = tareas.FirstOrDefault(t => t.Id == tarea.Id);
            if (tareaActualizar != null)
            {
                tareaActualizar.Estado = tarea.Estado;
                tareaActualizar.Titulo = tarea.Titulo;
                tareaActualizar.Descripcion = tarea.Descripcion;
                accesoTareas.Guardar(tareas);
            }
            return tareaActualizar;
        }

        public bool DeleteTarea(int idTarea)
        {
            var tareas = accesoTareas.Obtener();
            var tarea = tareas.FirstOrDefault(t => t.Id == idTarea);
            if (tarea != null)
            {
                var exito = tareas.Remove(tarea);
                if (exito)
                {
                    accesoTareas.Guardar(tareas);
                    return true;
                }
                return true;
            }else return false;
        }

        public List<Tarea> GetTareas()
        {
            return accesoTareas.Obtener();
        }

        public List<Tarea> GetTareasCompletadas()
        {
            var tareas = accesoTareas.Obtener();
            var tareasCompletadas = tareas.FindAll(t => t.Estado == Estado.Completado);
            return tareasCompletadas;
        }
    }   
}
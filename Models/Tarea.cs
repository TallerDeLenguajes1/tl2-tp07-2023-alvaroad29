namespace tl2_tp07_2023_alvaroad29{
    public class Tarea{
        public int Id{get;set;} = 0;
        public string Titulo {get;set;}
        public string Descripcion {get;set;}
        public Estado Estado{get;set;}
    }

    public enum Estado{
        Pendiente,
        EnProgreso,
        Completado
    }
}

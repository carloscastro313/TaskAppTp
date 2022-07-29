namespace TaskAppTp.Helpers
{
    public static class TareasHelper
    {
        public static string GetBgPrioridad(ePrioridad prioridad)
        {
            switch (prioridad)
            {
                case ePrioridad.Baja:
                    return "bg-success";
                case ePrioridad.Media:
                    return "bg-warning";
                case ePrioridad.Alta:
                    return "bg-danger";
                default:
                    return "bg-success";
            }
        }

        public static string GetBtnColorEstado(eEstado estado)
        {
            switch (estado)
            {
                case eEstado.Pendiente:
                    return "btn-danger";
                case eEstado.Realizando:
                    return "btn-warning";
                case eEstado.Terminado:
                    return "btn-success";
                default:
                    return "btn-success";
            }
        }
    }
}

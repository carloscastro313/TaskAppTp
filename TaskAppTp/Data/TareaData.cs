using Microsoft.Data.SqlClient;
using System.Data;
using TaskAppTp.Models;

namespace TaskAppTp.Data
{
    public class TareaData
    {
        public Tarea GetTarea(int id)
        {
            SqlCommand cmd = new SqlCommand("spGetTarea");

            cmd.Parameters.AddWithValue("@Id", id);

            DbConnection dbConnection = new DbConnection();

            DataTable dt = dbConnection.ExcecuteReaderProcedure(cmd);


            if (dt.Rows.Count != 1)
            {
                return null;
            }

            DataRow row = dt.Rows[0];

            return new Tarea
            {
                Id = row.Field<int>("Id"),
                Nombre = row.Field<string>("Nombre"),
                Completo = row.Field<eEstado>("Completo"),
                Descripcion = row.Field<string>("Descripcion"),
                Prioridad = row.Field<ePrioridad>("Prioridad"),
                IdCarpeta = row.Field<int>("IdCarpeta"),
                FechaCreado = row.Field<DateTime>("FechaCreada"),
                FechaCambioEstado = row.Field<DateTime?>("FechaCambioEstado")
            };
        }

        public List<Tarea> GetTareas(int id, int prioridad = -1, string? nombre = null)
        {
            SqlCommand cmd = new SqlCommand("spGetTareas");

            cmd.Parameters.AddWithValue("@IdCarpeta", id);
            if (prioridad != -1)
                cmd.Parameters.AddWithValue("@Prioridad", prioridad);
            if (!string.IsNullOrEmpty(nombre))
                cmd.Parameters.AddWithValue("@nombre", nombre);

            DbConnection dbConnection = new DbConnection();


            DataTable dtTareas = dbConnection.ExcecuteReaderProcedure(cmd);

            return dtTareas.AsEnumerable().Select(row => new Tarea
            {
                Id = row.Field<int>("Id"),
                Nombre = row.Field<string>("Nombre"),
                Completo = row.Field<eEstado>("Completo"),
                Descripcion = row.Field<string>("Descripcion"),
                Prioridad = row.Field<ePrioridad>("Prioridad"),
                IdCarpeta = row.Field<int>("IdCarpeta"),
                FechaCreado = row.Field<DateTime>("FechaCreada"),
                FechaCambioEstado = row.Field<DateTime?>("FechaCambioEstado")
            }).ToList();
        }

        public bool CreateTarea(Tarea tarea)
        {
            SqlCommand cmd = new SqlCommand("spCreateTarea");

            cmd.Parameters.AddWithValue("@Nombre", tarea.Nombre);
            cmd.Parameters.AddWithValue("@Descripcion", tarea.Descripcion);
            cmd.Parameters.AddWithValue("@Prioridad", tarea.Prioridad);
            cmd.Parameters.AddWithValue("@FechaCreado", tarea.FechaCreado);
            cmd.Parameters.AddWithValue("@IdCarpeta", tarea.IdCarpeta);

            DbConnection dbConnection = new DbConnection();

            return dbConnection.ExcecuteProcedure(cmd);
        }

        public bool UpdateTarea(Tarea tarea)
        {
            SqlCommand cmd = new SqlCommand("spUpdateTarea");

            cmd.Parameters.AddWithValue("@Id", tarea.Id);
            cmd.Parameters.AddWithValue("@Nombre", tarea.Nombre);
            cmd.Parameters.AddWithValue("@Descripcion", tarea.Descripcion);
            cmd.Parameters.AddWithValue("@Prioridad", tarea.Prioridad);
            cmd.Parameters.AddWithValue("@Completo", tarea.Completo);
            cmd.Parameters.AddWithValue("@FechaCambioEstado", tarea.FechaCambioEstado);

            DbConnection dbConnection = new DbConnection();

            return dbConnection.ExcecuteProcedure(cmd);
        }

        public bool DeleteTarea(int id)
        {
            SqlCommand cmd = new SqlCommand("spDeleteTarea");

            cmd.Parameters.AddWithValue("@Id", id);

            DbConnection dbConnection = new DbConnection();

            return dbConnection.ExcecuteProcedure(cmd);
        }

        public static bool TareaExiste(int id)
        {
            TareaData tareaData = new TareaData();
            Tarea existe = tareaData.GetTarea(id);

            return existe != null;
        }
    }
}

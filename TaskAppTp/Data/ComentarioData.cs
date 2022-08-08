using Microsoft.Data.SqlClient;
using System.Data;
using TaskAppTp.Models;

namespace TaskAppTp.Data
{
    public class ComentarioData
    {

        public List<Comentario> GetComentarios(int idTarea)
        {
            SqlCommand cmd = new SqlCommand("spGetComentarios");

            cmd.Parameters.AddWithValue("@IdTarea", idTarea);

            DbConnection dbConnection = new DbConnection();

            DataTable dtCarpetas = dbConnection.ExcecuteReaderProcedure(cmd);

            return dtCarpetas.AsEnumerable().Select(row => new Comentario
            {
                Id = row.Field<int>("Id"),
                Texto = row.Field<string>("Texto"),
                FechaCreada = row.Field<DateTime>("FechaCreada"),
                IdTarea = row.Field<int>("IdTarea"),
            }).ToList();
        }

        public bool CreateComentario(Comentario comentario)
        {
            SqlCommand cmd = new SqlCommand("spCreateComentario");

            cmd.Parameters.AddWithValue("@Texto", comentario.Texto);
            cmd.Parameters.AddWithValue("@FechaCreada", comentario.FechaCreada);
            cmd.Parameters.AddWithValue("@IdTarea", comentario.IdTarea);

            DbConnection dbConnection = new DbConnection();

            return dbConnection.ExcecuteProcedure(cmd);
        }

        public bool DeleteComentario(int id)
        {
            SqlCommand cmd = new SqlCommand("spDeleteComentario");

            cmd.Parameters.AddWithValue("@Id", id);

            DbConnection dbConnection = new DbConnection();

            return dbConnection.ExcecuteProcedure(cmd);
        }
    }
}

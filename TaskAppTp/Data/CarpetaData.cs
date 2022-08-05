using Microsoft.Data.SqlClient;
using System.Data;
using TaskAppTp.Models;

namespace TaskAppTp.Data
{
    public class CarpetaData
    {

        public List<Carpeta> GetCarpetas(string? nombre = null)
        {
            SqlCommand cmd = new SqlCommand("spGetCarpetas");

            if (!string.IsNullOrEmpty(nombre))
                cmd.Parameters.AddWithValue("@nombre", nombre);

            DbConnection dbConnection = new DbConnection();

            DataTable dtCarpetas = dbConnection.ExcecuteReaderProcedure(cmd);

            return dtCarpetas.AsEnumerable().Select(row => new Carpeta
            {
                Id = row.Field<int>("Id"),
                Nombre = row.Field<string>("Nombre"),
                CantidadTareas = row.Field<int>("CantidadTareas"),
                Terminadas = row.Field<int>("Terminado"),
                Pendiente = row.Field<int>("Pendiente")
            }).ToList();
        }

        public Carpeta GetCarpeta(int id)
        {
            SqlCommand cmd = new SqlCommand("spGetCarpeta");

            cmd.Parameters.AddWithValue("@Id", id);

            DbConnection dbConnection = new DbConnection();

            DataTable dt = dbConnection.ExcecuteReaderProcedure(cmd);


            if (dt.Rows.Count != 1)
            {
                return null;
            }

            DataRow row = dt.Rows[0];

            return new Carpeta
            {
                Id = (int)row["Id"],
                Nombre = (string)row["Nombre"]
            };
        }

        public bool CreateCarpeta(Carpeta carpeta)
        {
            SqlCommand cmd = new SqlCommand("spCreateCarpeta");

            cmd.Parameters.AddWithValue("@Nombre", carpeta.Nombre);

            DbConnection dbConnection = new DbConnection();

            return dbConnection.ExcecuteProcedure(cmd);
        }

        public bool DeleteCarpeta(int id)
        {
            SqlCommand cmd = new SqlCommand("spDeleteCarpeta");

            cmd.Parameters.AddWithValue("@Id", id);

            DbConnection dbConnection = new DbConnection();

            return dbConnection.ExcecuteProcedure(cmd);
        }

        public bool UpdateCarpeta(Carpeta carpeta)
        {
            SqlCommand cmd = new SqlCommand("spUpdateCarpeta");

            cmd.Parameters.AddWithValue("@Id", carpeta.Id);
            cmd.Parameters.AddWithValue("@Nombre", carpeta.Nombre);

            DbConnection dbConnection = new DbConnection();

            return dbConnection.ExcecuteProcedure(cmd);
        }

        public static bool CarpetaExiste(int id, out Carpeta carpeta)
        {
            CarpetaData carpetaData = new CarpetaData();
            carpeta = carpetaData.GetCarpeta(id);

            return carpeta != null;
        }

        public static bool CarpetaExiste(int id)
        {
            return CarpetaExiste(id, out _);
        }
    }
}

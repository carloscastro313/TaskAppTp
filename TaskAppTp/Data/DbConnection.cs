using Microsoft.Data.SqlClient;
using System.Data;

namespace TaskAppTp.Data
{
    public class DbConnection
    {

        private string _connectionString = String.Empty;

        public DbConnection()
        {
            var builder = new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory()).AddJsonFile("appsettings.json").Build();

            _connectionString = builder.GetSection("ConnectionStrings:DB").Value;
        }

        public string ConnectionString
        {
            get => _connectionString;
        }

        public bool ExcecuteProcedure(SqlCommand cmd)
        {
            bool respuesta;
            try
            {
                using (SqlConnection sql = new SqlConnection(ConnectionString))
                {
                    cmd.Connection = sql;
                    cmd.CommandType = CommandType.StoredProcedure;

                    sql.Open();

                    int AffectedRows = cmd.ExecuteNonQuery();

                    sql.Close();

                    respuesta = AffectedRows > 0;
                }
            }
            catch (Exception e)
            {
                respuesta = false;
                throw e;
            }

            return respuesta;
        }

        public DataTable ExcecuteReaderProcedure(SqlCommand cmd)
        {
            DataTable dt = new DataTable();
            try
            {
                using (SqlConnection sql = new SqlConnection(ConnectionString))
                {
                    cmd.Connection = sql;
                    cmd.CommandType = CommandType.StoredProcedure;

                    sql.Open();

                    using (SqlDataReader dataReader = cmd.ExecuteReader())
                    {
                        dt.Load(dataReader);
                    }

                    sql.Close();

                }
            }
            catch (Exception)
            {
                throw;
            }

            return dt;
        }
    }
}

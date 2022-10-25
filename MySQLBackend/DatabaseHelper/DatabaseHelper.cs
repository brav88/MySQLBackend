using MySql.Data.MySqlClient;
using MySQLBackend.Models;
using System.Data;

namespace MySQLBackend.DatabaseHelper
{
    public class DatabaseHelper
    {
        const string user = "root";
        const string password = "Admin$1234";
        const string servidor = @"localhost";
        const string port = "3306";
        const string baseDatos = "mydatabase";
        const string strConexion = $"server={servidor};Port={port};uid={user};pwd={password};database={baseDatos}";

        public static void InsertUser(User user)
        {
            List<MySqlParameter> paramList = new List<MySqlParameter>()
            {
                new MySqlParameter("pName", user.Name),
                new MySqlParameter("pLastName",user.LastName),
                new MySqlParameter("pEmail",user.Email),
                new MySqlParameter("pPhone",user.Phone),
                new MySqlParameter("pAddress",user.Address),
                new MySqlParameter("pDateIn",user.DateIn)
            };

            ExecStoreProcedure("spInsertUser", paramList);
        }

        //Para select 
        public static DataTable ExecuteStoreProcedure(string procedure, List<MySqlParameter> param)
        {
            try
            {
                using (MySqlConnection conn = new MySqlConnection(strConexion))
                {
                    conn.Open();
                    MySqlCommand cmd = new MySqlCommand();
                    cmd.CommandText = procedure;
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Connection = conn;

                    if (param != null)
                    {
                        foreach (MySqlParameter item in param)
                        {
                            cmd.Parameters.Add(item);
                        }
                    }

                    cmd.ExecuteNonQuery();
                    MySqlDataAdapter adapter = new MySqlDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    adapter.Fill(dt);

                    return dt;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static void ExecStoreProcedure(string procedure, List<MySqlParameter> param)
        {
            try
            {
                using (MySqlConnection conn = new MySqlConnection(strConexion))
                {
                    conn.Open();
                    MySqlCommand cmd = new MySqlCommand();
                    cmd.CommandText = procedure;
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Connection = conn;

                    if (param != null)
                    {
                        foreach (MySqlParameter item in param)
                        {
                            cmd.Parameters.Add(item);
                        }
                    }

                    cmd.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}

using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using TEST.Models;

namespace TEST.Repositories
{
    public class TiqueteRepository
    {

        public static bool addTiqueteToDB(Tiquete tiquete)
        {
            var connectionString = "Data Source=.;Initial Catalog=TECAirlines;Integrated Security=SSPI";

            var query = "INSERT INTO Tiquete (ID, Asiento) VALUES ('@ID', '@Asiento')";

            query = query.Replace("@ID", tiquete.ID.ToString())
                    .Replace("@Asiento", tiquete.Asiento.ToString());
                    


            SqlConnection connection = new SqlConnection(connectionString);

            try
            {
                connection.Open();
                SqlCommand command = new SqlCommand(query, connection);
                command.ExecuteNonQuery();
                command.Dispose();
                connection.Close();
                return true;
            }
            catch (Exception)
            {
                return false;
            }

        }

        public static Tiquete getTiqueteFromDB(int ID)
        {

            SqlDataReader reader = null;
            SqlConnection connection = new SqlConnection();
            connection.ConnectionString = "Data Source=.;Initial Catalog=TECAirlines;Integrated Security=SSPI";

            SqlCommand sqlCmd = new SqlCommand();
            sqlCmd.CommandType = CommandType.Text;

            var query = "SELECT * FROM Tiquete WHERE ID='@ID'";

            query = query.Replace("@ID", ID.ToString());

            sqlCmd.CommandText = query;

            sqlCmd.Connection = connection;
            connection.Open();
            reader = sqlCmd.ExecuteReader();
            Tiquete tiquete = null;
            while (reader.Read())
            {
                tiquete = new Tiquete();
                tiquete.ID = Convert.ToInt32(reader.GetValue(0));
                tiquete.Asiento = Convert.ToInt32(reader.GetValue(1));

            }
            connection.Close();
            return tiquete;
        }




        public static List<Tiquete> getAllTiquetesFromDB()
        {

            SqlDataReader reader = null;
            SqlConnection connection = new SqlConnection();
            connection.ConnectionString = "Data Source=.;Initial Catalog=TECAirlines;Integrated Security=SSPI";

            SqlCommand sqlCmd = new SqlCommand();
            sqlCmd.CommandType = CommandType.Text;

            var query = "SELECT * FROM Tiquete ";



            sqlCmd.CommandText = query;

            sqlCmd.Connection = connection;
            connection.Open();
            reader = sqlCmd.ExecuteReader();
            List<Tiquete> listaTiquetes = new List<Tiquete>();

            while (reader.Read())
            {
                Tiquete tiquete = null;
                tiquete = new Tiquete();
                tiquete.ID = Convert.ToInt32(reader.GetValue(0));
                tiquete.Asiento = Convert.ToInt32(reader.GetValue(1));

                listaTiquetes.Add(tiquete);
            }
            connection.Close();
            return listaTiquetes;
        }



        public static bool deleteTiqueteFromDB(int ID)
        {
            var connectionString = "Data Source=.;Initial Catalog=TECAirlines;Integrated Security=SSPI";


            var query = "DELETE FROM Tiquete WHERE ID='@ID'";

            query = query.Replace("@ID", ID.ToString());


            SqlConnection connection = new SqlConnection(connectionString);

            try
            {
                connection.Open();
                SqlCommand command = new SqlCommand(query, connection);
                command.ExecuteNonQuery();
                command.Dispose();
                connection.Close();
                return true;
            }
            catch (Exception)
            {
                return false;
            }

        }

    }
}
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using TEST.Models;

namespace TEST.Repositories
{
    public class PromocionRepository
    {

        public static bool addPromocionToDB(Promocion promocion)
        {
            var connectionString = "Data Source=.;Initial Catalog=TECAirlines;Integrated Security=SSPI";

            var query = "INSERT INTO Promoción (Costo, Ruta, Fecha) " +
                                "VALUES ('@Costo', '@Ruta', '@Fecha')";


            query = query.Replace("@Costo", promocion.Costo.ToString())
                    .Replace("@Ruta", promocion.Ruta)
                    .Replace("@Fecha", promocion.Fecha.ToString());


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

        public static Promocion getPromocionFromDB(string ruta)
        {

            SqlDataReader reader = null;
            SqlConnection connection = new SqlConnection();
            connection.ConnectionString = "Data Source=.;Initial Catalog=TECAirlines;Integrated Security=SSPI";

            SqlCommand sqlCmd = new SqlCommand();
            sqlCmd.CommandType = CommandType.Text;

            var query = "SELECT * FROM Promoción WHERE Ruta='@Ruta'";

            query = query.Replace("@Ruta", ruta);

            sqlCmd.CommandText = query;

            sqlCmd.Connection = connection;
            connection.Open();
            reader = sqlCmd.ExecuteReader();
            Promocion promocion = null;
            while (reader.Read())
            {
                promocion = new Promocion();
                
                promocion.Costo = Convert.ToInt32(reader.GetValue(0));
                promocion.Ruta = reader.GetValue(1).ToString();
                promocion.Fecha = reader.GetValue(2).ToString();

            }
            connection.Close();
            return promocion;
        }




        public static List<Promocion> getAllPromocionesFromDB()
        {

            SqlDataReader reader = null;
            SqlConnection connection = new SqlConnection();
            connection.ConnectionString = "Data Source=.;Initial Catalog=TECAirlines;Integrated Security=SSPI";

            SqlCommand sqlCmd = new SqlCommand();
            sqlCmd.CommandType = CommandType.Text;

            var query = "SELECT * FROM Promoción ";



            sqlCmd.CommandText = query;

            sqlCmd.Connection = connection;
            connection.Open();
            reader = sqlCmd.ExecuteReader();
            List<Promocion> listaPromociones = new List<Promocion>();

            while (reader.Read())
            {
                Promocion promocion = null;
                promocion = new Promocion();
                promocion.Costo = Convert.ToInt32(reader.GetValue(0));
                promocion.Ruta = reader.GetValue(1).ToString();
                promocion.Fecha = reader.GetValue(2).ToString();

                listaPromociones.Add(promocion);
            }
            connection.Close();
            return listaPromociones;
        }



        public static bool deletePromocionFromDB(string ruta)
        {
            var connectionString = "Data Source=.;Initial Catalog=TECAirlines;Integrated Security=SSPI";


            var query = "DELETE FROM Promoción WHERE Ruta='@Ruta'";

            query = query.Replace("@Ruta", ruta);


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
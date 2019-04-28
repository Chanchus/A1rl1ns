using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using TEST.Models;

namespace TEST.Repositories
{
    public class AvionRepository
    {

        public static bool addAvionToDB(Avion avion)
        {
            var connectionString = "Data Source=.;Initial Catalog=TECAirlines;Integrated Security=SSPI";

            var query = "INSERT INTO Avión (Tipo, ID, AsientosDisponibles, PrimClase, EconClase) VALUES ('@Tipo', '@ID', @AsientosDisponibles, @PrimClase, @EconClase)";

            query = query.Replace("@Tipo", avion.Tipo)
                   .Replace("@ID", avion.ID)
                   .Replace("@AsientosDisponibles", avion.AsientosDisponibles.ToString())
                   .Replace("@PrimClase", avion.PrimClase.ToString())
                   .Replace("@EconClase" , avion.EconClase.ToString());


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

        public static Avion getAvionFromDB(string id)
        {

            SqlDataReader reader = null;
            SqlConnection connection = new SqlConnection();
            connection.ConnectionString = "Data Source=.;Initial Catalog=TECAirlines;Integrated Security=SSPI";

            SqlCommand sqlCmd = new SqlCommand();
            sqlCmd.CommandType = CommandType.Text;

            var query = "SELECT * FROM Avión WHERE ID='@ID'";

            query = query.Replace("@ID", id);

            sqlCmd.CommandText = query;

            sqlCmd.Connection = connection;
            connection.Open();
            reader = sqlCmd.ExecuteReader();
            Avion avion = null;
            while (reader.Read())
            {
                avion = new Avion();
                avion.Tipo = reader.GetValue(0).ToString();
                avion.ID = reader.GetValue(1).ToString();
                avion.AsientosDisponibles = Convert.ToInt32(reader.GetValue(2)); 
                avion.PrimClase = Convert.ToInt32(reader.GetValue(3)); 
                avion.EconClase = Convert.ToInt32(reader.GetValue(4)); 

            }
            connection.Close();
            return avion;
        }




        public static List<Avion> getAllAvionesFromDB()
        {

            SqlDataReader reader = null;
            SqlConnection connection = new SqlConnection();
            connection.ConnectionString = "Data Source=.;Initial Catalog=TECAirlines;Integrated Security=SSPI";

            SqlCommand sqlCmd = new SqlCommand();
            sqlCmd.CommandType = CommandType.Text;

            var query = "SELECT * FROM Avión ";



            sqlCmd.CommandText = query;

            sqlCmd.Connection = connection;
            connection.Open();
            reader = sqlCmd.ExecuteReader();
            List<Avion> listaAviones = new List<Avion>();

            while (reader.Read())
            {
                Avion avion = null;
                avion = new Avion();
                avion.Tipo = reader.GetValue(0).ToString();
                avion.ID = reader.GetValue(1).ToString();
                avion.AsientosDisponibles = Convert.ToInt32(reader.GetValue(2)); 
                avion.PrimClase = Convert.ToInt32(reader.GetValue(3)); 
                avion.EconClase = Convert.ToInt32(reader.GetValue(4)); 

                listaAviones.Add(avion);
            }
            connection.Close();
            return listaAviones;
        }



        public static bool deleteAvionFromDB(string id)
        {
            var connectionString = "Data Source=.;Initial Catalog=TECAirlines;Integrated Security=SSPI";


            var query = "DELETE FROM Avión WHERE ID='@ID'";

            query = query.Replace("@ID", id);


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
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using TEST.Models;

namespace TEST.Repositories
{
    public class ReservacionRepository
    {

        public static bool addReservacionToDB(Reservacion reservacion)
        {
            var connectionString = "Data Source=.;Initial Catalog=TECAirlines;Integrated Security=SSPI";

            var query = "INSERT INTO Reservación (ID, CantidadTiquetes, IDPropietario) " +
                                "VALUES (@ID, '@CantidadTiquetes', '@IDPropietario')";

            query = query.Replace("@ID", reservacion.ID.ToString())
                    .Replace("@CantidadTiquetes", reservacion.CantidadTiquetes.ToString())
                    .Replace("@IDPropietario", reservacion.IDPropietario);


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

        public static Reservacion getReservacionFromDB(int ID)
        {

            SqlDataReader reader = null;
            SqlConnection connection = new SqlConnection();
            connection.ConnectionString = "Data Source=.;Initial Catalog=TECAirlines;Integrated Security=SSPI";

            SqlCommand sqlCmd = new SqlCommand();
            sqlCmd.CommandType = CommandType.Text;

            var query = "SELECT * FROM Reservación WHERE ID=@ID";

            query = query.Replace("@ID", ID.ToString());

            sqlCmd.CommandText = query;

            sqlCmd.Connection = connection;
            connection.Open();
            reader = sqlCmd.ExecuteReader();
            Reservacion reservacion = null;
            while (reader.Read())
            {
                reservacion = new Reservacion();
                reservacion.ID = Convert.ToInt32(reader.GetValue(0));
                reservacion.CantidadTiquetes = Convert.ToInt32(reader.GetValue(1));
                reservacion.IDPropietario = reader.GetValue(2).ToString();

            }
            connection.Close();
            return reservacion;
        }




        public static List<Reservacion> getAllReservacionesFromDB()
        {

            SqlDataReader reader = null;
            SqlConnection connection = new SqlConnection();
            connection.ConnectionString = "Data Source=.;Initial Catalog=TECAirlines;Integrated Security=SSPI";

            SqlCommand sqlCmd = new SqlCommand();
            sqlCmd.CommandType = CommandType.Text;

            var query = "SELECT * FROM Reservación ";



            sqlCmd.CommandText = query;

            sqlCmd.Connection = connection;
            connection.Open();
            reader = sqlCmd.ExecuteReader();
            List<Reservacion> listaReservaciones = new List<Reservacion>();

            while (reader.Read())
            {
                Reservacion reservacion = null;
                reservacion = new Reservacion();
                reservacion.ID = Convert.ToInt32(reader.GetValue(0));
                reservacion.CantidadTiquetes = Convert.ToInt32(reader.GetValue(1));
                reservacion.IDPropietario = reader.GetValue(2).ToString();

                listaReservaciones.Add(reservacion);
            }
            connection.Close();
            return listaReservaciones;
        }



        public static bool deleteReservacionFromDB(int ID)
        {
            var connectionString = "Data Source=.;Initial Catalog=TECAirlines;Integrated Security=SSPI";


            var query = "DELETE FROM Reservación WHERE ID=@ID";

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
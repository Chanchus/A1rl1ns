using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using TEST.Models;

namespace TEST.Repositories
{
    public class ClienteRepository
    {

        public static bool addClienteToDB(Cliente cliente)
        {
            var connectionString = "Data Source=.;Initial Catalog=TECAirlines;Integrated Security=SSPI";
            
            var query = "INSERT INTO Cliente (Pasaporte, NombreComp, Telefono, Correo, Estudiante, Pass, NTarjeta) VALUES ('@Pasaporte', '@NombreComp', @Telefono, '@Correo', @Estudiante, '@Pass', @NTarjeta)";

            query = query.Replace("@Pasaporte", cliente.Pasaporte)
                    .Replace("@NombreComp", cliente.NombreComp)
                    .Replace("@Telefono", cliente.Telefono.ToString())
                    .Replace("@Correo", cliente.Correo)
                    .Replace("@Estudiante", cliente.Estudiante.ToString())
                    .Replace("@Pass", cliente.Pass)
                    .Replace("@NTarjeta", cliente.NTarjeta.ToString());

          

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
            catch(Exception)
            {
                return false;
            }

        }

        public static Cliente getClienteFromDB(string pasaporte)
        {

            SqlDataReader reader = null;
            SqlConnection connection = new SqlConnection();
            connection.ConnectionString = "Data Source=.;Initial Catalog=TECAirlines;Integrated Security=SSPI";

            SqlCommand sqlCmd = new SqlCommand();
            sqlCmd.CommandType = CommandType.Text;

            var query = "SELECT * FROM Cliente WHERE Pasaporte='@Pasaporte'";

            query =  query.Replace("@Pasaporte", pasaporte);

            sqlCmd.CommandText = query; 

            sqlCmd.Connection = connection;
            connection.Open();
            reader = sqlCmd.ExecuteReader();
            Cliente cliente = null;
            while (reader.Read())
            {
                cliente = new Cliente();
                cliente.Pasaporte = reader.GetValue(0).ToString();
                cliente.NombreComp = reader.GetValue(1).ToString();
                cliente.Telefono = Convert.ToInt32(reader.GetValue(2));
                cliente.Correo = reader.GetValue(3).ToString();
                cliente.Estudiante = Convert.ToInt32(reader.GetValue(4));
                cliente.Pass = reader.GetValue(5).ToString();
                cliente.NTarjeta = Convert.ToInt32(reader.GetValue(6));
  
            }
            connection.Close();
            return cliente;
        }




        public static List<Cliente> getAllClientesFromDB()
        {

            SqlDataReader reader = null;
            SqlConnection connection = new SqlConnection();
            connection.ConnectionString = "Data Source=.;Initial Catalog=TECAirlines;Integrated Security=SSPI";

            SqlCommand sqlCmd = new SqlCommand();
            sqlCmd.CommandType = CommandType.Text;

            var query = "SELECT * FROM Cliente ";

            

            sqlCmd.CommandText = query;

            sqlCmd.Connection = connection;
            connection.Open();
            reader = sqlCmd.ExecuteReader();
            List<Cliente> listaClientes = new List<Cliente>();
            
            while (reader.Read())
            {
                Cliente cliente = null;
                cliente = new Cliente();
                cliente.Pasaporte = reader.GetValue(0).ToString();
                cliente.NombreComp = reader.GetValue(1).ToString();
                cliente.Telefono = Convert.ToInt32(reader.GetValue(2));
                cliente.Correo = reader.GetValue(3).ToString();
                cliente.Estudiante = Convert.ToInt32(reader.GetValue(4));
                cliente.Pass = reader.GetValue(5).ToString();
                cliente.NTarjeta = Convert.ToInt32(reader.GetValue(6));
                listaClientes.Add(cliente);
            }
            connection.Close();
            return listaClientes;
        }



        public static bool deleteClienteFromDB(string pasaporte)
        {
            var connectionString = "Data Source=.;Initial Catalog=TECAirlines;Integrated Security=SSPI";


            var query = "DELETE  FROM Cliente WHERE Pasaporte='@Pasaporte'";

            query = query.Replace("@Pasaporte", pasaporte);


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
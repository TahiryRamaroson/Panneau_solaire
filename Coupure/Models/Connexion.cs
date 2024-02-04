using Npgsql;
using System;


namespace Coupure.Models
{
    public class Connexion
    {
        public Connexion()
        {

        }

        public static NpgsqlConnection getConnection()
        {
            string config = "Host=localhost;Database=prevision_coupure;Username=postgres;Password=Tahiry1849";
            Console.WriteLine(config);
            NpgsqlConnection connect;
            try
            {
                connect = new NpgsqlConnection(config);
                connect.Open();
                return connect;
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }
    }
}

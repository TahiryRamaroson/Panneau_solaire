using Npgsql;

namespace Coupure.Models
{
    public class Journee
    {
        public int idJournee { get; set; }
        public DateOnly dateJournee { get; set; }

        public Journee() { }

        public Journee(int idJournee, DateOnly dateJournee)
        {
            this.idJournee = idJournee;
            this.dateJournee = dateJournee;
        }

        public static Boolean checkExistence(NpgsqlConnection connect, DateOnly date)
        {
            Boolean iscreated = false;

            try
            {
                if (connect == null)
                {
                    connect = Connexion.getConnection();
                    iscreated = true;
                }
                String script = "select * from Journee where dateJournee='" + date + "'";
                Console.WriteLine(script);
                NpgsqlCommand sql = new NpgsqlCommand(script, connect);
                NpgsqlDataReader reader = sql.ExecuteReader();
                if (reader.HasRows) return true;

                reader.Close();

                return false;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.StackTrace);
            }
            finally
            {
                try
                {
                    if (iscreated == true) connect.Close();
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }
            }
            return false;
        }
        public static int getId(NpgsqlConnection connect, DateOnly date)
        {
            Boolean iscreated = false;
            int idJ = -1;
            try
            {
                if (connect == null)
                {
                    connect = Connexion.getConnection();
                    iscreated = true;
                }
                String script = "select idJournee from Journee where dateJournee='" + date + "'";
                Console.WriteLine(script);
                NpgsqlCommand sql = new NpgsqlCommand(script, connect);
                NpgsqlDataReader reader = sql.ExecuteReader();

                while (reader.Read())
                {
                    idJ = reader.GetInt32(0);
                    Console.WriteLine("IdJournee: " + idJ);
                }

                reader.Close();

                return idJ;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.StackTrace);
            }
            finally
            {
                try
                {
                    if (iscreated == true) connect.Close();
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }
            }
            Console.WriteLine("Tsy nety ilay naka idJournee");
            return idJ;
        }
    }
}

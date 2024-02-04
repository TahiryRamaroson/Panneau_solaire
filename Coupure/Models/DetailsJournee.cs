using Npgsql;

namespace Coupure.Models
{
    public class DetailsJournee
    {
        public int idDetails { get; set; }
        public TimeOnly heure { get; set; }
        public double luminosite { get; set; }
        public int idJournee { get; set; }

        public DetailsJournee(){}
        public DetailsJournee(int idDetails, TimeOnly heure, double luminosite, int idJournee)
        {
            this.idDetails = idDetails;
            this.heure = heure;
            this.luminosite = luminosite;
            this.idJournee = idJournee;
        }

        public static List<DetailsJournee> getByIdJournee(NpgsqlConnection connect, int idjournee)
        {
            Boolean iscreated = false;
            List<DetailsJournee> all = new List<DetailsJournee>();
            try
            {
                if (connect == null)
                {
                    connect = Connexion.getConnection();
                    iscreated = true;
                }
                String script = "select * from DetailsJournee where idJournee=" + idjournee + " order by heure";
                Console.WriteLine(script);
                NpgsqlCommand sql = new NpgsqlCommand(script, connect);
                NpgsqlDataReader reader = sql.ExecuteReader();
                while (reader.Read())
                {
                    DetailsJournee dtjournee = new DetailsJournee(reader.GetInt32(0), TimeOnly.FromTimeSpan(reader.GetTimeSpan(1)), reader.GetDouble(2), reader.GetInt32(3));
                    all.Add(dtjournee);
                }
                reader.Close();
                return all;
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
                    Console.WriteLine(e.StackTrace);
                }
            }
            Console.WriteLine("Vide ilay maka somme DetailsJournee");
            return all;
        }
    }
}

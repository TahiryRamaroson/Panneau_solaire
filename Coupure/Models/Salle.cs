using Npgsql;

namespace Coupure.Models
{
    public class Salle
    {
        public int idSalle { get; set; }
        public string nomSalle { get; set; }
        public int idSource {  get; set; }

        public Salle() {}
        public Salle(int idSalle, string nomSalle, int idSource)
        {
            this.idSalle = idSalle;
            this.nomSalle = nomSalle;
            this.idSource = idSource;
        }

        public static List<int> getIdBySource(NpgsqlConnection connect, int idsrc)
        {
            Boolean iscreated = false;
            List<int> all = new List<int>();
            try
            {
                if (connect == null)
                {
                    connect = Connexion.getConnection();
                    iscreated = true;
                }
                String script = "select idsalle from Salle where idSource="+idsrc;
                Console.WriteLine(script);
                NpgsqlCommand sql = new NpgsqlCommand(script, connect);
                NpgsqlDataReader reader = sql.ExecuteReader();
                while (reader.Read())
                {
                    int idS = reader.GetInt32(0);
                    all.Add(idS);
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
            Console.WriteLine("Vide ilay maka idSalle");
            return all;
        }
    }
}

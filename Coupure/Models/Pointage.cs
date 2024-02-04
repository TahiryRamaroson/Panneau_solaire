using Npgsql;
using System.Text;

namespace Coupure.Models
{
    public class Pointage
    {
        public int idPointage { get; set; }
        public DateOnly datePointage { get; set; }
        public int nbEtudiant { get; set; }
        public int partieJournee { get; set; }
        public int idSalle { get; set; }

        public Pointage() { }

        public Pointage(int idPointage, DateOnly datePointage, int nbEtudiant, int partieJournee, int idSalle)
        {
            this.idPointage = idPointage;
            this.datePointage = datePointage;
            this.nbEtudiant = nbEtudiant;
            this.partieJournee = partieJournee;
            this.idSalle = idSalle;
        }

        public static int getPointage(NpgsqlConnection connect, DateOnly date, int partie, int idsrc)
        {
            Boolean iscreated = false;
            int nbPersonne = 0;
            
            try
            {
                if (connect == null)
                {
                    connect = Connexion.getConnection();
                    iscreated = true;
                }

                List<int> allSalle = Salle.getIdBySource(connect, idsrc);

                StringBuilder sbuilder = new StringBuilder();
                sbuilder.Append("select sum(nbetudiant) from pointage where (");
                int temp = 0;

                foreach (int item in allSalle)
                {
                    if (temp == allSalle.Count - 1) sbuilder.Append(" idsalle=" + item);
                    else sbuilder.Append(" idsalle=" + item + " or");

                    temp ++;
                }

                sbuilder.Append(") and partiejournee=" + partie + " and datepointage='" + date + "'");

                String script = sbuilder.ToString();
                Console.WriteLine(script);
                NpgsqlCommand sql = new NpgsqlCommand(script, connect);
                NpgsqlDataReader reader = sql.ExecuteReader();
                while (reader.Read())
                {
                    nbPersonne = reader.GetInt32(0);;
                }
                reader.Close();
                return nbPersonne;
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
            Console.WriteLine("Vide ilay maka somme nbEtudiant");
            return nbPersonne;
        }

        public static int getPointageMoyenne(NpgsqlConnection connect, int partie, DateOnly date, int idsrc)
        {
            Boolean iscreated = false;
            int nbPersonne = 0;

            try
            {
                if (connect == null)
                {
                    connect = Connexion.getConnection();
                    iscreated = true;
                }

                List<int> allSalle = Salle.getIdBySource(connect, idsrc);

                /*StringBuilder sbuilder = new StringBuilder();
                sbuilder.Append("select avg(nbetudiant) from pointage where (");
                int temp = 0;

                foreach (int item in allSalle)
                {
                    if (temp == allSalle.Count - 1) sbuilder.Append(" idsalle=" + item);
                    else sbuilder.Append(" idsalle=" + item + " or");

                    temp++;
                }

                sbuilder.Append(") and partiejournee=" + partie + " and (SELECT EXTRACT(DOW FROM datepointage::date)=" + (int)date.DayOfWeek + ")");

                String script = sbuilder.ToString();*/

                List<int> valiny = new List<int>();

                foreach (int item in allSalle)
                {
                    String script = "select avg(nbetudiant) from pointage where idsalle=" + item + " and partiejournee=" + partie + " and (SELECT EXTRACT(DOW FROM datepointage::date)=" + (int)date.DayOfWeek + ") and datepointage < '" + date + "'";
                    Console.WriteLine(script);
                    NpgsqlCommand sql = new NpgsqlCommand(script, connect);
                    NpgsqlDataReader reader = sql.ExecuteReader();
                    while (reader.Read())
                    {
                        nbPersonne = reader.GetInt32(0);
                        valiny.Add(nbPersonne);
                    }
                    reader.Close();
                    
                }

                
                return valiny.Sum();
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
            Console.WriteLine("Vide ilay maka moyenne nbEtudiant");
            return nbPersonne;
        }
    }
}

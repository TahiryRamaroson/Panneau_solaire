using Npgsql;

namespace Coupure.Models
{
    public class Source
    {
        public int idSource { get; set; }
        public double capacitePanneau { get; set; }
        public double capaciteBatterie { get; set; }
        public double coupureBatterie { get; set; }

        public Source() { }
        public Source(int idSource, double capacitePanneau, double capaciteBatterie, double coupureBatterie)
        {
            this.idSource = idSource;
            this.capacitePanneau = capacitePanneau;
            this.capaciteBatterie = capaciteBatterie;
            this.coupureBatterie = coupureBatterie;
        }

        public static Source getById(NpgsqlConnection connect, int idSource)
        {
            Boolean iscreated = false;
            Source src = new Source();
            try
            {
                if (connect == null)
                {
                    connect = Connexion.getConnection();
                    iscreated = true;
                }
                String script = "select * from Source where idSource=" + idSource;
                Console.WriteLine(script);
                NpgsqlCommand sql = new NpgsqlCommand(script, connect);
                NpgsqlDataReader reader = sql.ExecuteReader();
                while (reader.Read())
                {
                    src = new Source(reader.GetInt32(0), reader.GetDouble(1), reader.GetDouble(2), reader.GetDouble(3));
                    
                }
                reader.Close();
                return src;
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
            Console.WriteLine("Vide ilay maka somme Source");
            return src;
        }

        public static double getConsoOneDay(NpgsqlConnection connect, int idSource, DateOnly date)
        {
            Boolean iscreated = false;
            double conso = 0;
            try
            {
                if (connect == null)
                {
                    connect = Connexion.getConnection();
                    iscreated = true;
                }

                double rep = 0;

                double min = 0;
                double max = 500;
                double nbrAItere = 0;

                while (true)
                {

                    nbrAItere = (min + max) / 2;

                    TimeOnly reel = CoupureClass.getHeureCoupure(connect, date);
                    TimeOnly? calcul = CoupureClass.getCoupureByConso(connect, nbrAItere, date, idSource);

                    if (calcul == null)
                    {
                        //Console.WriteLine("----------");
                        //Console.WriteLine("Result Prediction " + resultsPrediction);
                        min = nbrAItere;
                        //Console.WriteLine("min " + min);
                        //Console.WriteLine("max " + max);
                        //Console.WriteLine("----------");

                    }
                    else
                    {
                        //Console.WriteLine("----------");
                        //Console.WriteLine("Result Prediction " + resultsPrediction);
                        if (calcul.Value.Hour == reel.Hour && calcul.Value.Minute == reel.Minute)
                        {
                            rep = nbrAItere;
                            return rep;
                        }
                        else if (calcul > reel)
                        {
                            min = nbrAItere;
                            //Console.WriteLine("min " + min);
                            //Console.WriteLine("max " + max);
                            //Console.WriteLine("----------");
                        }
                        else
                        {
                            max = nbrAItere;
                            //Console.WriteLine("min " + min);
                            //Console.WriteLine("max " + max);
                            //Console.WriteLine("----------");
                        }
                    }
                }



                return rep;
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
            return conso;
        }

        public static double getConsoMoyenneBySource(NpgsqlConnection connect, int idSource, DateOnly date)
        {
            Boolean iscreated = false;
            double conso = 0;
            try
            {
                if (connect == null)
                {
                    connect = Connexion.getConnection();
                    iscreated = true;
                }

                List<double> rep = new List<double>();
                List<CoupureClass> allcoupure = CoupureClass.getByIdSource(connect, idSource, date);

                foreach (CoupureClass item in allcoupure)
                {
                    double consommation = Source.getConsoOneDay(connect, idSource ,DateOnly.FromDateTime(item.heureCoupure));
                    rep.Add(consommation);
                }

                conso = rep.Average();

                return conso;
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
            return conso;
        }

        public static List<Source> getAll(NpgsqlConnection connect)
        {
            Boolean iscreated = false;
            List<Source> all = new List<Source>();
            try
            {
                if (connect == null)
                {
                    connect = Connexion.getConnection();
                    iscreated = true;
                }
                String script = "select * from Source";
                NpgsqlCommand sql = new NpgsqlCommand(script, connect);
                NpgsqlDataReader reader = sql.ExecuteReader();
                while (reader.Read())
                {
                    Source src = new Source(reader.GetInt32(0), reader.GetDouble(1), reader.GetDouble(2), reader.GetDouble(3));
                    all.Add(src);
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
            return all;
        }
    }
}

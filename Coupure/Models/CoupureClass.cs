using Npgsql;

namespace Coupure.Models
{
    public class CoupureClass
    {
        public int idCoupure {  get; set; }
        public int idSource { get; set; }
        public DateTime heureCoupure { get; set; }

        public CoupureClass() { }
        public CoupureClass(int idCoupure, int idSource, DateTime heureCoupure)
        {
            this.idCoupure = idCoupure;
            this.idSource = idSource;
            this.heureCoupure = heureCoupure;
        }

        public static TimeOnly? getCoupureByConso(NpgsqlConnection connect ,double consommation, DateOnly date, int idSource)
        {
            int etudiantMatin = Pointage.getPointage(connect, date, 0, idSource);
            int etudiantAp = Pointage.getPointage(connect, date, 10, idSource);

            //if (Journee.checkExistence(connect, date) == false) Console.WriteLine("tsisy any anaty journee io date io");

            int idjournee = Journee.getId(connect, date);
            List<DetailsJournee> detailsjournee = DetailsJournee.getByIdJournee(connect, idjournee);
            Source infosource = Source.getById(connect, idSource);


            double puissanceMatin = etudiantMatin * consommation;
            double puissanceAp = etudiantAp * consommation;
            double batterieinitial = infosource.capaciteBatterie;
            double finbatterie = (infosource.capaciteBatterie * infosource.coupureBatterie) / 100;

            foreach (DetailsJournee item in detailsjournee)
            {
                if(item.heure <= TimeOnly.Parse("12:00"))
                {
                    double panneau = (infosource.capacitePanneau * item.luminosite) / 10;
                    if(panneau - puissanceMatin < 0)
                    {
                        double tsylanypanneau = puissanceMatin - panneau;
                        double batterieavconso = batterieinitial;
                        batterieinitial -= (puissanceMatin - panneau);
                        if(batterieinitial <= finbatterie)
                        {
                            double depense = tsylanypanneau;
                            double restedepense = batterieavconso - finbatterie;
                            double reste = (restedepense / depense) * 60;
                            TimeOnly valiny = item.heure.AddMinutes(reste);
                            return valiny;
                        }
                    }
                    else
                    {
                        batterieinitial += (panneau - puissanceMatin);
                        if(batterieinitial > infosource.capaciteBatterie) batterieinitial = infosource.capaciteBatterie;
                    }
                }
            }

            foreach (DetailsJournee item in detailsjournee)
            {
                if (item.heure > TimeOnly.Parse("12:00"))
                {
                    double panneau = (infosource.capacitePanneau * item.luminosite) / 10;
                    if (panneau - puissanceAp < 0)
                    {
                        double tsylanypanneau = puissanceAp - panneau;
                        double batterieavconso = batterieinitial;
                        batterieinitial -= (puissanceAp - panneau);
                        if (batterieinitial <= finbatterie)
                        {
                            double depense = tsylanypanneau;
                            double restedepense = batterieavconso - finbatterie;
                            double reste = (restedepense / depense) * 60;
                            TimeOnly valiny = item.heure.AddMinutes(reste);
                            return valiny;
                        }
                    }
                    else
                    {
                        batterieinitial += (panneau - puissanceAp);
                        if (batterieinitial > infosource.capaciteBatterie) batterieinitial = infosource.capaciteBatterie;
                    }
                }
            }

            return null;
        }

        public static TimeOnly getHeureCoupure(NpgsqlConnection connect, DateOnly date)
        {
            Boolean iscreated = false;
            TimeOnly coupure = new TimeOnly();
            try
            {
                if (connect == null)
                {
                    connect = Connexion.getConnection();
                    iscreated = true;
                }
                String script = "select heurecoupure from Coupure where date(heurecoupure)='" + date + "'";
                Console.WriteLine(script);
                NpgsqlCommand sql = new NpgsqlCommand(script, connect);
                NpgsqlDataReader reader = sql.ExecuteReader();
                while (reader.Read())
                {
                    coupure = TimeOnly.FromDateTime(reader.GetDateTime(0));

                }
                reader.Close();
                return coupure;
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
            Console.WriteLine("Vide ilay maka heure coupure");
            return coupure;
        }

        public static List<CoupureClass> getByIdSource(NpgsqlConnection connect, int idsrc, DateOnly date)
        {
            Boolean iscreated = false;
            List<CoupureClass> all = new List<CoupureClass>();
            try
            {
                if (connect == null)
                {
                    connect = Connexion.getConnection();
                    iscreated = true;
                }
                String script = "select * from Coupure where idSource=" + idsrc + " and heureCoupure < '" + date + "'";
                NpgsqlCommand sql = new NpgsqlCommand(script, connect);
                NpgsqlDataReader reader = sql.ExecuteReader();
                while (reader.Read())
                {
                    CoupureClass cpr = new CoupureClass(reader.GetInt32(0), reader.GetInt32(1), reader.GetDateTime(2));
                    all.Add(cpr);
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

        public static Prediction predict(NpgsqlConnection connect, DateOnly date, int idSource)
        {
            Prediction valiny = new Prediction();

            int etudiantMatin = Pointage.getPointageMoyenne(connect, 0, date, idSource);
            int etudiantAp = Pointage.getPointageMoyenne(connect, 10, date, idSource);

            valiny.nbMatinMoyenne = etudiantMatin;
            valiny.nbApMoyenne = etudiantAp;
            valiny.idSource = idSource;
            valiny.datePrediction = date;

            //if (Journee.checkExistence(connect, date) == false) Console.WriteLine("tsisy any anaty journee io date io");

            int idjournee = Journee.getId(connect, date);
            List<DetailsJournee> detailsjournee = DetailsJournee.getByIdJournee(connect, idjournee);
            Source infosource = Source.getById(connect, idSource);

            double consommation = Source.getConsoMoyenneBySource(connect, idSource, date);
            double puissanceMatin = etudiantMatin * consommation;
            double puissanceAp = etudiantAp * consommation;

            valiny.consoMoyenne = consommation;
            valiny.puissanceMatin = puissanceMatin;
            valiny.puissanceAp = puissanceAp;
            
            double batterieinitial = infosource.capaciteBatterie;
            double finbatterie = (infosource.capaciteBatterie * infosource.coupureBatterie) / 100;

            List<DetailsPrediction> dtprediction = new List<DetailsPrediction> ();
            valiny.detailsPredictions = dtprediction;

            foreach (DetailsJournee item in detailsjournee)
            {
                if (item.heure <= TimeOnly.Parse("12:00"))
                {
                    double panneau = (infosource.capacitePanneau * item.luminosite) / 10;
                    dtprediction.Add(new DetailsPrediction(item.heure.ToString(), panneau, batterieinitial));
                    if (panneau - puissanceMatin < 0)
                    {
                        double tsylanypanneau = puissanceMatin - panneau;
                        double batterieavconso = batterieinitial;
                        batterieinitial -= (puissanceMatin - panneau);
                        if (batterieinitial <= finbatterie)
                        {
                            double depense = tsylanypanneau;
                            double restedepense = batterieavconso - finbatterie;
                            double reste = (restedepense / depense) * 60;
                            TimeOnly cpr = item.heure.AddMinutes(reste);
                            if (cpr.ToString() == "") valiny.heureCoupure = "Aucune coupure";
                            else valiny.heureCoupure = cpr.ToString();
                            return valiny;
                        }
                    }
                    else
                    {
                        batterieinitial += (panneau - puissanceMatin);
                        if (batterieinitial > infosource.capaciteBatterie) batterieinitial = infosource.capaciteBatterie;
                    }
                    
                } else
                {
                    double panneau = (infosource.capacitePanneau * item.luminosite) / 10;
                    dtprediction.Add(new DetailsPrediction(item.heure.ToString(), panneau, batterieinitial));
                    if (panneau - puissanceAp < 0)
                    {
                        double tsylanypanneau = puissanceAp - panneau;
                        double batterieavconso = batterieinitial;
                        batterieinitial -= (puissanceAp - panneau);
                        if (batterieinitial <= finbatterie)
                        {
                            double depense = tsylanypanneau;
                            double restedepense = batterieavconso - finbatterie;
                            double reste = (restedepense / depense) * 60;
                            TimeOnly cpr = item.heure.AddMinutes(reste);
                            if (cpr.ToString() == "") valiny.heureCoupure = "Aucune coupure";
                            else valiny.heureCoupure = cpr.ToString();
                            return valiny;
                        }
                    }
                    else
                    {
                        batterieinitial += (panneau - puissanceAp);
                        if (batterieinitial > infosource.capaciteBatterie) batterieinitial = infosource.capaciteBatterie;
                    }
                    
                }
            }

            return valiny;
        }
    }
}

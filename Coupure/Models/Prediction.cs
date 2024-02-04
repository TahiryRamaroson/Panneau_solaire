namespace Coupure.Models
{
    public class Prediction
    {
        public int idSource { get; set; }
        public double consoMoyenne { get; set; }
        public int nbMatinMoyenne {  get; set; }
        public int nbApMoyenne { get; set; }
        public DateOnly datePrediction { get; set; }
        public String heureCoupure { get; set; }
        public double puissanceMatin {  get; set; }
        public double puissanceAp {  get; set; }
        public List<DetailsPrediction> detailsPredictions { get; set; }

        public Prediction() { }

        public Prediction(int idSource, double consoMoyenne, int nbMatinMoyenne, int nbApMoyenne, DateOnly datePrediction, String heureCoupure, double puissanceMatin, double puissanceAp, List<DetailsPrediction> detailsPredictions)
        {
            this.idSource = idSource;
            this.consoMoyenne = consoMoyenne;
            this.nbMatinMoyenne = nbMatinMoyenne;
            this.nbApMoyenne = nbApMoyenne;
            this.datePrediction = datePrediction;
            this.heureCoupure = heureCoupure;
            this.puissanceMatin = puissanceMatin;
            this.puissanceAp = puissanceAp;
            this.detailsPredictions = detailsPredictions;
        }
    }
}

namespace Coupure.Models
{
    public class DetailsPrediction
    {
        public String heure {  get; set; }
        public double puissancePanneau {  get; set; }
        public double capaciteBatterie { get; set; }

        public DetailsPrediction() { }
        public DetailsPrediction(string heure, double puissancePanneau, double capaciteBatterie)
        {
            this.heure = heure;
            this.puissancePanneau = puissancePanneau;
            this.capaciteBatterie = capaciteBatterie;
        }
    }
}

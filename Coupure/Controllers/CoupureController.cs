using Coupure.Models;
using Microsoft.AspNetCore.Mvc;
using Npgsql;

namespace Coupure.Controllers
{
    public class CoupureController : Controller
    {
        public IActionResult Index()
        {
            NpgsqlConnection conn = Connexion.getConnection();

            List<Source> sources = Source.getAll(conn);
            ViewBag.Sources = sources;

            conn.Close();
            return View();
        }

        public IActionResult Resultat(int idSource, DateOnly datePrediction)
        {
            NpgsqlConnection conn = Connexion.getConnection();

            Prediction prediction = CoupureClass.predict(conn, datePrediction, idSource);
            ViewBag.Prediction = prediction;

            conn.Close();
            return View();
        }
    }
}

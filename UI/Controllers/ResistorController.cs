using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using UI.Models;
using ResistorEngine;

namespace UI.Controllers
{
    public class ResistorController : Controller
    {
        // GET: Resistor
        public ActionResult Index()
        {
            var calculator = new OhmValueCalculator(new BandA(), new BandB(), new Multiplier(), new Tolerance());

            var model = new Resistor
            {
                BandAColor = BandColor.Black,
                BandBColor = BandColor.Black,
                BandCColor = BandColor.Black,
                BandDColor = BandColor.Silver,
                Value =
                    calculator.CalculateOhmValue(BandColor.Black.ToString(), BandColor.Black.ToString(),
                        BandColor.Black.ToString(), BandColor.Silver.ToString())
            };

            ViewData["BandAB"] = GetDigitBandList();
            ViewData["BandC"] = GetMultiplierBandList();
            ViewData["BandD"] = GetToleranceBandList();

            return View(model);
        }

        [HttpPost]
        public ActionResult Index(Resistor model)
        {
            if (model == null)
            {
                return RedirectToAction("Index"); // Redirect to the GET method
            }

            var calculator = new OhmValueCalculator(new BandA(), new BandB(), new Multiplier(), new Tolerance());
            model.Value = calculator.CalculateOhmValue(model.BandAColor.ToString(), model.BandBColor.ToString(),
                model.BandCColor.ToString(), model.BandDColor.ToString());

            ViewData["BandAB"] = GetDigitBandList();
            ViewData["BandC"] = GetMultiplierBandList();
            ViewData["BandD"] = GetToleranceBandList();

            return View(model);
        }

        private IEnumerable<SelectListItem> GetMultiplierBandList()
        {
            var list = new Dictionary<int, string>
            {
                {(int) BandColor.Black, BandColor.Black.ToString()},
                {(int) BandColor.Brown, BandColor.Brown.ToString()},
                {(int) BandColor.Red, BandColor.Red.ToString()},
                {(int) BandColor.Orange, BandColor.Orange.ToString()},
                {(int) BandColor.Yellow, BandColor.Yellow.ToString()},
                {(int) BandColor.Green, BandColor.Green.ToString()},
                {(int) BandColor.Blue, BandColor.Blue.ToString()},
                {(int) BandColor.Violet, BandColor.Violet.ToString()},
                {(int) BandColor.Gray, BandColor.Gray.ToString()},
                {(int) BandColor.White, BandColor.White.ToString()},
                {(int) BandColor.Gold, BandColor.Gold.ToString()},
                {(int) BandColor.Silver, BandColor.Silver.ToString()},
                {(int) BandColor.None, BandColor.None.ToString()}
            };

            return list
                .OrderBy(l => l.Key)
                .Select(x => new SelectListItem {Text = x.Value, Value = x.Key.ToString()})
                .ToList();
        }

        private IEnumerable<SelectListItem> GetDigitBandList()
        {
            var list = new Dictionary<int, string>
            {
                {(int) BandColor.Black, BandColor.Black.ToString()},
                {(int) BandColor.Brown, BandColor.Brown.ToString()},
                {(int) BandColor.Red, BandColor.Red.ToString()},
                {(int) BandColor.Orange, BandColor.Orange.ToString()},
                {(int) BandColor.Yellow, BandColor.Yellow.ToString()},
                {(int) BandColor.Green, BandColor.Green.ToString()},
                {(int) BandColor.Blue, BandColor.Blue.ToString()},
                {(int) BandColor.Violet, BandColor.Violet.ToString()},
                {(int) BandColor.Gray, BandColor.Gray.ToString()},
                {(int) BandColor.White, BandColor.White.ToString()},
                {(int) BandColor.None, BandColor.None.ToString()}
            };

            return list
                .OrderBy(l => l.Key)
                .Select(x => new SelectListItem {Text = x.Value, Value = x.Key.ToString()})
                .ToList();
        }

        private IEnumerable<SelectListItem> GetToleranceBandList()
        {
            var tolerance = new Dictionary<int, string>
            {
                {(int) BandColor.Brown, "Brown 1%"},
                {(int) BandColor.Red, "Red 2%"},
                {(int) BandColor.Yellow, "Yellow (5%)"},
                {(int) BandColor.Green, "Green 0.5%"},
                {(int) BandColor.Blue, "Blue 0.25%"},
                {(int) BandColor.Violet, "Violet 0.1%"},
                {(int) BandColor.Gray, "Gray 0.05% (10%)"},
                {(int) BandColor.Gold, "Gold 5%"},
                {(int) BandColor.Silver, "Silver 10%"},
                {(int) BandColor.None, "None 20%"}
            };

            return tolerance
                .OrderBy(l => l.Key)
                .Select(x => new SelectListItem {Text = x.Value, Value = x.Key.ToString()})
                .ToList();
        }
    }
}
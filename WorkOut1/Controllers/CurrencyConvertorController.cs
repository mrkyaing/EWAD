using Microsoft.AspNetCore.Mvc;

namespace WorkOut1.Controllers {
    public class CurrencyConvertorController : Controller {
        public IActionResult Convertor() {
            return View();
        }
        [HttpPost]
        public IActionResult Convertor(string fromCurrency,decimal amount) {
            decimal result = 0;
            switch (fromCurrency) {
                case "USD": result = amount * 3000.25M; break;
                case "SDG": result = amount * 2100.3M; break;
                case "YAN": result = amount * 20.5M; break;
            }
            ViewBag.Amount = amount;
            ViewBag.SelectedCurrency = fromCurrency;
            ViewBag.Result = result;
            return View();
        }
        private decimal ConvertCurrencyExchangeFromTo(string fromCurrency, string toCurrency, decimal amount) {
            decimal result = 0;
            switch (fromCurrency) {
                case "USD":
                    if (toCurrency.Equals("USD")) {
                        result = amount;
                    }
                   else if (toCurrency.Equals("SDG")) {
                        result = amount * 1.35M;
                    }
                   else if (toCurrency.Equals("MMK")) {
                        result = amount * 3100.37M;
                    }; break;
                case "SDG":
                    if (toCurrency.Equals("SDG")) {
                        result = amount;
                    }
                    else if (toCurrency.Equals("USD")) {
                        result = amount /1.35M;
                    }
                    else if (toCurrency.Equals("MMK")) {
                        result = amount / 2500.37M;
                    }; break;
                case "MMK":
                    if (toCurrency.Equals("USD")) {
                        result = amount/3100.37M;
                    }
                    else if (toCurrency.Equals("SDG")) {
                        result = amount / 2500.37M;
                    }
                    else if (toCurrency.Equals("MMK")) {
                        result = amount;
                    }; break;
            }
            return result;
        }

        public IActionResult FromToConvertor() {
            return View();
        }
        [HttpPost]
        public IActionResult FromToConvertor(string fromCurrency,string toCurrency, decimal amount) {
            decimal result = 0;
            result = this.ConvertCurrencyExchangeFromTo(fromCurrency, toCurrency, amount);
            ViewBag.Amount = amount;
            ViewBag.FromCurrency = fromCurrency;
            ViewBag.ToCurrency = toCurrency;
            ViewBag.Result = result;
            return View();
        }
    }
}

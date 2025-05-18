using MVC_Calculator1.Models;
using System.Web.Mvc;

namespace MVC_Calculator1.Controllers
{
    public class CalculatorController : Controller
    {
        // GET: Calculator
        public ActionResult Index()
        {
            return View(new CalculatorModel());
        }

        // POST: Calculator
        [HttpPost]
        public ActionResult Index(CalculatorModel model, string submitButton)
        {
            if (submitButton == "calculate")
            {
                if (ModelState.IsValid)
                {
                    switch (model.Operation)
                    {
                        case "Add":
                            model.Result = model.Operand1 + model.Operand2;
                            break;
                        case "Subtract":
                            model.Result = model.Operand1 - model.Operand2;
                            break;
                        case "Multiply":
                            model.Result = model.Operand1 * model.Operand2;
                            break;
                        case "Divide":
                            if (model.Operand2 != 0)
                                model.Result = model.Operand1 / model.Operand2;
                            else
                                ModelState.AddModelError("", "Нельзя делить на ноль");
                            break;
                        default:
                            ModelState.AddModelError("", "Выберите операцию");
                            break;
                    }

                    ViewBag.CheckValue = 100f;
                }
            }
            else if (submitButton == "clear")
            {
                ModelState.Clear();
                model = new CalculatorModel();
            }

            return View(model);
        }
        public ActionResult Result(string operand1, string operand2, string operation, string result)
        {
            string opWord = "";

            if (operation == "Add") opWord = "плюс";
            else if (operation == "Subtract") opWord = "минус";
            else if (operation == "Multiply") opWord = "умножить на";
            else if (operation == "Divide") opWord = "делить на";

            ViewBag.OperationWord = opWord;
            ViewBag.Operand1 = operand1;
            ViewBag.Operand2 = operand2;
            ViewBag.Result = result;

            return View();
        }

    }
}

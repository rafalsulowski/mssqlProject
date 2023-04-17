using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using mssqlProject.Models;

namespace mssqlProject.Web.Controllers
{
    public class BudgetController : Controller
    {
        private static readonly HttpClient _HttpClient = new HttpClient();

        [HttpGet]
        public IActionResult ShowGrid(string SortOrder, string CurrentSort)
        {
            var response = _HttpClient.GetAsync("https://localhost:44304/api/Budget").Result;
            if(response.IsSuccessStatusCode)
            {

                SortOrder = String.IsNullOrEmpty(SortOrder) ? "Id" : SortOrder;
                ViewBag.CurrentSort = SortOrder;
                var budgets = response.Content.ReadFromJsonAsync<List<Budget>>().Result;

                if (budgets == null)
                    return View();

                switch (SortOrder)
                {
                    case "Id":
                        if (SortOrder.Equals(CurrentSort))
                        {
                            ViewBag.CurrentSort = "";
                            budgets = budgets.OrderByDescending(m => m.Id).ToList();
                        }
                        else
                            budgets = budgets.OrderBy(m => m.Id).ToList();
                        break;
                    case "TripId":
                        if (SortOrder.Equals(CurrentSort))
                        {
                            ViewBag.CurrentSort = "";
                            budgets = budgets.OrderByDescending(m => m.TripId).ToList();
                        }
                        else
                            budgets = budgets.OrderBy(m => m.TripId).ToList();
                        break;
                    case "BankAccunt":
                        if (SortOrder.Equals(CurrentSort))
                        {
                            ViewBag.CurrentSort = "";
                            budgets = budgets.OrderByDescending(m => m.BankAccunt).ToList();
                        }
                        else
                            budgets = budgets.OrderBy(m => m.BankAccunt).ToList();
                        break;
                    case "ShareHoldersCount":
                        if (SortOrder.Equals(CurrentSort))
                        {
                            ViewBag.CurrentSort = "";
                            budgets = budgets.OrderByDescending(m => m.ShareHoldersCount).ToList();
                        }
                        else
                            budgets = budgets.OrderBy(m => m.ShareHoldersCount).ToList();
                        break;
                    case "BudgetSize":
                        if (SortOrder.Equals(CurrentSort))
                        {
                            ViewBag.CurrentSort = "";
                            budgets = budgets.OrderByDescending(m => m.BudgetSize).ToList();
                        }
                        else
                            budgets = budgets.OrderBy(m => m.BudgetSize).ToList();
                        break;
                    default:
                        budgets = budgets.OrderBy(m => m.Id).ToList();
                        break;
                }

                return View(budgets);
            }
            else
            {
                return View();
            }
        }



        [HttpPost]
        public IActionResult FilterShowGrid(int minSH, int maSH, double inBS, double maxBS)
        {
            return View("ShowGrid");
        }

    }
}

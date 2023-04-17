using Microsoft.AspNetCore.Mvc;
using mssqlProject.Models;

namespace mssqlProject.Web.Controllers
{
    public class BudgetController : Controller
    {
        private static readonly HttpClient _HttpClient = new HttpClient();

        public IActionResult ShowGrid(string SortOrder, string CurrentSort, int doFilter, int minSH, int maxSH, double minBS, double maxBS, int doFilterForTmp)
        {
            //var response = _HttpClient.GetAsync("https://localhost:44304/api/Budget").Result;
            //if (response.IsSuccessStatusCode)
            //{
            //    List<Budget> budgets = response.Content.ReadFromJsonAsync<List<Budget>>().Result;

            //    //uzytkownik kliknac "Filtruj"
            //    if(doFilter == 1 || (TempData["DoFilter"] != null && TempData["DoFilter"].ToString() == "1"))
            //    {
            //        TempData["DoFilter"] = doFilterForTmp; //zapis ostatnich parametrow filtowania
            //        TempData["minSH"] = minSH;
            //        TempData["maxSH"] = maxSH;
            //        TempData["minBS"] = minBS;
            //        TempData["maxBS"] = maxBS;

            //        List<Budget> tmpbud = new List<Budget>(); //filtowanie
            //        foreach (Budget budget in budgets)
            //        {
            //            var el = TempData["minSH"].ToString();
            //            if (budget.ShareHoldersCount > int.Parse(TempData["minSH"].ToString()) && budget.ShareHoldersCount < int.Parse(TempData["maxSH"].ToString())
            //                && budget.BudgetSize > int.Parse(TempData["minBS"].ToString()) && budget.BudgetSize < int.Parse(TempData["maxBS"].ToString()))
            //                tmpbud.Add(budget);
            //        }
            //        budgets = tmpbud;
            //    }

            //    //zerowanie filtrow
            //    if(doFilter == -1)
            //    {
            //        TempData["DoFilter"] = 0;
            //    }

            //    //sortowanie
            //    SortOrder = String.IsNullOrEmpty(SortOrder) ? "Id" : SortOrder;
            //    ViewBag.CurrentSort = SortOrder;
            //    ViewBag.SortOrder = SortOrder;
            //    switch (SortOrder)
            //    {
            //        case "Id":
            //            if (SortOrder.Equals(CurrentSort))
            //            {
            //                ViewBag.CurrentSort = "";
            //                //ViewBag.SortOrder = "Id";
            //                budgets = budgets.OrderByDescending(m => m.Id).ToList();
            //            }
            //            else
            //            {
            //                budgets = budgets.OrderBy(m => m.Id).ToList();
            //                //ViewBag.SortOrder = "Id";
            //            }
            //            break;
            //        case "TripId":
            //            if (SortOrder.Equals(CurrentSort))
            //            {
            //                ViewBag.CurrentSort = "";
            //                ViewBag.SortOrder = "TripId";
            //                budgets = budgets.OrderByDescending(m => m.TripId).ToList();
            //            }
            //            else
            //            {
            //                budgets = budgets.OrderBy(m => m.TripId).ToList();
            //                ViewBag.SortOrder = "TripId";
            //            }
            //            break;
            //        case "BankAccunt":
            //            if (SortOrder.Equals(CurrentSort))
            //            {
            //                ViewBag.CurrentSort = "";
            //                ViewBag.SortOrder = "BankAccunt";
            //                budgets = budgets.OrderByDescending(m => m.BankAccunt).ToList();
            //            }
            //            else
            //            {
            //                budgets = budgets.OrderBy(m => m.BankAccunt).ToList();
            //                ViewBag.SortOrder = "BankAccunt";
            //            }
            //            break;
            //        case "ShareHoldersCount":
            //            if (SortOrder.Equals(CurrentSort))
            //            {
            //                ViewBag.CurrentSort = "";
            //                ViewBag.SortOrder = "ShareHoldersCount";
            //                budgets = budgets.OrderByDescending(m => m.ShareHoldersCount).ToList();
            //            }
            //            else
            //            {
            //                budgets = budgets.OrderBy(m => m.ShareHoldersCount).ToList();
            //                ViewBag.SortOrder = "ShareHoldersCount";
            //            }
            //            break;
            //        case "BudgetSize":
            //            if (SortOrder.Equals(CurrentSort))
            //            {
            //                ViewBag.CurrentSort = "";
            //                ViewBag.SortOrder = "BudgetSize";
            //                budgets = budgets.OrderByDescending(m => m.BudgetSize).ToList();
            //            }
            //            else
            //            {
            //                budgets = budgets.OrderBy(m => m.BudgetSize).ToList();
            //                ViewBag.SortOrder = "BudgetSize";
            //            }
            //            break;
            //        default:
            //            budgets = budgets.OrderBy(m => m.Id).ToList();
            //            ViewBag.SortOrder = "Id";
            //            break;
            //    }

            //    return View(budgets);
            //}
            //else
            //{
            //    return View();
            //}

               return View();
        }
    }
}

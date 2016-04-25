using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WorkWithAzureTable.Interfaces.Interfaces;

namespace WorkWithAzureTable.Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly IAzureTableService azureTableService;

        public HomeController(IAzureTableService azureTableService)
        {
            this.azureTableService = azureTableService;
        }


        public ActionResult Index()
        {
            return View();
        }

        public ActionResult GetTables()
        {
            var tables = azureTableService.GetTableList();
            return View(tables);
        }


    }
}
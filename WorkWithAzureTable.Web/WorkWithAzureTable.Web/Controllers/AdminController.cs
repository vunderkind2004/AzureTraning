using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WorkWithAzureTable.Interfaces.Interfaces;
using WorkWithAzureTable.Interfaces.Models;
using WorkWithAzureTable.Web.Enums;

namespace WorkWithAzureTable.Web.Controllers
{
    public class AdminController : Controller
    {
        private readonly IAzureTableService azureTableService;

        public AdminController(IAzureTableService azureTableService)
        {
            this.azureTableService = azureTableService;
        }


        public ActionResult Index()
        {
            return RedirectToAction("GetTables", "Admin");
        }

        public ActionResult GetTables()
        {
            var tables = azureTableService.GetTableList();
            return View(tables);
        }

        public ActionResult Initialize()
        {
            DeleteTables();

            var message = CreateTables();

            Response.Write(message);
            return Content(null);
        }

        private void DeleteTables()
        {
            var tables = GetMyTables();
            foreach (var tableName in tables)
            {
                azureTableService.DeleteTable(tableName);
            }
        }

        private string CreateTables()
        {
            var existingTables = azureTableService.GetTableList();

            var tables = GetMyTables();
            var message = "<h3>Start creation of tables </h3>";

            foreach (var tableName in tables)
            {
                if (!existingTables.Contains(tableName))
                {
                    azureTableService.CreateTable(tableName);
                    FillTable((TableType)Enum.Parse(typeof(TableType), tableName));
                }
                message += string.Format("Table '{0}' was created<br/>", tableName);
            }

            message += "Creation of tables finished.";

            return message;            
        }

        private string[] GetMyTables()
        {
            var tables = new string[] { TableType.Department.ToString(), TableType.Employe.ToString() };
            return tables;
        }

        private void FillTable(TableType tableType)
        {
            switch (tableType)
            {
                case TableType.Department:
                    azureTableService.Insert(tableType.ToString(), new Department { PartitionKey = "", RowKey = "Department1", Name = "Department 1" });
                    break;
                case TableType.Employe:
                    azureTableService.Insert(tableType.ToString(), new Employe { PartitionKey =  "Department 1" , RowKey = "Brus Li" , FirstName = "Li" , LastName="Brus" });
                    break;
                default:
                    break;
            }
        }

    }
}
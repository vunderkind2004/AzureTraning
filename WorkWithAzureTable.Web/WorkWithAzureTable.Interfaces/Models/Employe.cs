using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.WindowsAzure.Storage.Table;

namespace WorkWithAzureTable.Interfaces.Models
{
    public class Employe : TableEntity
    {
        public Employe()
        {
            RegistrationDate = DateTime.Now;
        }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime RegistrationDate { get; private set; }
        public IDepartment Department { get; set; }
        public string Position { get; set; }
        public decimal Salary { get; set; }

    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WorkWithAzureTable.Interfaces.Models
{
    public interface IEmploye
    {
        string FirstName { get; set; }
        string LastName { get; set; }
        DateTime RegistrationDate { get; }
        IDepartment Department { get; set; }
        string Position { get; set; }
        decimal Salary { get; set; }
    }
}

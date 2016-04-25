using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.WindowsAzure.Storage.Table;

namespace WorkWithAzureTable.Interfaces.Models
{
    public class Department : TableEntity
    {
        public string Name { get; set; }
    }
}

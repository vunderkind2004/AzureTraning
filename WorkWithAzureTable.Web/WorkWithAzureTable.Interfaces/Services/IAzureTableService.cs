using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Microsoft.WindowsAzure.Storage.Table;
using WorkWithAzureTable.Interfaces.Models;

namespace WorkWithAzureTable.Interfaces.Interfaces
{
    public interface IAzureTableService
    {        
        void CreateTable(string tableName);
        void DeleteTable(string tableName);
        IEnumerable<string> GetTableList();

        T SelectOne<T>(string tableName, string partitionKey, string rowKey) where T : TableEntity, new();
        IEnumerable<T> Select<T>(string tableName, string partitionKey) where T : TableEntity, new();
        void Insert<T>(string tableName, T item) where T : TableEntity, new();
        void Update<T>(string tableName, T item) where T : TableEntity, new();
    }
}

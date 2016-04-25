using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WorkWithAzureTable.Interfaces.Interfaces;
using Microsoft.WindowsAzure.Storage; // Namespace for CloudStorageAccount
using Microsoft.WindowsAzure.Storage.Table;
using WorkWithAzureTable.Interfaces.Models;
using Newtonsoft.Json; // Namespace for Table storage types

namespace WorkWithAzureTable.Core.Services
{
    public class AzureTableService : IAzureTableService
    {
        private readonly string storageConnectionString;
        private readonly CloudStorageAccount storageAccount;
        private readonly CloudTableClient tableClient;

        public AzureTableService(string storageConnectionString)
        {
            this.storageConnectionString = storageConnectionString;
            this.storageAccount = CloudStorageAccount.Parse(storageConnectionString);
            this.tableClient = storageAccount.CreateCloudTableClient();
        }

        public void CreateTable(string tableName)
        {
            CloudTable table = tableClient.GetTableReference(tableName);            
            table.CreateIfNotExists();
        }

        public void DeleteTable(string tableName)
        {
            var table = tableClient.GetTableReference(tableName);
            table.DeleteIfExists();
        }

        public IEnumerable<string> GetTableList()
        {
            var tables = tableClient.ListTables();
            return tables.Select(x => x.Name).ToList();
        }

        public T SelectOne<T>(string tableName, string partitionKey, string rowKey) where T : TableEntity, new ()
        {
            var table = tableClient.GetTableReference(tableName);
            var tableOperation = TableOperation.Retrieve(partitionKey, rowKey);
            var retrieveResult = table.Execute(tableOperation);
            var tableEntity =  retrieveResult.Result as T;
            return tableEntity;
        }

        public IEnumerable<T> Select<T>(string tableName, string partitionKey) where T : TableEntity, new()
        {
            var table = tableClient.GetTableReference(tableName);
            var query = new TableQuery<T>().Where(TableQuery.GenerateFilterCondition("PartitionKey", QueryComparisons.Equal, partitionKey));
            var tableEntities = table.ExecuteQuery(query);
            return tableEntities;

        }

        public void Insert<T>(string tableName, T item) where T : TableEntity, new()
        {
            var table = tableClient.GetTableReference(tableName);
            TableOperation insertOperation = TableOperation.Insert(item);
            table.Execute(insertOperation);
        }

        public void Update<T>(string tableName, T item) where T : TableEntity, new()
        {
            throw new NotImplementedException();
        }

        //private ITableEntity ConvertFromCustomEntity<T>(T customEntity) where T: IEntity
        //{
        //    if (customEntity == null)
        //        return null;
        //    string json = JsonConvert.SerializeObject(customEntity);
        //    var tableEntity = JsonConvert.DeserializeObject<TableEntity>(json);
        //    return tableEntity;
        //}

        //private T ConvertToCustomEntity<T>(ITableEntity tableEntity) where T : IEntity
        //{
        //    if (tableEntity == null)
        //        return default(T);
        //    string json = JsonConvert.SerializeObject(tableEntity);
        //    var customEntity = JsonConvert.DeserializeObject<T>(json);
        //    return customEntity;
        //}

        

    }
}

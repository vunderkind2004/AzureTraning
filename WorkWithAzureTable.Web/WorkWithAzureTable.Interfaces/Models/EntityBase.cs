using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WorkWithAzureTable.Interfaces.Models
{
    public class EntityBase : IEntity
    {
        //
        // Summary:
        //     Gets or sets the entity's ETag. Set this value to '*' in order to force an
        //     overwrite to an entity as part of an update operation.
        public string ETag { get; set; }
        //
        // Summary:
        //     Gets or sets the entity's partition key.
        public string PartitionKey { get; set; }
        //
        // Summary:
        //     Gets or sets the entity's row key.
        public string RowKey { get; set; }
        //
        // Summary:
        //     Gets or sets the entity's timestamp.
        public DateTimeOffset Timestamp { get; set; }

       
    }
}

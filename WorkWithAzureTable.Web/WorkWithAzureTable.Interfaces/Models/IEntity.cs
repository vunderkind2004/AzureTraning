using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WorkWithAzureTable.Interfaces.Models
{
    public interface IEntity
    {
        // Summary:
        //     Gets or sets the entity's current ETag. Set this value to '*' in order to
        //     blindly overwrite an entity as part of an update operation.
        string ETag { get; set; }
        //
        // Summary:
        //     Gets or sets the entity's partition key.
        string PartitionKey { get; set; }
        //
        // Summary:
        //     Gets or sets the entity's row key.
        string RowKey { get; set; }
        //
        // Summary:
        //     Gets or sets the entity's timestamp.
        DateTimeOffset Timestamp { get; set; }
    }
}

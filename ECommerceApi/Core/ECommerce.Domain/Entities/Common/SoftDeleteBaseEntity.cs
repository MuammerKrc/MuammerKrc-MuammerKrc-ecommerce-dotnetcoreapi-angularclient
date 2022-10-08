using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.Domain.Entities.Common
{
    public class SoftDeleteBaseEntity<TKey> : BaseEntity<TKey>
    {
        public bool IsDeleted { get; set; } = false;
    }
}

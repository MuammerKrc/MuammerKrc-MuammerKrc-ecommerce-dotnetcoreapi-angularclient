using ECommerce.Domain.Entities.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.Domain.Entities.Common
{
    public class FullAuditBaseEntity<TKey> : BaseEntity<TKey>
    {
        public string? CreatorId { get; set; }
        public AppUser? Creator { get; set; }
        public bool IsDeleted { get; set; } = false;
    }
}

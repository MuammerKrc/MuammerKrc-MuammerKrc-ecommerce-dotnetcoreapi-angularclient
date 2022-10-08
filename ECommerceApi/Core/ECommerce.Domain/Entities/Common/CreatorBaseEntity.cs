﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ECommerce.Domain.Entities.Identity;

namespace ECommerce.Domain.Entities.Common
{
    public class CreatorBaseEntity<Tkey> : BaseEntity<Tkey>
    {
        public string? CreatorId { get; set; }
        public AppUser? Creator { get; set; }
    }
}

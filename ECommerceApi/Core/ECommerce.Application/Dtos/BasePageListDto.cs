using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.Application.Dtos
{
    public class BasePageListDto<TModel>
    {
        public int TotalCount { get; set; }
        public List<TModel> Result { get; set; }
    }
}

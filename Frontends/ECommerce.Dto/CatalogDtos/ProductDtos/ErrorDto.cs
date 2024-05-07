using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.Dto.CatalogDtos.ProductDtos
{
    public class ErrorDto
    {
        public Dictionary<string, string[]> errors { get; set; }
    }

}

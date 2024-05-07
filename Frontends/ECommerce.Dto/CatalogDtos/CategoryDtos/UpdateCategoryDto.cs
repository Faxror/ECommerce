using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.Dto.CatalogDtos.CategoryDtos
{
    public class UpdateCategoryDto
    {
        [JsonProperty("categoryID")]
        public string CategoryID { get; set; }

        [JsonProperty("categoryName")]
        public string CategoryName { get; set; }
        public string CategoryImageUrl { get; set; }
    }
}

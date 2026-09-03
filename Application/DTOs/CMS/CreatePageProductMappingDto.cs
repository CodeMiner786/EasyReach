using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EasyReach_Application.DTOs.CMS
{
    public class CreatePageProductMappingDto
    {
        public Guid ProductId { get; set; }
        public int DisplayOrder { get; set; }
        public string? SectionTitle { get; set; }
    }
}

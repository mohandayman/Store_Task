using BL.Dtos.Property;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL.Dtos.Category
{
    public class CategoryRenderDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string ImgUrl { get; set; }
        public ICollection<PropertyRenderDto> Properties { get; set; } 
    }
}

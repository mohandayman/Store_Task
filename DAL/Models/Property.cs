using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Models
{
    public class Property
    {
        [Key]
        public int Id { get; set; }
        public string Description { get; set; }
        [ForeignKey(nameof(CategoryNavigation))]
        public int Category_Id { get; set; }
        public virtual Category CategoryNavigation{ get; set; }
        public ICollection<DevicePropertyValue> DevicePropertyValues { get; set; } = new HashSet<DevicePropertyValue>();
    }
}

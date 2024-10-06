using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Models
{
    public class DevicePropertyValue
    {
        [ForeignKey(nameof(DeviceNavigation))]
        public int Device_Id { get; set; }
        public virtual Device DeviceNavigation { get; set; }
        [ForeignKey(nameof(PropertyNavigation))]
        public int Property_Id { get; set; }
        public virtual Property PropertyNavigation { get; set; }
        public string Property_Value{ get; set; }
    }
}

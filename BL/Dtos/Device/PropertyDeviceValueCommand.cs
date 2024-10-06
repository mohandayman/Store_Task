using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL.Dtos.Device
{
    public class PropertyDeviceValueCommand
    {
        public int Property_Id { get; set; }
        public string Property_Value { get; set; }
    }
}

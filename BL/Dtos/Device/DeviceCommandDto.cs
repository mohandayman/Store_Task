using BL.Dtos.Category;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL.Dtos.Device
{
    public class DeviceCommandDto
    {
        public string Name { get; set; }
        public DateTime Acquisition_Date { get; set; }

        public int Category_Id { get; set; }
        public ICollection<PropertyDeviceValueCommand>  propertyDeviceValueCommands{ get; set; }
    }
}

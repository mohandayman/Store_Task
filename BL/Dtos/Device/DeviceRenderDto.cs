using BL.Dtos.Category;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL.Dtos.Device
{
    public class DeviceRenderDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime Acquisition_Date { get; set; }

        public CategoryRenderDto Category_Details{ get; set; }
    }
}

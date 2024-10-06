using BL.Dtos.Device;
using BL.Services;
using Microsoft.AspNetCore.Mvc;

namespace Store_PL.Controllers
{
    public class ITDepartmentController : Controller
    {
        private readonly DeviceService deviceService;

        public ITDepartmentController(DeviceService deviceService)
        {
            this.deviceService = deviceService;
        }
        public async Task< IActionResult >Index()
        {
            var Cats = await deviceService.GetAllCategories();
            return View(Cats);
        }
        
        public async Task< IActionResult >Devices( int? CategoryId , string CatImg)
        {
            var devices = await deviceService.GetDevices(CategoryId);
            ViewBag.CatImgUrl = CatImg;
            ViewBag.CategoryId = CategoryId;
            ViewBag.CatName = devices.FirstOrDefault().Category_Details.Name;
            return View(devices);
        }
        
        public async Task< IActionResult >AddDevice( int CategoryId  , string CatName , string CatImg)
        {
            var model = new DeviceCommandDto();
            model.propertyDeviceValueCommands = new List<PropertyDeviceValueCommand>();

            ViewBag.CatName = CatName;
            ViewBag.CatImgUrl = CatImg;
            var device_props = await deviceService.GetDeviceProps(CategoryId);
            ViewBag.device_props = device_props;
            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> AddDevice(DeviceCommandDto device, int CategoryId, string CatName, string CatImg)
        {
            device.Category_Id = CategoryId;
            var result = deviceService.AddDevice(device);
            if (result == "Success")
            {
                return RedirectToAction("Index");
            }
            return View("AddDevice" , new {  CategoryId = CategoryId,  CatName= CatName, CatImg = CatImg });
        }

        public async Task<IActionResult> GetDeviceById(int DeviceId)
        {
           var Device  = await deviceService.GetDeviceById(DeviceId);
            return View(Device);
        }

        public async Task<IActionResult> Edit(int Id  , DeviceRenderDto device)
        {
            var DeviceCommand = new DeviceCommandDto()
            {
                Category_Id = device.Category_Details.Id,
                Acquisition_Date = device.Acquisition_Date,
                Name = device.Name,
                propertyDeviceValueCommands = device.Category_Details.Properties.Select(p => new PropertyDeviceValueCommand()
                {
                    Property_Id = p.Id,
                    Property_Value = p.Value
                }).ToList(),
            };
            var result = await deviceService.Edit(Id, DeviceCommand);
            if(result.IsSuccess)return RedirectToAction("Index");
            return View(device);
        }

    }
}

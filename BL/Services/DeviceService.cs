using BL.Dtos.Category;
using BL.Dtos.Device;
using BL.Dtos.Property;
using DAL.Models;
using DAL.Repositories.Implemetations;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TanvirArjel.Extensions.Microsoft.DependencyInjection;

namespace BL.Services
{
    [ScopedService]
    public class DeviceService
    {
        private readonly StoreDbContext dbContext;
        private readonly DeviceRepo deviceRepo;

        public DeviceService(StoreDbContext dbContext, DeviceRepo deviceRepo)
        {
            this.dbContext = dbContext;
            this.deviceRepo = deviceRepo;
        }

        public async Task<ICollection<DeviceRenderDto>> GetDevices(int? CategoryId)
        {
            ICollection<DeviceRenderDto> DevicesResult;

            var Query = dbContext.devices.Include(x => x.CategoryNavigation).Include(x => x.DevicePropertyValues).ThenInclude(x => x.PropertyNavigation).AsNoTracking();

            if (CategoryId.HasValue) Query =  Query.Where(x => x.Category_Id == CategoryId);

            DevicesResult = await Query.Select(x => new DeviceRenderDto()
            {
                Id = x.Id,
                Name = x.Name,
                Acquisition_Date = x.Acquisition_Date,
                Category_Details = new CategoryRenderDto()
                {
                    Id = x.Category_Id,
                    Name = x.CategoryNavigation.Name,
                    Properties = x.DevicePropertyValues.Select(p => new PropertyRenderDto()
                    {
                        Id = p.Property_Id, 
                        Description = p.PropertyNavigation.Description,
                        Value = p.Property_Value
                    }).ToList()
                }

            }).ToListAsync();

            return DevicesResult;

        }

        public string AddDevice(DeviceCommandDto deviceCommandDto)
        {
            using (var transaction = dbContext.Database.BeginTransaction())
            {

                try
                {
                    var Device = new Device()
                    {
                        Name = deviceCommandDto.Name,
                        Acquisition_Date = deviceCommandDto.Acquisition_Date,
                        Category_Id = deviceCommandDto.Category_Id,
                        DevicePropertyValues = deviceCommandDto.propertyDeviceValueCommands.Select(x =>
                        new DevicePropertyValue()
                        {
                            Property_Id = x.Property_Id,
                            Property_Value = x.Property_Value,
                        }
                        ).ToList()


                    };

                    deviceRepo.Add(Device);
                    transaction.Commit();

                    return "Success";

                } catch (Exception ex)
                {
                    transaction.Rollback();
                    throw ex;
                }


            }
        }

        public async Task<ICollection<PropertyRenderDto>> GetDeviceProps(int Cat_Id)
        {
            var query = dbContext.properties.Where(x=>x.Category_Id == Cat_Id);
            return await query.Select(x=>new PropertyRenderDto()
            {
                Id = x.Id,
                Description = x.Description
            }).ToListAsync();
        }
        
        public async Task<DeviceRenderDto> GetDeviceById(int DeviceId)
        {
            var Element = await dbContext.devices.Include(x => x.CategoryNavigation).Include(x => x.DevicePropertyValues).ThenInclude(x => x.PropertyNavigation).FirstOrDefaultAsync(x=> x.Id == DeviceId);
            return new DeviceRenderDto()
            {
                Id = Element.Id,
                Name = Element.Name,
                Acquisition_Date = Element.Acquisition_Date,
                Category_Details = new CategoryRenderDto()
                {
                    Id = Element.Category_Id,
                    Name = Element.CategoryNavigation.Name,
                    Properties = Element.DevicePropertyValues.Select(p => new PropertyRenderDto()
                    {
                        Id = p.Property_Id,
                        Description = p.PropertyNavigation.Description,
                        Value = p.Property_Value
                    }).ToList()
                }

            };
        
        }

        public async Task<Result> Edit(int Id , DeviceCommandDto deviceCommandDto) {

            using (var transaction = dbContext.Database.BeginTransaction())
            {


                var Device = new Device()
                {
                    Id= Id,
                    Name = deviceCommandDto.Name,
                    Acquisition_Date = deviceCommandDto.Acquisition_Date,
                    Category_Id = deviceCommandDto.Category_Id,
                    DevicePropertyValues = deviceCommandDto.propertyDeviceValueCommands.Select(x =>
                    new DevicePropertyValue()
                    {
                        Property_Id = x.Property_Id,
                        Property_Value = x.Property_Value,
                    }
                    ).ToList()


                };

                var result = await deviceRepo.UpdateDevice( Device);
                if (result.IsSuccess)
                {
                    transaction.Commit();
                }
                else { transaction.Rollback(); }

                return result;
            }
         }

        public async Task<ICollection<CategoryBreifDto>> GetAllCategories()
        {
            var Categories = await dbContext.Categories.ToListAsync();
           var Result =  Categories.Select(x =>
            new CategoryBreifDto()
            {
                Id = x.Id,
                Name = x.Name,
                ImgUrl = x.ImgUrl,
            }).ToList();

            return Result;
        }

    }
}

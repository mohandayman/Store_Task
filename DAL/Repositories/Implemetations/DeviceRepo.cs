using DAL.Models;
using DAL.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using TanvirArjel.Extensions.Microsoft.DependencyInjection;

namespace DAL.Repositories.Implemetations
{
    [ScopedService]
    public class DeviceRepo : EntityRepo<Device>
    {
        private readonly StoreDbContext dbContext;

        public DeviceRepo(StoreDbContext dbContext) : base(dbContext)
        {
            this.dbContext = dbContext;
        }

        public async Task<Result> UpdateDevice(Device entity)
        {
            var existingEntity = await dbContext.devices
                .Include(d => d.DevicePropertyValues) // Include the related collection
                .FirstOrDefaultAsync(d => d.Id == entity.Id);

            if (existingEntity == null)
            {
                throw new InvalidOperationException("Device not found.");
            }

            // Step 1: Update scalar properties (excluding navigation properties)
            dbContext.Entry(existingEntity).CurrentValues.SetValues(entity);

            // Step 2: Handle related entities (DevicePropertyValues)
            UpdateDevicePropertyValues(existingEntity, entity);

            // Save changes
            try
            {
                await dbContext.SaveChangesAsync();
                return Result.Success();
            }
            catch (DbUpdateConcurrencyException)
            {
                return Result.Failure("The entity has been modified by another user.");
            }
            catch (Exception ex)
            {
                // Log exception
                return Result.Failure($"An error occurred while updating the entity: {ex.Message}");
            }
        }

        private void UpdateDevicePropertyValues(Device existingEntity, Device updatedEntity)
        {
            // Get the existing and new property values
            var existingPropertyValues = existingEntity.DevicePropertyValues.ToList();
            var newPropertyValues = updatedEntity.DevicePropertyValues.Select(x=> { x.Device_Id = existingEntity.Id; return x; }).ToList();


            // Step 2a: Add or update existing properties
            foreach (var newProperty in newPropertyValues)
            {
                var existingProperty = existingPropertyValues
                    .FirstOrDefault(p => p.Property_Id == newProperty.Property_Id);

                if (existingProperty == null)
                {
                    // Property does not exist, add it
                    existingEntity.DevicePropertyValues.Add(newProperty);
                }
                else
                {
                    // Property exists, update its values
                    var entry = dbContext.Entry(existingProperty);
                    dbContext.Entry(existingProperty).CurrentValues.SetValues(newProperty);
                    entry.Property(e => e.Property_Id).IsModified = false;
                    entry.Property(e => e.Device_Id).IsModified = false;

                }
            }

            // Step 2b: Remove properties that no longer exist in the new entity
            foreach (var existingProperty in existingPropertyValues)
            {
                if (!newPropertyValues.Any(p => p.Property_Id == existingProperty.Property_Id))
                {
                    // Property no longer exists, remove it
                    dbContext.devicePropertyValues.Remove(existingProperty);
                }
            }
        }

    }
}

using DAL.Models;
using DAL.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TanvirArjel.Extensions.Microsoft.DependencyInjection;

namespace DAL.Repositories.Implemetations
{
    [ScopedService]
    public class DeviceRepo : EntityRepo<Device>
    {
        public DeviceRepo(StoreDbContext dbContext) : base(dbContext)
        {
        }
    }
}

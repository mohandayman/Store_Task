using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Models
{
    public class StoreDbContext : DbContext
    {
        public StoreDbContext(DbContextOptions<StoreDbContext> dbContextOptions) : base(dbContextOptions)
        {

        }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Property> properties { get; set; }
        public DbSet<Device> devices { get; set; }
        public DbSet<DevicePropertyValue> devicePropertyValues { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Configure the composite primary key
            modelBuilder.Entity<DevicePropertyValue>()
                .HasKey(dp => new { dp.Device_Id, dp.Property_Id });

            modelBuilder.Entity<Category>().HasData(
                new Category() { Id = 1, Name = "Laptop", ImgUrl = "../assets/img/Laptops.png" },
                new Category() { Id = 2, Name = "Printer", ImgUrl = "../assets/img/Printers.jpg" },
                new Category() { Id = 3, Name = "Switch", ImgUrl = "../assets/img/Switches.jpg" }
            );

            modelBuilder.Entity<Property>().HasData(
                // Laptop properties
                new Property() { Id = 1, Category_Id = 1, Description = "Processor" },
                new Property() { Id = 2, Category_Id = 1, Description = "Ram" },
                new Property() { Id = 3, Category_Id = 1, Description = "Storage" },

                // Printer properties
                new Property() { Id = 4, Category_Id = 2, Description = "Print Speed" },
                new Property() { Id = 5, Category_Id = 2, Description = "Resolution" },
                new Property() { Id = 6, Category_Id = 2, Description = "Paper Size" },

                // Switch properties
                new Property() { Id = 7, Category_Id = 3, Description = "Ports" },
                new Property() { Id = 8, Category_Id = 3, Description = "Speed" },
                new Property() { Id = 9, Category_Id = 3, Description = "VLAN Support" }
            );

            modelBuilder.Entity<Device>().HasData(
                // Devices for Laptop category
                new Device() { Id = 1, Name = "Zbook G3", Category_Id = 1, Acquisition_Date = new DateTime(2023, 10, 20) },
                new Device() { Id = 2, Name = "MacBook Pro", Category_Id = 1, Acquisition_Date = new DateTime(2023, 09, 15) },
                new Device() { Id = 3, Name = "Dell XPS 13", Category_Id = 1, Acquisition_Date = new DateTime(2023, 08, 10) },

                // Devices for Printer category
                new Device() { Id = 4, Name = "HP LaserJet", Category_Id = 2, Acquisition_Date = new DateTime(2023, 07, 05) },
                new Device() { Id = 5, Name = "Epson EcoTank", Category_Id = 2, Acquisition_Date = new DateTime(2023, 06, 25) },
                new Device() { Id = 6, Name = "Canon Pixma", Category_Id = 2, Acquisition_Date = new DateTime(2023, 05, 30) },

                // Devices for Switch category
                new Device() { Id = 7, Name = "Cisco Catalyst 9200", Category_Id = 3, Acquisition_Date = new DateTime(2023, 04, 15) },
                new Device() { Id = 8, Name = "Netgear ProSAFE", Category_Id = 3, Acquisition_Date = new DateTime(2023, 03, 10) },
                new Device() { Id = 9, Name = "TP-Link TL-SG108", Category_Id = 3, Acquisition_Date = new DateTime(2023, 02, 18) }
            );

            modelBuilder.Entity<DevicePropertyValue>().HasData(
                // Laptop device property values
                new DevicePropertyValue() { Property_Id = 1, Device_Id = 1, Property_Value = "Core i7 8551Hq" },
                new DevicePropertyValue() { Property_Id = 2, Device_Id = 1, Property_Value = "16GB" },
                new DevicePropertyValue() { Property_Id = 3, Device_Id = 1, Property_Value = "512GB SSD" },

                new DevicePropertyValue() { Property_Id = 1, Device_Id = 2, Property_Value = "M1 Pro" },
                new DevicePropertyValue() { Property_Id = 2, Device_Id = 2, Property_Value = "32GB" },
                new DevicePropertyValue() { Property_Id = 3, Device_Id = 2, Property_Value = "1TB SSD" },

                new DevicePropertyValue() { Property_Id = 1, Device_Id = 3, Property_Value = "Core i5 1135G7" },
                new DevicePropertyValue() { Property_Id = 2, Device_Id = 3, Property_Value = "8GB" },
                new DevicePropertyValue() { Property_Id = 3, Device_Id = 3, Property_Value = "256GB SSD" },

                // Printer device property values
                new DevicePropertyValue() { Property_Id = 4, Device_Id = 4, Property_Value = "20ppm" },
                new DevicePropertyValue() { Property_Id = 5, Device_Id = 4, Property_Value = "1200x1200 dpi" },
                new DevicePropertyValue() { Property_Id = 6, Device_Id = 4, Property_Value = "A4" },

                new DevicePropertyValue() { Property_Id = 4, Device_Id = 5, Property_Value = "15ppm" },
                new DevicePropertyValue() { Property_Id = 5, Device_Id = 5, Property_Value = "1440x720 dpi" },
                new DevicePropertyValue() { Property_Id = 6, Device_Id = 5, Property_Value = "A3" },

                new DevicePropertyValue() { Property_Id = 4, Device_Id = 6, Property_Value = "25ppm" },
                new DevicePropertyValue() { Property_Id = 5, Device_Id = 6, Property_Value = "4800x2400 dpi" },
                new DevicePropertyValue() { Property_Id = 6, Device_Id = 6, Property_Value = "Letter" },

                // Switch device property values
                new DevicePropertyValue() { Property_Id = 7, Device_Id = 7, Property_Value = "48 Ports" },
                new DevicePropertyValue() { Property_Id = 8, Device_Id = 7, Property_Value = "1Gbps" },
                new DevicePropertyValue() { Property_Id = 9, Device_Id = 7, Property_Value = "Yes" },

                new DevicePropertyValue() { Property_Id = 7, Device_Id = 8, Property_Value = "24 Ports" },
                new DevicePropertyValue() { Property_Id = 8, Device_Id = 8, Property_Value = "1Gbps" },
                new DevicePropertyValue() { Property_Id = 9, Device_Id = 8, Property_Value = "Yes" },

                new DevicePropertyValue() { Property_Id = 7, Device_Id = 9, Property_Value = "8 Ports" },
                new DevicePropertyValue() { Property_Id = 8, Device_Id = 9, Property_Value = "1Gbps" },
                new DevicePropertyValue() { Property_Id = 9, Device_Id = 9, Property_Value = "No" }
            );


            base.OnModelCreating(modelBuilder);

        }
    }
}

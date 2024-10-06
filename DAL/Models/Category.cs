﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Models
{
    public class Category
    {
        [Key]
        public int Id { get; set; }
        public string   Name { get; set; }
        public string   ImgUrl { get; set; }
        public ICollection<Property> Properties { get; set; } = new HashSet<Property>();
    }
}

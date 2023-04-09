﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Models
{
    public class Hospital
    {
        public int Id { get; set; }
        public required string Name { get; set; }
        public required string Address { get; set; }

    }
}

﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicLayer.Dto
{
    public class UpdateCustomerDto
    {
        
        public string? Name { get; set; }
        public string? City { get; set; }
        public string? Password { get; set; }

        public string? Role { get; set; }
    }
}

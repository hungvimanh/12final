﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TwelveFinal.Controller.DTO
{
    public class RegisterDTO : DataDTO
    {
        public string Name { get; set; }
        public bool Gender { get; set; }
        public string Ethnic { get; set; }
        public DateTime Dob { get; set; }
        public string Identify { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
    }
}

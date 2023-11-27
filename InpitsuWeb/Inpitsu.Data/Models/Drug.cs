﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inpitsu.Data.Models
{
    public class Drug
    {
        public int Id { get; set; }
        public string? NameOfDrug { get; set; }
        public int? Counts { get; set; }
        public string ?FormCreations { get; set; }
        public double? ComingPrice { get; set; }
        public double? ComingProcent { get; set; }
        public double? Price { get; set; }
        public double Procent { get; set; }
        public DateTime? DateOfExplotation { get; set; }
        public string? Creator { get; set; }
        public string? SNumber { get; set; }
        public ComingDrug? ComingDrug { get; set; }
    }
}

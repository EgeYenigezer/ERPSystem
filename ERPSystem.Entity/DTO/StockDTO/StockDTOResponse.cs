﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ERPSystem.Entity.DTO.StockDTO
{
    public class StockDTOResponse
    {
        public Int64 Id { get; set; }
        public decimal Quantity { get; set; }
        public string ProductName { get; set; }
        public string UnitName { get; set; }
        public string DepartmentName { get; set; }
    }
}

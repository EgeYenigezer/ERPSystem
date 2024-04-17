﻿
using ERPSystem.Entity.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ERPSystem.Entity.DTO.ProductDTO
{
    public class ProductDTOResponse:BaseResponseDTO
    {
        public Int64 Id { get; set; }
        public string Name { get; set; }
        public string BrandName { get; set; }
        public string CategoryName { get; set; }
        public string Description { get; set; }
    }
}

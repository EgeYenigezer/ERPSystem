﻿using ERPSystem.Entity.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ERPSystem.Entity.DTO.OfferDTO
{
    public class OfferDTOResponse:BaseResponseDTO
    {
        public Int64 Id { get; set; }
        public string Name { get; set; }
        public string SupplierName { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public string StatusName { get; set; }
        public string ApproverUserName { get; set; }
    }
}

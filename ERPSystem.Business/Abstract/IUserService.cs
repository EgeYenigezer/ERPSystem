﻿using ERPSystem.Entity.DTO.UserDTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ERPSystem.Business.Abstract
{
    public interface IUserService:IGenericService<UserDTORequest, UserDTOResponse>
    {
    }
}

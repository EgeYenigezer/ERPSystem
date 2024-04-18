using AutoMapper;
using ERPSystem.Entity.DTO.UserDTO;
using ERPSystem.Entity.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ERPSystem.Business.DTOMapper.UserMapper
{
    public class UserResponseMapper:Profile
    {
        public UserResponseMapper()
        {
            CreateMap<User,UserDTOResponse>();
            CreateMap<UserDTOResponse, User>();
        }
    }
}

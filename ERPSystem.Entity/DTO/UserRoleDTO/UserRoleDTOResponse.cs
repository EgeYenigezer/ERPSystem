using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ERPSystem.Entity.DTO.UserRoleDTO
{
    public class UserRoleDTOResponse
    {
        public Int64 Id { get; set; }
        public string UserName { get; set; }
        public string RoleName { get; set; }
    }
}

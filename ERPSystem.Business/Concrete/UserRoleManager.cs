using AutoMapper;
using ERPSystem.Business.Abstract;
using ERPSystem.DataAccess.Abstract.DataManagement;
using ERPSystem.Entity.DTO.UserRoleDTO;
using ERPSystem.Entity.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ERPSystem.Business.Concrete
{
    public class UserRoleManager : IUserRoleService
    {
        private readonly IUnitOfWork _uow;
        private readonly IMapper _mapper;

        public UserRoleManager(IMapper mapper, IUnitOfWork uow)
        {
            _mapper = mapper;
            _uow = uow;
        }

        public async Task<UserRoleDTOResponse> AddAsync(UserRoleDTORequest RequestEntity)
        {
            var userRole = _mapper.Map<UserRole>(RequestEntity);
            var addedUserRole = await _uow.UserRoleRepository.AddAsync(userRole);
            await _uow.SaveChangeAsync();

            UserRoleDTOResponse userRoleDTOResponse = _mapper.Map<UserRoleDTOResponse>(addedUserRole.Entity);
            return userRoleDTOResponse;
        }

        public async Task DeleteAsync(UserRoleDTORequest RequestEntity)
        {
            var userRole = _mapper.Map<UserRole>(RequestEntity);
            await _uow.UserRoleRepository.RemoveAsync(userRole);
            await _uow.SaveChangeAsync();
        }

        public async Task<IEnumerable<UserRoleDTOResponse>> GetAllAsync(UserRoleDTORequest RequestEntity)
        {
            List<UserRoleDTOResponse> userRoleDTOResponses = new();

            if (RequestEntity != null)
            {
                if (RequestEntity.RoleId != null)
                {
                    var userRole = _mapper.Map<UserRole>(RequestEntity);
                    var filterRoleUsers = await _uow.UserRoleRepository.GetAllAsync(x=>x.RoleId==userRole.RoleId && x.IsActive==true);

                    foreach (var filterRoleUser in filterRoleUsers)
                    {
                        userRoleDTOResponses.Add(_mapper.Map<UserRoleDTOResponse>(filterRoleUser));
                    }
                }
            }
            else
            {
                var noFilterRoleUsers = await _uow.UserRoleRepository.GetAllAsync(x=>x.IsActive==true);

                foreach (var noFilterRoleUser in noFilterRoleUsers)
                {
                    userRoleDTOResponses.Add(_mapper.Map<UserRoleDTOResponse>(noFilterRoleUser));
                }
            }

            return userRoleDTOResponses;
        }

        public async Task<UserRoleDTOResponse> GetAsync(UserRoleDTORequest RequestEntity)
        {
            var userRole = _mapper.Map<UserRole>(RequestEntity);
            var dbUserRole = await _uow.UserRoleRepository.GetAsync(x=>x.Id==userRole.Id);

            UserRoleDTOResponse userRoleDTOResponse = _mapper.Map<UserRoleDTOResponse>(dbUserRole);
            return userRoleDTOResponse;
        }

        public async Task UpdateAsync(UserRoleDTORequest RequestEntity)
        {
            var userRole = _mapper.Map<UserRole>(RequestEntity);
            await _uow.UserRoleRepository.UpdateAsync(userRole);
            await _uow.SaveChangeAsync();
        }
    }
}

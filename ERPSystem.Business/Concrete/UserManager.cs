using AutoMapper;
using ERPSystem.Business.Abstract;
using ERPSystem.DataAccess.Abstract.DataManagement;
using ERPSystem.Entity.DTO.UserDTO;
using ERPSystem.Entity.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ERPSystem.Business.Concrete
{
    public class UserManager : IUserService
    {
        private readonly IUnitOfWork _uow;
        private readonly IMapper _mapper;

        public UserManager(IMapper mapper, IUnitOfWork uow)
        {
            _mapper = mapper;
            _uow = uow;
        }

        public async Task<UserDTOResponse> AddAsync(UserDTORequest RequestEntity)
        {
            var user = _mapper.Map<User>(RequestEntity);
            var addedUser = await _uow.UserRepository.AddAsync(user);
            await _uow.SaveChangeAsync();

            UserDTOResponse userDTOResponse = _mapper.Map<UserDTOResponse>(addedUser.Entity);
            return userDTOResponse;

        }

        public async Task DeleteAsync(UserDTORequest RequestEntity)
        {
            var user = _mapper.Map<User>(RequestEntity);
            await _uow.UserRepository.RemoveAsync(user);
            await _uow.SaveChangeAsync();
        }

        public async Task<IEnumerable<UserDTOResponse>> GetAllAsync(UserDTORequest RequestEntity)
        {
            List<UserDTOResponse> userDTOResponses = new();
            if (RequestEntity != null)
            {
                if (RequestEntity.DepartmentId !=null)
                {
                    var filterUser = _mapper.Map<User>(RequestEntity);
                    var departmentFilterUsers = await _uow.UserRepository.GetAllAsync(x=>x.DepartmentId==filterUser.DepartmentId);

                    foreach (var user in departmentFilterUsers)
                    {
                        userDTOResponses.Add(_mapper.Map<UserDTOResponse>(user));
                    }
                    
                }
            }
            else
            {
                var noFilterUsers = await _uow.UserRepository.GetAllAsync(x=>x.IsActive==true);
                foreach (var user in noFilterUsers)
                {
                    userDTOResponses.Add(_mapper.Map<UserDTOResponse>(user));
                }
                
            }

            return userDTOResponses;
        }

        public async Task<UserDTOResponse> GetAsync(UserDTORequest RequestEntity)
        {
            var user = _mapper.Map<User>(RequestEntity);
            var dbUser = await _uow.UserRepository.GetAsync(x=>x.Id==user.Id && x.IsActive==true);

            UserDTOResponse userDTOResponse =_mapper.Map<UserDTOResponse>(dbUser);
            return userDTOResponse;
        }

        public async Task UpdateAsync(UserDTORequest RequestEntity)
        {
            var user = _mapper.Map<User>(RequestEntity);
            await _uow.UserRepository.UpdateAsync(user);
            await _uow.SaveChangeAsync();
        }
    }
}

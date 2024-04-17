﻿using AutoMapper;
using ERPSystem.Business.Abstract;
using ERPSystem.DataAccess.Abstract.DataManagement;
using ERPSystem.Entity.DTO.DepartmentDTO;
using ERPSystem.Entity.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ERPSystem.Business.Concrete
{
    public class DepartmentManager : IDepartmentService
    {
        private readonly IUnitOfWork _uow;
        private readonly IMapper _mapper;

        public DepartmentManager(IMapper mapper, IUnitOfWork uow)
        {
            _mapper = mapper;
            _uow = uow;
        }

        public async Task<DepartmentDTOResponse> AddAsync(DepartmentDTORequest RequestEntity)
        {
            var department = _mapper.Map<Department>(RequestEntity);
            await _uow.DepartmentRepository.AddAsync(department);
            await _uow.SaveChangeAsync();
            DepartmentDTOResponse departmentDTOResponse = _mapper.Map<DepartmentDTOResponse>(department);
            return departmentDTOResponse;

        }

        public async Task DeleteAsync(DepartmentDTORequest RequestEntity)
        {
            var department = _mapper.Map<Department>(RequestEntity);
            await _uow.DepartmentRepository.RemoveAsync(department);
            await _uow.SaveChangeAsync();
        }

        public async Task<IEnumerable<DepartmentDTOResponse>> GetAllAsync(DepartmentDTORequest RequestEntity)
        {
            if (RequestEntity.CompanyId != null)
            {
                var department = _mapper.Map<Department>(RequestEntity);
                var departments = await _uow.DepartmentRepository.GetAllAsync(x=>x.CompanyId == RequestEntity.CompanyId);
                List<DepartmentDTOResponse> departmentDTOResponses = new();

                foreach (var item in departments)
                {
                    departmentDTOResponses.Add(_mapper.Map<DepartmentDTOResponse>(item));
                }
                return departmentDTOResponses;
            }
            else
            {
                var departments = await _uow.DepartmentRepository.GetAllAsync(x => true);
                List<DepartmentDTOResponse> departmentDTOResponses = new();

                foreach (var item in departments)
                {
                    departmentDTOResponses.Add(_mapper.Map<DepartmentDTOResponse>(item));
                }
                return departmentDTOResponses;
            }
            
        }

        public async Task<DepartmentDTOResponse> GetAsync(DepartmentDTORequest RequestEntity)
        {
            var department = _mapper.Map<Department>(RequestEntity);
            var dbDepartment = await _uow.DepartmentRepository.GetAsync(x=>x.Id==department.Id);
            DepartmentDTOResponse departmentDTOResponse = _mapper.Map<DepartmentDTOResponse>(dbDepartment);
            return departmentDTOResponse;
        }

        public async Task UpdateAsync(DepartmentDTORequest RequestEntity)
        {
            var department = _mapper.Map<Department>(RequestEntity);

            await _uow.DepartmentRepository.UpdateAsync(department);
            await _uow.SaveChangeAsync();
        }
    }
}

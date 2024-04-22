﻿using AutoMapper;
using AutoMapper.Configuration.Annotations;
using ERPSystem.Business.Abstract;
using ERPSystem.DataAccess.Abstract.DataManagement;
using ERPSystem.Entity.DTO.RequestDTO;
using ERPSystem.Entity.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ERPSystem.Business.Concrete
{
    public class RequestManager : IRequestService
    {
        private readonly IUnitOfWork _uow;
        private readonly IMapper _mapper;

        public RequestManager(IMapper mapper, IUnitOfWork uow)
        {
            _mapper = mapper;
            _uow = uow;
        }

        public async Task<RequestDTOResponse> AddAsync(RequestDTORequest RequestEntity)
        {
            if(RequestEntity.ApproverId == 0)
            {
                RequestEntity.ApproverId = null;
            }
            var request = _mapper.Map<Request>(RequestEntity);
            var addedRequest = await _uow.RequestRepository.AddAsync(request);
            await _uow.SaveChangeAsync();
            RequestDTOResponse requestDTOResponse =_mapper.Map<RequestDTOResponse>(addedRequest.Entity);
            return requestDTOResponse;
        }

        public async Task DeleteAsync(RequestDTORequest RequestEntity)
        {
            var request = _mapper.Map<Request>(RequestEntity);
            await _uow.RequestRepository.RemoveAsync(request);
            await _uow.SaveChangeAsync();
        }

        public async Task<IEnumerable<RequestDTOResponse>> GetAllAsync(RequestDTORequest RequestEntity)
        {
            List<RequestDTOResponse> requestDTOResponses = new();
            if (RequestEntity.StatusId!=0)
            {
                var request = _mapper.Map<Request>(RequestEntity);

                var dbRequests = await _uow.RequestRepository.GetAllAsync(x=>x.StatusId==request.StatusId, "RequesterUser", "ApproverUser", "Status","Product","Unit");

                

                foreach (var dbRequest in dbRequests)
                {
                    requestDTOResponses.Add(_mapper.Map<RequestDTOResponse>(dbRequest));
                }
                
            }
            else if (RequestEntity.ProductId != 0)
            {
                var request = _mapper.Map<Request>(RequestEntity);

                var dbRequests = await _uow.RequestRepository.GetAllAsync(x => x.ProductId == request.ProductId, "RequesterUser", "ApproverUser", "Status", "Product", "Unit");

                

                foreach (var dbRequest in dbRequests)
                {
                    requestDTOResponses.Add(_mapper.Map<RequestDTOResponse>(dbRequest));
                }
                
            }
            else
            {
                var dbRequests = await _uow.RequestRepository.GetAllAsync(x=>true,"RequesterUser","ApproverUser", "Status", "Product", "Unit");

                

                foreach (var dbRequest in dbRequests)
                {
                    requestDTOResponses.Add(_mapper.Map<RequestDTOResponse>(dbRequest));
                }
                
            }
            return requestDTOResponses;
        }

        public async Task<RequestDTOResponse> GetAsync(RequestDTORequest RequestEntity)
        {
            var request = _mapper.Map<Request>(RequestEntity);

            var dbRequest = await _uow.RequestRepository.GetAsync(x=>x.Id==request.Id,"RequesterUser","ApproverUser", "Status", "Product", "Unit");
            RequestDTOResponse requestDTOResponse = _mapper.Map<RequestDTOResponse>(dbRequest);
            return requestDTOResponse;

        }

        public async Task UpdateAsync(RequestDTORequest RequestEntity)
        {
            var request = _mapper.Map<Request>(RequestEntity);
            await _uow.RequestRepository.UpdateAsync(request);
            await _uow.SaveChangeAsync();
        }
    }
}

using AutoMapper;
using ERPSystem.Business.Abstract;
using ERPSystem.DataAccess.Abstract.DataManagement;
using ERPSystem.Entity.DTO.OfferDTO;
using ERPSystem.Entity.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.WebSockets;
using System.Text;
using System.Threading.Tasks;

namespace ERPSystem.Business.Concrete
{
    public class OfferManager : IOfferService
    {
        private readonly IUnitOfWork _uow;
        private readonly IMapper _mapper;

        public OfferManager(IMapper mapper, IUnitOfWork uow)
        {
            _mapper = mapper;
            _uow = uow;
        }

        public async Task<OfferDTOResponse> AddAsync(OfferDTORequest RequestEntity)
        {
            if(RequestEntity.ApproverUserId == 0)
            {
                RequestEntity.ApproverUserId = null;
            }
            var offer = _mapper.Map<Offer>(RequestEntity);
            var dbOffer= await _uow.OfferRepository.AddAsync(offer);
            await _uow.SaveChangeAsync();

            OfferDTOResponse offerDTOResponse = _mapper.Map<OfferDTOResponse>(dbOffer.Entity);
            return offerDTOResponse;
            
        }

        public async Task DeleteAsync(OfferDTORequest RequestEntity)
        {
            var offer = _mapper.Map<Offer>(RequestEntity);

            await _uow.OfferRepository.RemoveAsync(offer);
            await _uow.SaveChangeAsync();

        }

        public async Task<IEnumerable<OfferDTOResponse>> GetAllAsync(OfferDTORequest RequestEntity)
        {
            if (RequestEntity.SupplierName!=null)
            {
                var offer = _mapper.Map<Offer>(RequestEntity);

                var dbOffers = await _uow.OfferRepository.GetAllAsync(x=>x.SupplierName==offer.SupplierName);

                List<OfferDTOResponse> offerDTOResponses = new();

                foreach (var dbOffer in dbOffers)
                {
                    offerDTOResponses.Add(_mapper.Map<OfferDTOResponse>(dbOffer));
                }
                return offerDTOResponses;
            }
            else
            {
                var dbOffers = await _uow.OfferRepository.GetAllAsync();

                List<OfferDTOResponse> offerDTOResponses = new();

                foreach (var dbOffer in dbOffers)
                {
                    offerDTOResponses.Add(_mapper.Map<OfferDTOResponse>(dbOffer));
                }
                return offerDTOResponses;
            }


        }

        public async Task<OfferDTOResponse> GetAsync(OfferDTORequest RequestEntity)
        {
            var offer = _mapper.Map<Offer>(RequestEntity);

            var dbOffer = await _uow.OfferRepository.GetAsync(x=>x.Id==offer.Id);

            OfferDTOResponse offerDTOResponse = _mapper.Map<OfferDTOResponse>(dbOffer);

            return offerDTOResponse;
        }

        public async Task UpdateAsync(OfferDTORequest RequestEntity)
        {
            var offer = _mapper.Map<Offer>(RequestEntity);

            await _uow.OfferRepository.UpdateAsync(offer);
            await _uow.SaveChangeAsync();
        }
    }
}

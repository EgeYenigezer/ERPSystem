using AutoMapper;
using AutoMapper.Configuration.Annotations;
using ERPSystem.Business.Abstract;
using ERPSystem.DataAccess.Abstract;
using ERPSystem.DataAccess.Abstract.DataManagement;
using ERPSystem.Entity.DTO.InvoiceDTO;
using ERPSystem.Entity.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ERPSystem.Business.Concrete
{
    public class InvoiceManager : IInvoiceService
    {
        private readonly IUnitOfWork _uow;
        private readonly IMapper _mapper;

        public InvoiceManager(IMapper mapper, IUnitOfWork uow)
        {
            _mapper = mapper;
            _uow = uow;
        }

        public async Task<InvoiceDTOResponse> AddAsync(InvoiceDTORequest RequestEntity)
        {
            var invoice = _mapper.Map<Invoice>(RequestEntity);

            await _uow.InvoiceRepository.AddAsync(invoice);
            await _uow.SaveChangeAsync();

            InvoiceDTOResponse invoiceDTOResponse = _mapper.Map<InvoiceDTOResponse>(invoice);

            return invoiceDTOResponse;

        }

        public async Task DeleteAsync(InvoiceDTORequest RequestEntity)
        {
            var invoice = _mapper.Map<Invoice>(RequestEntity);
            await _uow.InvoiceRepository.RemoveAsync(invoice);
            await _uow.SaveChangeAsync();
        }

        public async Task<IEnumerable<InvoiceDTOResponse>> GetAllAsync(InvoiceDTORequest RequestEntity)
        {
            if (RequestEntity.InvoiceDate!=null)
            {
                var invoice = _mapper.Map<Invoice>(RequestEntity);

                var dbInvoices= await _uow.InvoiceRepository.GetAllAsync(x=>x.InvoiceDate==invoice.InvoiceDate);

                List<InvoiceDTOResponse> invoiceDTOResponses = new();

                foreach(var item in dbInvoices)
                {
                    invoiceDTOResponses.Add(_mapper.Map<InvoiceDTOResponse>(item));

                }

                return invoiceDTOResponses;
            }

            else if (RequestEntity.ProductName!=null)
            {
                var invoice = _mapper.Map<Invoice>(RequestEntity);

                var dbInvoices = await _uow.InvoiceRepository.GetAllAsync(x => x.ProductName == invoice.ProductName);

                List<InvoiceDTOResponse> invoiceDTOResponses = new();

                foreach (var item in dbInvoices)
                {
                    invoiceDTOResponses.Add(_mapper.Map<InvoiceDTOResponse>(item));

                }

                return invoiceDTOResponses;

            }
            else if (RequestEntity.CompanyName!=null)
            {

                var invoice = _mapper.Map<Invoice>(RequestEntity);

                var dbInvoices = await _uow.InvoiceRepository.GetAllAsync(x => x.CompanyName == invoice.CompanyName);

                List<InvoiceDTOResponse> invoiceDTOResponses = new();

                foreach (var item in dbInvoices)
                {
                    invoiceDTOResponses.Add(_mapper.Map<InvoiceDTOResponse>(item));

                }

                return invoiceDTOResponses;
            }
            else if (RequestEntity.SupplierName!=null)
            {

                var invoice = _mapper.Map<Invoice>(RequestEntity);

                var dbInvoices = await _uow.InvoiceRepository.GetAllAsync(x => x.SupplierName == invoice.SupplierName);

                List<InvoiceDTOResponse> invoiceDTOResponses = new();

                foreach (var item in dbInvoices)
                {
                    invoiceDTOResponses.Add(_mapper.Map<InvoiceDTOResponse>(item));

                }

                return invoiceDTOResponses;
            }
            else
            {
                var dbInvoices = await _uow.InvoiceRepository.GetAllAsync();

                List<InvoiceDTOResponse> invoiceDTOResponses = new();

                foreach (var item in dbInvoices)
                {
                    invoiceDTOResponses.Add(_mapper.Map<InvoiceDTOResponse>(item));

                }
                return invoiceDTOResponses;
            }


        }

        public async Task<InvoiceDTOResponse> GetAsync(InvoiceDTORequest RequestEntity)
        {
            var invoice = _mapper.Map<Invoice>(RequestEntity);

            var dbInvoice = await _uow.InvoiceRepository.GetAsync(x=>x.Id==invoice.Id);

            InvoiceDTOResponse invoiceDTOResponse = _mapper.Map<InvoiceDTOResponse>(dbInvoice);

            return invoiceDTOResponse;
        }

        public async Task UpdateAsync(InvoiceDTORequest RequestEntity)
        {
            var invoice = _mapper.Map<Invoice>(RequestEntity);

            await _uow.InvoiceRepository.UpdateAsync(invoice);

            await _uow.SaveChangeAsync();
        }
    }
}

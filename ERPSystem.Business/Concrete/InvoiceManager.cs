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
using System.Reflection.Emit;
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
            List<InvoiceDTOResponse> invoiceDTOResponses = new();

             if (!(RequestEntity.ProductName.Contains("string")))
            {
                var invoice = _mapper.Map<Invoice>(RequestEntity);

                var dbInvoices = await _uow.InvoiceRepository.GetAllAsync(x => x.ProductName == invoice.ProductName);

                

                foreach (var item in dbInvoices)
                {
                    invoiceDTOResponses.Add(_mapper.Map<InvoiceDTOResponse>(item));

                }

                

            }
             if (!(RequestEntity.CompanyName.Contains("string")))
            {

                var invoice = _mapper.Map<Invoice>(RequestEntity);

                var dbInvoices = await _uow.InvoiceRepository.GetAllAsync(x => x.CompanyName == invoice.CompanyName);

                

                foreach (var item in dbInvoices)
                {
                    invoiceDTOResponses.Add(_mapper.Map<InvoiceDTOResponse>(item));

                }

                
            }
             if (!(RequestEntity.SupplierName.Contains("string")))
            {

                var invoice = _mapper.Map<Invoice>(RequestEntity);

                var dbInvoices = await _uow.InvoiceRepository.GetAllAsync(x => x.SupplierName == invoice.SupplierName);

               

                foreach (var item in dbInvoices)
                {
                    invoiceDTOResponses.Add(_mapper.Map<InvoiceDTOResponse>(item));

                }

                

            }
            else
            {
                var dbInvoices = await _uow.InvoiceRepository.GetAllAsync();

                

                foreach (var item in dbInvoices)
                {
                    invoiceDTOResponses.Add(_mapper.Map<InvoiceDTOResponse>(item));

                }
                
            }
            return invoiceDTOResponses;


        }

        public async Task<IEnumerable<InvoiceDTOResponse>> GetAllAsyncByDate(string date)
        {
            string[] dates = date.Split('-');
            DateTime startDate = Convert.ToDateTime(dates[0]);
            DateTime endDate = Convert.ToDateTime(dates[1]);
            endDate = endDate.AddDays(1).AddSeconds(-1);
            
            var invoices = await _uow.InvoiceRepository.GetAllAsync(x=>x.IsActive==true && x.InvoiceDate<= endDate && x.InvoiceDate >= startDate);

            List<InvoiceDTOResponse> invoiceDTOResponseList = new();
            foreach (var invoice in invoices)
            {
                invoiceDTOResponseList.Add(_mapper.Map<InvoiceDTOResponse>(invoice));
                
            }

            return invoiceDTOResponseList;
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

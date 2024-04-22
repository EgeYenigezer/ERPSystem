using Azure.Core;
using ERPSystem.Business.Abstract;
using ERPSystem.Entity.DTO.InvoiceDTO;
using ERPSystem.Entity.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ERPSystem.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class InvoiceController : ControllerBase
    {
        private readonly IInvoiceService _invoiceService;

        public InvoiceController(IInvoiceService invoiceService)
        {
            _invoiceService = invoiceService;
        }

        [HttpPost("/Invoices")]
        public async Task<IActionResult> GetAllAsync(InvoiceDTORequest invoiceDTORequest)
        {
            var Invoices = await _invoiceService.GetAllAsync(invoiceDTORequest);

            return Ok(Invoices);
        }

        [HttpPost("/InvoicesByDate")]
        public async Task<IActionResult> GetAllAsync(string date)
        {
            var Invoices = await _invoiceService.GetAllAsyncByDate(date);

            return Ok(Invoices);
        }



        [HttpPost("/Invoice")]
        public async Task<IActionResult> GetAsync(InvoiceDTORequest invoiceDTORequest)
        {
            var Invoice = await _invoiceService.GetAsync(invoiceDTORequest);

            return Ok(Invoice);
        }

        [HttpPost("/AddInvoice")]
        public async Task<IActionResult> AddAsync(InvoiceDTORequest invoiceDTORequest)
        {
            var addedInvoice = await _invoiceService.AddAsync(invoiceDTORequest);

            return Ok($"{addedInvoice.Id} 'li Fatura Eklendi! ");
        }

        [HttpPost("/UpdateInvoice")]
        public async Task<IActionResult> UpdateAsync(InvoiceDTORequest invoiceDTORequest)
        {
            await _invoiceService.UpdateAsync(invoiceDTORequest);
            return Ok("İşlem Başarılı!!");
        }

        [HttpPost("/DeleteInvoice")]
        public async Task<IActionResult> DeleteAsync(InvoiceDTORequest invoiceDTORequest)
        {
            await _invoiceService.DeleteAsync(invoiceDTORequest);
            return Ok("İşlem Başarılı!!");
        }

    }
}

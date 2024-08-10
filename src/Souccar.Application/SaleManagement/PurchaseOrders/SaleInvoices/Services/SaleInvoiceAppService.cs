using Abp.UI;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Souccar.Core.Dto.PagedRequests;
using Souccar.Core.Services;
using Souccar.SaleManagement.PurchaseOrders.Deliveries.Dto;
using Souccar.SaleManagement.PurchaseOrders.SaleInvoices.Dto;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http.Headers;
using System.Threading.Tasks;

namespace Souccar.SaleManagement.PurchaseOrders.SaleInvoices.Services
{
    public class SaleInvoiceAppService :
        AsyncSouccarAppService<SaleInvoice, SaleInvoiceDto, int, FullPagedRequestDto, CreateSaleInvoiceDto, UpdateSaleInvoiceDto>, ISaleInvoiceAppService
    {
        private readonly ISaleInvoiceDomainService _saleInvoiceDomainService;
        private readonly IWebHostEnvironment _hostingEnvironment;


        public SaleInvoiceAppService(ISaleInvoiceDomainService saleInvoiceDomainService, IWebHostEnvironment hostingEnvironment = null) : base(saleInvoiceDomainService)
        {
            _saleInvoiceDomainService = saleInvoiceDomainService;
            _hostingEnvironment = hostingEnvironment;
        }

        public override Task<SaleInvoiceDto> CreateAsync(CreateSaleInvoiceDto input)
        {
            input.DateForPaid = DateTime.Now.AddDays(input.DaysForPaid).ToString();
            return base.CreateAsync(input);
        }

        public async Task<PdfAndUrnDto> GetPdfAndUrnByIdAsync(int saleInvoiceId)
        {
           var saleInvoice = await _saleInvoiceDomainService.GetAsync(saleInvoiceId);
            return ObjectMapper.Map<PdfAndUrnDto>(saleInvoice);
        }

        public async Task<SaleInvoiceDto> GetWithDetailsByIdAsync(int saleInvoiceId)
        {
            var invoice = await _saleInvoiceDomainService.GetWithDetailsByIdAsync(saleInvoiceId);
            return ObjectMapper.Map<SaleInvoiceDto>(invoice);
        }

        [HttpPost]
        [DisableRequestSizeLimit]
        public async Task<FileUploadOutputModel> UploadFile(IFormFile file,int saleInvoiceId)
        {
            if (file == null)
                return new FileUploadOutputModel(false, "NoFileFoundInTheRequest");

            try
            {
                string webRootPath = _hostingEnvironment.WebRootPath;
                string uploadsDir = Path.Combine(webRootPath, "PdfFiles");

                if (!Directory.Exists(uploadsDir))
                    Directory.CreateDirectory(uploadsDir);

                var output = new FileOutputModel("","","");
                
                    string fileName = ContentDispositionHeaderValue.Parse(file.ContentDisposition).FileName.Trim('"');
                    string fullPath = Path.Combine(uploadsDir, fileName);

                    var buffer = 1024 * 1024;
                    var stream = new FileStream(fullPath, FileMode.Create, FileAccess.Write, FileShare.None, buffer, useAsync: false);
                    await file.CopyToAsync(stream);
                    await stream.FlushAsync();
                    stream.Dispose();

                    string path = $"pdfFiles/{fileName}";

                    output.Path = path;
                    output.FileType = file.ContentType;
                    output.FileName = fileName;

                var saleInvoice = await _saleInvoiceDomainService.GetAsync(saleInvoiceId);
                if (saleInvoice == null)
                    return new FileUploadOutputModel(false, "There is no sale invoice for id: " + saleInvoiceId);
                saleInvoice.PDFFilePath = path;
                CurrentUnitOfWork.SaveChanges();

                return new FileUploadOutputModel(true,output);
            }
            catch (Exception ex)
            {
                return new FileUploadOutputModel(false, "Upload failed: " + ex.Message);
            }
        }

        public async Task<SaleInvoiceDto> AddOrEditUrnNumber(PdfAndUrnDto pdfAndUrnDto)
        {
            try
            {
                var saleInvoice = await _saleInvoiceDomainService.GetAsync(pdfAndUrnDto.Id);
                if (saleInvoice == null)
                    throw new UserFriendlyException("There is no sale invoice for id: " + pdfAndUrnDto.Id);
                saleInvoice.PillURN = pdfAndUrnDto.PillURN;
                CurrentUnitOfWork.SaveChanges();
                return ObjectMapper.Map<SaleInvoiceDto>(saleInvoice);
            }
            catch (Exception ex)
            {
                throw new UserFriendlyException(ex.Message);
            }
        }
    }
}

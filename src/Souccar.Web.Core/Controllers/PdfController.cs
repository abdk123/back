using Abp.Threading;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Localization;
using Microsoft.AspNetCore.Mvc;
using QuestPDF.Fluent;
using QuestPDF.Helpers;
using QuestPDF.Infrastructure;
using Souccar.Hcpc.WarehousesApp.OutputRequests.Dto;
using Souccar.Hcpc.WarehousesApp.OutputRequests.Services;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;

namespace Souccar.Controllers
{
    [Route("api/[controller]/[action]")]
    public class PdfController : SouccarControllerBase
    {
        private readonly IOutputRequestAppService _outputRequestAppService;
        private readonly IWebHostEnvironment _hostingEnvironment;

        public int PlanId { get; set; }
        public CultureInfo Language { get; set; }

        public PdfController(IOutputRequestAppService outputRequestAppService, IWebHostEnvironment hostingEnvironment)
        {
            _outputRequestAppService = outputRequestAppService;
            _hostingEnvironment = hostingEnvironment;
        }

        private IList<OutputRequestWithDetailDto> GetOutputRequestsForPlan(int planId)
        {
            var outputRequests = AsyncHelper.RunSync(() => _outputRequestAppService.GetWithDetail(planId));
            return outputRequests;
        }

        [HttpGet]
        public void GenerateDailyProductionsReport(int planId)
        {
            PlanId = planId;
            var rqf = Request.HttpContext.Features.Get<IRequestCultureFeature>();
            var culture = rqf.RequestCulture.Culture.Name;
            Language = new CultureInfo(culture);

            if (culture == "ar")
            {
                Document document = Document.Create(ArabicDailyProductionsReportCompose);
                document.GeneratePdfAndShow();
            }
            else
            {
                Document document = Document.Create(DailyProductionsReportCompose);
                document.GeneratePdfAndShow();
            }            
        }

        #region Helper Methods
        private void ArabicDailyProductionsReportCompose(IDocumentContainer container)
        {
            var rootPath = _hostingEnvironment.WebRootPath;
            Image logoImage = Image.FromFile(rootPath + "\\Images\\logo.png");
            var outputRequests = GetOutputRequestsForPlan(PlanId);

            container
            .Page(page =>
             {
                 page.Margin(50);
                 page.ContentFromRightToLeft();

                 page.Header()
                 .Row(row =>
                 {
                     row.RelativeItem().ContentFromRightToLeft().Column(column =>
                     {
                         column.Item().AlignMiddle().Text(text =>
                         {
                             text.Span(L("Date") + ": ").FontFamily(Fonts.Calibri).SemiBold().DirectionFromRightToLeft();
                             text.Span(DateTime.Now.ToString("dd/MM/yyyy"));
                         });
                     });

                     row.ConstantItem(175).ContentFromRightToLeft().Image(logoImage);
                 });

                 page.Content()
                .PaddingVertical(25).ContentFromRightToLeft().Table(table =>
                {
                    var headerStyle = TextStyle.Default.SemiBold().FontFamily(Fonts.Calibri);
                    var contentStyle = TextStyle.Default.FontFamily(Fonts.Calibri);
                    
                    table.ColumnsDefinition(columns =>
                    {
                        columns.RelativeColumn(40);
                        columns.RelativeColumn(30);
                        columns.RelativeColumn(60);
                        columns.RelativeColumn(60);
                    });

                    table.Header(header =>
                    {
                        header.Cell().Element(CellStyle).Text(L("RequestTitle", Language)).Style(headerStyle);
                        header.Cell().Element(CellStyle).Text(L("RequestDate", Language)).Style(headerStyle);
                        header.Cell().Element(CellStyle).Text(L("Products", Language)).Style(headerStyle);
                        header.Cell().Element(CellStyle).Text(L("DailyProduction", Language)).Style(headerStyle);
                    });

                    foreach (var item in outputRequests)
                    {
                        var count = (uint)(item.OutputRequestProducts.Count * item.DailyProductions.Count);
                        if (count == 0)
                        {
                            table.Cell().ContentFromRightToLeft().Element(CellStyle).ShowOnce().Text(item.Title).Style(contentStyle);
                            table.Cell().ContentFromRightToLeft().Element(CellStyle).Text(item.OutputDate.ToString("dd/MM/yyyy")).Style(contentStyle);
                            table.Cell().Element(CellStyle).Text("-").Style(contentStyle)
                            .FontSize(12).FontColor(Colors.BlueGrey.Medium);
                            table.Cell().Element(CellStyle).Text("-").Style(contentStyle)
                            .FontSize(12).FontColor(Colors.BlueGrey.Medium);
                        }
                        else
                        {
                            table.Cell().RowSpan(count).ContentFromRightToLeft().Element(CellStyle).ShowOnce().Text(item.Title).Style(contentStyle);
                            table.Cell().RowSpan(count).ContentFromRightToLeft().Element(CellStyle).Text(item.OutputDate.ToString("dd/MM/yyyy")).Style(contentStyle);

                            int colorNum = 0;


                            foreach (var product in item.OutputRequestProducts)
                            {
                                var numberOfDaily = item.DailyProductions
                                .Where(x => x.DailyProductionDetails.Any(y => y.ProductId == product.ProductId))
                                .Count();

                                if (numberOfDaily != 0)
                                {
                                    if (colorNum == 0)
                                    {
                                        table.Cell().RowSpan((uint)numberOfDaily).Element(CellStyle).ContentFromRightToLeft()
                                        .Text(text =>
                                        {
                                            text.Span(product.Product.Name).FontSize(11).FontColor(Colors.BlueGrey.Medium).Style(contentStyle);
                                            text.Span(" / " + L("CanProduce", Language) + ": ").FontSize(11).FontColor(Colors.BlueGrey.Medium).Style(contentStyle);
                                            text.Span(product.CanProduce.ToString()).FontSize(11).FontColor(Colors.BlueGrey.Medium).Style(contentStyle);
                                        });

                                        foreach (var dailyProduction in item.DailyProductions)
                                        {
                                            colorNum = 1;
                                            table.Cell().Element(CellStyle).ContentFromRightToLeft()
                                            .Text(text =>
                                             {
                                                 text.Span(dailyProduction.CreationTime.ToString("dd/MM/yyyy")).FontSize(9).FontColor(Colors.BlueGrey.Medium).Style(contentStyle);
                                                 text.Span(" - " + L("Produced", Language) + ": ").FontSize(9).FontColor(Colors.BlueGrey.Medium).Style(contentStyle);
                                                 text.Span(dailyProduction.DailyProductionDetails.FirstOrDefault(z => z.ProductId == product.ProductId).Quantity.ToString()).FontSize(9).FontColor(Colors.BlueGrey.Medium).Style(contentStyle);
                                             });
                                        }
                                    }
                                    else
                                    {
                                        table.Cell().RowSpan((uint)numberOfDaily).Element(CellStyle).ContentFromRightToLeft()
                                        .Text(text =>
                                        {
                                             text.Span(product.Product.Name).FontSize(11).FontColor(Colors.LightBlue.Accent4).Style(contentStyle);
                                             text.Span(" / " + L("CanProduce", Language) + ": ").FontSize(11).FontColor(Colors.LightBlue.Accent4).Style(contentStyle);
                                             text.Span(product.CanProduce.ToString()).FontSize(11).FontColor(Colors.LightBlue.Accent4).Style(contentStyle);
                                        });

                                        foreach (var dailyProduction in item.DailyProductions)
                                        {
                                            colorNum = 0;
                                            table.Cell().Element(CellStyle).ContentFromRightToLeft()
                                            .Text(text =>
                                             {
                                                 text.Span(dailyProduction.CreationTime.ToString("dd/MM/yyyy")).FontSize(9).FontColor(Colors.LightBlue.Accent4).Style(contentStyle);
                                                 text.Span(" - " + L("Produced", Language) + ": ").FontSize(9).FontColor(Colors.LightBlue.Accent4).Style(contentStyle);
                                                 text.Span(dailyProduction.DailyProductionDetails.FirstOrDefault(z => z.ProductId == product.ProductId).Quantity.ToString()).FontSize(9).FontColor(Colors.LightBlue.Accent4).Style(contentStyle);
                                             });
                                        }
                                    }
                                }
                                else
                                {
                                    table.Cell().Element(CellStyle).ContentFromRightToLeft()
                                    .Text(text =>
                                    {
                                        text.Span(product.Product.Name).FontSize(11).FontColor(Colors.BlueGrey.Medium).Style(contentStyle);
                                        text.Span(" / " + L("CanProduce", Language) + ": ").FontSize(11).FontColor(Colors.BlueGrey.Medium).Style(contentStyle);
                                        text.Span(product.CanProduce.ToString()).FontSize(11).FontColor(Colors.BlueGrey.Medium).Style(contentStyle);
                                    });

                                    foreach (var dailyProduction in item.DailyProductions)
                                    {
                                        table.Cell().Element(CellStyle).Text("-").Style(contentStyle)
                                        .FontSize(7).FontColor(Colors.BlueGrey.Medium);
                                    }
                                }
                            }
                        }
                    }
                    IContainer CellStyle(IContainer container1) => container1.Border(1).BorderColor(Colors.Grey.Lighten2).PaddingVertical(5).AlignCenter().AlignMiddle();

                });

                 page.Footer().AlignCenter().Text(text =>
                 {
                     text.CurrentPageNumber();
                     text.Span(" / ");
                     text.TotalPages();
                 });
             });
        }
        private void DailyProductionsReportCompose(IDocumentContainer container)
        {           
            var rootPath = _hostingEnvironment.WebRootPath;
            Image logoImage = Image.FromFile(rootPath + "\\Images\\logo.png");
            var outputRequests = GetOutputRequestsForPlan(PlanId);

            container
            .Page(page =>
            {
                page.Margin(50);

                page.Header()
                .Row(row =>
                {
                    row.RelativeItem().Column(column =>
                    {
                        column.Item().AlignMiddle().Text(text =>
                        {
                            text.Span("Date: ").SemiBold();
                            text.Span(DateTime.Now.ToString("dd/MM/yyyy"));
                        });
                    });

                    row.ConstantItem(175).Image(logoImage);
                });

                page.Content()
               .PaddingVertical(25).Table(table =>
               {
                   var headerStyle = TextStyle.Default.SemiBold().FontFamily(Fonts.Calibri);
                   var contentStyle = TextStyle.Default.FontFamily(Fonts.Calibri);

                   table.ColumnsDefinition(columns =>
                   {
                       columns.RelativeColumn(40);
                       columns.RelativeColumn(30);
                       columns.RelativeColumn(60);
                       columns.RelativeColumn(60);
                   });

                   table.Header(header =>
                   {
                       header.Cell().Element(CellStyle).Text(L("RequestTitle", Language)).Style(headerStyle);
                       header.Cell().Element(CellStyle).Text(L("RequestDate", Language)).Style(headerStyle);
                       header.Cell().Element(CellStyle).Text(L("Products", Language)).Style(headerStyle);
                       header.Cell().Element(CellStyle).Text(L("DailyProduction", Language)).Style(headerStyle);
                   });

                   foreach (var item in outputRequests)
                   {
                       var count = (uint)(item.OutputRequestProducts.Count * item.DailyProductions.Count);
                       if (count == 0)
                       {
                           table.Cell().Element(CellStyle).ShowOnce().Text(item.Title).Style(contentStyle);
                           table.Cell().Element(CellStyle).Text(item.OutputDate.ToString("dd/MM/yyyy")).Style(contentStyle);
                           table.Cell().Element(CellStyle).Text("-").Style(contentStyle)
                           .FontSize(12).FontColor(Colors.BlueGrey.Medium);
                           table.Cell().Element(CellStyle).Text("-").Style(contentStyle)
                           .FontSize(12).FontColor(Colors.BlueGrey.Medium);
                       }
                       else
                       {
                           table.Cell().RowSpan(count).Element(CellStyle).ShowOnce().Text(item.Title).Style(contentStyle);
                           table.Cell().RowSpan(count).Element(CellStyle).Text(item.OutputDate.ToString("dd/MM/yyyy")).Style(contentStyle);

                           int colorNum = 0;

                           foreach (var product in item.OutputRequestProducts)
                           {
                               var numberOfDaily = item.DailyProductions
                               .Where(x => x.DailyProductionDetails.Any(y => y.ProductId == product.ProductId))
                               .Count();

                               if (numberOfDaily != 0)
                               {
                                   if (colorNum == 0)
                                   {
                                       table.Cell().RowSpan((uint)numberOfDaily).Element(CellStyle)
                                       .Text(text =>
                                       {
                                           text.Span(product.Product.Name).FontSize(11).FontColor(Colors.BlueGrey.Medium).Style(contentStyle);
                                           text.Span(" / " + L("CanProduce", Language) + ": ").FontSize(11).FontColor(Colors.BlueGrey.Medium).Style(contentStyle);
                                           text.Span(product.CanProduce.ToString()).FontSize(11).FontColor(Colors.BlueGrey.Medium).Style(contentStyle);
                                       });

                                       foreach (var dailyProduction in item.DailyProductions)
                                       {
                                           colorNum = 1;
                                           table.Cell().Element(CellStyle)
                                           .Text(text =>
                                            {
                                                text.Span(dailyProduction.CreationTime.ToString("dd/MM/yyyy")).FontSize(9).FontColor(Colors.BlueGrey.Medium).Style(contentStyle);
                                                text.Span(" - " + L("Produced", Language) + ": ").FontSize(9).FontColor(Colors.BlueGrey.Medium).Style(contentStyle);
                                                text.Span(dailyProduction.DailyProductionDetails.FirstOrDefault(z => z.ProductId == product.ProductId).Quantity.ToString()).FontSize(9).FontColor(Colors.BlueGrey.Medium).Style(contentStyle);
                                            });
                                       }
                                   }
                                   else
                                   {
                                       table.Cell().RowSpan((uint)numberOfDaily).Element(CellStyle)
                                       .Text(text =>
                                       {
                                           text.Span(product.Product.Name).FontSize(11).FontColor(Colors.LightBlue.Accent4).Style(contentStyle);
                                           text.Span(" / " + L("CanProduce", Language) + ": ").FontSize(11).FontColor(Colors.LightBlue.Accent4).Style(contentStyle);
                                           text.Span(product.CanProduce.ToString()).FontSize(11).FontColor(Colors.LightBlue.Accent4).Style(contentStyle);
                                       });

                                       foreach (var dailyProduction in item.DailyProductions)
                                       {
                                           colorNum = 0;
                                           table.Cell().Element(CellStyle)
                                           .Text(text =>
                                            {
                                                text.Span(dailyProduction.CreationTime.ToString("dd/MM/yyyy")).FontSize(9).FontColor(Colors.LightBlue.Accent4).Style(contentStyle);
                                                text.Span(" - " + L("Produced", Language) + ": ").FontSize(9).FontColor(Colors.LightBlue.Accent4).Style(contentStyle);
                                                text.Span(dailyProduction.DailyProductionDetails.FirstOrDefault(z => z.ProductId == product.ProductId).Quantity.ToString()).FontSize(9).FontColor(Colors.LightBlue.Accent4).Style(contentStyle);
                                            });
                                       }
                                   }
                               }
                               else
                               {
                                   table.Cell().Element(CellStyle)
                                   .Text(text =>
                                   {
                                       text.Span(product.Product.Name).FontSize(11).FontColor(Colors.BlueGrey.Medium).Style(contentStyle);
                                       text.Span(" / " + L("CanProduce", Language) + ": ").FontSize(11).FontColor(Colors.BlueGrey.Medium).Style(contentStyle);
                                       text.Span(product.CanProduce.ToString()).FontSize(11).FontColor(Colors.BlueGrey.Medium).Style(contentStyle);
                                   });

                                   foreach (var dailyProduction in item.DailyProductions)
                                   {
                                       table.Cell().Element(CellStyle).Text("-").Style(contentStyle)
                                       .FontSize(7).FontColor(Colors.BlueGrey.Medium);
                                   }
                               }
                           }
                       }
                   }
                   IContainer CellStyle(IContainer container1) => container1.Border(1).BorderColor(Colors.Grey.Lighten2).PaddingVertical(5).AlignCenter().AlignMiddle();

               });

                page.Footer().AlignCenter().Text(text =>
                {
                    text.CurrentPageNumber();
                    text.Span(" / ");
                    text.TotalPages();
                });
            });
        }
        #endregion
    }
}

using AlcaldiaAraucaPortalWeb.Data.Entities.Afil;
using AlcaldiaAraucaPortalWeb.Helpers.Afil;
using AlcaldiaAraucaPortalWeb.Helpers.Gene;
using AlcaldiaAraucaPortalWeb.Models.Gene;
using AlcaldiaAraucaPortalWeb.Models.ModelsViewRepo;
using iTextSharp.text;
using iTextSharp.text.pdf;

namespace AlcaldiaAraucaPortalWeb.Helpers.Pdf
{
    public class PdfDocumentHelper : IPdfDocumentHelper
    {
        private readonly IAffiliateProfessionHelper _affiliateProfession; 
        private readonly IAffiliateGroupProductiveHelper _affiliateGroupProductive; 
        private readonly IAffiliateGroupCommunityHelper _affiliateGroupCommunity; 
        private readonly IAffiliateSocialNetworkHelper _affiliateSocialNetwork;
        private readonly IUserHelper _userHelper;

        private readonly IWebHostEnvironment _env;

        private Document doc = new Document(PageSize.A4, 28f, 25f, 20f, 40f);
        private MemoryStream ms = new MemoryStream();
        private PdfWriter write;
        private BaseFont fontCourier = BaseFont.CreateFont(BaseFont.COURIER, BaseFont.CP1250, true);
        private BaseFont fontHelveti = BaseFont.CreateFont(BaseFont.HELVETICA, BaseFont.CP1250, true);
        private iTextSharp.text.Font paragraph9;
        private iTextSharp.text.Font theader;

        private PdfPTable myTable;
        private iTextSharp.text.Font _titles12;


        private iTextSharp.text.Image logo;

        public PdfDocumentHelper(IWebHostEnvironment env,
                IAffiliateProfessionHelper affiliateProfession,
                IAffiliateGroupProductiveHelper affiliateGroupProductive,
                IAffiliateGroupCommunityHelper affiliateGroupCommunity,
                IAffiliateSocialNetworkHelper affiliateSocialNetwork,
                IUserHelper userHelper)
        {
            _env = env;
            write = PdfWriter.GetInstance(doc, ms);
            _titles12 = new iTextSharp.text.Font(fontHelveti, 12f, iTextSharp.text.Font.BOLD, new BaseColor(0, 127, 0));
            logo = iTextSharp.text.Image.GetInstance(Path.Combine(_env.WebRootPath, "Image", "Imagen01.png"));

            doc.AddAuthor("araucactiva");
            float proporcion = logo.Width / logo.Height;
            logo.ScaleAbsoluteWidth(150);
            logo.ScaleAbsoluteHeight(40 * proporcion);
            logo.SetAbsolutePosition(0, 567f);

            myTable = new PdfPTable(new float[] { 50f, 50f }) { WidthPercentage = 100f };

            paragraph9 = new iTextSharp.text.Font(fontHelveti, 9f, iTextSharp.text.Font.NORMAL, new BaseColor(0, 0, 0));
            theader = new iTextSharp.text.Font(fontCourier, 12f, iTextSharp.text.Font.BOLD, new BaseColor(140, 40, 74));


            myTable.AddCell(new PdfPCell(logo) { Border = 0, Rowspan = 4, VerticalAlignment = Element.ALIGN_MIDDLE });
            myTable.AddCell(new PdfPCell(new Phrase("Araucactiva", paragraph9)) { Border = 0, HorizontalAlignment = Element.ALIGN_RIGHT });
            myTable.AddCell(new PdfPCell(new Phrase("Alcaldia de Arauca", paragraph9)) { Border = 0, HorizontalAlignment = Element.ALIGN_RIGHT });
            myTable.AddCell(new PdfPCell(new Phrase("Calle 20 con carrera 24", paragraph9)) { Border = 0, HorizontalAlignment = Element.ALIGN_RIGHT });
            myTable.AddCell(new PdfPCell(new Phrase(DateTime.Now.ToString("dd/MMM/yyyy"), paragraph9)) { Border = 0, HorizontalAlignment = Element.ALIGN_RIGHT });
            _affiliateProfession = affiliateProfession;
            _affiliateGroupProductive = affiliateGroupProductive;
            _affiliateGroupCommunity = affiliateGroupCommunity;
            _affiliateSocialNetwork = affiliateSocialNetwork;
            _userHelper = userHelper;
        }

        public async Task<MemoryStream> StatisticsAsync(int id, string title, string idOp = "")
        {
            doc.AddTitle(title);

            write.PageEvent = new PageEventHelper();

            doc.Open();

            doc.Add(myTable);

            doc.Add(new Phrase(" "));


            myTable = new PdfPTable(new float[] { 100f }) { WidthPercentage = 100f };
            myTable.AddCell(new PdfPCell(new Phrase($"Estadística por {title.ToLower()}", _titles12)) { Border = 0, HorizontalAlignment = Element.ALIGN_CENTER, VerticalAlignment = Element.ALIGN_MIDDLE });
            doc.Add(myTable);
            doc.Add(new Phrase("\n"));



            if (title == "Profesión" || title == "Grupo productivo" || title == "Grupo comunitario" || title == "Red social")
            {
                myTable = new PdfPTable(new float[] { 80f, 20f }) { WidthPercentage = 100f };
                PdfPCell pdfPCell1 = new PdfPCell(new Phrase(title, theader)) { Border = 0, BorderColorTop = new BaseColor(195, 195, 195), BorderWidthTop = 1.99f, HorizontalAlignment = Element.ALIGN_LEFT, PaddingTop = 8f, PaddingBottom = 8f };
                PdfPCell pdfPCell2 = new PdfPCell(new Phrase("Total", theader)) { Border = 0, BorderColorTop = new BaseColor(195, 195, 195), BorderWidthTop = 1.99f, HorizontalAlignment = Element.ALIGN_CENTER, PaddingTop = 8f, PaddingBottom = 8f };
                myTable.AddCell(pdfPCell1);
                myTable.AddCell(pdfPCell2);

                await AfiliateStatistics(id, title, pdfPCell1, pdfPCell2);
            }
            else
            {
                myTable = new PdfPTable(new float[] { 13f, 16f,26F,16F,13F,16F }) { WidthPercentage = 100f };
                await UsuariosRoles(idOp, title);
            }
            
            doc.Add(myTable);

            doc.Close();

            write.Close();

            return ms;

        }

        private async Task UsuariosRoles(string id, string title)
        {
            int cont = 1;
            List<UsersViewModel> model = await _userHelper.ListAsync(id);

            PdfPCell pdfPCell1 = new PdfPCell(new Phrase("Documento", theader)) { Border = 0, BorderColorTop = new BaseColor(195, 195, 195), BorderWidthTop = 1.99f, HorizontalAlignment = Element.ALIGN_LEFT, PaddingTop = 8f, PaddingBottom = 8f };
            PdfPCell pdfPCell2 = new PdfPCell(new Phrase("Tipo", theader)) { Border = 0, BorderColorTop = new BaseColor(195, 195, 195), BorderWidthTop = 1.99f, HorizontalAlignment = Element.ALIGN_CENTER, PaddingTop = 8f, PaddingBottom = 8f };
            PdfPCell pdfPCell3 = new PdfPCell(new Phrase("Nombre", theader)) { Border = 0, BorderColorTop = new BaseColor(195, 195, 195), BorderWidthTop = 1.99f, HorizontalAlignment = Element.ALIGN_CENTER, PaddingTop = 8f, PaddingBottom = 8f };
            PdfPCell pdfPCell4 = new PdfPCell(new Phrase("Email", theader)) { Border = 0, BorderColorTop = new BaseColor(195, 195, 195), BorderWidthTop = 1.99f, HorizontalAlignment = Element.ALIGN_CENTER, PaddingTop = 8f, PaddingBottom = 8f };
            PdfPCell pdfPCell5 = new PdfPCell(new Phrase("Genero", theader)) { Border = 0, BorderColorTop = new BaseColor(195, 195, 195), BorderWidthTop = 1.99f, HorizontalAlignment = Element.ALIGN_CENTER, PaddingTop = 8f, PaddingBottom = 8f };
            PdfPCell pdfPCell6 = new PdfPCell(new Phrase("Dirección", theader)) { Border = 0, BorderColorTop = new BaseColor(195, 195, 195), BorderWidthTop = 1.99f, HorizontalAlignment = Element.ALIGN_CENTER, PaddingTop = 8f, PaddingBottom = 8f };

            myTable.AddCell(pdfPCell1);
            myTable.AddCell(pdfPCell2);
            myTable.AddCell(pdfPCell3);
            myTable.AddCell(pdfPCell4);
            myTable.AddCell(pdfPCell5);
            myTable.AddCell(pdfPCell6);

            foreach (var item in model)
            {
                pdfPCell1.Phrase = new Phrase(item.Document, paragraph9);
                pdfPCell1.Border = 0;

                pdfPCell2.Phrase = new Phrase(item.DocumentTypeName, paragraph9);
                pdfPCell2.Border = 0;

                pdfPCell3.Phrase = new Phrase($"{item.FirstName} {item.LastName}", paragraph9);
                pdfPCell3.Border = 0;

                pdfPCell4.Phrase = new Phrase(item.Email, paragraph9);
                pdfPCell4.Border = 0;

                pdfPCell5.Phrase = new Phrase(item.GenderName, paragraph9);
                pdfPCell5.Border = 0;

                pdfPCell6.Phrase = new Phrase(item.Address, paragraph9);
                pdfPCell6.Border = 0;


                if (cont % 2 == 0)
                {
                    pdfPCell1.BackgroundColor = BaseColor.WHITE;
                    pdfPCell2.BackgroundColor = BaseColor.WHITE;
                    pdfPCell3.BackgroundColor = BaseColor.WHITE;
                    pdfPCell4.BackgroundColor = BaseColor.WHITE;
                    pdfPCell5.BackgroundColor = BaseColor.WHITE;
                    pdfPCell6.BackgroundColor = BaseColor.WHITE;
                }
                else
                {
                    pdfPCell1.BackgroundColor = new BaseColor(248, 248, 248);
                    pdfPCell2.BackgroundColor = new BaseColor(248, 248, 248);
                    pdfPCell3.BackgroundColor = new BaseColor(248, 248, 248);
                    pdfPCell4.BackgroundColor = new BaseColor(248, 248, 248);
                    pdfPCell5.BackgroundColor = new BaseColor(248, 248, 248);
                    pdfPCell6.BackgroundColor = new BaseColor(248, 248, 248);
                }

                myTable.AddCell(pdfPCell1);
                myTable.AddCell(pdfPCell2);
                myTable.AddCell(pdfPCell3);
                myTable.AddCell(pdfPCell4);
                myTable.AddCell(pdfPCell5);
                myTable.AddCell(pdfPCell6);

                cont++;
            }

        }

        private async Task AfiliateStatistics(int id, string title, PdfPCell pdfPCell1, PdfPCell pdfPCell2)
        {
            int cont = 1;

            List<StatisticsViewModel> model = title== "Profesión" ? 
                                                await _affiliateProfession.StatisticsAsync(id):
                                              title == "Grupo productivo" ?
                                                await _affiliateGroupProductive.StatisticsAsync(id):
                                              title == "Grupo comunitario" ?
                                                await _affiliateGroupCommunity.StatisticsAsync(id):
                                                await _affiliateSocialNetwork.StatisticsAsync(id);

            foreach (var item in model)
            {
                pdfPCell1.Phrase = new Phrase(item.Name, paragraph9);
                pdfPCell1.Border = 0;

                pdfPCell2.Phrase = new Phrase(item.Total.ToString("N"), paragraph9);
                pdfPCell2.Border = 0;

                if (cont % 2 == 0)
                {
                    pdfPCell1.BackgroundColor = BaseColor.WHITE;
                    pdfPCell2.BackgroundColor = BaseColor.WHITE;
                }
                else
                {
                    pdfPCell1.BackgroundColor = new BaseColor(248, 248, 248);
                    pdfPCell2.BackgroundColor = new BaseColor(248, 248, 248);
                }

                myTable.AddCell(pdfPCell1);
                myTable.AddCell(pdfPCell2);

                cont++;
            }
        }

    }
}

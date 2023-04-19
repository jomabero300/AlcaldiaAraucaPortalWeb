using AlcaldiaAraucaPortalWeb.Data;
using AlcaldiaAraucaPortalWeb.Data.Entities.Gene;
using AlcaldiaAraucaPortalWeb.Models.Gene;
using Microsoft.EntityFrameworkCore;

namespace AlcaldiaAraucaPortalWeb.Helpers.Gene
{
    public class DocumentTypeHelper : IDocumentTypeHelper
    {
        private readonly ApplicationDbContext _context;

        public DocumentTypeHelper(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<Response> AddUpdateAsync(DocumentType model)
        {
            if (model.DocumentTypeId == 0)
            {
                _context.DocumentTypes.Add(model);
            }
            else
            {
                _context.DocumentTypes.Update(model);
            }


            var response = new Response() { Succeeded = true };

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException dbUpdateException)
            {
                if (dbUpdateException.InnerException.Message.Contains("duplica"))
                {
                    response.Message = $"Ya existe una registro con el mismo nombre.!!!";
                }
                else
                {
                    response.Message = dbUpdateException.InnerException.Message;
                }

                response.Succeeded = false;
            }
            catch (Exception exception)
            {
                response.Message = exception.Message;

                response.Succeeded = false;
            }

            return response;
        }

        public async Task<DocumentType> ByIdAsync(int id)
        {
            var model = await _context.DocumentTypes.FirstOrDefaultAsync(a => a.DocumentTypeId == id);

            return model;
        }

        public async Task<DocumentType> ByIdNameAsync(string name)
        {
            var model = await _context.DocumentTypes.FirstOrDefaultAsync(a => a.DocumentTypeName == name);

            return model;
        }

        public async Task<List<DocumentType>> ComboAsync()
        {
            List<DocumentType> model = await _context.DocumentTypes.ToListAsync();

            model.Add(new DocumentType { DocumentTypeId = 0, DocumentTypeName = "[Seleccione un documento..]" });

            return model.OrderBy(m => m.DocumentTypeName).ToList();
        }

        public async Task<Response> DeleteAsync(int id)
        {
            var response = new Response() { Succeeded = true };

            var model = await _context.DocumentTypes.Where(a => a.DocumentTypeId == id).FirstOrDefaultAsync();

            try
            {
                _context.DocumentTypes.Remove(model);
            }
            catch (Exception ex)
            {
                response.Succeeded = false;

                if (ex.InnerException.Message.Contains("REFERENCE"))
                {
                    response.Message = "No se puede borrar tipo de documento, porque tiene registros relacionados";
                }
                else
                {
                    response.Message = ex.Message;
                }
            }

            return response;
        }

        public async Task<List<DocumentType>> ListAsync()
        {
            List<DocumentType> model = await _context.DocumentTypes.ToListAsync();

            return model.OrderBy(m => m.DocumentTypeName).ToList();
        }
    }
}

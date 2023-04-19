using AlcaldiaAraucaPortalWeb.Data;
using AlcaldiaAraucaPortalWeb.Data.Entities.Gene;
using AlcaldiaAraucaPortalWeb.Models.Gene;
using Microsoft.EntityFrameworkCore;

namespace AlcaldiaAraucaPortalWeb.Helpers.Gene
{
    public class GenderHelper : IGenderHelper
    {
        private readonly ApplicationDbContext _context;

        public GenderHelper(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<Response> AddUpdateAsync(Gender model)
        {
            if (model.GenderId == 0)
            {
                _context.Genders.Add(model);
            }
            else
            {
                _context.Genders.Update(model);
            }
            Response response = new Response() { Succeeded = true };
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

        public async Task<Gender> ByIdAsync(int id)
        {
            var model = await _context.Genders.FirstOrDefaultAsync(a => a.GenderId == id);

            return model;
        }

        public async Task<Gender> ByIdNameAsync(string name)
        {
            var model = await _context.Genders.FirstOrDefaultAsync(a => a.GenderName == name);

            return model;
        }

        public async Task<List<Gender>> ComboAsync()
        {
            List<Gender> model = await _context.Genders.ToListAsync();

            model.Add(new Gender { GenderId = 0, GenderName = "[Seleccione un genero..]" });

            return model.OrderBy(m => m.GenderName).ToList();
        }

        public async Task<Response> DeleteAsync(int id)
        {
            var response = new Response() { Succeeded = true };

            var model = await _context.Genders.Where(a => a.GenderId == id).FirstOrDefaultAsync();

            try
            {
                _context.Genders.Remove(model);
            }
            catch (Exception ex)
            {
                response.Succeeded = false;

                if (ex.InnerException.Message.Contains("REFERENCE"))
                {
                    response.Message = "No se puede borrar este genero, porque tiene registros relacionados";

                }
                else
                {
                    response.Message = ex.Message;
                }
            }

            return response;
        }

        public async Task<List<Gender>> ListAsync()
        {
            var model = await _context.Genders.ToListAsync();

            return model.OrderBy(m => m.GenderName).ToList();
        }
    }
}

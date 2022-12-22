using AlcaldiaAraucaPortalWeb.Data;
using AlcaldiaAraucaPortalWeb.Data.Entities.Afil;
using AlcaldiaAraucaPortalWeb.Helpers.Gene;
using AlcaldiaAraucaPortalWeb.Models.Gene;
using Microsoft.EntityFrameworkCore;

namespace AlcaldiaAraucaPortalWeb.Helpers.Afil
{
    public class ProfessionHelper : IProfessionHelper
    {
        private readonly ApplicationDbContext _context;
        private readonly IUtilitiesHelper _utilitiesHelper;

        public ProfessionHelper(ApplicationDbContext context, IUtilitiesHelper utilitiesHelper)
        {
            _context = context;
            _utilitiesHelper = utilitiesHelper;
        }

        public async Task<Response> AddUpdateAsync(Profession model)
        {
            model.ProfessionName= _utilitiesHelper.StartCharacterToUpper(model.ProfessionName);

            if (model.ProfessionId == 0)
            {
                _context.Professions.Add(model);
            }
            else
            {
                _context.Professions.Update(model);
            }
            var response = new Response() { Succeeded = true };
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                response.Succeeded = false;
                response.Message = ex.Message;
            }

            return response;

        }

        public async Task<List<Profession>> ByIdAffiliateAsync(int id)
        {
            var group = await _context.AffiliateProfessions.Where(a => a.AffiliateId == id).Select(a => a.ProfessionId).ToListAsync();

            var model = await _context.Professions.Where(g => !group.Contains(g.ProfessionId)).ToListAsync();

            model.Add(new Profession { ProfessionId = 0, ProfessionName = "[Seleccione una profesión..]" });

            return model.OrderBy(g => g.ProfessionName).ToList();
        }

        public async Task<Profession> ByIdAsync(int id)
        {
            var model = await _context.Professions.Include(g => g.State).FirstOrDefaultAsync(a => a.ProfessionId == id);

            return model;
        }

        public async Task<List<Profession>> ComboAsync()
        {
            var model = await _context.Professions.Include(P => P.State).Where(p => p.State.StateName.Equals("Activo")).ToListAsync();

            model.Add(new Profession { ProfessionId = 0, ProfessionName = "[Seleccione una profesión..]" });

            return model.OrderBy(m => m.ProfessionName).ToList();
        }

        public async Task<List<Profession>> ComboAsync(string[] GroupProfession, bool lbEsta)
        {
            List<Profession> model = GroupProfession!=null ?
                await _context.Professions.Where(g => g.State.StateName.Equals("Activo") && !GroupProfession.Contains(g.ProfessionName)).ToListAsync() :
                 await _context.Professions.Where(g => g.State.StateName.Equals("Activo") ).ToListAsync();
            string titulo = lbEsta ? "[Seleccione una profesión..]" : "[Todas las profesiones..]";
            model.Add(new Profession { ProfessionId = 0, ProfessionName = titulo });

            return model.OrderBy(m => m.ProfessionName).ToList();

        }

        public async Task<Response> DeleteAsync(int id)
        {
            var response = new Response() { Succeeded = true };

            var model = await _context.Professions.Where(a => a.ProfessionId == id).FirstOrDefaultAsync();

            try
            {
                _context.Professions.Remove(model);

                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                response.Succeeded = false;
                response.Message = ex.Message.Contains("REFERENCE") ? "No se puede borrar la categoría porque tiene registros relacionados" : ex.Message;
            }

            return response;
        }

        public async Task<List<Profession>> ListAsync()
        {
            var model = await _context.Professions.Include(g => g.State).ToListAsync();

            return model.OrderBy(m => m.ProfessionName).ToList();
        }
    }
}

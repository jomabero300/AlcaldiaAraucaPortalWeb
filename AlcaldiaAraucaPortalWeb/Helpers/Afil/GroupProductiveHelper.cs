using AlcaldiaAraucaPortalWeb.Data;
using AlcaldiaAraucaPortalWeb.Data.Entities.Afil;
using AlcaldiaAraucaPortalWeb.Helpers.Gene;
using AlcaldiaAraucaPortalWeb.Models.Gene;
using AlcaldiaAraucaPortalWeb.Models.ModelsViewAfil;
using Microsoft.EntityFrameworkCore;

namespace AlcaldiaAraucaPortalWeb.Helpers.Afil
{
    public class GroupProductiveHelper : IGroupProductiveHelper
    {
        private readonly ApplicationDbContext _context;
        private readonly IUtilitiesHelper _utilitiesHelper;

        public GroupProductiveHelper(ApplicationDbContext context, IUtilitiesHelper utilitiesHelper)
        {
            _context = context;
            _utilitiesHelper = utilitiesHelper;
        }

        public async Task<Response> AddUpdateAsync(GroupProductive model)
        {
            model.GroupProductiveName= _utilitiesHelper.StartCharacterToUpper(model.GroupProductiveName);

            if (model.GroupProductiveId == 0)
            {
                _context.GroupProductives.Add(model);
            }
            else
            {
                _context.GroupProductives.Update(model);
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

        public async Task<List<GroupProductive>> ByIdAffiliateAsync(int id)
        {
            var affiliateGrupoProductive = await _context.AffiliateGroupProductives.Where(a => a.AffiliateId == id).Select(a => a.GroupProductiveId).ToListAsync();

            var model = await _context.GroupProductives.Where(g => !affiliateGrupoProductive.Contains(g.GroupProductiveId)).ToListAsync();

            model.Add(new GroupProductive { GroupProductiveId = 0, GroupProductiveName = "[Seleccione un Grupo..]" });

            return model.OrderBy(g => g.GroupProductiveName).ToList();
        }

        public async Task<GroupProductive> ByIdAsync(int id)
        {
            var model = await _context.GroupProductives.Include(g => g.State).FirstOrDefaultAsync(a => a.GroupProductiveId == id);

            return model;
        }

        public async Task<List<GroupProductive>> ComboAsync()
        {
            var model = await _context.GroupProductives.Where(g => g.State.StateName.Equals("Activo")).ToListAsync();

            model.Add(new GroupProductive { GroupProductiveId = 0, GroupProductiveName = "[Seleccione un Grupo..]" });

            return model.OrderBy(m => m.GroupProductiveName).ToList();
        }

        public async Task<List<GroupProductive>> ComboAsync(string[] groupProductives, bool lbEsta)
        {

            List<GroupProductive> model = groupProductives!=null ?
                await _context.GroupProductives.Where(g => g.State.StateName.Equals("Activo") && !groupProductives.Contains(g.GroupProductiveName)).ToListAsync():
                await _context.GroupProductives.Where(g => g.State.StateName.Equals("Activo")).ToListAsync();
            string Ltname = lbEsta ? "[Seleccione un grupo productivo..]" : "[Todos los Grupo..]";
            model.Add(new GroupProductive { GroupProductiveId = 0, GroupProductiveName = Ltname });

            return model.OrderBy(m => m.GroupProductiveName).ToList();
        }

        public async Task<Response> DeleteAsync(int id)
        {
            var response = new Response() { Succeeded = true };

            var model = await _context.GroupProductives.Where(a => a.GroupProductiveId == id).FirstOrDefaultAsync();

            try
            {
                _context.GroupProductives.Remove(model);

                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                response.Succeeded = false;

                if (ex.InnerException.Message.Contains("REFERENCE"))
                {
                    response.Message = "No se puede borrar este grupo productivo, porque tiene registros relacionados";
                }
                else
                {
                    response.Message = ex.Message;
                }
            }

            return response;
        }

        public async Task<List<GroupProductive>> ListAsync()
        {
            var model = await _context.GroupProductives.Include(g => g.State).ToListAsync();

            return model.OrderBy(m => m.GroupProductiveName).ToList();
        }

        public async Task<AffiliateGroupProductiveViewModelsFilter> ListAsync(int RowsCant, int OmitCant, string SearchText = "")
        {
            AffiliateGroupProductiveViewModelsFilter model = new AffiliateGroupProductiveViewModelsFilter();

            IQueryable<GroupProductive> query = _context.GroupProductives.Include(g=>g.State);

            int Rows = query.Count();

            if(!string.IsNullOrEmpty(SearchText))
            {
                query = query
                    .Where(p => p.GroupProductiveName.Contains(SearchText));
            }
            model.RowsFilterTotal = query.Count();

            model.GroupProductives = await query.Skip(OmitCant).Take(RowsCant).ToListAsync();

            return model;
        }
    }
}

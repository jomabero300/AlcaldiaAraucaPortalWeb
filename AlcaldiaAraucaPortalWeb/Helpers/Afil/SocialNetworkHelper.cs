using AlcaldiaAraucaPortalWeb.Data;
using AlcaldiaAraucaPortalWeb.Data.Entities.Afil;
using AlcaldiaAraucaPortalWeb.Helpers.Gene;
using AlcaldiaAraucaPortalWeb.Models.Gene;
using AlcaldiaAraucaPortalWeb.Models.ModelsViewAfil;
using Microsoft.EntityFrameworkCore;

namespace AlcaldiaAraucaPortalWeb.Helpers.Afil
{
    public class SocialNetworkHelper : ISocialNetworkHelper
    {
        private readonly ApplicationDbContext _context;
        private readonly IUtilitiesHelper _utilitiesHelper;

        public SocialNetworkHelper(ApplicationDbContext context, IUtilitiesHelper utilitiesHelper)
        {
            _context = context;
            _utilitiesHelper = utilitiesHelper;
        }

        public async Task<Response> AddUpdateAsync(SocialNetwork model)
        {
            model.SocialNetworkName= _utilitiesHelper.StartCharacterToUpper(model.SocialNetworkName);

            if (model.SocialNetworkId == 0)
            {
                _context.SocialNetworks.Add(model);
            }
            else
            {
                _context.SocialNetworks.Update(model);
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

        public async Task<SocialNetwork> ByIdAsync(int id)
        {
            SocialNetwork model = await _context.SocialNetworks.FindAsync(id);

            return model;
        }

        public Task<SocialNetwork> ByIdNameAsync(string name)
        {
            throw new NotImplementedException();
        }

        public async Task<List<SocialNetwork>> ComboAsync()
        {
            List<SocialNetwork> model = await _context.SocialNetworks.ToListAsync();

            model.Add(new SocialNetwork { SocialNetworkId = 0, SocialNetworkName = "[Seleccione una red social..]" });

            return model.OrderBy(m => m.SocialNetworkName).ToList();
        }

        public async Task<List<SocialNetwork>> ComboAsync(string[] socialNetworkName,bool lbEsta)
        {
            string ltname = lbEsta ? "[Seleccione una red social..]" : "[Todas las redes sociales..]";
            List <SocialNetwork> model = socialNetworkName!=null?
                            await _context.SocialNetworks.Where(s => !socialNetworkName.Contains(s.SocialNetworkName)).ToListAsync():
                            await _context.SocialNetworks.ToListAsync();

            model.Add(new SocialNetwork { SocialNetworkId = 0, SocialNetworkName = ltname });

            return model.OrderBy(m => m.SocialNetworkName).ToList();
        }

        public async Task<List<SocialNetwork>> ComboAsync(int affiliatId)
        {
            List<int> group = await _context.AffiliateSocialNetworks.Where(a => a.AffiliateId == affiliatId).Select(a => a.SocialNetworkId).ToListAsync();

            List<SocialNetwork> model = await _context.SocialNetworks.Where(g => !group.Contains(g.SocialNetworkId)).ToListAsync();

            model.Add(new SocialNetwork { SocialNetworkId = 0, SocialNetworkName = "[Seleccione un red social..]" });

            return model.OrderBy(g => g.SocialNetworkName).ToList();
        }

        public async Task<Response> DeleteAsync(int id)
        {
            var response = new Response() { Succeeded = true };

            var model = await _context.SocialNetworks.Where(a => a.SocialNetworkId == id).FirstOrDefaultAsync();

            try
            {
                _context.SocialNetworks.Remove(model);

                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                response.Succeeded = false;

                if (ex.InnerException.Message.Contains("REFERENCE"))
                {
                    response.Message = "No se puede borrar la red social, porque tiene registros relacionados";
                }
                else
                {
                    response.Message = ex.Message;
                }
            }

            return response;
        }

        public async Task<List<SocialNetwork>> ListAsync()
        {
            List<SocialNetwork> model =await _context.SocialNetworks.ToListAsync();

            return model.OrderBy(s=>s.SocialNetworkName).ToList();
        }

        public async Task<AffiliateSocialNetworkViewModelsFilter> ListAsync(int RowsCant, int OmitCant, string SearchText = "")
        {
            AffiliateSocialNetworkViewModelsFilter model = new AffiliateSocialNetworkViewModelsFilter();

            IQueryable<SocialNetwork> query = _context.SocialNetworks.Include(g => g.State);

            int Rows = query.Count();
            if (!string.IsNullOrEmpty(SearchText))
            {
                query = query
                    .Where(p => p.SocialNetworkName.Contains(SearchText));
            }
            model.RowsFilterTotal = query.Count();

            model.SocialNetworks = await query.Skip(OmitCant).Take(RowsCant).ToListAsync();

            return model;
        }
    }
}

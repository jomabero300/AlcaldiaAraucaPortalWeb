using AlcaldiaAraucaPortalWeb.Data;
using AlcaldiaAraucaPortalWeb.Data.Entities.Afil;
using AlcaldiaAraucaPortalWeb.Helpers.Gene;
using AlcaldiaAraucaPortalWeb.Models.Gene;
using AlcaldiaAraucaPortalWeb.Models.ModelsViewAfil;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design.Internal;

namespace AlcaldiaAraucaPortalWeb.Helpers.Afil
{
    public class GroupCommunityHelper : IGroupCommunityHelper
    {
        private readonly ApplicationDbContext _context;
        private readonly IUtilitiesHelper _utilitiesHelper;

        public GroupCommunityHelper(ApplicationDbContext context, IUtilitiesHelper utilitiesHelper)
        {
            _context = context;
            _utilitiesHelper = utilitiesHelper;
        }

        public async Task<Response> AddUpdateAsync(GroupCommunity model)
        {
            model.GroupCommunityName= _utilitiesHelper.StartCharacterToUpper(model.GroupCommunityName);

            if (model.GroupCommunityId == 0)
            {
                _context.GroupCommunities.Add(model);
            }
            else
            {
                _context.GroupCommunities.Update(model);
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

        public async Task<List<GroupCommunity>> ByIdAffiliateAsync(int id)
        {
            var group = await _context.AffiliateGroupCommunities.Where(a => a.AffiliateId == id).Select(a => a.GroupCommunityId).ToListAsync();

            var model = await _context.GroupCommunities.Where(g => !group.Contains(g.GroupCommunityId)).ToListAsync();

            model.Add(new GroupCommunity { GroupCommunityId = 0, GroupCommunityName = "[Seleccione un grupo comunitario..]" });

            return model.OrderBy(g => g.GroupCommunityName).ToList();
        }

        public async Task<GroupCommunity> ByIdAsync(int id)
        {
            var model = await _context.GroupCommunities.Include(g => g.State).FirstOrDefaultAsync(a => a.GroupCommunityId == id);

            return model;
        }

        public async Task<List<GroupCommunity>> ComboAsync()
        {
            var model = await _context.GroupCommunities.Where(g => g.State.StateName.Equals("Activo")).ToListAsync();

            model.Add(new GroupCommunity { GroupCommunityId = 0, GroupCommunityName = "[Seleccione un grupo comunitario..]" });

            return model.OrderBy(m => m.GroupCommunityName).ToList();
        }

        public async Task<List<GroupCommunity>> ComboAsync(string[] GroupCommunity,bool lbEsta)
        {
            string lsName = lbEsta ? "[Seleccione un grupo comunitario..]" : "[Todos los grupo comunitarios..]";

            List<GroupCommunity> model = GroupCommunity!= null? 
                                    await _context.GroupCommunities.Where(g => g.State.StateName.Equals("Activo") && !GroupCommunity.Contains(g.GroupCommunityName)).ToListAsync():
                                    await _context.GroupCommunities.Where(g => g.State.StateName.Equals("Activo"))
                                 .ToListAsync();

            model.Add(new GroupCommunity { GroupCommunityId = 0, GroupCommunityName = lsName });

            return model.OrderBy(m => m.GroupCommunityName).ToList();
        }

        public async Task<Response> DeleteAsync(int id)
        {
            var response = new Response() { Succeeded = true };

            var model = await _context.GroupCommunities.Where(a => a.GroupCommunityId == id).FirstOrDefaultAsync();

            try
            {
                _context.Remove(model);
                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                response.Succeeded = false;
                response.Message = ex.Message.Contains("REFERENCE") ? "No se puede borrar la categoría porque tiene registros relacionados" : ex.Message;
            }

            return response;
        }

        public async Task<List<GroupCommunity>> ListAsync()
        {
            var model = await _context.GroupCommunities.Include(g => g.State).ToListAsync();

            return model.OrderBy(m => m.GroupCommunityName).ToList();
        }

        public async Task<List<GroupCommunityViewModel>> StatisticsReportAsync(GroupCommunityViewModel model)
        {
            List<GroupCommunityViewModel> report = model.GroupCommunityId == 0 ?
                        await _context.AffiliateGroupCommunities
                                 .Include(g => g.GroupCommunity)
                                 .GroupBy(g => new { g.GroupCommunityId, g.GroupCommunity.GroupCommunityName })
                                .Select(g => new GroupCommunityViewModel { GroupCommunityId= g.Key.GroupCommunityId, GroupCommunityName=g.Key.GroupCommunityName, Total = g.Count() })
                                 .ToListAsync() :
                        await _context.AffiliateGroupCommunities
                                 .Include(g => g.GroupCommunity)
                                 .Where(g => g.GroupCommunityId == model.GroupCommunityId)
                                 .GroupBy(g => new { g.GroupCommunityId, g.GroupCommunity.GroupCommunityName })
                                .Select(g => new GroupCommunityViewModel { GroupCommunityId = g.Key.GroupCommunityId, GroupCommunityName = g.Key.GroupCommunityName, Total = g.Count() })
                                 .ToListAsync();

            return report;
        }
    }
}

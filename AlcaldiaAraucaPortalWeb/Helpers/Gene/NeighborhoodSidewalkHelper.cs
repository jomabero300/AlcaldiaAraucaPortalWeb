using AlcaldiaAraucaPortalWeb.Data;
using AlcaldiaAraucaPortalWeb.Data.Entities.Gene;
using Microsoft.EntityFrameworkCore;

namespace AlcaldiaAraucaPortalWeb.Helpers.Gene
{
    public class NeighborhoodSidewalkHelper : INeighborhoodSidewalkHelper
    {
        private readonly ApplicationDbContext _context;

        public NeighborhoodSidewalkHelper(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<NeighborhoodSidewalk> ByIdAsync(int id)
        {
            NeighborhoodSidewalk model = await _context.NeighborhoodSidewalks.Where(n => n.NeighborhoodSidewalkId == id).FirstOrDefaultAsync();

            return model;
        }

        public async Task<NeighborhoodSidewalk> ByIdNameAsync(string name)
        {
            NeighborhoodSidewalk model=await _context.NeighborhoodSidewalks.Where(n=>n.NeighborhoodSidewalkName==name).FirstOrDefaultAsync();

            return model;
        }

        public async Task<List<NeighborhoodSidewalk>> ComboAsync(int CommuneTownshipId)
        {
            List<NeighborhoodSidewalk> model = await _context.NeighborhoodSidewalks
                                                             .Where(g => g.CommuneTownshipId == CommuneTownshipId)
                                                             .ToListAsync();

            CommuneTownship zone = await _context.CommuneTownships.Include(c => c.Zone).Where(c => c.CommuneTownshipId == CommuneTownshipId).FirstOrDefaultAsync();

            string title = CommuneTownshipId.Equals(0) ? "[Seleccione una opcion anterior...]" : (zone.Zone.ZoneName.Equals("Urbano") ? "[Seleccione una barrio...]" : "[Seleccione una vereda...]");


            model.Add(new NeighborhoodSidewalk { NeighborhoodSidewalkId = 0, NeighborhoodSidewalkName = title });

            return model.OrderBy(m => m.NeighborhoodSidewalkName).ToList();
        }
    }
}

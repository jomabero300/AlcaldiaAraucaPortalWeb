using AlcaldiaAraucaPortalWeb.Data;
using AlcaldiaAraucaPortalWeb.Data.Entities.Gene;
using Microsoft.EntityFrameworkCore;

namespace AlcaldiaAraucaPortalWeb.Helpers.Gene
{
    public class CommuneTownshipHelper : ICommuneTownshipHelper
    {
        private readonly ApplicationDbContext _context;

        public CommuneTownshipHelper(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<CommuneTownship> ByIdAsync(int id)
        {
            return await _context.CommuneTownships.FindAsync(id);
        }

        public async Task<List<CommuneTownship>> ComboAsync(int zoneId)
        {
            List< CommuneTownship> model = await _context.CommuneTownships.Where(g => g.ZoneId == zoneId).ToListAsync();

            Zone zone = _context.Zones.Where(z => z.ZoneId == zoneId).FirstOrDefault();

            string title = zoneId.Equals(0) ? "[Seleccione una zona primero...]" : (zone.ZoneName.Equals("Urbano") ? "[Seleccione una comuna...]" : "[Seleccione un corregimiento...]");

            model.Add(new CommuneTownship { CommuneTownshipId = 0, CommuneTownshipName = title });

            return model.OrderBy(m => m.CommuneTownshipId).ToList();
        }
    }
}

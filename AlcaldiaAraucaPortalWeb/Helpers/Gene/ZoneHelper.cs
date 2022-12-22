using AlcaldiaAraucaPortalWeb.Data;
using AlcaldiaAraucaPortalWeb.Data.Entities.Gene;
using Microsoft.EntityFrameworkCore;

namespace AlcaldiaAraucaPortalWeb.Helpers.Gene
{
    public class ZoneHelper : IZoneHelper
    {
        private readonly ApplicationDbContext _context;

        public ZoneHelper(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<List<Zone>> ComboAsync()
        {
            var model = await _context.Zones.ToListAsync();

            model.Add(new Zone { ZoneId = 0, ZoneName = "[Seleccione una zona..]" });

            return model.OrderBy(m => m.ZoneName).ToList();
        }
    }
}

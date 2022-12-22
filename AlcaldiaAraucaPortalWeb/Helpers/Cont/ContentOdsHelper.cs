using AlcaldiaAraucaPortalWeb.Data;
using AlcaldiaAraucaPortalWeb.Data.Entities.Cont;
using Microsoft.EntityFrameworkCore;

namespace AlcaldiaAraucaPortalWeb.Helpers.Cont
{
    public class ContentOdsHelper : IContentOdsHelper
    {
        private readonly ApplicationDbContext _context;

        public ContentOdsHelper(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<List<ContentOds>> ByIdAsync(int SectorId)
        {
            var model = await _context.ContentOds.Where(c => c.PqrsStrategicLineSectorId == SectorId).ToListAsync();

            return model.OrderBy(c => c.ContentOdsId).ToList();

        }
    }
}

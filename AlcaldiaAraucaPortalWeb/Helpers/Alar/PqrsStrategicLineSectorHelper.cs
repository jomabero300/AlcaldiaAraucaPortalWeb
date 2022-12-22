using AlcaldiaAraucaPortalWeb.Data;
using AlcaldiaAraucaPortalWeb.Data.Entities.Alar;
using Microsoft.EntityFrameworkCore;

namespace AlcaldiaAraucaPortalWeb.Helpers.Alar
{
    public class PqrsStrategicLineSectorHelper : IPqrsStrategicLineSectorHelper
    {
        private readonly ApplicationDbContext _context;

        public PqrsStrategicLineSectorHelper(ApplicationDbContext context)
        {
            _context = context;
        }

        public PqrsStrategicLineSector ById(int pqrsStrategicLineSectorId)
        {
            PqrsStrategicLineSector model = _context.PqrsStrategicLineSectors.Include(p => p.PqrsStrategicLine).Where(p => p.PqrsStrategicLineSectorId == pqrsStrategicLineSectorId).FirstOrDefault();

            return model;
        }

        public async Task<PqrsStrategicLineSector> ByIdAsync(int pqrsStrategicLineSectorId)
        {
            PqrsStrategicLineSector model = await _context.PqrsStrategicLineSectors.Where(p => p.PqrsStrategicLineSectorId == pqrsStrategicLineSectorId).FirstOrDefaultAsync();

            return model;
        }

        public async Task<PqrsStrategicLineSector> ByNameAsync(string pqrsStrategicLineSectorName, int PqrsStrategicLineId)
        {
            PqrsStrategicLineSector model = await _context.PqrsStrategicLineSectors.Where(p => p.PqrsStrategicLineSectorName == pqrsStrategicLineSectorName && p.PqrsStrategicLineId == PqrsStrategicLineId).FirstOrDefaultAsync();

            return model;
        }

        public async Task<List<PqrsStrategicLineSector>> ComboAsync(int pqrsStrategicLineId)
        {
            List<PqrsStrategicLineSector> model = await _context.PqrsStrategicLineSectors.Where(p => p.PqrsStrategicLineId == pqrsStrategicLineId).ToListAsync();

            model.Add(new PqrsStrategicLineSector { PqrsStrategicLineSectorId = 0, PqrsStrategicLineSectorName = "[Seleccione un Sector..]" });

            return model.OrderBy(m => m.PqrsStrategicLineSectorName).ToList();
        }

        public async Task<List<PqrsStrategicLineSector>> ComboAsync(string email)
        {
            PqrsUserStrategicLine userStrategicLine = await _context.PqrsUserStrategicLines.Where(p => p.ApplicationUser.Email == email).FirstOrDefaultAsync();
            List<PqrsStrategicLineSector> model = await _context.PqrsStrategicLineSectors
                                                                .Where(p => p.PqrsStrategicLineId== userStrategicLine.PqrsStrategicLineId).ToListAsync();

            model.Add(new PqrsStrategicLineSector { PqrsStrategicLineSectorId = 0, PqrsStrategicLineSectorName = "[Seleccione un Sector..]" });

            return model.OrderBy(m => m.PqrsStrategicLineSectorName).ToList();
        }

        public async Task<List<PqrsStrategicLineSector>> ListAsync()
        {
            return await _context.PqrsStrategicLineSectors
                                 .Include(x => x.PqrsStrategicLine)
                                 .OrderBy(x => x.PqrsStrategicLineSectorId)
                                 .ToListAsync();
        }
    }
}

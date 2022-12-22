using AlcaldiaAraucaPortalWeb.Data;
using AlcaldiaAraucaPortalWeb.Data.Entities.Alar;
using Microsoft.EntityFrameworkCore;

namespace AlcaldiaAraucaPortalWeb.Helpers.Alar
{
    public class PqrsStrategicLineHelper : IPqrsStrategicLineHelper
    {
        private readonly ApplicationDbContext _context;

        public PqrsStrategicLineHelper(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<PqrsStrategicLine> ByNameAsync(string name)
        {
            var model = await _context.PqrsStrategicLines.FirstOrDefaultAsync(a => a.PqrsStrategicLineName == name);

            return model;
        }

        public async Task<List<PqrsStrategicLine>> PqrsStrategicLineComboAsync()
        {
            List<PqrsStrategicLine> model = await _context.PqrsStrategicLines.ToListAsync();

            model.Add(new PqrsStrategicLine { PqrsStrategicLineId = 0, PqrsStrategicLineName = "[Seleccione un linea..]" });

            return model.OrderBy(m => m.PqrsStrategicLineName).ToList();
        }

        public async Task<List<PqrsStrategicLine>> PqrsStrategicLineComboPrenAsync()
        {
            List<PqrsStrategicLine> model = await _context.PqrsStrategicLines.Where(s => s.PqrsStrategicLineId != 1).ToListAsync();

            model.Add(new PqrsStrategicLine { PqrsStrategicLineId = 0, PqrsStrategicLineName = "[Seleccione un linea..]" });

            return model.OrderBy(m => m.PqrsStrategicLineName).ToList();
        }

        public async Task<List<PqrsStrategicLine>> PqrsStrategicLineUserComboAsync()
        {
            var modelI = await (from p in _context.PqrsStrategicLines
                                from e in _context.PqrsUserStrategicLines
                                where p.PqrsStrategicLineId == e.PqrsStrategicLineId
                                select new { PqrsStrategicLineId = p.PqrsStrategicLineId, PqrsStrategicLineName = p.PqrsStrategicLineName }).Distinct().ToListAsync();

            List<PqrsStrategicLine> model;

            model = modelI.Select(b => new PqrsStrategicLine()
            {
                PqrsStrategicLineId = b.PqrsStrategicLineId,
                PqrsStrategicLineName = b.PqrsStrategicLineName
            }).ToList();

            model.Add(new PqrsStrategicLine { PqrsStrategicLineId = 0, PqrsStrategicLineName = "[Seleccione una Linea..]" });

            return model.OrderBy(m => m.PqrsStrategicLineName).ToList();
        }
    }
}

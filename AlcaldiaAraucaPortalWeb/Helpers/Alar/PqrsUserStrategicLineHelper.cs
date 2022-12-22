using AlcaldiaAraucaPortalWeb.Data;
using AlcaldiaAraucaPortalWeb.Data.Entities.Alar;
using AlcaldiaAraucaPortalWeb.Models.Gene;
using Microsoft.EntityFrameworkCore;

namespace AlcaldiaAraucaPortalWeb.Helpers.Alar
{
    public class PqrsUserStrategicLineHelper : IPqrsUserStrategicLineHelper
    {
        private readonly ApplicationDbContext _context;

        public PqrsUserStrategicLineHelper(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<Response> AddUpdateAsync(PqrsUserStrategicLine model)
        {
            if (model.PqrsStrategicLineId == 0)
            {
                _context.PqrsUserStrategicLines.Add(model);
            }
            else
            {
                _context.PqrsUserStrategicLines.Update(model);
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

        public async Task<PqrsUserStrategicLine> ByIdAsync(int id)
        {
            PqrsUserStrategicLine model = await _context.PqrsUserStrategicLines
                                                        .Include(p => p.ApplicationUser)
                                                        .Include(p => p.PqrsStrategicLine)
                                                        .Where(p => p.PqrsUserStrategicLineId == id )
                                                        .FirstOrDefaultAsync();
            return model;
        }

        public async Task<Response> DeleteAsync(int id)
        {
            var response = new Response() { Succeeded = true };

            PqrsUserStrategicLine model = await _context.PqrsUserStrategicLines.FindAsync(id);

            _context.PqrsUserStrategicLines.Remove(model);

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                response.Succeeded = false;
                response.Message = ex.Message.Contains("REFERENCE") ? "No se puede borrar la categoría porque tiene registros relacionados" : ex.Message;
            }

            return response;

        }

        public async Task<List<PqrsUserStrategicLine>> ListAsync()
        {
            List<PqrsUserStrategicLine> model =await _context.PqrsUserStrategicLines
                                               .Include(p => p.ApplicationUser)
                                               .Include(p => p.PqrsStrategicLine)
                                               .Include(p => p.State)
                                               .ToListAsync();
            return model;
        }

        public async Task<List<PqrsStrategicLine>> PqrsStrategicLineAsync(string userId)
        {
            List<int> list = await _context.PqrsUserStrategicLines.Where(p => p.UserId == userId)
                    .Select(p => p.PqrsStrategicLineId).ToListAsync();

            List<PqrsStrategicLine> lista = (from l in _context.PqrsStrategicLines
                         where
                              !list.Contains(l.PqrsStrategicLineId)
                         select l).ToList();

            return lista;
        }

        //public async Task<PqrsStrategicLine> PqrsStrategicLineBIdAsync(string email)
        //{
        //    PqrsStrategicLine model = await _context.PqrsUserStrategicLines
        //                                            .Include(p => p.PqrsStrategicLine)
        //                                            .Where(p => p.ApplicationUser.Email == email && p.State.StateName == "Activo")
        //                                            .Select(p => new PqrsStrategicLine() { PqrsStrategicLineId = p.PqrsStrategicLineId, PqrsStrategicLineName = p.PqrsStrategicLine.PqrsStrategicLineName })
        //                                            .FirstOrDefaultAsync();
        //    return model;
        //}

        public async Task<PqrsStrategicLine> PqrsStrategicLineBIdAsync(int strategiaLineaId)
        {
            PqrsStrategicLine pqrsStrategicLine = await _context.PqrsStrategicLines.Where(p => p.PqrsStrategicLineId == strategiaLineaId).FirstOrDefaultAsync();

            return pqrsStrategicLine;
        }

        public async Task<PqrsStrategicLine> PqrsStrategicLineBIdAsync(string id)
        {
            PqrsStrategicLine model = await _context.PqrsUserStrategicLines
                                                    .Include(p => p.PqrsStrategicLine)
                                                    .Where(p => p.ApplicationUser.Id == id && p.State.StateName == "Activo")
                                                    .Select(p => new PqrsStrategicLine() { PqrsStrategicLineId = p.PqrsStrategicLineId, PqrsStrategicLineName = p.PqrsStrategicLine.PqrsStrategicLineName })
                                                    .FirstOrDefaultAsync();
            return model;
        }

        public async Task<PqrsStrategicLine> PqrsStrategicLineEmaildAsync(string email)
        {
            PqrsStrategicLine model = await _context.PqrsUserStrategicLines
                                                    .Include(p => p.PqrsStrategicLine)
                                                    .Where(p => p.ApplicationUser.Email == email && p.State.StateName == "Activo")
                                                    .Select(p => new PqrsStrategicLine() { PqrsStrategicLineId = p.PqrsStrategicLineId, PqrsStrategicLineName = p.PqrsStrategicLine.PqrsStrategicLineName })
                                                    .FirstOrDefaultAsync();
            return model;
        }
    }
}

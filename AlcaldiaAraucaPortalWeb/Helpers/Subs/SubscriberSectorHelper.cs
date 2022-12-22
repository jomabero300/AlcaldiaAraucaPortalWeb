using AlcaldiaAraucaPortalWeb.Data;
using AlcaldiaAraucaPortalWeb.Data.Entities.Subs;
using AlcaldiaAraucaPortalWeb.Models.Gene;
using Microsoft.EntityFrameworkCore;

namespace AlcaldiaAraucaPortalWeb.Helpers.Subs
{
    public class SubscriberSectorHelper : ISubscriberSectorHelper
    {
        private readonly ApplicationDbContext _context;

        public SubscriberSectorHelper(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<Response> AddUpdateAsync(List<SubscriberSector> model)
        {
            _context.SubscriberSectors.UpdateRange(model);

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

        public async Task<List<SubscriberSector>> BySectorIdAsync(int pqrsStrategicLineSectorId)
        {
            List<SubscriberSector> model = await _context.SubscriberSectors
                                                        .Where(s =>
                                                               s.Subscriber.EmailConfirmed == true &&
                                                               s.Subscriber.State.StateName == "Activo" &&
                                                               s.Subscriber.State.StateType == "G" &&
                                                               s.PqrsStrategicLineSectorId == pqrsStrategicLineSectorId)
                                                        .ToListAsync();
            if (model != null)
            {
                model.ForEach(m => m.SendUrl = true);
            }

            return model;
        }

        public async Task<List<SubscriberSector>> BySubSectorAsync()
        {
            List<SubscriberSector> model = await _context.SubscriberSectors.Include(s => s.Subscriber)
                                                        .Where(s => s.Subscriber.EmailConfirmed == true &&
                                                               s.Subscriber.State.StateName == "Activo" &&
                                                               s.Subscriber.State.StateType == "G" &&
                                                               s.State.StateName == "Activo" &&
                                                               s.SendUrl == true)
                                                        .ToListAsync();
            return model;
        }
    }
}

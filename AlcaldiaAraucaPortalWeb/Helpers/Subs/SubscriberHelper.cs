using AlcaldiaAraucaPortalWeb.Data;
using AlcaldiaAraucaPortalWeb.Data.Entities.Subs;
using AlcaldiaAraucaPortalWeb.Models.Gene;

namespace AlcaldiaAraucaPortalWeb.Helpers.Subs
{
    public class SubscriberHelper : ISubscriberHelper
    {
        private readonly ApplicationDbContext _context;

        public SubscriberHelper(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<Response> AddUpdateAsync(Subscriber model)
        {
            if (model.SubscriberId == 0)
            {
                _context.Subscribers.Add(model);
            }
            else
            {
                _context.Subscribers.Update(model);
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
    }
}

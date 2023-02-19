using AlcaldiaAraucaPortalWeb.Data.Entities.Subs;
using AlcaldiaAraucaPortalWeb.Models.Gene;

namespace AlcaldiaAraucaPortalWeb.Helpers.Subs
{
    public interface ISubscriberHelper
    {
        Task<Response> AddUpdateAsync(Subscriber model);
        Task<Subscriber> ByIdAsync(int id);
        Task<bool> ByEmailAsync(string email);
        Task<Response> ConfirmEmailAsync(Subscriber subscriber, string token);
        Task<List<string>> emailsSubscribeAsync(int id);
        Task<List<string>> SectorMenuUrl(int id);
    }
}

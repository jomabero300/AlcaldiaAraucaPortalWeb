using AlcaldiaAraucaPortalWeb.Data.Entities.Subs;
using AlcaldiaAraucaPortalWeb.Models.Gene;

namespace AlcaldiaAraucaPortalWeb.Helpers.Subs
{
    public interface ISubscriberHelper
    {
        Task<Response> AddUpdateAsync(Subscriber model);
    }
}

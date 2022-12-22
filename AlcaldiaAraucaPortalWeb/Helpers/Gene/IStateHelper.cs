using AlcaldiaAraucaPortalWeb.Data.Entities.Gene;
using AlcaldiaAraucaPortalWeb.Models.Gene;

namespace AlcaldiaAraucaPortalWeb.Helpers.Gene
{
    public interface IStateHelper
    {
        Task<Response> AddUpdateAsync(State model);
        Task<List<State>> ListAsync();
        Task<State> ByIdAsync(int id);
        Task<Response> DeleteAsync(int id);


        Task<List<State>> StateComboAsync(string stateType);
        Task<int> StateIdAsync(string stateType, string stateName);
        Task<List<State>> StateAsync(string stateType, string[] stateName);
    }
}

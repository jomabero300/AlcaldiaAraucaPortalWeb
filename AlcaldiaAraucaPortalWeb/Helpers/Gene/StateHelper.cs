using AlcaldiaAraucaPortalWeb.Data;
using AlcaldiaAraucaPortalWeb.Data.Entities.Gene;
using AlcaldiaAraucaPortalWeb.Models.Gene;
using Microsoft.EntityFrameworkCore;

namespace AlcaldiaAraucaPortalWeb.Helpers.Gene
{
    public class StateHelper : IStateHelper
    {
        private readonly ApplicationDbContext _context;

        public StateHelper(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<List<State>> StateComboAsync(string stateType)
        {
            var model = await _context.States.Where(s => s.StateType == stateType).ToListAsync();

            model.Add(new State { StateId = 0, StateName = "[Seleccione un estado..]" });

            return model.OrderBy(m => m.StateName).ToList();
        }

        public async Task<int> StateIdAsync(string stateType, string stateName)
        {
            var model = await _context.States.Where(s => s.StateType == stateType && s.StateName.Equals(stateName)).FirstOrDefaultAsync();

            return model.StateId;
        }
        public async Task<List<State>> StateAsync(string stateType, string[] stateName)
        {
            var model = await _context.States.Where(s => s.StateType == stateType && stateName.Contains(s.StateName)).ToListAsync();

            return model;
        }

        public async Task<List<State>> ListAsync()
        {
            return await _context.States.OrderBy(s=>s.StateName).ToListAsync();
        }

        public async Task<State> ByIdAsync(int id)
        {
            return await _context.States
                .FirstOrDefaultAsync(m => m.StateId == id);
        }

        public async Task<Response> AddUpdateAsync(State model)
        {
            if (model.StateId == 0)
            {
                _context.States.Add(model);
            }
            else
            {
                _context.States.Update(model);
            }
            var response = new Response() { Succeeded = true };
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                response.Message = ex.Message;
            }

            return response;
        }

        public async Task<Response> DeleteAsync(int id)
        {
            var response = new Response() { Succeeded = true };

            var model = await _context.States.Where(a => a.StateId == id).FirstOrDefaultAsync();

            try
            {
                _context.States.Remove(model);
            }
            catch (Exception ex)
            {
                response.Succeeded = false;
                response.Message = ex.Message.Contains("REFERENCE") ? "No se puede borrar la categoría porque tiene registros relacionados" : ex.Message;
            }

            return response;
        }
    }
}

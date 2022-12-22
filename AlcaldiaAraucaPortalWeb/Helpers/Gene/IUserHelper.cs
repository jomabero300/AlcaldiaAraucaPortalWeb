using AlcaldiaAraucaPortalWeb.Data.Entities.Gene;
using AlcaldiaAraucaPortalWeb.Models.Gene;
using Microsoft.AspNetCore.Identity;

namespace AlcaldiaAraucaPortalWeb.Helpers.Gene
{
    public interface IUserHelper
    {
        Task AddUserToRoleAsync(ApplicationUser user, string roleName);
        Task<IdentityResult> AddUserAsync(ApplicationUser user, string password);
        Task<IdentityResult> UpdateUserAsync(ApplicationUser user);
        Task<bool> IsUserInRoleAsync(ApplicationUser user, string roleName);
        Task<ApplicationUser> GetUserAsync(string email);
        Task<List<RoleUserModelView>> GetRoleUserAsync();
        Task<RoleUserModelView> GetRoleUserAsync(string id);
        Task<Response> DeleteUserAsync(string id);
        Task<List<ApplicationUser>> UsersComboAsync();
        Task<List<ApplicationUser>> ListAsync();
        Task<List<UsersViewModel>> ListAsync(string id);


        Task<string> GenerateEmailConfirmationTokenAsync(ApplicationUser user);
        Task<IdentityResult> ConfirmEmailAsync(ApplicationUser user, string token);


        Task CheckRoleAsync(string roleName);
        Task<List<IdentityRole>> GetRoleAsync();
        Task<List<IdentityRole>> ComboRolesAsync();
        Task<Response> RemoveRoleUserAsync(string Userid,string roleNewName);
    }
}

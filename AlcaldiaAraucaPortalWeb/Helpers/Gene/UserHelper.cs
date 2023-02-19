using AlcaldiaAraucaPortalWeb.Data;
using AlcaldiaAraucaPortalWeb.Data.Entities.Gene;
using AlcaldiaAraucaPortalWeb.Models.Gene;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Rewrite;
using Microsoft.EntityFrameworkCore;

namespace AlcaldiaAraucaPortalWeb.Helpers.Gene
{
    public class UserHelper : IUserHelper
    {
        private readonly ApplicationDbContext _context;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;

        public UserHelper(ApplicationDbContext context, UserManager<ApplicationUser> userManager, RoleManager<IdentityRole> roleManager)
        {
            _context = context;
            _userManager = userManager;
            _roleManager = roleManager;
        }

        public async Task<IdentityResult> AddUserAsync(ApplicationUser user, string password)
        {
            IdentityResult mode = await _userManager.CreateAsync(user, password);

            return mode;
        }

        public async Task AddUserToRoleAsync(ApplicationUser user, string roleName)
        {
            await _userManager.AddToRoleAsync(user, roleName);
        }

        public async Task CheckRoleAsync(string roleName)
        {
            bool roleExists = await _roleManager.RoleExistsAsync(roleName);
            if (!roleExists)
            {
                await _roleManager.CreateAsync(new IdentityRole
                {
                    Name = roleName
                });
            }
        }

        public async Task<ApplicationUser> GetUserAsync(string email)
        {
            return await _context.Users
                .FirstOrDefaultAsync(u => u.Email == email);
        }

        public async Task<bool> IsUserInRoleAsync(ApplicationUser user, string roleName)
        {
            return await _userManager.IsInRoleAsync(user, roleName);
        }

        public async Task<List<RoleUserModelView>> GetRoleUserAsync()
        {
            List<RoleUserModelView> users = await (from U in _context.Users
                                                   join E in _context.UserRoles on U.Id equals E.UserId
                                                   join R in _context.Roles on E.RoleId equals R.Id
                                                   select new RoleUserModelView { UserId = U.Id, FullName = U.FullName, RoleId = R.Name,email=U.Email }).ToListAsync();

            return users.OrderBy(u => u.FullName).ToList();
        }

        public async Task<RoleUserModelView> GetRoleUserAsync(string id)
        {
            RoleUserModelView user = await (from U in _context.Users
                                            join E in _context.UserRoles on U.Id equals E.UserId
                                            join R in _context.Roles on E.RoleId equals R.Id
                                            where U.Id == id
                                            select new RoleUserModelView { UserId = U.Id, FullName = U.FullName, RoleName = R.Name,RoleId=R.Id }).FirstOrDefaultAsync();

            return user;
        }

        public async Task<List<IdentityRole>> GetRoleAsync()
        {
            List<IdentityRole> model = await _context.Roles.ToListAsync();

            return model;
        }

        public async Task<Response> RemoveRoleUserAsync(string userId, string roleNewId)
        {
            Response response = new Response { Succeeded = true };

            try
            {
                ApplicationUser user = await _userManager.FindByIdAsync(userId);


                var xx = await _userManager.GetRolesAsync(user);

                //var roleUser = _context.UserRoles.Where(u => u.UserId == userId).FirstOrDefault();

                //string roleOldName = _context.Roles.Where(r => r.Id == roleUser.RoleId).FirstOrDefault().Name;

                //await _userManager.RemoveFromRoleAsync(user, roleOldName);
                await _userManager.RemoveFromRoleAsync(user, xx[0].ToString());

                string roleNewName = _context.Roles.Where(r => r.Id == roleNewId).FirstOrDefault().Name;

                await _userManager.AddToRoleAsync(user, roleNewName);

            }
            catch (Exception ex)
            {

                response.Succeeded = false;
                response.Message = ex.Message;
            }

            return response;
        }

        public async Task<Response> DeleteUserAsync(string id)
        {
            Response response = new Response { Succeeded = true };

            try
            {
                var state = await _context.Users.FindAsync(id);
                _context.Users.Remove(state);
            }
            catch (Exception ex)
            {
                response.Succeeded = false;

                response.Message = ex.Message;
            }

            return response;
        }

        public async Task<List<ApplicationUser>> UsersComboAsync()
        {
            List<string> model1 =await (from u in _context.Users
                         join ur in _context.UserRoles on u.Id equals ur.UserId
                         join r in _context.Roles on ur.RoleId equals r.Id
                         where r.Name.Equals("Publicador")
                         select u.Id).ToListAsync();

            List<ApplicationUser> model = await _context.Users.Where(a => model1.Contains(a.Id)).ToListAsync();

            model.Add(new ApplicationUser { Id = "", LastName = "[Seleccione un usuario..]" });

            return model.OrderBy(m => m.FullName).ToList();
        }

        public async Task<List<ApplicationUser>> ListAsync()
        {
            return await _context.Users.ToListAsync();
        }

        public async Task<IdentityResult> UpdateUserAsync(ApplicationUser user)
        {
            IdentityResult mode = await _userManager.UpdateAsync(user);

            return mode;
        }

        public async Task<string> GenerateEmailConfirmationTokenAsync(ApplicationUser user)
        {
            return await _userManager.GenerateEmailConfirmationTokenAsync(user);
        }

        public async Task<IdentityResult> ConfirmEmailAsync(ApplicationUser user, string token)
        {
            return await _userManager.ConfirmEmailAsync(user, token);
        }

        public async Task<List<UsersViewModel>> ListAsync(string id)
        {
            List<UsersViewModel> model =await( string.IsNullOrEmpty(id) ?
                                from u in _context.Users
                                join ur in _context.UserRoles on u.Id equals ur.UserId
                                join r in _context.Roles on ur.RoleId equals r.Id
                                orderby u.FirstName, u.LastName
                                select new UsersViewModel { FirstName= u.FirstName, LastName= u.LastName,Email= u.Email,Address= u.Address, Document= u.Document, DocumentTypeName= u.DocumentType.DocumentTypeName,GenderName= u.Gender.GenderName } :
                                from u in _context.Users
                                join ur in _context.UserRoles on u.Id equals ur.UserId
                                join r in _context.Roles on ur.RoleId equals r.Id
                                where r.Id == id
                                orderby u.FirstName, u.LastName
                                select new UsersViewModel { FirstName = u.FirstName, LastName = u.LastName, Email = u.Email, Address = u.Address, Document = u.Document, DocumentTypeName = u.DocumentType.DocumentTypeName, GenderName = u.Gender.GenderName }).ToListAsync();

            return model.OrderBy(u=>u.FirstName).ThenBy(u=>u.LastName).ToList();
        }

        public async Task<List<IdentityRole>> ComboRolesAsync()
        {
            List<IdentityRole> model = await _context.Roles.ToListAsync();

            model.Add(new IdentityRole { Id = "", Name = "[Seleccione un rol..]" });

            return model.OrderBy(m => m.Name).ToList();
        }

        public async Task<List<string>> ListPrensaEmailsAsync()
        {
            List<string> model = await (from u in _context.Users
                                         join ur in _context.UserRoles on u.Id equals ur.UserId
                                         join r in _context.Roles on ur.RoleId equals r.Id
                                         where r.Name.Equals("Prensa")
                                         select u.Email).ToListAsync();

            return model;
        }
    }
}

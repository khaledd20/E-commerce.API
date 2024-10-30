using AngEcommerceProject.Repositorys;
using AngEcommerceProject.Dto;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using AngEcommerceProject.Models;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace AngEcommerceProject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly IAuthRepository _authService;
        private readonly UserManager<User> _userManager;
        private readonly RoleManager<IdentityRole> roleManager;
        public AccountController(IAuthRepository authService,
            UserManager<User> userManager, RoleManager<IdentityRole> roleManager)
        {
            _authService = authService;
            _userManager = userManager;
            this.roleManager = roleManager;
        }
        [HttpPost("register")]
        public async Task<IActionResult> RegisterAsync([FromBody] RegesterDto model)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            var result = await _authService.RegisterAsync(model);
            if (!result.IsAuthenticated)
                return BadRequest(result.Message);

            return Ok(result);
        }

        [HttpPost("login")]
        public async Task<IActionResult> GetTokenAsync([FromBody] LoginDto model)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var result = await _authService.LoginAsync(model);

            if (!result.IsAuthenticated)
                return BadRequest(result.Message);

            return Ok(result);
        }
        [HttpPatch("UpdateUser")]
        public async Task<IActionResult>UpdateUser(string id , [FromBody] RegesterDto model)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            var user = await _userManager.FindByIdAsync(id);
            if (user == null)
                return BadRequest();
            var resEm = await _userManager.FindByEmailAsync(model.email);
            if (resEm != null) 
            {
                if(model.email != user.Email)
                    return BadRequest();
            }
            resEm = await _userManager.FindByNameAsync(model.username);
            if (resEm != null)
            {
                if (model.username != user.UserName)
                    return BadRequest();
            }
            var resultPass = await _userManager.ChangePasswordAsync(user,user.PasswordHash,model.password);
            if (resultPass.Succeeded)
            {
                user.Pass = model.password;
                user.name = model.name;
                user.UserName = model.username;
                user.Email = model.email;
                user.city = model.city;
                user.postalCode = model.postalCode;
                user.street = model.street;
                user.PhoneNumber = model.phoneNumber;
                user.Pass = model.password;
                var result = await _userManager.UpdateAsync(user);
                return Ok(result);
            }
            return BadRequest(resultPass.Errors);
         }
        [HttpGet("filter")]
        public async Task<IActionResult> GetFiltered([FromQuery] FilteredProduct product)
        {
            var result = await _userManager.Users.ToListAsync();
            var users = await usersRolles(result);
            users = users.Skip(product.page * product.size).Take(product.size).ToList();
            if (product.filter != null)
            {
                users = users.FindAll(x => (x.name.Any(i => product.filter.Contains(i))));
            }
            if (product.order != "asc")
            {
                users.Reverse();
            }
            if (users != null)
            {
                return Ok(users);
            }
            return BadRequest();
        }
       
        [HttpPost("addrole")]
        public async Task<IActionResult> AddRoleAsync([FromBody] AddRoleDto model)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var result = await _authService.AddRoleAsync(model);

            if (!string.IsNullOrEmpty(result))
                return BadRequest(result);

            return Ok(model);
        }
        [HttpGet("check")]
        public async Task<IActionResult> checker(string UsId=null,string email=null , string username=null )
        {
            if (email != null)
            {
                email = email.Trim();
                var res = await _userManager.FindByEmailAsync(email);
                
                if (UsId != null)
                {
                    var user = await _userManager.FindByIdAsync(UsId);
                    if (res != null && user != null)
                    {
                        if (email != user.Email)
                            return Ok(true);
                    }
                }
                
                if (res is null)
                    return Ok(false);

                return Ok(true);
            }
            if (username != null)
            {
                var resUs = await _userManager.FindByNameAsync(username);
                if(UsId != null)
                {
                    var user = await _userManager.FindByIdAsync(UsId);
                    if (resUs != null && user != null)
                    {
                        if (username != user.UserName)
                            return Ok(false);
                    }
                }
                if (resUs is null)
                    return Ok(false);
                return Ok(true);
            }
            return BadRequest();
        }
        [HttpGet]
        public async Task<IActionResult> getAllUsers()
        {
            var result = await _userManager.Users.ToListAsync();
            return Ok(result);
        }
        private async Task<List<UserRollesDto>> usersRolles(List<User> list)
        {
            List<UserRollesDto> res = new();
            foreach (var item in list)
            {

                var result = await _userManager.GetRolesAsync(item);
                var user = new UserRollesDto();
                user.name = item.name;
                user.id = item.Id;
                user.PhoneNumber = item.PhoneNumber;
                user.postalCode = item.postalCode;
                user.city = item.city;
                user.street = item.street;
                user.Email = item.Email;
                user.UserName = item.UserName;
                user.Roles = result.ToList();
                res.Add(user);
            }
            return res;
        }

    }
}

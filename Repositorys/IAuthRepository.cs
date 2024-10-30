using System.Threading.Tasks;
using AngEcommerceProject.Dto;
namespace AngEcommerceProject.Repositorys
{
    public interface IAuthRepository
    {
        Task<AuthDto> RegisterAsync(RegesterDto model);
        Task<AuthDto> LoginAsync(LoginDto model);
        Task<string> AddRoleAsync(AddRoleDto model);
    }
}

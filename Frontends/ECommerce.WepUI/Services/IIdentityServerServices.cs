using ECommerce.Dto.IdentityServerDto;

namespace ECommerce.WebUI.Services
{
    public interface IIdentityServerServices
    {
        Task<bool> SignIn(SingInDto singInDto);
    }
}

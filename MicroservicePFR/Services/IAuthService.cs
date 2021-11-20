using MicroservicePFR.Domain.Models;
using System.Threading.Tasks;

namespace MicroservicePFR.Services
{
    public interface IAuthService
    {
        User GetCurrentUser();
        bool IsAuthorized();
    }
}

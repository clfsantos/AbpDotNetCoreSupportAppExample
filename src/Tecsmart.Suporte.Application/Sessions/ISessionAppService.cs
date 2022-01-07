using System.Threading.Tasks;
using Abp.Application.Services;
using Tecsmart.Suporte.Sessions.Dto;

namespace Tecsmart.Suporte.Sessions
{
    public interface ISessionAppService : IApplicationService
    {
        Task<GetCurrentLoginInformationsOutput> GetCurrentLoginInformations();
    }
}

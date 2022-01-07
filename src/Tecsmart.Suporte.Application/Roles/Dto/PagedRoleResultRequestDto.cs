using Abp.Application.Services.Dto;

namespace Tecsmart.Suporte.Roles.Dto
{
    public class PagedRoleResultRequestDto : PagedResultRequestDto
    {
        public string Keyword { get; set; }
    }
}


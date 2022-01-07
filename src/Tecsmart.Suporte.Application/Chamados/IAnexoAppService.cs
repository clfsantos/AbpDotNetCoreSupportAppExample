using Abp.Application.Services;
using Abp.Application.Services.Dto;
using DevExtreme.AspNet.Data.ResponseModel;
using DevExtreme.AspNet.Mvc;
using Microsoft.AspNetCore.Http;
using System.Threading.Tasks;
using Tecsmart.Suporte.Chamados.Dto;

namespace Tecsmart.Suporte.Chamados
{
    public interface IAnexoAppService : IApplicationService
	{
		Task<GetAnexoForEditOutput> GetAnexoForEdit(EntityDto<int> input);
		Task CreateOrEdit(CreateOrEditAnexoDto input);
		Task Delete(int input);
		Task<LoadResult> GetAllForLoadResult(DataSourceLoadOptions loadOptions, int ChamadoId);
	}
}

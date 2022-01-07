using Abp.Application.Services;
using Abp.Application.Services.Dto;
using DevExtreme.AspNet.Data.ResponseModel;
using DevExtreme.AspNet.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using Tecsmart.Suporte.Chamados.Dto;

namespace Tecsmart.Suporte.Chamados
{
    public interface IFluxoAppService : IApplicationService
	{
		Task<GetChamadoFluxoForEditOutput> GetChamadoFluxoForEdit(EntityDto<int> input);
		Task CreateOrEdit(CreateOrEditChamadoFluxoDto input);
		//Task Cancelar(EntityDto<int> input);
		Task<LoadResult> GetAllForLoadResult(DataSourceLoadOptions loadOptions);
	}
}

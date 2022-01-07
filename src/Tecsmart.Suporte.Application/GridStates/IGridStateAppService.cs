using Abp.Application.Services;
using Abp.Application.Services.Dto;
using DevExtreme.AspNet.Data.ResponseModel;
using DevExtreme.AspNet.Mvc;
using System.Threading.Tasks;
using Tecsmart.Suporte.GridStates.Dto;

namespace Tecsmart.Suporte.GridStates
{
    public interface IGridStateAppService : IApplicationService
	{
		Task<GetGridStateForEditOutput> GetGridStateForEdit(EntityDto<int> input);
		Task CreateOrEdit(CreateOrEditGridStateDto input);
		Task Delete(EntityDto<int> input);
		Task<LoadResult> GetAllForLoadResult(DataSourceLoadOptions loadOptions, string tela);
	}
}

using Abp.Application.Services;
using Abp.Application.Services.Dto;
using DevExtreme.AspNet.Data.ResponseModel;
using DevExtreme.AspNet.Mvc;
using System.Threading.Tasks;
using Tecsmart.Suporte.Modelos.Dto;

namespace Tecsmart.Suporte.Modelos
{
    public interface IModeloAppService : IApplicationService
	{
		Task<GetModeloForEditOutput> GetModeloForEdit(EntityDto<int> input);
		Task CreateOrEdit(CreateOrEditModeloDto input);
		Task Delete(EntityDto<int> input);
		Task<LoadResult> GetAllForLoadResult(DataSourceLoadOptions loadOptions);
	}
}

using Abp.Application.Services;
using Abp.Application.Services.Dto;
using DevExtreme.AspNet.Data.ResponseModel;
using DevExtreme.AspNet.Mvc;
using System.Threading.Tasks;
using Tecsmart.Suporte.Equipamentos.Fabricantes.Dto;

namespace Tecsmart.Suporte.Equipamentos.Fabricantes
{
    public interface IFabricanteAppService : IApplicationService
	{
		Task<GetFabricanteForEditOutput> GetFabricanteForEdit(EntityDto<int> input);
		Task<int> CreateOrEdit(CreateOrEditFabricanteDto input);
		Task Delete(EntityDto<int> input);
		Task<LoadResult> GetAllForLoadResult(DataSourceLoadOptions loadOptions);
	}
}

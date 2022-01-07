using Abp.Application.Services;
using Abp.Application.Services.Dto;
using DevExtreme.AspNet.Data.ResponseModel;
using DevExtreme.AspNet.Mvc;
using System.Threading.Tasks;
using Tecsmart.Suporte.Equipamentos.Dto;

namespace Tecsmart.Suporte.Equipamentos
{
    public interface IEquipamentoAppService : IApplicationService
	{
		Task<GetEquipamentoForEditOutput> GetEquipamentoForEdit(EntityDto<int> input);
		Task CreateOrEdit(CreateOrEditEquipamentoDto input);
		Task Delete(EntityDto<int> input);
		Task<LoadResult> GetAllForLoadResult(DataSourceLoadOptions loadOptions);
	}
}

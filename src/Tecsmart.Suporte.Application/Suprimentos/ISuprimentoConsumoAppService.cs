using Abp.Application.Services;
using Abp.Application.Services.Dto;
using DevExtreme.AspNet.Data.ResponseModel;
using DevExtreme.AspNet.Mvc;
using System.Threading.Tasks;
using Tecsmart.Suporte.Suprimentos.Dto;

namespace Tecsmart.Suporte.Suprimentos
{
    public interface ISuprimentoConsumoAppService : IApplicationService
	{
		Task<GetSuprimentoConsumoForEditOutput> GetSuprimentoConsumoForEdit(EntityDto<int> input);
		Task CreateOrEdit(CreateOrEditSuprimentoConsumoDto input);
		Task Delete(EntityDto<int> input);
		Task<LoadResult> GetAllForLoadResult(DataSourceLoadOptions loadOptions);
	}
}

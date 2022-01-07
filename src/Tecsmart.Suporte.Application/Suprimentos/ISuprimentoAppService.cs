using Abp.Application.Services;
using Abp.Application.Services.Dto;
using DevExtreme.AspNet.Data.ResponseModel;
using DevExtreme.AspNet.Mvc;
using System.Threading.Tasks;
using Tecsmart.Suporte.Suprimentos.Dto;

namespace Tecsmart.Suporte.Suprimentos
{
    public interface ISuprimentoAppService : IApplicationService
	{
		Task<GetSuprimentoForEditOutput> GetSuprimentoForEdit(EntityDto<int> input);
		Task CreateOrEdit(CreateOrEditSuprimentoDto input);
		Task Delete(EntityDto<int> input);
		Task<LoadResult> GetAllForLoadResult(DataSourceLoadOptions loadOptions);
	}
}

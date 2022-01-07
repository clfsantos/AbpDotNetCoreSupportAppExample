using Abp.Application.Services;
using Abp.Application.Services.Dto;
using DevExtreme.AspNet.Data.ResponseModel;
using DevExtreme.AspNet.Mvc;
using System.Threading.Tasks;
using Tecsmart.Suporte.Crachas.Dto;

namespace Tecsmart.Suporte.Crachas
{
    public interface ICrachaAppService : IApplicationService
	{
		Task<GetCrachaForEditOutput> GetCrachaForEdit(EntityDto<int> input);
		Task CreateOrEdit(CreateOrEditCrachaDto input);
		Task Delete(EntityDto<int> input);
		Task<LoadResult> GetAllForLoadResult(DataSourceLoadOptions loadOptions);
		CrachaInfoDto GetInfoCrachas();
	}
}

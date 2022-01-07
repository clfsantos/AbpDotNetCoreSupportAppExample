using Abp.Application.Services;
using Abp.Application.Services.Dto;
using DevExtreme.AspNet.Data.ResponseModel;
using DevExtreme.AspNet.Mvc;
using System.Threading.Tasks;
using Tecsmart.Suporte.Releases.Dto;

namespace Tecsmart.Suporte.Releases
{
    public interface IReleaseAppService : IApplicationService
	{
		Task<GetReleaseForEditOutput> GetReleaseForEdit(EntityDto<int> input);
		Task CreateOrEdit(CreateOrEditReleaseDto input);
		Task Delete(EntityDto<int> input);
		Task<LoadResult> GetAllForLoadResult(DataSourceLoadOptions loadOptions);
	}
}

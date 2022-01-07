using Abp.Application.Services;
using Abp.Application.Services.Dto;
using DevExtreme.AspNet.Data.ResponseModel;
using DevExtreme.AspNet.Mvc;
using System.Threading.Tasks;
using Tecsmart.Suporte.Produtos.Dto;

namespace Tecsmart.Suporte.Produtos
{
    public interface IGrupoAppService : IApplicationService
	{
		Task<GetGrupoForEditOutput> GetGrupoForEdit(EntityDto<int> input);
		Task CreateOrEdit(GetGrupoForEditOutput input);
		Task Delete(EntityDto<int> input);
		Task<LoadResult> GetAllForLoadResult(DataSourceLoadOptions loadOptions);
		Task<LoadResult> GetAllGrupos(DataSourceLoadOptions loadOptions);
	}
}

using Abp.Application.Services;
using Abp.Application.Services.Dto;
using DevExtreme.AspNet.Data.ResponseModel;
using DevExtreme.AspNet.Mvc;
using System.Threading.Tasks;
using Tecsmart.Suporte.Equipamentos.Categorias.Dto;

namespace Tecsmart.Suporte.Equipamentos.Categorias
{
    public interface ICategoriaAppService : IApplicationService
	{
		Task<GetCategoriaForEditOutput> GetCategoriaForEdit(EntityDto<int> input);
		Task<int> CreateOrEdit(CreateOrEditCategoriaDto input);
		Task Delete(EntityDto<int> input);
		Task<LoadResult> GetAllForLoadResult(DataSourceLoadOptions loadOptions);
	}
}

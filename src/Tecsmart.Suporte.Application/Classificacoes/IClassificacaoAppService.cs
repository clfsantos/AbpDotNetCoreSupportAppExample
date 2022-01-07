using Abp.Application.Services;
using Abp.Application.Services.Dto;
using DevExtreme.AspNet.Data.ResponseModel;
using DevExtreme.AspNet.Mvc;
using System.Threading.Tasks;
using Tecsmart.Suporte.Classificacoes.Dto;

namespace Tecsmart.Suporte.Classificacoes
{
    public interface IClassificacaoAppService : IApplicationService
	{
		//Task<GetOrigemForEditOutput> GetOrigemForEdit(EntityDto<int> input);
		//Task CreateOrEdit(CreateOrEditOrigemDto input);
		//Task Delete(EntityDto<int> input);
		Task<LoadResult> GetAllForLoadResult(DataSourceLoadOptions loadOptions);
	}
}

using Abp.Application.Services;
using Abp.Application.Services.Dto;
using DevExtreme.AspNet.Data.ResponseModel;
using DevExtreme.AspNet.Mvc;
using System.Threading.Tasks;
using Tecsmart.Suporte.FilaAtendimentos.Dto;

namespace Tecsmart.Suporte.FilaAtendimentos
{
    public interface IFilaRetornoAppService : IApplicationService
	{
		Task<GetFilaRetornoForEditOutput> GetFilaRetornoForEdit(EntityDto<int> input);
		Task CreateOrEdit(CreateOrEditFilaRetornoDto input);
		//Task Cancelar(EntityDto<int> input);
		Task<LoadResult> GetAllForLoadResult(DataSourceLoadOptions loadOptions, int filaAtendimentoId);
	}
}

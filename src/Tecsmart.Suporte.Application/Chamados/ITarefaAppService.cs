using Abp.Application.Services;
using Abp.Application.Services.Dto;
using DevExtreme.AspNet.Data.ResponseModel;
using DevExtreme.AspNet.Mvc;
using System.Threading.Tasks;
using Tecsmart.Suporte.Chamados.Dto;

namespace Tecsmart.Suporte.Chamados
{
    public interface ITarefaAppService : IApplicationService
	{
		Task<GetTarefaForEditOutput> GetTarefaForEdit(EntityDto<int> input);
		Task CreateOrEdit(CreateOrEditTarefaDto input);
		Task Cancelar(EntityDto<int> input);
		Task<LoadResult> GetAllForLoadResult(DataSourceLoadOptions loadOptions, int ChamadoId);
		Task<LoadResult> GetAllForAgendaLoadResult(DataSourceLoadOptions loadOptions);
	}
}

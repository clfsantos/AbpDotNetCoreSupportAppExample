using Abp.Application.Services;
using Abp.Application.Services.Dto;
using DevExtreme.AspNet.Data.ResponseModel;
using DevExtreme.AspNet.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using Tecsmart.Suporte.Chamados.Dto;

namespace Tecsmart.Suporte.Chamados
{
    public interface IChamadoAppService : IApplicationService
	{
		Task<List<PrioridadeFluxoViewDto>> ObterListaPrioridadeFluxo();
		Task<GetChamadoForEditOutput> GetChamadoForEdit(EntityDto<int> input);
		Task<int> CreateOrEdit(CreateOrEditChamadoDto input);
		Task Cancelar(EntityDto<int> input);
		Task Assumir(CreateOrEditChamadoDto input);
		Task<LoadResult> GetAllForLoadResult(DataSourceLoadOptions loadOptions);
		Task<LoadResult> GetAllForRelatorioLoadResult(DataSourceLoadOptions loadOptions);
		Task<LoadResult> GetAllForRelatorioAssistenciaLoadResult(DataSourceLoadOptions loadOptions);
		Task<LoadResult> GetChamadosDia(DataSourceLoadOptions loadOptions);
		Task<LoadResult> GetChamadosMes(DataSourceLoadOptions loadOptions);
		Task<LoadResult> GetChamadosAno(DataSourceLoadOptions loadOptions);
		Task<LoadResult> GetChamadosTecnico(DataSourceLoadOptions loadOptions);
	}
}

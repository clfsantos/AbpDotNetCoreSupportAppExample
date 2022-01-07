using Abp.Application.Services;
using Abp.Application.Services.Dto;
using DevExtreme.AspNet.Data.ResponseModel;
using DevExtreme.AspNet.Mvc;
using System.Threading.Tasks;
using Tecsmart.Suporte.Chamados.Dto;

namespace Tecsmart.Suporte.Chamados
{
    public interface IImplantacaoAppService : IApplicationService
	{
		Task<GetEtapaChamadoForEditOutput> GetEtapaChamadoForEdit(EntityDto<int> input);
		Task CreateOrEdit(CreateOrEditEtapaChamadoDto input);
		Task AprovarConcluirEtapa(EntityDto<int> input);
		Task<LoadResult> GetAllForLoadResult(DataSourceLoadOptions loadOptions, int ChamadoId);
		Task<LoadResult> GetEtapasAbertasPendentes(DataSourceLoadOptions loadOptions);
		Task<LoadResult> GetEtapasAbertasPendentesGeral(DataSourceLoadOptions loadOptions);
	}
}

using Abp.Application.Services;
using Abp.Application.Services.Dto;
using DevExtreme.AspNet.Data.ResponseModel;
using DevExtreme.AspNet.Mvc;
using System.Threading.Tasks;
using Tecsmart.Suporte.FilaAtendimentos.Dto;

namespace Tecsmart.Suporte.FilaAtendimentos
{
    public interface IFilaAtendimentoAppService : IApplicationService
	{
		Task<GetFilaAtendimentoForEditOutput> GetFilaAtendimentoForEdit(EntityDto<int> input);
		Task CreateOrEdit(CreateOrEditFilaAtendimentoDto input);
		Task Atender(EntityDto<int> input);
		Task<int> QtdFilaAtendimento();
		Task Cancelar(EntityDto<int> input);
		Task<LoadResult> GetAllForLoadResult(DataSourceLoadOptions loadOptions);
	}
}

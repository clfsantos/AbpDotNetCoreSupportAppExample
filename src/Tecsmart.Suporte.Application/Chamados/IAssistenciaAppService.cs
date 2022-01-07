using Abp.Application.Services;
using Abp.Application.Services.Dto;
using DevExtreme.AspNet.Data.ResponseModel;
using DevExtreme.AspNet.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using Tecsmart.Suporte.Chamados.Dto;

namespace Tecsmart.Suporte.Chamados
{
    public interface IAssistenciaAppService : IApplicationService
	{
		Task<GetAssistenciaForEditOutput> GetAssistenciaForEdit(EntityDto<int> input);
		Task CreateOrEdit(CreateOrEditAssistenciaDto input);
		Task<AssistenciaDto> GetAssistencia(int? chamadoId);
		Task<List<AssistenciaDto>> GetAssistenciasAbertas();
		Task<LoadResult> GetAssistenciasAbertas(DataSourceLoadOptions loadOptions);
	}
}

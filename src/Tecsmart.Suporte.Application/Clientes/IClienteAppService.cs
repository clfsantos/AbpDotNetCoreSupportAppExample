using Abp.Application.Services;
using Abp.Application.Services.Dto;
using DevExtreme.AspNet.Data.ResponseModel;
using DevExtreme.AspNet.Mvc;
using System.Threading.Tasks;
using Tecsmart.Suporte.Clientes.Dto;

namespace Tecsmart.Suporte.Clientes
{
    public interface IClienteAppService : IApplicationService
	{
		Task<GetClienteForEditOutput> GetClienteForEdit(EntityDto<int> input);
		Task CreateOrEdit(CreateOrEditClienteDto input);
		Task Delete(EntityDto<int> input);
		Task<LoadResult> GetAllForLoadResult(DataSourceLoadOptions loadOptions);
		Task<LoadResult> GetContratosCliente(DataSourceLoadOptions loadOptions);
		Task IntegracaoOmie(EntityDto<bool> input);
	}
}

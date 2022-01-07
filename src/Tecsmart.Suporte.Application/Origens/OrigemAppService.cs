using Abp.Application.Services.Dto;
using Abp.Authorization;
using Abp.Domain.Repositories;
using AutoMapper;
using DevExtreme.AspNet.Data.ResponseModel;
using DevExtreme.AspNet.Mvc;
using System.Threading.Tasks;
using Tecsmart.Suporte.Authorization;
using Tecsmart.Suporte.Origens.Dto;

namespace Tecsmart.Suporte.Origens
{
    //[AbpAuthorize(PermissionNames.Pages_Clientes)]
    public class OrigemAppService : SuporteAppServiceBase, IOrigemAppService
    {
        private readonly IRepository<Origem, int> _origemRepository;
        private readonly IMapper _mapper;

        public OrigemAppService(IRepository<Origem, int> origemRepository, IMapper mapper)
        {
            _origemRepository = origemRepository;
            _mapper = mapper;
        }

        //[AbpAuthorize(PermissionNames.Pages_Clientes)]
        //public async Task<GetClienteForEditOutput> GetClienteForEdit(EntityDto<int> input)
        //{
        //    var cliente = await _clienteRepository.FirstOrDefaultAsync(input.Id);
        //    var output = new GetClienteForEditOutput { Cliente = ObjectMapper.Map<CreateOrEditClienteDto>(cliente) };
        //    return output;
        //}

        //public async Task CreateOrEdit(CreateOrEditClienteDto input)
        //{
        //    if (input.Id == null)
        //    {
        //        await Create(input);
        //    }
        //    else
        //    {
        //        await Update(input);
        //    }
        //}

        //[AbpAuthorize(PermissionNames.Pages_Clientes)]
        //protected virtual async Task Create(CreateOrEditClienteDto input)
        //{
        //    var cliente = ObjectMapper.Map<Cliente>(input);
        //    await _clienteRepository.InsertAsync(cliente);
        //}

        //[AbpAuthorize(PermissionNames.Pages_Clientes)]
        //protected virtual async Task Update(CreateOrEditClienteDto input)
        //{
        //    var cliente = await _clienteRepository.FirstOrDefaultAsync((int)input.Id);
        //    ObjectMapper.Map(input, cliente);
        //}

        //[AbpAuthorize(PermissionNames.Pages_Clientes)]
        //public async Task Delete(EntityDto<int> input)
        //{
        //    await _clienteRepository.DeleteAsync(input.Id);
        //}

        public async Task<LoadResult> GetAllForLoadResult(DataSourceLoadOptions loadOptions)
        {
            var filteredOrigens = _origemRepository.GetAll();
            return await Devex.DataSourceLoader.LoadDtoAsync<Origem, OrigemDto>(_mapper, filteredOrigens, loadOptions);
        }

    }
}

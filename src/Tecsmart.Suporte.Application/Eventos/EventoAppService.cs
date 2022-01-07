using Abp.Application.Services.Dto;
using Abp.Authorization;
using Abp.Domain.Repositories;
using AutoMapper;
using DevExtreme.AspNet.Data.ResponseModel;
using DevExtreme.AspNet.Mvc;
using System.Threading.Tasks;
using Tecsmart.Suporte.Authorization;
using Tecsmart.Suporte.Eventos.Dto;

namespace Tecsmart.Suporte.Eventos
{
    //[AbpAuthorize(PermissionNames.Pages_Clientes)]
    public class EventoAppService : SuporteAppServiceBase, IEventoAppService
    {
        private readonly IRepository<Evento, int> _eventoRepository;
        private readonly IMapper _mapper;

        public EventoAppService(IRepository<Evento, int> eventoRepository, IMapper mapper)
        {
            _eventoRepository = eventoRepository;
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
            var filteredEventos = _eventoRepository.GetAll();
            loadOptions.StringToLower = true;
            return await Devex.DataSourceLoader.LoadDtoAsync<Evento, EventoDto>(_mapper, filteredEventos, loadOptions);
        }

    }
}

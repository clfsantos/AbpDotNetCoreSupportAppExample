using Abp.Application.Services.Dto;
using Abp.Authorization;
using Abp.Domain.Repositories;
using AutoMapper;
using DevExtreme.AspNet.Data.ResponseModel;
using DevExtreme.AspNet.Mvc;
using System.Threading.Tasks;
using Tecsmart.Suporte.Authorization;
using Tecsmart.Suporte.Equipamentos.Dto;

namespace Tecsmart.Suporte.Equipamentos
{
    [AbpAuthorize(PermissionNames.Pages_Equipamentos)]
    public class EquipamentoAppService : SuporteAppServiceBase, IEquipamentoAppService
    {
        private readonly IRepository<Equipamento, int> _equipamentoRepository;
        private readonly IMapper _mapper;

        public EquipamentoAppService(IRepository<Equipamento, int> equipamentoRepository, IMapper mapper)
        {
            _equipamentoRepository = equipamentoRepository;
            _mapper = mapper;
        }

        [AbpAuthorize(PermissionNames.Pages_Equipamentos)]
        public async Task<GetEquipamentoForEditOutput> GetEquipamentoForEdit(EntityDto<int> input)
        {
            var equipamento = await _equipamentoRepository.FirstOrDefaultAsync(input.Id);
            var output = new GetEquipamentoForEditOutput { Equipamento = ObjectMapper.Map<CreateOrEditEquipamentoDto>(equipamento) };
            return output;
        }

        public async Task CreateOrEdit(CreateOrEditEquipamentoDto input)
        {
            if (input.Id == null)
            {
                await Create(input);
            }
            else
            {
                await Update(input);
            }
        }

        [AbpAuthorize(PermissionNames.Pages_Equipamentos)]
        protected virtual async Task Create(CreateOrEditEquipamentoDto input)
        {
            var equipamento = ObjectMapper.Map<Equipamento>(input);
            await _equipamentoRepository.InsertAsync(equipamento);
        }

        [AbpAuthorize(PermissionNames.Pages_Equipamentos)]
        protected virtual async Task Update(CreateOrEditEquipamentoDto input)
        {
            var equipamento = await _equipamentoRepository.FirstOrDefaultAsync((int)input.Id);
            ObjectMapper.Map(input, equipamento);
        }

        [AbpAuthorize(PermissionNames.Pages_Equipamentos)]
        public async Task Delete(EntityDto<int> input)
        {
            await _equipamentoRepository.DeleteAsync(input.Id);
        }

        [AbpAuthorize(PermissionNames.Pages_Equipamentos)]
        public async Task<LoadResult> GetAllForLoadResult(DataSourceLoadOptions loadOptions)
        {
            var filteredEquipamentos = _equipamentoRepository.GetAll();
            loadOptions.StringToLower = true;
            return await Devex.DataSourceLoader.LoadDtoAsync<Equipamento, EquipamentoDto>(_mapper, filteredEquipamentos, loadOptions);
        }

    }
}

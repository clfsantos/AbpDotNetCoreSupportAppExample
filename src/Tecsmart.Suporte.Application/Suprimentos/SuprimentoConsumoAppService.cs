using Abp.Application.Services.Dto;
using Abp.Authorization;
using Abp.Domain.Repositories;
using AutoMapper;
using DevExtreme.AspNet.Data.ResponseModel;
using DevExtreme.AspNet.Mvc;
using System.Threading.Tasks;
using Tecsmart.Suporte.Authorization;
using Tecsmart.Suporte.Crachas;
using Tecsmart.Suporte.Suprimentos.Dto;

namespace Tecsmart.Suporte.Suprimentos
{
    [AbpAuthorize(PermissionNames.Pages_Crachas_Suprimentos)]
    public class SuprimentoConsumoAppService : SuporteAppServiceBase, ISuprimentoConsumoAppService
    {
        private readonly IRepository<SuprimentoConsumo, int> _suprimentoConsumoRepository;
        private readonly IMapper _mapper;

        public SuprimentoConsumoAppService(IRepository<SuprimentoConsumo, int> suprimentoConsumoRepository, IMapper mapper)
        {
            _suprimentoConsumoRepository = suprimentoConsumoRepository;
            _mapper = mapper;
        }

        [AbpAuthorize(PermissionNames.Pages_Crachas_Suprimentos)]
        public async Task<GetSuprimentoConsumoForEditOutput> GetSuprimentoConsumoForEdit(EntityDto<int> input)
        {
            var suprimentoConsumo = await _suprimentoConsumoRepository.FirstOrDefaultAsync(input.Id);
            var output = new GetSuprimentoConsumoForEditOutput { SuprimentoConsumo = ObjectMapper.Map<CreateOrEditSuprimentoConsumoDto>(suprimentoConsumo) };
            return output;
        }

        public async Task CreateOrEdit(CreateOrEditSuprimentoConsumoDto input)
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

        [AbpAuthorize(PermissionNames.Pages_Crachas_Suprimentos)]
        protected virtual async Task Create(CreateOrEditSuprimentoConsumoDto input)
        {
            var suprimentoConsumo = ObjectMapper.Map<SuprimentoConsumo>(input);
            await _suprimentoConsumoRepository.InsertAsync(suprimentoConsumo);
        }

        [AbpAuthorize(PermissionNames.Pages_Clientes)]
        protected virtual async Task Update(CreateOrEditSuprimentoConsumoDto input)
        {
            var suprimentoConsumo = await _suprimentoConsumoRepository.FirstOrDefaultAsync((int)input.Id);
            ObjectMapper.Map(input, suprimentoConsumo);
        }

        [AbpAuthorize(PermissionNames.Pages_Crachas_Suprimentos)]
        public async Task Delete(EntityDto<int> input)
        {
            await _suprimentoConsumoRepository.DeleteAsync(input.Id);
        }

        [AbpAuthorize(PermissionNames.Pages_Crachas_Suprimentos)]
        public async Task<LoadResult> GetAllForLoadResult(DataSourceLoadOptions loadOptions)
        {
            var filtered = _suprimentoConsumoRepository.GetAll();
            return await Devex.DataSourceLoader.LoadDtoAsync<SuprimentoConsumo, SuprimentoConsumoDto>(_mapper, filtered, loadOptions);
        }

    }
}

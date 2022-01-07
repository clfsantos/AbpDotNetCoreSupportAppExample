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
    public class SuprimentoAppService : SuporteAppServiceBase, ISuprimentoAppService
    {
        private readonly IRepository<Suprimento, int> _suprimentoRepository;
        private readonly IMapper _mapper;

        public SuprimentoAppService(IRepository<Suprimento, int> suprimentoRepository, IMapper mapper)
        {
            _suprimentoRepository = suprimentoRepository;
            _mapper = mapper;
        }

        [AbpAuthorize(PermissionNames.Pages_Crachas_Suprimentos)]
        public async Task<GetSuprimentoForEditOutput> GetSuprimentoForEdit(EntityDto<int> input)
        {
            var suprimento = await _suprimentoRepository.FirstOrDefaultAsync(input.Id);
            var output = new GetSuprimentoForEditOutput { Suprimento = ObjectMapper.Map<CreateOrEditSuprimentoDto>(suprimento) };
            return output;
        }

        public async Task CreateOrEdit(CreateOrEditSuprimentoDto input)
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
        protected virtual async Task Create(CreateOrEditSuprimentoDto input)
        {
            var suprimento = ObjectMapper.Map<Suprimento>(input);
            await _suprimentoRepository.InsertAsync(suprimento);
        }

        [AbpAuthorize(PermissionNames.Pages_Clientes)]
        protected virtual async Task Update(CreateOrEditSuprimentoDto input)
        {
            var suprimento = await _suprimentoRepository.FirstOrDefaultAsync((int)input.Id);
            ObjectMapper.Map(input, suprimento);
        }

        [AbpAuthorize(PermissionNames.Pages_Crachas_Suprimentos)]
        public async Task Delete(EntityDto<int> input)
        {
            await _suprimentoRepository.DeleteAsync(input.Id);
        }

        [AbpAuthorize(PermissionNames.Pages_Crachas_Suprimentos)]
        public async Task<LoadResult> GetAllForLoadResult(DataSourceLoadOptions loadOptions)
        {
            var filtered = _suprimentoRepository.GetAll();
            return await Devex.DataSourceLoader.LoadDtoAsync<Suprimento, SuprimentoDto>(_mapper, filtered, loadOptions);
        }

    }
}

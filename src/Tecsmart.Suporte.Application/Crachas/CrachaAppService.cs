using Abp.Application.Services.Dto;
using Abp.Authorization;
using Abp.Domain.Repositories;
using Abp.UI;
using AutoMapper;
using DevExtreme.AspNet.Data.ResponseModel;
using DevExtreme.AspNet.Mvc;
using System.Linq;
using System.Threading.Tasks;
using Tecsmart.Suporte.Authorization;
using Tecsmart.Suporte.Crachas.Dto;
using Tecsmart.Suporte.Crachas.Type;

namespace Tecsmart.Suporte.Crachas
{
    [AbpAuthorize(PermissionNames.Pages_Crachas)]
    public class CrachaAppService : SuporteAppServiceBase, ICrachaAppService
    {
        private readonly IRepository<Cracha, int> _crachaRepository;
        private readonly IMapper _mapper;

        public CrachaAppService(IRepository<Cracha, int> crachaRepository, IMapper mapper)
        {
            _crachaRepository = crachaRepository;
            _mapper = mapper;
        }

        [AbpAuthorize(PermissionNames.Pages_Crachas)]
        public async Task<GetCrachaForEditOutput> GetCrachaForEdit(EntityDto<int> input)
        {
            var cracha = await _crachaRepository.FirstOrDefaultAsync(input.Id);
            var output = new GetCrachaForEditOutput { Cracha = ObjectMapper.Map<CreateOrEditCrachaDto>(cracha) };
            return output;
        }

        public async Task CreateOrEdit(CreateOrEditCrachaDto input)
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

        [AbpAuthorize(PermissionNames.Pages_Crachas)]
        protected virtual async Task Create(CreateOrEditCrachaDto input)
        {
            var cracha = ObjectMapper.Map<Cracha>(input);
            await _crachaRepository.InsertAsync(cracha);
        }

        [AbpAuthorize(PermissionNames.Pages_Crachas)]
        protected virtual async Task Update(CreateOrEditCrachaDto input)
        {
            var cracha = await _crachaRepository.FirstOrDefaultAsync((int)input.Id);
            if (input.Status == 3)
            {
                if (!input.QtdImpressa.HasValue)
                {
                    throw new UserFriendlyException("Ops!", "A quantidade impressa deve ser informada na conclusão.");
                }

                if (!input.QtdPerdida.HasValue)
                {
                    throw new UserFriendlyException("Ops!", "A quantidade perdida deve ser informada na conclusão.");
                }

                if (!input.Impressora.HasValue)
                {
                    throw new UserFriendlyException("Ops!", "A impressora utilizada deve ser informada na conclusão.");
                }

                if (!input.DataTermino.HasValue)
                {
                    throw new UserFriendlyException("Ops!", "A data do término deve ser informada na conclusão.");
                }
            }
            ObjectMapper.Map(input, cracha);
        }

        [AbpAuthorize(PermissionNames.Pages_Crachas)]
        public async Task Delete(EntityDto<int> input)
        {
            await _crachaRepository.DeleteAsync(input.Id);
        }

        [AbpAuthorize(PermissionNames.Pages_Crachas)]
        public async Task<LoadResult> GetAllForLoadResult(DataSourceLoadOptions loadOptions)
        {
            var filteredCrachas = _crachaRepository.GetAll();
            loadOptions.StringToLower = true;
            return await Devex.DataSourceLoader.LoadDtoAsync<Cracha, CrachaDto>(_mapper, filteredCrachas, loadOptions);
        }

        [AbpAuthorize(PermissionNames.Pages_Crachas)]
        public CrachaInfoDto GetInfoCrachas()
        {
            var crachas = _crachaRepository.GetAll().GroupBy(x => 1).Select(p => new CrachaInfoDto() { 
                TotalPedido = p.Sum(y => y.QtdPedida),
                TotalPerdido = p.Sum(y => y.QtdPerdida),
                TotalImpresso = p.Sum(y => y.QtdImpressa)
            }).ToList().FirstOrDefault();
            
            return crachas;
        }

    }
}

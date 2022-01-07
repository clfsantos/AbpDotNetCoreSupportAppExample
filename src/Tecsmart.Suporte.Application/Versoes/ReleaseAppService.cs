using Abp.Application.Services.Dto;
using Abp.Authorization;
using Abp.Domain.Repositories;
using AutoMapper;
using DevExtreme.AspNet.Data.ResponseModel;
using DevExtreme.AspNet.Mvc;
using System.Threading.Tasks;
using Tecsmart.Suporte.Authorization;
using Tecsmart.Suporte.Releases.Dto;

namespace Tecsmart.Suporte.Releases
{
    [AbpAuthorize(PermissionNames.Pages_Releases)]
    public class ReleaseAppService : SuporteAppServiceBase, IReleaseAppService
    {
        private readonly IRepository<Release, int> _releaseRepository;
        private readonly IMapper _mapper;

        public ReleaseAppService(IRepository<Release, int> releaseRepository, IMapper mapper)
        {
            _releaseRepository = releaseRepository;
            _mapper = mapper;
        }

        [AbpAuthorize(PermissionNames.Pages_Releases)]
        public async Task<GetReleaseForEditOutput> GetReleaseForEdit(EntityDto<int> input)
        {
            var release = await _releaseRepository.FirstOrDefaultAsync(input.Id);
            var output = new GetReleaseForEditOutput { Release = ObjectMapper.Map<CreateOrEditReleaseDto>(release) };
            return output;
        }

        public async Task CreateOrEdit(CreateOrEditReleaseDto input)
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

        [AbpAuthorize(PermissionNames.Pages_Releases)]
        protected virtual async Task Create(CreateOrEditReleaseDto input)
        {
            var release = ObjectMapper.Map<Release>(input);
            await _releaseRepository.InsertAsync(release);
        }

        [AbpAuthorize(PermissionNames.Pages_Releases)]
        protected virtual async Task Update(CreateOrEditReleaseDto input)
        {
            var release = await _releaseRepository.FirstOrDefaultAsync((int)input.Id);
            ObjectMapper.Map(input, release);
        }

        [AbpAuthorize(PermissionNames.Pages_Releases)]
        public async Task Delete(EntityDto<int> input)
        {
            await _releaseRepository.DeleteAsync(input.Id);
        }

        [AbpAuthorize(PermissionNames.Pages_Releases)]
        public async Task<LoadResult> GetAllForLoadResult(DataSourceLoadOptions loadOptions)
        {
            var filteredReleases = _releaseRepository.GetAll();
            return await Devex.DataSourceLoader.LoadDtoAsync<Release, ReleaseDto>(_mapper, filteredReleases, loadOptions);
        }

    }
}

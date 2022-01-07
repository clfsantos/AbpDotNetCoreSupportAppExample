using Abp.Application.Services.Dto;
using Abp.Authorization;
using Abp.Domain.Repositories;
using AutoMapper;
using DevExtreme.AspNet.Data.ResponseModel;
using DevExtreme.AspNet.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using Tecsmart.Suporte.Authorization;
using Tecsmart.Suporte.Produtos.Dto;

namespace Tecsmart.Suporte.Produtos
{
    [AbpAuthorize(PermissionNames.Pages_SubGrupos)]
    public class SubGrupoAppService : SuporteAppServiceBase, ISubGrupoAppService
    {
        private readonly IRepository<SubGrupo, int> _subGrupoRepository;
        private readonly IRepository<GrupoSubGrupo, int> _grupoSubGrupoRepository;
        private readonly IMapper _mapper;

        public SubGrupoAppService(IRepository<SubGrupo, int> subGrupoRepository, IRepository<GrupoSubGrupo, int> grupoSubGrupoRepository, IMapper mapper)
        {
            _subGrupoRepository = subGrupoRepository;
            _grupoSubGrupoRepository = grupoSubGrupoRepository;
            _mapper = mapper;
        }

        [AbpAuthorize(PermissionNames.Pages_SubGrupos)]
        public async Task<GetSubGrupoForEditOutput> GetSubGrupoForEdit(EntityDto<int> input)
        {
            var subGrupo = await _subGrupoRepository.FirstOrDefaultAsync(input.Id);
            var output = new GetSubGrupoForEditOutput { SubGrupo = ObjectMapper.Map<CreateOrEditSubGrupoDto>(subGrupo) };
            var grupos = _grupoSubGrupoRepository.GetAllListAsync(x => x.Id == input.Id).Result;
            List<int> itens = new List<int>();
            foreach (var item in grupos)
            {
                itens.Add(item.GrupoId);
            }
            output.Grupos = itens;
            return output;
        }

        public async Task CreateOrEdit(GetSubGrupoForEditOutput input)
        {
            if (input.SubGrupo.Id == null)
            {
                await Create(input);
            }
            else
            {
                await Update(input);
            }
        }

        [AbpAuthorize(PermissionNames.Pages_SubGrupos_Create)]
        protected virtual async Task Create(GetSubGrupoForEditOutput input)
        {
            var subGrupo = ObjectMapper.Map<SubGrupo>(input.SubGrupo);
            int subGrupoId = await _subGrupoRepository.InsertAndGetIdAsync(subGrupo);
            await RelacionaGrupoSubGrupo(input.Grupos, subGrupoId);
        }

        [AbpAuthorize(PermissionNames.Pages_SubGrupos_Edit)]
        protected virtual async Task Update(GetSubGrupoForEditOutput input)
        {
            var subGrupo = await _subGrupoRepository.FirstOrDefaultAsync((int)input.SubGrupo.Id);
            ObjectMapper.Map(input.SubGrupo, subGrupo);
            await RelacionaGrupoSubGrupo(input.Grupos, subGrupo.Id);
        }

        private async Task RelacionaGrupoSubGrupo(List<int> grupos, int subGrupoId)
        {
            await _grupoSubGrupoRepository.DeleteAsync(p => p.Id == subGrupoId);
            foreach (var item in grupos)
            {
                var grupoSubGrupo = new GrupoSubGrupo()
                {
                    Id = subGrupoId,
                    GrupoId = item
                };
                await _grupoSubGrupoRepository.InsertAsync(grupoSubGrupo);
            }
        }

        [AbpAuthorize(PermissionNames.Pages_SubGrupos_Delete)]
        public async Task Delete(EntityDto<int> input)
        {
            await _subGrupoRepository.DeleteAsync(input.Id);
        }

        [AbpAuthorize(PermissionNames.Pages_SubGrupos)]
        public async Task<LoadResult> GetAllForLoadResult(DataSourceLoadOptions loadOptions)
        {
            var filteredSubGrupos = _grupoSubGrupoRepository.GetAll();
            return await Devex.DataSourceLoader.LoadDtoAsync<GrupoSubGrupo, GrupoSubGrupoDto>(_mapper, filteredSubGrupos, loadOptions);
        }

        [AbpAuthorize(PermissionNames.Pages_SubGrupos)]
        public async Task<LoadResult> GetAllSubGrupos(DataSourceLoadOptions loadOptions)
        {
            var filteredSubGrupos = _subGrupoRepository.GetAll();
            return await Devex.DataSourceLoader.LoadDtoAsync<SubGrupo, SubGrupoDto>(_mapper, filteredSubGrupos, loadOptions);
        }

    }
}

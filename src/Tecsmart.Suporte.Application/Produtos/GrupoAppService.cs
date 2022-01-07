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
    [AbpAuthorize(PermissionNames.Pages_Grupos)]
    public class GrupoAppService : SuporteAppServiceBase, IGrupoAppService
    {
        private readonly IRepository<Grupo, int> _grupoRepository;
        private readonly IRepository<ProdutoGrupo, int> _produtoGrupoRepository;
        private readonly IMapper _mapper;

        public GrupoAppService(IRepository<Grupo, int> grupoRepository, IRepository<ProdutoGrupo, int> produtoGrupoRepository, IMapper mapper)
        {
            _grupoRepository = grupoRepository;
            _produtoGrupoRepository = produtoGrupoRepository;
            _mapper = mapper;
        }

        [AbpAuthorize(PermissionNames.Pages_Grupos)]
        public async Task<GetGrupoForEditOutput> GetGrupoForEdit(EntityDto<int> input)
        {
            var grupo = await _grupoRepository.FirstOrDefaultAsync(input.Id);
            var output = new GetGrupoForEditOutput { Grupo = ObjectMapper.Map<CreateOrEditGrupoDto>(grupo) };
            var produtos = _produtoGrupoRepository.GetAllListAsync(x => x.Id == input.Id).Result;
            List<int> itens = new List<int>();
            foreach (var item in produtos)
            {
                itens.Add(item.ProdutoId);
            }
            output.Produtos = itens;
            return output;
        }

        public async Task CreateOrEdit(GetGrupoForEditOutput input)
        {
            if (input.Grupo.Id == null)
            {
                await Create(input);
            }
            else
            {
                await Update(input);
            }
        }

        [AbpAuthorize(PermissionNames.Pages_Grupos_Create)]
        protected virtual async Task Create(GetGrupoForEditOutput input)
        {
            var grupo = ObjectMapper.Map<Grupo>(input.Grupo);
            int grupoId = await _grupoRepository.InsertAndGetIdAsync(grupo);
            await RelacionaProdutoGrupo(input.Produtos, grupoId);
        }

        [AbpAuthorize(PermissionNames.Pages_Grupos_Edit)]
        protected virtual async Task Update(GetGrupoForEditOutput input)
        {
            var grupo = await _grupoRepository.FirstOrDefaultAsync((int)input.Grupo.Id);
            ObjectMapper.Map(input.Grupo, grupo);
            await RelacionaProdutoGrupo(input.Produtos, grupo.Id);
        }

        private async Task RelacionaProdutoGrupo(List<int> produtos, int grupoId)
        {
            await _produtoGrupoRepository.DeleteAsync(p => p.Id == grupoId);
            foreach (var item in produtos)
            {
                var produtoGrupo = new ProdutoGrupo()
                {
                    Id = grupoId,
                    ProdutoId = item
                };
                await _produtoGrupoRepository.InsertAsync(produtoGrupo);
            }
        }

        [AbpAuthorize(PermissionNames.Pages_Grupos_Delete)]
        public async Task Delete(EntityDto<int> input)
        {
            await _grupoRepository.DeleteAsync(input.Id);
        }

        [AbpAuthorize(PermissionNames.Pages_Grupos)]
        public async Task<LoadResult> GetAllForLoadResult(DataSourceLoadOptions loadOptions)
        {
            var filteredGrupos = _produtoGrupoRepository.GetAll();
            return await Devex.DataSourceLoader.LoadDtoAsync<ProdutoGrupo, ProdutoGrupoDto>(_mapper, filteredGrupos, loadOptions);
        }

        [AbpAuthorize(PermissionNames.Pages_Grupos)]
        public async Task<LoadResult> GetAllGrupos(DataSourceLoadOptions loadOptions)
        {
            var filteredGrupos = _grupoRepository.GetAll();
            return await Devex.DataSourceLoader.LoadDtoAsync<Grupo, GrupoDto>(_mapper, filteredGrupos, loadOptions);
        }

    }
}

using Abp.Application.Services.Dto;
using Abp.Authorization;
using Abp.Domain.Repositories;
using Abp.Runtime.Session;
using Abp.UI;
using AutoMapper;
using DevExtreme.AspNet.Data.ResponseModel;
using DevExtreme.AspNet.Mvc;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System.Threading.Tasks;
using Tecsmart.Suporte.Authorization;
using Tecsmart.Suporte.Chamados.Dto;

namespace Tecsmart.Suporte.Chamados
{
    [AbpAuthorize(PermissionNames.Pages_Chamados)]
    public class AnexoAppService : SuporteAppServiceBase, IAnexoAppService
    {
        private readonly IRepository<Anexo, int> _anexoRepository;
        private readonly IMapper _mapper;
        private readonly IAbpSession _session;

        public AnexoAppService(IRepository<Anexo, int> anexoRepository, IMapper mapper, IAbpSession session)
        {
            _anexoRepository = anexoRepository;
            _mapper = mapper;
            _session = session;
        }

        [AbpAuthorize(PermissionNames.Pages_Chamados)]
        public async Task<GetAnexoForEditOutput> GetAnexoForEdit(EntityDto<int> input)
        {
            var anexo = await _anexoRepository.FirstOrDefaultAsync(input.Id);
            var output = new GetAnexoForEditOutput { Anexo = ObjectMapper.Map<CreateOrEditAnexoDto>(anexo) };
            return output;
        }

        public async Task CreateOrEdit(CreateOrEditAnexoDto input)
        {
            input.UsuarioId = (long)_session.UserId;
            if (input.Id == null)
            {
                await Create(input);
            }
            else
            {
                await Update(input);
            }
        }

        [AbpAuthorize(PermissionNames.Pages_Chamados)]
        protected virtual async Task Create(CreateOrEditAnexoDto input)
        {
            var anexo = ObjectMapper.Map<Anexo>(input);
            await _anexoRepository.InsertAsync(anexo);
        }

        [AbpAuthorize(PermissionNames.Pages_Chamados)]
        protected virtual async Task Update(CreateOrEditAnexoDto input)
        {
            var anexo = await _anexoRepository.FirstOrDefaultAsync((int)input.Id);
            ObjectMapper.Map(input, anexo);
        }

        [AbpAuthorize(PermissionNames.Pages_Chamados)]
        public async Task Delete(int input)
        {
            await _anexoRepository.DeleteAsync(input);
        }

        public async Task<LoadResult> GetAllForLoadResult(DataSourceLoadOptions loadOptions, int chamadoId)
        {
            var filteredAnexos = _anexoRepository.GetAll().Where(p => p.ChamadoId == chamadoId);
            return await Devex.DataSourceLoader.LoadDtoAsync<Anexo, AnexoDto>(_mapper, filteredAnexos, loadOptions);
        }

    }
}

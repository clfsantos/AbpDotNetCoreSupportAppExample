using Abp.Application.Services.Dto;
using Abp.Authorization;
using Abp.Domain.Repositories;
using Abp.Domain.Uow;
using Abp.Runtime.Session;
using Abp.UI;
using AutoMapper;
using DevExtreme.AspNet.Data.ResponseModel;
using DevExtreme.AspNet.Mvc;
using System.Linq;
using System.Threading.Tasks;
using Tecsmart.Suporte.Authorization;
using Tecsmart.Suporte.FilaAtendimentos.Dto;

namespace Tecsmart.Suporte.FilaAtendimentos
{
    [AbpAuthorize(PermissionNames.Pages_Fila_Atendimento)]
    public class FilaRetornoAppService : SuporteAppServiceBase, IFilaRetornoAppService
    {
        private readonly IRepository<FilaRetorno, int> _filaRetornoRepository;
        private readonly IRepository<FilaAtendimento, int> _filaAtendimentoRetornoRepository;
        private readonly IMapper _mapper;
        private readonly IAbpSession _session;

        public FilaRetornoAppService(IRepository<FilaRetorno, int> filaRetornoRepository,
                                     IRepository<FilaAtendimento, int> filaAtendimentoRetornoRepository,
                                     IMapper mapper,
                                     IAbpSession session)
        {
            _filaRetornoRepository = filaRetornoRepository;
            _filaAtendimentoRetornoRepository = filaAtendimentoRetornoRepository;
            _mapper = mapper;
            _session = session;
        }

        [AbpAuthorize(PermissionNames.Pages_Fila_Atendimento)]
        public async Task<GetFilaRetornoForEditOutput> GetFilaRetornoForEdit(EntityDto<int> input)
        {
            var filaRetorno = await _filaRetornoRepository.FirstOrDefaultAsync(input.Id);
            var output = new GetFilaRetornoForEditOutput { FilaRetorno = ObjectMapper.Map<CreateOrEditFilaRetornoDto>(filaRetorno) };
            return output;
        }

        public async Task CreateOrEdit(CreateOrEditFilaRetornoDto input)
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

        [AbpAuthorize(PermissionNames.Pages_Fila_Atendimento)]
        [UnitOfWork]
        protected virtual async Task Create(CreateOrEditFilaRetornoDto input)
        {
            var filaRetorno = ObjectMapper.Map<FilaRetorno>(input);
            await _filaRetornoRepository.InsertAsync(filaRetorno);
            var filaAtendimento = await _filaAtendimentoRetornoRepository.FirstOrDefaultAsync(input.FilaAtendimentoId);
            if (filaAtendimento.Atendido)
            {
                throw new UserFriendlyException("Ops!", "Não é possível cadastrar retornos para atendimentos que já foram atendidos.");
            }
            if (input.TipoRetorno == 2)
            {
                filaAtendimento.QtdRetorno += 1;
            }
            await _filaAtendimentoRetornoRepository.UpdateAsync(filaAtendimento);
        }

        [AbpAuthorize(PermissionNames.Pages_Fila_Atendimento)]
        protected virtual async Task Update(CreateOrEditFilaRetornoDto input)
        {
            var filaRetorno = await _filaRetornoRepository.FirstOrDefaultAsync((int)input.Id);
            ObjectMapper.Map(input, filaRetorno);
        }

        public async Task<LoadResult> GetAllForLoadResult(DataSourceLoadOptions loadOptions, int filaAtendimentoId)
        {
            var filteredRetornos = _filaRetornoRepository.GetAll().Where(p => p.FilaAtendimentoId == filaAtendimentoId); ;
            return await Devex.DataSourceLoader.LoadDtoAsync<FilaRetorno, FilaRetornoDto>(_mapper, filteredRetornos, loadOptions);
        }

    }
}

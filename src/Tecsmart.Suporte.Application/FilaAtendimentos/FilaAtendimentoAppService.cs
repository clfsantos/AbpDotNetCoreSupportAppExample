using Abp.Application.Services.Dto;
using Abp.Authorization;
using Abp.Domain.Repositories;
using Abp.Domain.Uow;
using Abp.Runtime.Session;
using Abp.UI;
using AutoMapper;
using DevExtreme.AspNet.Data.ResponseModel;
using DevExtreme.AspNet.Mvc;
using System;
using System.Linq;
using System.Threading.Tasks;
using Tecsmart.Suporte.Authorization;
using Tecsmart.Suporte.Chamados;
using Tecsmart.Suporte.FilaAtendimentos.Dto;
using Tecsmart.Suporte.OnSignal;

namespace Tecsmart.Suporte.FilaAtendimentos
{
    [AbpAuthorize(PermissionNames.Pages_Fila_Atendimento)]
    public class FilaAtendimentoAppService : SuporteAppServiceBase, IFilaAtendimentoAppService
    {
        private readonly IRepository<FilaAtendimento, int> _filaAtendimentoRepository;
        private readonly IRepository<FilaRetorno, int> _filaRetornoRepository;
        private readonly IRepository<ChamadoFluxo, int> _chamadoFluxoRepository;
        private readonly IMapper _mapper;
        private readonly IAbpSession _session;

        public FilaAtendimentoAppService(IRepository<FilaAtendimento, int> filaAtendimentoRepository,
                                         IRepository<FilaRetorno, int> filaRetornoRepository,
                                         IRepository<ChamadoFluxo, int> chamadoFluxoRepository, 
                                         IMapper mapper,
                                         IAbpSession session)
        {
            _filaAtendimentoRepository = filaAtendimentoRepository;
            _filaRetornoRepository = filaRetornoRepository;
            _chamadoFluxoRepository = chamadoFluxoRepository;
            _mapper = mapper;
            _session = session;
        }

        [AbpAuthorize(PermissionNames.Pages_Fila_Atendimento)]
        public async Task<GetFilaAtendimentoForEditOutput> GetFilaAtendimentoForEdit(EntityDto<int> input)
        {
            var filaAtendimento = await _filaAtendimentoRepository.FirstOrDefaultAsync(input.Id);
            var output = new GetFilaAtendimentoForEditOutput { FilaAtendimento = ObjectMapper.Map<CreateOrEditFilaAtendimentoDto>(filaAtendimento) };
            return output;
        }

        public async Task CreateOrEdit(CreateOrEditFilaAtendimentoDto input)
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

        [AbpAuthorize(PermissionNames.Pages_Fila_Atendimento)]
        [UnitOfWork]
        protected virtual async Task Create(CreateOrEditFilaAtendimentoDto input)
        {
            var filaAtendimento = ObjectMapper.Map<FilaAtendimento>(input);
            var filaInsertedId = await _filaAtendimentoRepository.InsertAndGetIdAsync(filaAtendimento);
            var retorno = new FilaRetorno()
            {
                FilaAtendimentoId = filaInsertedId,
                DataRetorno = (DateTime)input.DataFila,
                Observacao = input.Observacao,
                TipoRetorno = 2,
                UsuarioId = (long)_session.UserId
            };
            await _filaRetornoRepository.InsertAsync(retorno);

            OneSignalService.SendPushSuporte("Novo atendimento na fila!", "Foi cadastrado um novo atendimento na fila", "http://10.0.0.251/FilaAtendimentos");
        }

        [AbpAuthorize(PermissionNames.Pages_Fila_Atendimento)]
        protected virtual async Task Update(CreateOrEditFilaAtendimentoDto input)
        {
            var filaAtendimento = await _filaAtendimentoRepository.FirstOrDefaultAsync((int)input.Id);
            ObjectMapper.Map(input, filaAtendimento);
        }

        public async Task<int> QtdFilaAtendimento()
        {
            var qtdFila = await _filaAtendimentoRepository.CountAsync(p => p.Atendido == false);
            return qtdFila;
        }

        [AbpAuthorize(PermissionNames.Pages_Fila_Atendimento)]
        [UnitOfWork]
        public async Task Atender(EntityDto<int> input)
        {
            var fila = await _filaAtendimentoRepository.FirstOrDefaultAsync(input.Id);
            if (fila.Atendido)
            {
                throw new UserFriendlyException("Ops!", "Já foi atendido!");
            }
            fila.Atendido = true;
            var fluxo = new ChamadoFluxo() {
                ClienteId = fila.ClienteId,
                UsuarioId = (long)_session.UserId,
                DataFluxo = DateTime.Now
            };
            await _filaAtendimentoRepository.UpdateAsync(fila);
            await _chamadoFluxoRepository.InsertAsync(fluxo);
        }

        [AbpAuthorize(PermissionNames.Pages_Fila_Atendimento)]
        public async Task Cancelar(EntityDto<int> input)
        {
            var fila = await _filaAtendimentoRepository.FirstOrDefaultAsync(input.Id);
            if (fila.Atendido)
            {
                throw new UserFriendlyException("Ops!", "Não pode cancelar atendimentos já atendidos.");
            }
            fila.Cancelado = true;
            fila.Atendido = true;
            await _filaAtendimentoRepository.UpdateAsync(fila);
        }

        public async Task<LoadResult> GetAllForLoadResult(DataSourceLoadOptions loadOptions)
        {
            var filteredFila = _filaAtendimentoRepository.GetAll();
            //loadOptions.DefaultSort = "id";
            loadOptions.SortByPrimaryKey = true;
           
            return await Devex.DataSourceLoader.LoadDtoAsync<FilaAtendimento, FilaAtendimentoDto>(_mapper, filteredFila, loadOptions);
        }

    }
}

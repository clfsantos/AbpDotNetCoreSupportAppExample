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
using Tecsmart.Suporte.Chamados.Dto;
using Tecsmart.Suporte.OnSignal;

namespace Tecsmart.Suporte.Chamados
{
    [AbpAuthorize(PermissionNames.Pages_Chamados)]
    public class FollowupAppService : SuporteAppServiceBase, IFollowupAppService
    {
        private readonly IRepository<ChamadoFollowup, int> _chamadofollowupRepository;
        private readonly IRepository<Followup, int> _followupRepository;
        private readonly IRepository<Chamado, int> _chamadoRepository;
        private readonly IMapper _mapper;
        private readonly IAbpSession _session;

        public FollowupAppService(IRepository<ChamadoFollowup, int> chamadofollowupRepository,
                                  IRepository<Followup, int> followupRepository,
                                  IRepository<Chamado, int> chamadoRepository,
                                  IMapper mapper,
                                  IAbpSession session)
        {
            _chamadofollowupRepository = chamadofollowupRepository;
            _followupRepository = followupRepository;
            _chamadoRepository = chamadoRepository;
            _mapper = mapper;
            _session = session;
        }

        [AbpAuthorize(PermissionNames.Pages_Chamados)]
        public async Task<GetFollowupForEditOutput> GetFollowupForEdit(EntityDto<int> input)
        {
            var followup = await _followupRepository.FirstOrDefaultAsync(input.Id);
            var output = new GetFollowupForEditOutput { Followup = ObjectMapper.Map<CreateOrEditFollowupDto>(followup) };
            return output;
        }

        public async Task CreateOrEdit(CreateOrEditFollowupDto input)
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
        [UnitOfWork]
        protected virtual async Task Create(CreateOrEditFollowupDto input)
        {
            await VerificaPermissao(input);
            if(input.TransferirChamado)
            {
                input.Tipo = 2;
            }
            var followup = ObjectMapper.Map<Followup>(input);
            var followupInsertedId = await _followupRepository.InsertAndGetIdAsync(followup);
            var chamadoFollowup = new ChamadoFollowup
            {
                ChamadoId = input.ChamadoId,
                Id = followupInsertedId
            };
            await _chamadofollowupRepository.InsertAsync(chamadoFollowup);

            if(input.Tipo == 2 || input.TransferirChamado == true)
            {
                await TransferirChamado(input); 
            }

        }

        [AbpAuthorize(PermissionNames.Pages_Chamados)]
        [UnitOfWork]
        protected virtual async Task Update(CreateOrEditFollowupDto input)
        {
            if (input.TransferirChamado)
            {
                input.Tipo = 2;
            }
            var followup = await _followupRepository.FirstOrDefaultAsync((int)input.Id);
            ObjectMapper.Map(input, followup);

            if (input.Tipo == 2 || input.TransferirChamado == true)
            {
                await TransferirChamado(input);
            }
        }

        private async Task VerificaPermissao(CreateOrEditFollowupDto input)
        {
            var chamado = await _chamadoRepository.FirstOrDefaultAsync(input.ChamadoId);
            //if (chamado.ResponsavelAtualId != (long)_session.UserId)
            //{
            //    throw new UserFriendlyException("Ops!", "Somente o responsável atual do chamado pode incluir follow-ups, se precisar, assuma o chamado primeiro!");
            //}
            if (chamado.ClassificacaoId != 9)
            {
                if (input.Tipo == 3)
                {
                    throw new UserFriendlyException("Ops!", "Somente chamados de manutenção podem receber followups de manutenção!");
                }
            }
            if (chamado.ClassificacaoId == 9)
            {
                if(input.Tipo != 3)
                {
                    throw new UserFriendlyException("Ops!", "Somente followups de manutenção podem ser cadastrados em chamados de manutenção!");
                }
            }
        }

        private async Task TransferirChamado(CreateOrEditFollowupDto input)
        {
            var chamado = await _chamadoRepository.FirstOrDefaultAsync(input.ChamadoId);
            chamado.ResponsavelAtualId = (long)input.UsuarioTransferenciaId;
            await _chamadoRepository.UpdateAsync(chamado);
            OneSignalService.SendPush((long)input.UsuarioTransferenciaId, "Transferência de chamado!", "Você teve uma transferência de chamado", "http://10.0.0.251/Chamados");
        }

        [AbpAuthorize(PermissionNames.Pages_Chamados)]
        public async Task Cancelar(EntityDto<int> input)
        {
            var followup = await _followupRepository.FirstOrDefaultAsync(input.Id);
            if (followup.Cancelado == true)
            {
                throw new UserFriendlyException("Ops!", "Este Followup já está cancelado!");
            }

            followup.Cancelado = true;
            await _followupRepository.UpdateAsync(followup);
        }

        public async Task<LoadResult> GetAllForLoadResult(DataSourceLoadOptions loadOptions, int chamadoId)
        {
            var filteredFollowups = _chamadofollowupRepository.GetAll().Where(p => p.ChamadoId == chamadoId);
            return await Devex.DataSourceLoader.LoadDtoAsync<ChamadoFollowup, ChamadoFollowupDto>(_mapper, filteredFollowups, loadOptions);
        }

    }
}

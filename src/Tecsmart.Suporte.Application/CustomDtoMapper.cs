using AutoMapper;
using Tecsmart.Suporte.CategoriasProblemas.Dto;
using Tecsmart.Suporte.Chamados;
using Tecsmart.Suporte.Chamados.ChartsDto;
using Tecsmart.Suporte.Chamados.Dto;
using Tecsmart.Suporte.Classificacoes;
using Tecsmart.Suporte.Classificacoes.Dto;
using Tecsmart.Suporte.Clientes;
using Tecsmart.Suporte.Clientes.Dto;
using Tecsmart.Suporte.Contratos;
using Tecsmart.Suporte.Contratos.Dto;
using Tecsmart.Suporte.Crachas;
using Tecsmart.Suporte.Crachas.Dto;
using Tecsmart.Suporte.Equipamentos;
using Tecsmart.Suporte.Equipamentos.Categorias;
using Tecsmart.Suporte.Equipamentos.Categorias.Dto;
using Tecsmart.Suporte.Equipamentos.CategoriasProblemas;
using Tecsmart.Suporte.Equipamentos.Dto;
using Tecsmart.Suporte.Equipamentos.Fabricantes;
using Tecsmart.Suporte.Equipamentos.Fabricantes.Dto;
using Tecsmart.Suporte.Equipamentos.Modelos;
using Tecsmart.Suporte.Eventos;
using Tecsmart.Suporte.Eventos.Dto;
using Tecsmart.Suporte.FilaAtendimentos;
using Tecsmart.Suporte.FilaAtendimentos.Dto;
using Tecsmart.Suporte.GridStates;
using Tecsmart.Suporte.GridStates.Dto;
using Tecsmart.Suporte.Modelos.Dto;
using Tecsmart.Suporte.Origens;
using Tecsmart.Suporte.Origens.Dto;
using Tecsmart.Suporte.Produtos;
using Tecsmart.Suporte.Produtos.Dto;
using Tecsmart.Suporte.Releases;
using Tecsmart.Suporte.Releases.Dto;
using Tecsmart.Suporte.Slas;
using Tecsmart.Suporte.Slas.Dto;
using Tecsmart.Suporte.Suprimentos.Dto;

namespace Tecsmart.Suporte
{
    internal static class CustomDtoMapper
    {
        public static void CreateMappings(IMapperConfigurationExpression configuration)
        {
            configuration.CreateMap<CreateOrEditClienteDto, Cliente>().ReverseMap();
            configuration.CreateMap<ClienteViewDto, ClienteView>().ReverseMap();

            configuration.CreateMap<CreateOrEditChamadoDto, Chamado>().ReverseMap();
            configuration.CreateMap<ChamadoDto, Chamado>().ReverseMap();
            configuration.CreateMap<ChamadoViewDto, ChamadoView>().ReverseMap();
            configuration.CreateMap<ChamadoFollowupDto, ChamadoFollowup>().ReverseMap();
            configuration.CreateMap<CreateOrEditFollowupDto, Followup>().ReverseMap();
            configuration.CreateMap<CreateOrEditTarefaDto, Tarefa>().ReverseMap();
            configuration.CreateMap<TarefaDto, Tarefa>().ReverseMap();
            configuration.CreateMap<EtapaChamadoDto, EtapaChamado>().ReverseMap();
            configuration.CreateMap<CreateOrEditEtapaChamadoDto, EtapaChamado>().ReverseMap();
            configuration.CreateMap<EtapaViewDto, EtapaView>().ReverseMap();
            configuration.CreateMap<CreateOrEditAnexoDto, Anexo>().ReverseMap();
            configuration.CreateMap<AnexoDto, Anexo>().ReverseMap();

            configuration.CreateMap<CreateOrEditFilaAtendimentoDto, FilaAtendimento>().ReverseMap();
            configuration.CreateMap<FilaAtendimentoDto, FilaAtendimento>().ReverseMap();
            configuration.CreateMap<FilaRetornoDto, FilaRetorno>().ReverseMap();
            configuration.CreateMap<CreateOrEditFilaRetornoDto, FilaRetorno>().ReverseMap();

            configuration.CreateMap<PrioridadeFluxoViewDto, PrioridadeFluxoView>().ReverseMap();
            configuration.CreateMap<ChamadoFluxoDto, ChamadoFluxo>().ReverseMap();
            configuration.CreateMap<CreateOrEditChamadoFluxoDto, ChamadoFluxo>().ReverseMap();

            configuration.CreateMap<CreateOrEditProdutoDto, Produto>().ReverseMap();
            configuration.CreateMap<ProdutoDto, Produto>().ReverseMap();
            configuration.CreateMap<ProdutoGrupoDto, ProdutoGrupo>().ReverseMap();
            configuration.CreateMap<GrupoSubGrupoDto, GrupoSubGrupo>().ReverseMap();
            configuration.CreateMap<CreateOrEditGrupoDto, Grupo>().ReverseMap();
            configuration.CreateMap<GrupoDto, Grupo>().ReverseMap();
            configuration.CreateMap<CreateOrEditSubGrupoDto, SubGrupo>().ReverseMap();
            configuration.CreateMap<SubGrupoDto, SubGrupo>().ReverseMap();

            configuration.CreateMap<CreateOrEditOrigemDto, Origem>().ReverseMap();
            configuration.CreateMap<OrigemDto, Origem>().ReverseMap();

            configuration.CreateMap<CreateOrEditClassificacaoDto, Classificacao>().ReverseMap();
            configuration.CreateMap<ClassificacaoDto, Classificacao>().ReverseMap();

            configuration.CreateMap<CreateOrEditSlaDto, Sla>().ReverseMap();
            configuration.CreateMap<SlaDto, Sla>().ReverseMap();

            configuration.CreateMap<CreateOrEditReleaseDto, Release>().ReverseMap();
            configuration.CreateMap<ReleaseDto, Release>().ReverseMap();

            configuration.CreateMap<CreateOrEditCrachaDto, Cracha>().ReverseMap();
            configuration.CreateMap<CrachaDto, Cracha>().ReverseMap();

            configuration.CreateMap<CreateOrEditSuprimentoDto, Suprimento>().ReverseMap();
            configuration.CreateMap<SuprimentoDto, Suprimento>().ReverseMap();

            configuration.CreateMap<CreateOrEditSuprimentoConsumoDto, SuprimentoConsumo>().ReverseMap();
            configuration.CreateMap<SuprimentoConsumoDto, SuprimentoConsumo>().ReverseMap();

            configuration.CreateMap<CreateOrEditEventoDto, Evento>().ReverseMap();
            configuration.CreateMap<EventoDto, Evento>().ReverseMap();

            configuration.CreateMap<CreateOrEditAssistenciaDto, Assistencia>().ReverseMap();
            configuration.CreateMap<AssistenciaDto, Assistencia>().ReverseMap();

            configuration.CreateMap<CreateOrEditEquipamentoDto, Equipamento>().ReverseMap();
            configuration.CreateMap<EquipamentoDto, Equipamento>().ReverseMap();

            configuration.CreateMap<CreateOrEditGridStateDto, GridState>().ReverseMap();
            configuration.CreateMap<GridStateDto, GridState>().ReverseMap();

            configuration.CreateMap<ChamadosTecnicoDto, Chamado>().ReverseMap();

            configuration.CreateMap<ContratoDto, Contrato>().ReverseMap();

            configuration.CreateMap<CategoriaProblemaDto, CategoriaProblema>().ReverseMap();

            configuration.CreateMap<CreateOrEditModeloDto, Modelo>().ReverseMap();
            configuration.CreateMap<ModeloDto, Modelo>().ReverseMap();

            configuration.CreateMap<CreateOrEditFabricanteDto, Fabricante>().ReverseMap();
            configuration.CreateMap<FabricanteDto, Fabricante>().ReverseMap();

            configuration.CreateMap<CreateOrEditCategoriaDto, Categoria>().ReverseMap();
            configuration.CreateMap<CategoriaDto, Categoria>().ReverseMap();
        }
    }
}

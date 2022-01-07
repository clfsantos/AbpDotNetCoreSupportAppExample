using Abp.Zero.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Tecsmart.Suporte.Authorization.Roles;
using Tecsmart.Suporte.Authorization.Users;
using Tecsmart.Suporte.Chamados;
using Tecsmart.Suporte.Classificacoes;
using Tecsmart.Suporte.Clidades;
using Tecsmart.Suporte.Clientes;
using Tecsmart.Suporte.Contratos;
using Tecsmart.Suporte.Crachas;
using Tecsmart.Suporte.Equipamentos;
using Tecsmart.Suporte.Equipamentos.Categorias;
using Tecsmart.Suporte.Equipamentos.CategoriasProblemas;
using Tecsmart.Suporte.Equipamentos.Fabricantes;
using Tecsmart.Suporte.Equipamentos.Modelos;
using Tecsmart.Suporte.Eventos;
using Tecsmart.Suporte.FilaAtendimentos;
using Tecsmart.Suporte.GridStates;
using Tecsmart.Suporte.MultiTenancy;
using Tecsmart.Suporte.Origens;
using Tecsmart.Suporte.Produtos;
using Tecsmart.Suporte.Releases;
using Tecsmart.Suporte.Slas;
using Tecsmart.Suporte.Tags;

namespace Tecsmart.Suporte.EntityFrameworkCore
{
    public class SuporteDbContext : AbpZeroDbContext<Tenant, Role, User, SuporteDbContext>
    {
        public virtual DbSet<Chamado> Chamados { get; set; }
        public virtual DbSet<ChamadoView> ViewChamados { get; set; }
        public virtual DbSet<Followup> Followups { get; set; }
        public virtual DbSet<ChamadoFollowup> ChamadoFollowups { get; set; }
        public virtual DbSet<Tarefa> Tarefas { get; set; }
        public virtual DbSet<Etapa> Etapas { get; set; }
        public virtual DbSet<EtapaStatus> EtapaStatus { get; set; }
        public virtual DbSet<EtapaChamado> EtapaChamado { get; set; }
        public virtual DbSet<EtapaView> ViewEtapas { get; set; }
        public virtual DbSet<Anexo> Anexos { get; set; }
        public virtual DbSet<PrioridadeFluxoView> ViewPrioridadeFluxo { get; set; }
        public virtual DbSet<ChamadoFluxo> ChamadoFluxo { get; set; }
        public virtual DbSet<FilaAtendimento> FilaAtendimentos { get; set; }
        public virtual DbSet<FilaRetorno> FilaRetornos { get; set; }
        public virtual DbSet<Cliente> Clientes { get; set; }
        public virtual DbSet<ClienteView> ViewClientes { get; set; }
        public virtual DbSet<Produto> Produtos { get; set; }
        public virtual DbSet<Grupo> Grupos { get; set; }
        public virtual DbSet<ProdutoGrupo> ProdutoGrupo { get; set; }
        public virtual DbSet<SubGrupo> SubGrupos { get; set; }
        public virtual DbSet<GrupoSubGrupo> GrupoSubGrupo { get; set; }
        public virtual DbSet<Origem> Origens { get; set; }
        public virtual DbSet<Classificacao> Classificacoes { get; set; }
        public virtual DbSet<Sla> Slas { get; set; }
        public virtual DbSet<Release> Releases { get; set; }
        public virtual DbSet<Fabricante> Fabricantes { get; set; }
        public virtual DbSet<Categoria> Categorias { get; set; }
        public virtual DbSet<Modelo> Modelo { get; set; }
        public virtual DbSet<Equipamento> Equipamentos { get; set; }
        public virtual DbSet<Assistencia> Assistencias { get; set; }
        public virtual DbSet<Cracha> Crachas { get; set; }
        public virtual DbSet<Suprimento> Suprimentos { get; set; }
        public virtual DbSet<SuprimentoConsumo> SuprimentosConsumo { get; set; }
        public virtual DbSet<Evento> Eventos { get; set; }
        public virtual DbSet<GridState> GridStates { get; set; }
        public virtual DbSet<Contrato> Contratos { get; set; }
        public virtual DbSet<CategoriaProblema> CategoriasProblemas { get; set; }
        public virtual DbSet<Cidade> Cidades { get; set; }
        public virtual DbSet<Tag> Tags { get; set; }
        public virtual DbSet<TagCliente> TagsClientes { get; set; }

        public SuporteDbContext(DbContextOptions<SuporteDbContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Cliente>().Property(x => x.Id).HasColumnName("crcliente_id");
            modelBuilder.Entity<ClienteView>().ToView("vw_cliente");
            modelBuilder.Entity<ClienteView>().HasNoKey();
            modelBuilder.Entity<ClienteView>().Property(x => x.Id).HasColumnName("crcliente_id");
            modelBuilder.Entity<Chamado>().Property(x => x.Id).HasColumnName("spchamado_id");
            modelBuilder.Entity<ChamadoView>().ToView("vw_chamado");
            modelBuilder.Entity<ChamadoView>().HasNoKey();
            modelBuilder.Entity<ChamadoView>().Property(x => x.Id).HasColumnName("spchamado_id");
            modelBuilder.Entity<Followup>().Property(x => x.Id).HasColumnName("spfollowup_id");
            modelBuilder.Entity<ChamadoFollowup>().HasKey(x => new { x.ChamadoId, x.Id });
            modelBuilder.Entity<ChamadoFollowup>().Property(x => x.Id).HasColumnName("spfollowup_id");
            modelBuilder.Entity<Tarefa>().Property(x => x.Id).HasColumnName("sptarefa_id");
            modelBuilder.Entity<Etapa>().Property(x => x.Id).HasColumnName("etapa_id");
            modelBuilder.Entity<EtapaStatus>().Property(x => x.Id).HasColumnName("etapa_status_id");
            modelBuilder.Entity<EtapaChamado>().Property(x => x.Id).HasColumnName("id");
            modelBuilder.Entity<EtapaView>().ToView("vw_etapas");
            modelBuilder.Entity<EtapaView>().HasNoKey();
            modelBuilder.Entity<EtapaView>().Property(x => x.Id).HasColumnName("id");
            modelBuilder.Entity<Anexo>().Property(x => x.Id).HasColumnName("spanexo_id");
            modelBuilder.Entity<PrioridadeFluxoView>().ToView("vw_fluxo_prioridade");
            modelBuilder.Entity<PrioridadeFluxoView>().HasNoKey();
            modelBuilder.Entity<ChamadoFluxo>().Property(x => x.Id).HasColumnName("spchamado_fluxo_id");
            modelBuilder.Entity<FilaAtendimento>().Property(x => x.Id).HasColumnName("spchamado_fila_id");
            modelBuilder.Entity<Produto>().Property(x => x.Id).HasColumnName("spchamado_produto_id");
            modelBuilder.Entity<Grupo>().Property(x => x.Id).HasColumnName("spchamado_grupo_id");
            modelBuilder.Entity<SubGrupo>().Property(x => x.Id).HasColumnName("spchamado_subgrupo_id");
            modelBuilder.Entity<ProdutoGrupo>().HasKey(x => new { x.ProdutoId, x.Id });
            modelBuilder.Entity<GrupoSubGrupo>().HasKey(x => new { x.GrupoId, x.Id });
            modelBuilder.Entity<Origem>().Property(x => x.Id).HasColumnName("spchamado_origem_id");
            modelBuilder.Entity<Classificacao>().Property(x => x.Id).HasColumnName("spchamado_class_id");
            modelBuilder.Entity<Sla>().Property(x => x.Id).HasColumnName("spchamado_sla_id");
            modelBuilder.Entity<Release>().Property(x => x.Id).HasColumnName("spchamado_release_id");
            modelBuilder.Entity<Evento>().Property(x => x.Id).HasColumnName("id_evento");
            modelBuilder.Entity<Fabricante>().Property(x => x.Id).HasColumnName("codigo_fabricante");
            modelBuilder.Entity<Categoria>().Property(x => x.Id).HasColumnName("id_categoria");
            modelBuilder.Entity<Modelo>().Property(x => x.Id).HasColumnName("id_modelo");
            modelBuilder.Entity<Equipamento>().Property(x => x.Id).HasColumnName("codigo_equipamento");
            modelBuilder.Entity<Assistencia>().Property(x => x.Id).HasColumnName("assistencia_id");
            modelBuilder.Entity<Suprimento>().Property(x => x.Id).HasColumnName("id");
            modelBuilder.Entity<SuprimentoConsumo>().Property(x => x.Id).HasColumnName("id");
            modelBuilder.Entity<Contrato>().Property(x => x.Id).HasColumnName("contrato_cod_item");
            modelBuilder.Entity<CategoriaProblema>().Property(x => x.Id).HasColumnName("id_problema");
            modelBuilder.Entity<Cidade>().Property(x => x.Id).HasColumnName("id");
            modelBuilder.Entity<Tag>().Property(x => x.Id).HasColumnName("tag_id");
            modelBuilder.Entity<TagCliente>().HasKey(x => new { x.ClienteId, x.Id });
            modelBuilder.Entity<TagCliente>().Property(x => x.Id).HasColumnName("tag_id");

            modelBuilder.Entity<Cracha>().HasOne(x => x.ClienteFk).WithMany().OnDelete(DeleteBehavior.Restrict);
            modelBuilder.Entity<FilaRetorno>().HasOne(x => x.FilaAtendimentoFk).WithMany().OnDelete(DeleteBehavior.Restrict);

            //modelBuilder.HasCollation("my_collation", locale: "en-u-ks-primary", provider: "icu", deterministic: false);
            //modelBuilder.UseDefaultColumnCollation("my_collation");
        }
    }
}

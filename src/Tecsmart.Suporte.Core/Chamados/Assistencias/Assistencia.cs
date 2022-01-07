using Abp.Domain.Entities;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Tecsmart.Suporte.Equipamentos;
using Tecsmart.Suporte.Equipamentos.CategoriasProblemas;

namespace Tecsmart.Suporte.Chamados
{
    [Table("spchamado_assistencia")]
    public class Assistencia : Entity<int>
    {
        [Required]
        [Column("spchamado_id", TypeName = "integer")]
        public virtual int ChamadoId { get; set; }

        [Required]
        [Column("equipamento_id", TypeName = "integer")]
        public virtual int EquipamentoId { get; set; }

        [Required]
        [Column("categoria_id", TypeName = "integer")]
        public virtual int CategoriaId { get; set; }

        [Column("dados_adicionais", TypeName = "text")]
        public virtual string DadosAdicionais { get; set; }


        [ForeignKey("ChamadoId")]
        public Chamado ChamadoFk { get; set; }

        [ForeignKey("EquipamentoId")]
        public Equipamento EquipamentoFk { get; set; }

        [ForeignKey("CategoriaId")]
        public CategoriaProblema CategoriaProblemaFk { get; set; }

    }
}

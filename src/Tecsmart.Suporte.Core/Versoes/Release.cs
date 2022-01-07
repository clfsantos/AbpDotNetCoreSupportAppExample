using Abp.Domain.Entities;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Tecsmart.Suporte.Produtos;

namespace Tecsmart.Suporte.Releases
{
    [Table("spchamado_release")]
    public class Release : Entity<int>
    {
        [Required]
        [Column("spchamado_release_produto", TypeName = "integer")]
        public virtual int ProdutoId { get; set; }

        [Required]
        [Column("spchamado_release_num", TypeName = "varchar(60)")]
        public virtual string Versao { get; set; }

        [Required]
        [Column("spchamado_release_desc", TypeName = "text")]
        public virtual string Descricao { get; set; }

        [Required]
        [Column("spchamado_release_dt", TypeName = "date")]
        public virtual DateTime DataRelease { get; set; }


        [ForeignKey("ProdutoId")]
        public Produto ProdutoFk { get; set; }

    }
}

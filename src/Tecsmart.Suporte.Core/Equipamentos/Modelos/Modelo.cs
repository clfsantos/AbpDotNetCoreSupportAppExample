using Abp.Domain.Entities;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Tecsmart.Suporte.Equipamentos.Categorias;
using Tecsmart.Suporte.Equipamentos.Fabricantes;

namespace Tecsmart.Suporte.Equipamentos.Modelos
{
    [Table("modelo")]
    public class Modelo : Entity<int>
    {
        [Required]
        [Column("descricao", TypeName = "citext")]
        public virtual string Descricao { get; set; }

        [Required]
        [Column("id_categoria", TypeName = "integer")]
        public virtual int CategoriaId { get; set; }

        [Required]
        [Column("codigo_fabricante", TypeName = "integer")]
        public virtual int FabricanteId { get; set; }


        [ForeignKey("CategoriaId")]
        public Categoria CategoriaFk { get; set; }

        [ForeignKey("FabricanteId")]
        public Fabricante FabricanteFk { get; set; }
    }
}

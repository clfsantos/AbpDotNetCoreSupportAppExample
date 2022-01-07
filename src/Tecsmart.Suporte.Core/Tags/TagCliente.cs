using Abp.Domain.Entities;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Tecsmart.Suporte.Clientes;

namespace Tecsmart.Suporte.Tags
{
    [Table("crcliente_tag")]
    public class TagCliente : Entity<int>
    {
        [Required]
        [Column("tag_id", TypeName = "integer")]
        public override int Id { get; set; }

        [Required]
        [Column("crcliente_id", TypeName = "integer")]
        public virtual int ClienteId { get; set; }


        [ForeignKey("ClienteId")]
        public Cliente ClienteFk { get; set; }

        [ForeignKey("Id")]
        public Tag TagFk { get; set; }
    }
}

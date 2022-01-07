using Abp.Domain.Entities;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Tecsmart.Suporte.Authorization.Users;

namespace Tecsmart.Suporte.GridStates
{
    [Table("grid_state")]
    public class GridState : Entity<int>
    {
        [Required]
        public virtual long UsuarioId { get; set; }

        [Required]
        [Column(TypeName = "varchar(60)")]
        public virtual string Tela { get; set; }

        [Required]
        [Column(TypeName = "varchar(60)")]
        public virtual string Descricao { get; set; }

        [Required]
        [Column(TypeName = "text")]
        public virtual string State { get; set; }


        [ForeignKey("UsuarioId")]
        public User UserFk { get; set; }
    }
}

using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace Tecsmart.Suporte.Migrations
{
    public partial class AddGridStates : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_spanexo_AbpUsers_spanexo_usuario",
                table: "spanexo");

            migrationBuilder.DropForeignKey(
                name: "FK_spchamado_AbpUsers_spchamado_resp_atual_id",
                table: "spchamado");

            migrationBuilder.DropForeignKey(
                name: "FK_spchamado_AbpUsers_spchamado_resp_fechamento_id",
                table: "spchamado");

            migrationBuilder.DropForeignKey(
                name: "FK_spchamado_AbpUsers_spchamado_responsavel_id",
                table: "spchamado");

            migrationBuilder.DropForeignKey(
                name: "FK_spchamado_fila_retornos_AbpUsers_UsuarioId",
                table: "spchamado_fila_retornos");

            migrationBuilder.DropForeignKey(
                name: "FK_spchamado_fluxo_AbpUsers_usuario_id",
                table: "spchamado_fluxo");

            migrationBuilder.DropForeignKey(
                name: "FK_spfollowup_AbpUsers_spfollowup_usuario_id",
                table: "spfollowup");

            migrationBuilder.DropForeignKey(
                name: "FK_spfollowup_AbpUsers_spfollowup_usuario_trans",
                table: "spfollowup");

            migrationBuilder.DropForeignKey(
                name: "FK_spimplantacao_etapa_AbpUsers_etapa_resp",
                table: "spimplantacao_etapa");

            migrationBuilder.DropForeignKey(
                name: "FK_sptarefa_AbpUsers_sptarefa_u_atribuido",
                table: "sptarefa");

            migrationBuilder.DropForeignKey(
                name: "FK_sptarefa_AbpUsers_sptarefa_usuario",
                table: "sptarefa");

            migrationBuilder.DropUniqueConstraint(
                name: "AK_AbpUsers_TempId",
                table: "AbpUsers");

            migrationBuilder.DropUniqueConstraint(
                name: "AK_AbpUsers_TempId1",
                table: "AbpUsers");

            migrationBuilder.DropUniqueConstraint(
                name: "AK_AbpUsers_TempId10",
                table: "AbpUsers");

            migrationBuilder.DropUniqueConstraint(
                name: "AK_AbpUsers_TempId11",
                table: "AbpUsers");

            migrationBuilder.DropUniqueConstraint(
                name: "AK_AbpUsers_TempId12",
                table: "AbpUsers");

            migrationBuilder.DropUniqueConstraint(
                name: "AK_AbpUsers_TempId2",
                table: "AbpUsers");

            migrationBuilder.DropUniqueConstraint(
                name: "AK_AbpUsers_TempId3",
                table: "AbpUsers");

            migrationBuilder.DropUniqueConstraint(
                name: "AK_AbpUsers_TempId4",
                table: "AbpUsers");

            migrationBuilder.DropUniqueConstraint(
                name: "AK_AbpUsers_TempId5",
                table: "AbpUsers");

            migrationBuilder.DropUniqueConstraint(
                name: "AK_AbpUsers_TempId6",
                table: "AbpUsers");

            migrationBuilder.DropUniqueConstraint(
                name: "AK_AbpUsers_TempId7",
                table: "AbpUsers");

            migrationBuilder.DropUniqueConstraint(
                name: "AK_AbpUsers_TempId8",
                table: "AbpUsers");

            migrationBuilder.DropUniqueConstraint(
                name: "AK_AbpUsers_TempId9",
                table: "AbpUsers");

            migrationBuilder.DropColumn(
                name: "TempId",
                table: "AbpUsers");

            migrationBuilder.DropColumn(
                name: "TempId1",
                table: "AbpUsers");

            migrationBuilder.DropColumn(
                name: "TempId10",
                table: "AbpUsers");

            migrationBuilder.DropColumn(
                name: "TempId11",
                table: "AbpUsers");

            migrationBuilder.DropColumn(
                name: "TempId12",
                table: "AbpUsers");

            migrationBuilder.DropColumn(
                name: "TempId2",
                table: "AbpUsers");

            migrationBuilder.DropColumn(
                name: "TempId3",
                table: "AbpUsers");

            migrationBuilder.DropColumn(
                name: "TempId4",
                table: "AbpUsers");

            migrationBuilder.DropColumn(
                name: "TempId5",
                table: "AbpUsers");

            migrationBuilder.DropColumn(
                name: "TempId6",
                table: "AbpUsers");

            migrationBuilder.DropColumn(
                name: "TempId7",
                table: "AbpUsers");

            migrationBuilder.DropColumn(
                name: "TempId8",
                table: "AbpUsers");

            migrationBuilder.DropColumn(
                name: "TempId9",
                table: "AbpUsers");

            migrationBuilder.AlterColumn<DateTime>(
                name: "dt_inclusao",
                table: "equipamento",
                type: "timestamp",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "timestamp");

            migrationBuilder.CreateTable(
                name: "grid_state",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    UsuarioId = table.Column<long>(type: "bigint", nullable: false),
                    Tela = table.Column<string>(type: "varchar(60)", nullable: false),
                    Descricao = table.Column<string>(type: "varchar(60)", nullable: false),
                    State = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_grid_state", x => x.Id);
                    table.ForeignKey(
                        name: "FK_grid_state_AbpUsers_UsuarioId",
                        column: x => x.UsuarioId,
                        principalTable: "AbpUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_grid_state_UsuarioId",
                table: "grid_state",
                column: "UsuarioId");

            migrationBuilder.AddForeignKey(
                name: "FK_spanexo_AbpUsers_spanexo_usuario",
                table: "spanexo",
                column: "spanexo_usuario",
                principalTable: "AbpUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_spchamado_AbpUsers_spchamado_resp_atual_id",
                table: "spchamado",
                column: "spchamado_resp_atual_id",
                principalTable: "AbpUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_spchamado_AbpUsers_spchamado_resp_fechamento_id",
                table: "spchamado",
                column: "spchamado_resp_fechamento_id",
                principalTable: "AbpUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_spchamado_AbpUsers_spchamado_responsavel_id",
                table: "spchamado",
                column: "spchamado_responsavel_id",
                principalTable: "AbpUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_spchamado_fila_retornos_AbpUsers_UsuarioId",
                table: "spchamado_fila_retornos",
                column: "UsuarioId",
                principalTable: "AbpUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_spchamado_fluxo_AbpUsers_usuario_id",
                table: "spchamado_fluxo",
                column: "usuario_id",
                principalTable: "AbpUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_spfollowup_AbpUsers_spfollowup_usuario_id",
                table: "spfollowup",
                column: "spfollowup_usuario_id",
                principalTable: "AbpUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_spfollowup_AbpUsers_spfollowup_usuario_trans",
                table: "spfollowup",
                column: "spfollowup_usuario_trans",
                principalTable: "AbpUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_spimplantacao_etapa_AbpUsers_etapa_resp",
                table: "spimplantacao_etapa",
                column: "etapa_resp",
                principalTable: "AbpUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_sptarefa_AbpUsers_sptarefa_u_atribuido",
                table: "sptarefa",
                column: "sptarefa_u_atribuido",
                principalTable: "AbpUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_sptarefa_AbpUsers_sptarefa_usuario",
                table: "sptarefa",
                column: "sptarefa_usuario",
                principalTable: "AbpUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_spanexo_AbpUsers_spanexo_usuario",
                table: "spanexo");

            migrationBuilder.DropForeignKey(
                name: "FK_spchamado_AbpUsers_spchamado_resp_atual_id",
                table: "spchamado");

            migrationBuilder.DropForeignKey(
                name: "FK_spchamado_AbpUsers_spchamado_resp_fechamento_id",
                table: "spchamado");

            migrationBuilder.DropForeignKey(
                name: "FK_spchamado_AbpUsers_spchamado_responsavel_id",
                table: "spchamado");

            migrationBuilder.DropForeignKey(
                name: "FK_spchamado_fila_retornos_AbpUsers_UsuarioId",
                table: "spchamado_fila_retornos");

            migrationBuilder.DropForeignKey(
                name: "FK_spchamado_fluxo_AbpUsers_usuario_id",
                table: "spchamado_fluxo");

            migrationBuilder.DropForeignKey(
                name: "FK_spfollowup_AbpUsers_spfollowup_usuario_id",
                table: "spfollowup");

            migrationBuilder.DropForeignKey(
                name: "FK_spfollowup_AbpUsers_spfollowup_usuario_trans",
                table: "spfollowup");

            migrationBuilder.DropForeignKey(
                name: "FK_spimplantacao_etapa_AbpUsers_etapa_resp",
                table: "spimplantacao_etapa");

            migrationBuilder.DropForeignKey(
                name: "FK_sptarefa_AbpUsers_sptarefa_u_atribuido",
                table: "sptarefa");

            migrationBuilder.DropForeignKey(
                name: "FK_sptarefa_AbpUsers_sptarefa_usuario",
                table: "sptarefa");

            migrationBuilder.DropTable(
                name: "grid_state");

            migrationBuilder.AlterColumn<DateTime>(
                name: "dt_inclusao",
                table: "equipamento",
                type: "timestamp",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                oldClrType: typeof(DateTime),
                oldType: "timestamp",
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "TempId",
                table: "AbpUsers",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "TempId1",
                table: "AbpUsers",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "TempId10",
                table: "AbpUsers",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "TempId11",
                table: "AbpUsers",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "TempId12",
                table: "AbpUsers",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "TempId2",
                table: "AbpUsers",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "TempId3",
                table: "AbpUsers",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "TempId4",
                table: "AbpUsers",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "TempId5",
                table: "AbpUsers",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "TempId6",
                table: "AbpUsers",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "TempId7",
                table: "AbpUsers",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "TempId8",
                table: "AbpUsers",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "TempId9",
                table: "AbpUsers",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddUniqueConstraint(
                name: "AK_AbpUsers_TempId",
                table: "AbpUsers",
                column: "TempId");

            migrationBuilder.AddUniqueConstraint(
                name: "AK_AbpUsers_TempId1",
                table: "AbpUsers",
                column: "TempId1");

            migrationBuilder.AddUniqueConstraint(
                name: "AK_AbpUsers_TempId10",
                table: "AbpUsers",
                column: "TempId10");

            migrationBuilder.AddUniqueConstraint(
                name: "AK_AbpUsers_TempId11",
                table: "AbpUsers",
                column: "TempId11");

            migrationBuilder.AddUniqueConstraint(
                name: "AK_AbpUsers_TempId12",
                table: "AbpUsers",
                column: "TempId12");

            migrationBuilder.AddUniqueConstraint(
                name: "AK_AbpUsers_TempId2",
                table: "AbpUsers",
                column: "TempId2");

            migrationBuilder.AddUniqueConstraint(
                name: "AK_AbpUsers_TempId3",
                table: "AbpUsers",
                column: "TempId3");

            migrationBuilder.AddUniqueConstraint(
                name: "AK_AbpUsers_TempId4",
                table: "AbpUsers",
                column: "TempId4");

            migrationBuilder.AddUniqueConstraint(
                name: "AK_AbpUsers_TempId5",
                table: "AbpUsers",
                column: "TempId5");

            migrationBuilder.AddUniqueConstraint(
                name: "AK_AbpUsers_TempId6",
                table: "AbpUsers",
                column: "TempId6");

            migrationBuilder.AddUniqueConstraint(
                name: "AK_AbpUsers_TempId7",
                table: "AbpUsers",
                column: "TempId7");

            migrationBuilder.AddUniqueConstraint(
                name: "AK_AbpUsers_TempId8",
                table: "AbpUsers",
                column: "TempId8");

            migrationBuilder.AddUniqueConstraint(
                name: "AK_AbpUsers_TempId9",
                table: "AbpUsers",
                column: "TempId9");

            migrationBuilder.AddForeignKey(
                name: "FK_spanexo_AbpUsers_spanexo_usuario",
                table: "spanexo",
                column: "spanexo_usuario",
                principalTable: "AbpUsers",
                principalColumn: "TempId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_spchamado_AbpUsers_spchamado_resp_atual_id",
                table: "spchamado",
                column: "spchamado_resp_atual_id",
                principalTable: "AbpUsers",
                principalColumn: "TempId1",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_spchamado_AbpUsers_spchamado_resp_fechamento_id",
                table: "spchamado",
                column: "spchamado_resp_fechamento_id",
                principalTable: "AbpUsers",
                principalColumn: "TempId2",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_spchamado_AbpUsers_spchamado_responsavel_id",
                table: "spchamado",
                column: "spchamado_responsavel_id",
                principalTable: "AbpUsers",
                principalColumn: "TempId3",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_spchamado_fila_retornos_AbpUsers_UsuarioId",
                table: "spchamado_fila_retornos",
                column: "UsuarioId",
                principalTable: "AbpUsers",
                principalColumn: "TempId12",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_spchamado_fluxo_AbpUsers_usuario_id",
                table: "spchamado_fluxo",
                column: "usuario_id",
                principalTable: "AbpUsers",
                principalColumn: "TempId4",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_spfollowup_AbpUsers_spfollowup_usuario_id",
                table: "spfollowup",
                column: "spfollowup_usuario_id",
                principalTable: "AbpUsers",
                principalColumn: "TempId7",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_spfollowup_AbpUsers_spfollowup_usuario_trans",
                table: "spfollowup",
                column: "spfollowup_usuario_trans",
                principalTable: "AbpUsers",
                principalColumn: "TempId8",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_spimplantacao_etapa_AbpUsers_etapa_resp",
                table: "spimplantacao_etapa",
                column: "etapa_resp",
                principalTable: "AbpUsers",
                principalColumn: "TempId6",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_sptarefa_AbpUsers_sptarefa_u_atribuido",
                table: "sptarefa",
                column: "sptarefa_u_atribuido",
                principalTable: "AbpUsers",
                principalColumn: "TempId10",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_sptarefa_AbpUsers_sptarefa_usuario",
                table: "sptarefa",
                column: "sptarefa_usuario",
                principalTable: "AbpUsers",
                principalColumn: "TempId11",
                onDelete: ReferentialAction.Cascade);
        }
    }
}

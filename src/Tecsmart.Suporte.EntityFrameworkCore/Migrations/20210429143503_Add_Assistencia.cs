using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace Tecsmart.Suporte.Migrations
{
    public partial class Add_Assistencia : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Modelos_Categorias_CategoriaId",
                table: "Modelos");

            migrationBuilder.DropForeignKey(
                name: "FK_Modelos_Fabricantes_FabricanteId",
                table: "Modelos");

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

            migrationBuilder.DropPrimaryKey(
                name: "PK_Modelos",
                table: "Modelos");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Fabricantes",
                table: "Fabricantes");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Categorias",
                table: "Categorias");

            migrationBuilder.DropColumn(
                name: "CreationTime",
                table: "spchamado_fila_retornos");

            migrationBuilder.DropColumn(
                name: "CreatorUserId",
                table: "spchamado_fila_retornos");

            migrationBuilder.DropColumn(
                name: "DeleterUserId",
                table: "spchamado_fila_retornos");

            migrationBuilder.DropColumn(
                name: "DeletionTime",
                table: "spchamado_fila_retornos");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "spchamado_fila_retornos");

            migrationBuilder.DropColumn(
                name: "LastModificationTime",
                table: "spchamado_fila_retornos");

            migrationBuilder.DropColumn(
                name: "LastModifierUserId",
                table: "spchamado_fila_retornos");

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

            migrationBuilder.RenameTable(
                name: "Modelos",
                newName: "modelo");

            migrationBuilder.RenameTable(
                name: "Fabricantes",
                newName: "fabricante");

            migrationBuilder.RenameTable(
                name: "Categorias",
                newName: "categoria");

            migrationBuilder.RenameColumn(
                name: "Descricao",
                table: "modelo",
                newName: "descricao");

            migrationBuilder.RenameColumn(
                name: "FabricanteId",
                table: "modelo",
                newName: "codigo_fabricante");

            migrationBuilder.RenameColumn(
                name: "CategoriaId",
                table: "modelo",
                newName: "id_categoria");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "modelo",
                newName: "id_modelo");

            migrationBuilder.RenameIndex(
                name: "IX_Modelos_FabricanteId",
                table: "modelo",
                newName: "IX_modelo_codigo_fabricante");

            migrationBuilder.RenameIndex(
                name: "IX_Modelos_CategoriaId",
                table: "modelo",
                newName: "IX_modelo_id_categoria");

            migrationBuilder.RenameColumn(
                name: "Nome",
                table: "fabricante",
                newName: "nome_fabricante");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "fabricante",
                newName: "codigo_fabricante");

            migrationBuilder.RenameColumn(
                name: "Descricao",
                table: "categoria",
                newName: "descricao_categoria");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "categoria",
                newName: "id_categoria");

            migrationBuilder.AlterColumn<int>(
                name: "sptarefa_id",
                table: "sptarefa",
                type: "integer",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "integer")
                .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn)
                .OldAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn);

            migrationBuilder.AlterColumn<int>(
                name: "etapa_status_id",
                table: "spimplantacao_etapa_status",
                type: "integer",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "integer")
                .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn)
                .OldAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn);

            migrationBuilder.AlterColumn<int>(
                name: "id",
                table: "spimplantacao_etapa_chamado",
                type: "integer",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "integer")
                .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn)
                .OldAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn);

            migrationBuilder.AlterColumn<int>(
                name: "etapa_id",
                table: "spimplantacao_etapa",
                type: "integer",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "integer")
                .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn)
                .OldAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn);

            migrationBuilder.AlterColumn<int>(
                name: "spfollowup_id",
                table: "spfollowup",
                type: "integer",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "integer")
                .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn)
                .OldAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn);

            migrationBuilder.AddColumn<int>(
                name: "eventofollowup_id",
                table: "spfollowup",
                type: "integer",
                nullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "spchamado_subgrupo_id",
                table: "spchamado_subgrupo",
                type: "integer",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "integer")
                .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn)
                .OldAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn);

            migrationBuilder.AlterColumn<int>(
                name: "spchamado_sla_id",
                table: "spchamado_sla",
                type: "integer",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "integer")
                .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn)
                .OldAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn);

            migrationBuilder.AlterColumn<int>(
                name: "spchamado_produto_id",
                table: "spchamado_produto",
                type: "integer",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "integer")
                .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn)
                .OldAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn);

            migrationBuilder.AlterColumn<int>(
                name: "spchamado_origem_id",
                table: "spchamado_origem",
                type: "integer",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "integer")
                .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn)
                .OldAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn);

            migrationBuilder.AlterColumn<int>(
                name: "spchamado_grupo_id",
                table: "spchamado_grupo",
                type: "integer",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "integer")
                .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn)
                .OldAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn);

            migrationBuilder.AlterColumn<int>(
                name: "spchamado_fluxo_id",
                table: "spchamado_fluxo",
                type: "integer",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "integer")
                .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn)
                .OldAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn);

            migrationBuilder.AlterColumn<int>(
                name: "Id",
                table: "spchamado_fila_retornos",
                type: "integer",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "integer")
                .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn)
                .OldAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn);

            migrationBuilder.AddColumn<int>(
                name: "UsuarioId",
                table: "spchamado_fila_retornos",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AlterColumn<int>(
                name: "spchamado_fila_id",
                table: "spchamado_fila",
                type: "integer",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "integer")
                .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn)
                .OldAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn);

            migrationBuilder.AddColumn<bool>(
                name: "spchamado_fila_cancelado",
                table: "spchamado_fila",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AlterColumn<int>(
                name: "spchamado_class_id",
                table: "spchamado_class",
                type: "integer",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "integer")
                .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn)
                .OldAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn);

            migrationBuilder.AlterColumn<int>(
                name: "spchamado_id",
                table: "spchamado",
                type: "integer",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "integer")
                .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn)
                .OldAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn);

            migrationBuilder.AlterColumn<int>(
                name: "spanexo_id",
                table: "spanexo",
                type: "integer",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "integer")
                .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn)
                .OldAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn);

            migrationBuilder.AlterColumn<int>(
                name: "crcliente_id",
                table: "crcliente",
                type: "integer",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "integer")
                .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn)
                .OldAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn);

            migrationBuilder.AlterColumn<int>(
                name: "Id",
                table: "crachas",
                type: "integer",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "integer")
                .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn)
                .OldAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn);

            migrationBuilder.AlterColumn<long>(
                name: "Id",
                table: "AbpUserTokens",
                type: "bigint",
                nullable: false,
                oldClrType: typeof(long),
                oldType: "bigint")
                .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn)
                .OldAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn);

            migrationBuilder.AlterColumn<long>(
                name: "Id",
                table: "AbpUsers",
                type: "bigint",
                nullable: false,
                oldClrType: typeof(long),
                oldType: "bigint")
                .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn)
                .OldAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn);

            migrationBuilder.AlterColumn<long>(
                name: "Id",
                table: "AbpUserRoles",
                type: "bigint",
                nullable: false,
                oldClrType: typeof(long),
                oldType: "bigint")
                .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn)
                .OldAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn);

            migrationBuilder.AlterColumn<long>(
                name: "Id",
                table: "AbpUserOrganizationUnits",
                type: "bigint",
                nullable: false,
                oldClrType: typeof(long),
                oldType: "bigint")
                .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn)
                .OldAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn);

            migrationBuilder.AlterColumn<long>(
                name: "Id",
                table: "AbpUserLogins",
                type: "bigint",
                nullable: false,
                oldClrType: typeof(long),
                oldType: "bigint")
                .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn)
                .OldAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn);

            migrationBuilder.AlterColumn<long>(
                name: "Id",
                table: "AbpUserLoginAttempts",
                type: "bigint",
                nullable: false,
                oldClrType: typeof(long),
                oldType: "bigint")
                .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn)
                .OldAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn);

            migrationBuilder.AlterColumn<long>(
                name: "Id",
                table: "AbpUserClaims",
                type: "bigint",
                nullable: false,
                oldClrType: typeof(long),
                oldType: "bigint")
                .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn)
                .OldAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn);

            migrationBuilder.AlterColumn<long>(
                name: "Id",
                table: "AbpUserAccounts",
                type: "bigint",
                nullable: false,
                oldClrType: typeof(long),
                oldType: "bigint")
                .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn)
                .OldAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn);

            migrationBuilder.AlterColumn<int>(
                name: "Id",
                table: "AbpTenants",
                type: "integer",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "integer")
                .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn)
                .OldAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn);

            migrationBuilder.AlterColumn<long>(
                name: "Id",
                table: "AbpSettings",
                type: "bigint",
                nullable: false,
                oldClrType: typeof(long),
                oldType: "bigint")
                .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn)
                .OldAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn);

            migrationBuilder.AlterColumn<int>(
                name: "Id",
                table: "AbpRoles",
                type: "integer",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "integer")
                .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn)
                .OldAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn);

            migrationBuilder.AlterColumn<long>(
                name: "Id",
                table: "AbpRoleClaims",
                type: "bigint",
                nullable: false,
                oldClrType: typeof(long),
                oldType: "bigint")
                .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn)
                .OldAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn);

            migrationBuilder.AlterColumn<long>(
                name: "Id",
                table: "AbpPermissions",
                type: "bigint",
                nullable: false,
                oldClrType: typeof(long),
                oldType: "bigint")
                .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn)
                .OldAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn);

            migrationBuilder.AlterColumn<long>(
                name: "Id",
                table: "AbpOrganizationUnits",
                type: "bigint",
                nullable: false,
                oldClrType: typeof(long),
                oldType: "bigint")
                .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn)
                .OldAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn);

            migrationBuilder.AlterColumn<long>(
                name: "Id",
                table: "AbpOrganizationUnitRoles",
                type: "bigint",
                nullable: false,
                oldClrType: typeof(long),
                oldType: "bigint")
                .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn)
                .OldAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn);

            migrationBuilder.AlterColumn<long>(
                name: "Id",
                table: "AbpLanguageTexts",
                type: "bigint",
                nullable: false,
                oldClrType: typeof(long),
                oldType: "bigint")
                .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn)
                .OldAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn);

            migrationBuilder.AlterColumn<int>(
                name: "Id",
                table: "AbpLanguages",
                type: "integer",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "integer")
                .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn)
                .OldAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn);

            migrationBuilder.AlterColumn<long>(
                name: "Id",
                table: "AbpFeatures",
                type: "bigint",
                nullable: false,
                oldClrType: typeof(long),
                oldType: "bigint")
                .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn)
                .OldAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn);

            migrationBuilder.AlterColumn<long>(
                name: "Id",
                table: "AbpEntityPropertyChanges",
                type: "bigint",
                nullable: false,
                oldClrType: typeof(long),
                oldType: "bigint")
                .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn)
                .OldAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn);

            migrationBuilder.AlterColumn<long>(
                name: "Id",
                table: "AbpEntityChangeSets",
                type: "bigint",
                nullable: false,
                oldClrType: typeof(long),
                oldType: "bigint")
                .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn)
                .OldAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn);

            migrationBuilder.AlterColumn<long>(
                name: "Id",
                table: "AbpEntityChanges",
                type: "bigint",
                nullable: false,
                oldClrType: typeof(long),
                oldType: "bigint")
                .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn)
                .OldAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn);

            migrationBuilder.AlterColumn<int>(
                name: "Id",
                table: "AbpEditions",
                type: "integer",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "integer")
                .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn)
                .OldAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn);

            migrationBuilder.AlterColumn<int>(
                name: "Id",
                table: "AbpDynamicPropertyValues",
                type: "integer",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "integer")
                .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn)
                .OldAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn);

            migrationBuilder.AlterColumn<int>(
                name: "Id",
                table: "AbpDynamicProperties",
                type: "integer",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "integer")
                .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn)
                .OldAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn);

            migrationBuilder.AlterColumn<int>(
                name: "Id",
                table: "AbpDynamicEntityPropertyValues",
                type: "integer",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "integer")
                .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn)
                .OldAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn);

            migrationBuilder.AlterColumn<int>(
                name: "Id",
                table: "AbpDynamicEntityProperties",
                type: "integer",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "integer")
                .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn)
                .OldAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn);

            migrationBuilder.AlterColumn<long>(
                name: "Id",
                table: "AbpBackgroundJobs",
                type: "bigint",
                nullable: false,
                oldClrType: typeof(long),
                oldType: "bigint")
                .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn)
                .OldAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn);

            migrationBuilder.AlterColumn<long>(
                name: "Id",
                table: "AbpAuditLogs",
                type: "bigint",
                nullable: false,
                oldClrType: typeof(long),
                oldType: "bigint")
                .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn)
                .OldAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn);

            migrationBuilder.AlterColumn<string>(
                name: "descricao",
                table: "modelo",
                type: "citext",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "varchar(256)");

            migrationBuilder.AlterColumn<int>(
                name: "id_modelo",
                table: "modelo",
                type: "integer",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "integer")
                .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn)
                .OldAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn);

            migrationBuilder.AlterColumn<string>(
                name: "nome_fabricante",
                table: "fabricante",
                type: "citext",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "varchar(256)");

            migrationBuilder.AlterColumn<int>(
                name: "codigo_fabricante",
                table: "fabricante",
                type: "integer",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "integer")
                .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn)
                .OldAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn);

            migrationBuilder.AlterColumn<string>(
                name: "descricao_categoria",
                table: "categoria",
                type: "citext",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "varchar(256)");

            migrationBuilder.AlterColumn<int>(
                name: "id_categoria",
                table: "categoria",
                type: "integer",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "integer")
                .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn)
                .OldAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn);

            migrationBuilder.AddPrimaryKey(
                name: "PK_modelo",
                table: "modelo",
                column: "id_modelo");

            migrationBuilder.AddPrimaryKey(
                name: "PK_fabricante",
                table: "fabricante",
                column: "codigo_fabricante");

            migrationBuilder.AddPrimaryKey(
                name: "PK_categoria",
                table: "categoria",
                column: "id_categoria");

            migrationBuilder.CreateTable(
                name: "equipamento",
                columns: table => new
                {
                    codigo_equipamento = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    nr_serie = table.Column<string>(type: "varchar(17)", nullable: false),
                    crcliente_id = table.Column<int>(type: "integer", nullable: false),
                    id_modelo = table.Column<int>(type: "integer", nullable: false),
                    teste_ok = table.Column<bool>(type: "boolean", nullable: false),
                    inativo = table.Column<bool>(type: "boolean", nullable: false),
                    dt_inclusao = table.Column<DateTime>(type: "timestamp", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_equipamento", x => x.codigo_equipamento);
                    table.ForeignKey(
                        name: "FK_equipamento_crcliente_crcliente_id",
                        column: x => x.crcliente_id,
                        principalTable: "crcliente",
                        principalColumn: "crcliente_id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_equipamento_modelo_id_modelo",
                        column: x => x.id_modelo,
                        principalTable: "modelo",
                        principalColumn: "id_modelo",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "eventofollowup",
                columns: table => new
                {
                    id_evento = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    descricao_evento = table.Column<string>(type: "citext", nullable: false),
                    prioridade_id = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_eventofollowup", x => x.id_evento);
                });

            migrationBuilder.CreateTable(
                name: "spchamado_release",
                columns: table => new
                {
                    spchamado_release_id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    spchamado_release_produto = table.Column<int>(type: "integer", nullable: false),
                    spchamado_release_num = table.Column<string>(type: "varchar(60)", nullable: false),
                    spchamado_release_desc = table.Column<string>(type: "text", nullable: false),
                    spchamado_release_dt = table.Column<DateTime>(type: "date", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_spchamado_release", x => x.spchamado_release_id);
                    table.ForeignKey(
                        name: "FK_spchamado_release_spchamado_produto_spchamado_release_produ~",
                        column: x => x.spchamado_release_produto,
                        principalTable: "spchamado_produto",
                        principalColumn: "spchamado_produto_id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "spchamado_assistencia",
                columns: table => new
                {
                    assistencia_id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    spchamado_id = table.Column<int>(type: "integer", nullable: false),
                    equipamento_id = table.Column<int>(type: "integer", nullable: false),
                    categoria_id = table.Column<int>(type: "integer", nullable: false),
                    dados_adicionais = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_spchamado_assistencia", x => x.assistencia_id);
                    table.ForeignKey(
                        name: "FK_spchamado_assistencia_equipamento_equipamento_id",
                        column: x => x.equipamento_id,
                        principalTable: "equipamento",
                        principalColumn: "codigo_equipamento",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_spchamado_assistencia_spchamado_spchamado_id",
                        column: x => x.spchamado_id,
                        principalTable: "spchamado",
                        principalColumn: "spchamado_id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_spfollowup_eventofollowup_id",
                table: "spfollowup",
                column: "eventofollowup_id");

            migrationBuilder.CreateIndex(
                name: "IX_spchamado_fila_retornos_UsuarioId",
                table: "spchamado_fila_retornos",
                column: "UsuarioId");

            migrationBuilder.CreateIndex(
                name: "IX_spchamado_spchamado_produto_id",
                table: "spchamado",
                column: "spchamado_produto_id");

            migrationBuilder.CreateIndex(
                name: "IX_spchamado_spchamado_release_id",
                table: "spchamado",
                column: "spchamado_release_id");

            migrationBuilder.CreateIndex(
                name: "IX_equipamento_crcliente_id",
                table: "equipamento",
                column: "crcliente_id");

            migrationBuilder.CreateIndex(
                name: "IX_equipamento_id_modelo",
                table: "equipamento",
                column: "id_modelo");

            migrationBuilder.CreateIndex(
                name: "IX_spchamado_assistencia_equipamento_id",
                table: "spchamado_assistencia",
                column: "equipamento_id");

            migrationBuilder.CreateIndex(
                name: "IX_spchamado_assistencia_spchamado_id",
                table: "spchamado_assistencia",
                column: "spchamado_id");

            migrationBuilder.CreateIndex(
                name: "IX_spchamado_release_spchamado_release_produto",
                table: "spchamado_release",
                column: "spchamado_release_produto");

            migrationBuilder.AddForeignKey(
                name: "FK_modelo_categoria_id_categoria",
                table: "modelo",
                column: "id_categoria",
                principalTable: "categoria",
                principalColumn: "id_categoria",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_modelo_fabricante_codigo_fabricante",
                table: "modelo",
                column: "codigo_fabricante",
                principalTable: "fabricante",
                principalColumn: "codigo_fabricante",
                onDelete: ReferentialAction.Cascade);

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
                name: "FK_spchamado_spchamado_produto_spchamado_produto_id",
                table: "spchamado",
                column: "spchamado_produto_id",
                principalTable: "spchamado_produto",
                principalColumn: "spchamado_produto_id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_spchamado_spchamado_release_spchamado_release_id",
                table: "spchamado",
                column: "spchamado_release_id",
                principalTable: "spchamado_release",
                principalColumn: "spchamado_release_id",
                onDelete: ReferentialAction.Restrict);

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
                name: "FK_spfollowup_eventofollowup_eventofollowup_id",
                table: "spfollowup",
                column: "eventofollowup_id",
                principalTable: "eventofollowup",
                principalColumn: "id_evento",
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
                name: "FK_modelo_categoria_id_categoria",
                table: "modelo");

            migrationBuilder.DropForeignKey(
                name: "FK_modelo_fabricante_codigo_fabricante",
                table: "modelo");

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
                name: "FK_spchamado_spchamado_produto_spchamado_produto_id",
                table: "spchamado");

            migrationBuilder.DropForeignKey(
                name: "FK_spchamado_spchamado_release_spchamado_release_id",
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
                name: "FK_spfollowup_eventofollowup_eventofollowup_id",
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
                name: "eventofollowup");

            migrationBuilder.DropTable(
                name: "spchamado_assistencia");

            migrationBuilder.DropTable(
                name: "spchamado_release");

            migrationBuilder.DropTable(
                name: "equipamento");

            migrationBuilder.DropIndex(
                name: "IX_spfollowup_eventofollowup_id",
                table: "spfollowup");

            migrationBuilder.DropIndex(
                name: "IX_spchamado_fila_retornos_UsuarioId",
                table: "spchamado_fila_retornos");

            migrationBuilder.DropIndex(
                name: "IX_spchamado_spchamado_produto_id",
                table: "spchamado");

            migrationBuilder.DropIndex(
                name: "IX_spchamado_spchamado_release_id",
                table: "spchamado");

            migrationBuilder.DropPrimaryKey(
                name: "PK_modelo",
                table: "modelo");

            migrationBuilder.DropPrimaryKey(
                name: "PK_fabricante",
                table: "fabricante");

            migrationBuilder.DropPrimaryKey(
                name: "PK_categoria",
                table: "categoria");

            migrationBuilder.DropColumn(
                name: "eventofollowup_id",
                table: "spfollowup");

            migrationBuilder.DropColumn(
                name: "UsuarioId",
                table: "spchamado_fila_retornos");

            migrationBuilder.DropColumn(
                name: "spchamado_fila_cancelado",
                table: "spchamado_fila");

            migrationBuilder.RenameTable(
                name: "modelo",
                newName: "Modelos");

            migrationBuilder.RenameTable(
                name: "fabricante",
                newName: "Fabricantes");

            migrationBuilder.RenameTable(
                name: "categoria",
                newName: "Categorias");

            migrationBuilder.RenameColumn(
                name: "descricao",
                table: "Modelos",
                newName: "Descricao");

            migrationBuilder.RenameColumn(
                name: "id_categoria",
                table: "Modelos",
                newName: "CategoriaId");

            migrationBuilder.RenameColumn(
                name: "codigo_fabricante",
                table: "Modelos",
                newName: "FabricanteId");

            migrationBuilder.RenameColumn(
                name: "id_modelo",
                table: "Modelos",
                newName: "Id");

            migrationBuilder.RenameIndex(
                name: "IX_modelo_id_categoria",
                table: "Modelos",
                newName: "IX_Modelos_CategoriaId");

            migrationBuilder.RenameIndex(
                name: "IX_modelo_codigo_fabricante",
                table: "Modelos",
                newName: "IX_Modelos_FabricanteId");

            migrationBuilder.RenameColumn(
                name: "nome_fabricante",
                table: "Fabricantes",
                newName: "Nome");

            migrationBuilder.RenameColumn(
                name: "codigo_fabricante",
                table: "Fabricantes",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "descricao_categoria",
                table: "Categorias",
                newName: "Descricao");

            migrationBuilder.RenameColumn(
                name: "id_categoria",
                table: "Categorias",
                newName: "Id");

            migrationBuilder.AlterColumn<int>(
                name: "sptarefa_id",
                table: "sptarefa",
                type: "integer",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "integer")
                .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn)
                .OldAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

            migrationBuilder.AlterColumn<int>(
                name: "etapa_status_id",
                table: "spimplantacao_etapa_status",
                type: "integer",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "integer")
                .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn)
                .OldAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

            migrationBuilder.AlterColumn<int>(
                name: "id",
                table: "spimplantacao_etapa_chamado",
                type: "integer",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "integer")
                .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn)
                .OldAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

            migrationBuilder.AlterColumn<int>(
                name: "etapa_id",
                table: "spimplantacao_etapa",
                type: "integer",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "integer")
                .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn)
                .OldAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

            migrationBuilder.AlterColumn<int>(
                name: "spfollowup_id",
                table: "spfollowup",
                type: "integer",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "integer")
                .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn)
                .OldAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

            migrationBuilder.AlterColumn<int>(
                name: "spchamado_subgrupo_id",
                table: "spchamado_subgrupo",
                type: "integer",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "integer")
                .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn)
                .OldAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

            migrationBuilder.AlterColumn<int>(
                name: "spchamado_sla_id",
                table: "spchamado_sla",
                type: "integer",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "integer")
                .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn)
                .OldAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

            migrationBuilder.AlterColumn<int>(
                name: "spchamado_produto_id",
                table: "spchamado_produto",
                type: "integer",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "integer")
                .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn)
                .OldAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

            migrationBuilder.AlterColumn<int>(
                name: "spchamado_origem_id",
                table: "spchamado_origem",
                type: "integer",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "integer")
                .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn)
                .OldAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

            migrationBuilder.AlterColumn<int>(
                name: "spchamado_grupo_id",
                table: "spchamado_grupo",
                type: "integer",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "integer")
                .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn)
                .OldAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

            migrationBuilder.AlterColumn<int>(
                name: "spchamado_fluxo_id",
                table: "spchamado_fluxo",
                type: "integer",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "integer")
                .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn)
                .OldAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

            migrationBuilder.AlterColumn<int>(
                name: "Id",
                table: "spchamado_fila_retornos",
                type: "integer",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "integer")
                .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn)
                .OldAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

            migrationBuilder.AddColumn<DateTime>(
                name: "CreationTime",
                table: "spchamado_fila_retornos",
                type: "timestamp without time zone",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<long>(
                name: "CreatorUserId",
                table: "spchamado_fila_retornos",
                type: "bigint",
                nullable: true);

            migrationBuilder.AddColumn<long>(
                name: "DeleterUserId",
                table: "spchamado_fila_retornos",
                type: "bigint",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DeletionTime",
                table: "spchamado_fila_retornos",
                type: "timestamp without time zone",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "spchamado_fila_retornos",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<DateTime>(
                name: "LastModificationTime",
                table: "spchamado_fila_retornos",
                type: "timestamp without time zone",
                nullable: true);

            migrationBuilder.AddColumn<long>(
                name: "LastModifierUserId",
                table: "spchamado_fila_retornos",
                type: "bigint",
                nullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "spchamado_fila_id",
                table: "spchamado_fila",
                type: "integer",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "integer")
                .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn)
                .OldAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

            migrationBuilder.AlterColumn<int>(
                name: "spchamado_class_id",
                table: "spchamado_class",
                type: "integer",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "integer")
                .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn)
                .OldAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

            migrationBuilder.AlterColumn<int>(
                name: "spchamado_id",
                table: "spchamado",
                type: "integer",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "integer")
                .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn)
                .OldAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

            migrationBuilder.AlterColumn<int>(
                name: "spanexo_id",
                table: "spanexo",
                type: "integer",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "integer")
                .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn)
                .OldAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

            migrationBuilder.AlterColumn<int>(
                name: "crcliente_id",
                table: "crcliente",
                type: "integer",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "integer")
                .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn)
                .OldAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

            migrationBuilder.AlterColumn<int>(
                name: "Id",
                table: "crachas",
                type: "integer",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "integer")
                .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn)
                .OldAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

            migrationBuilder.AlterColumn<long>(
                name: "Id",
                table: "AbpUserTokens",
                type: "bigint",
                nullable: false,
                oldClrType: typeof(long),
                oldType: "bigint")
                .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn)
                .OldAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

            migrationBuilder.AlterColumn<long>(
                name: "Id",
                table: "AbpUsers",
                type: "bigint",
                nullable: false,
                oldClrType: typeof(long),
                oldType: "bigint")
                .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn)
                .OldAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

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

            migrationBuilder.AlterColumn<long>(
                name: "Id",
                table: "AbpUserRoles",
                type: "bigint",
                nullable: false,
                oldClrType: typeof(long),
                oldType: "bigint")
                .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn)
                .OldAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

            migrationBuilder.AlterColumn<long>(
                name: "Id",
                table: "AbpUserOrganizationUnits",
                type: "bigint",
                nullable: false,
                oldClrType: typeof(long),
                oldType: "bigint")
                .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn)
                .OldAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

            migrationBuilder.AlterColumn<long>(
                name: "Id",
                table: "AbpUserLogins",
                type: "bigint",
                nullable: false,
                oldClrType: typeof(long),
                oldType: "bigint")
                .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn)
                .OldAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

            migrationBuilder.AlterColumn<long>(
                name: "Id",
                table: "AbpUserLoginAttempts",
                type: "bigint",
                nullable: false,
                oldClrType: typeof(long),
                oldType: "bigint")
                .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn)
                .OldAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

            migrationBuilder.AlterColumn<long>(
                name: "Id",
                table: "AbpUserClaims",
                type: "bigint",
                nullable: false,
                oldClrType: typeof(long),
                oldType: "bigint")
                .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn)
                .OldAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

            migrationBuilder.AlterColumn<long>(
                name: "Id",
                table: "AbpUserAccounts",
                type: "bigint",
                nullable: false,
                oldClrType: typeof(long),
                oldType: "bigint")
                .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn)
                .OldAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

            migrationBuilder.AlterColumn<int>(
                name: "Id",
                table: "AbpTenants",
                type: "integer",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "integer")
                .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn)
                .OldAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

            migrationBuilder.AlterColumn<long>(
                name: "Id",
                table: "AbpSettings",
                type: "bigint",
                nullable: false,
                oldClrType: typeof(long),
                oldType: "bigint")
                .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn)
                .OldAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

            migrationBuilder.AlterColumn<int>(
                name: "Id",
                table: "AbpRoles",
                type: "integer",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "integer")
                .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn)
                .OldAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

            migrationBuilder.AlterColumn<long>(
                name: "Id",
                table: "AbpRoleClaims",
                type: "bigint",
                nullable: false,
                oldClrType: typeof(long),
                oldType: "bigint")
                .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn)
                .OldAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

            migrationBuilder.AlterColumn<long>(
                name: "Id",
                table: "AbpPermissions",
                type: "bigint",
                nullable: false,
                oldClrType: typeof(long),
                oldType: "bigint")
                .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn)
                .OldAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

            migrationBuilder.AlterColumn<long>(
                name: "Id",
                table: "AbpOrganizationUnits",
                type: "bigint",
                nullable: false,
                oldClrType: typeof(long),
                oldType: "bigint")
                .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn)
                .OldAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

            migrationBuilder.AlterColumn<long>(
                name: "Id",
                table: "AbpOrganizationUnitRoles",
                type: "bigint",
                nullable: false,
                oldClrType: typeof(long),
                oldType: "bigint")
                .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn)
                .OldAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

            migrationBuilder.AlterColumn<long>(
                name: "Id",
                table: "AbpLanguageTexts",
                type: "bigint",
                nullable: false,
                oldClrType: typeof(long),
                oldType: "bigint")
                .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn)
                .OldAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

            migrationBuilder.AlterColumn<int>(
                name: "Id",
                table: "AbpLanguages",
                type: "integer",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "integer")
                .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn)
                .OldAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

            migrationBuilder.AlterColumn<long>(
                name: "Id",
                table: "AbpFeatures",
                type: "bigint",
                nullable: false,
                oldClrType: typeof(long),
                oldType: "bigint")
                .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn)
                .OldAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

            migrationBuilder.AlterColumn<long>(
                name: "Id",
                table: "AbpEntityPropertyChanges",
                type: "bigint",
                nullable: false,
                oldClrType: typeof(long),
                oldType: "bigint")
                .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn)
                .OldAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

            migrationBuilder.AlterColumn<long>(
                name: "Id",
                table: "AbpEntityChangeSets",
                type: "bigint",
                nullable: false,
                oldClrType: typeof(long),
                oldType: "bigint")
                .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn)
                .OldAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

            migrationBuilder.AlterColumn<long>(
                name: "Id",
                table: "AbpEntityChanges",
                type: "bigint",
                nullable: false,
                oldClrType: typeof(long),
                oldType: "bigint")
                .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn)
                .OldAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

            migrationBuilder.AlterColumn<int>(
                name: "Id",
                table: "AbpEditions",
                type: "integer",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "integer")
                .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn)
                .OldAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

            migrationBuilder.AlterColumn<int>(
                name: "Id",
                table: "AbpDynamicPropertyValues",
                type: "integer",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "integer")
                .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn)
                .OldAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

            migrationBuilder.AlterColumn<int>(
                name: "Id",
                table: "AbpDynamicProperties",
                type: "integer",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "integer")
                .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn)
                .OldAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

            migrationBuilder.AlterColumn<int>(
                name: "Id",
                table: "AbpDynamicEntityPropertyValues",
                type: "integer",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "integer")
                .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn)
                .OldAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

            migrationBuilder.AlterColumn<int>(
                name: "Id",
                table: "AbpDynamicEntityProperties",
                type: "integer",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "integer")
                .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn)
                .OldAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

            migrationBuilder.AlterColumn<long>(
                name: "Id",
                table: "AbpBackgroundJobs",
                type: "bigint",
                nullable: false,
                oldClrType: typeof(long),
                oldType: "bigint")
                .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn)
                .OldAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

            migrationBuilder.AlterColumn<long>(
                name: "Id",
                table: "AbpAuditLogs",
                type: "bigint",
                nullable: false,
                oldClrType: typeof(long),
                oldType: "bigint")
                .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn)
                .OldAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

            migrationBuilder.AlterColumn<string>(
                name: "Descricao",
                table: "Modelos",
                type: "varchar(256)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "citext");

            migrationBuilder.AlterColumn<int>(
                name: "Id",
                table: "Modelos",
                type: "integer",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "integer")
                .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn)
                .OldAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

            migrationBuilder.AlterColumn<string>(
                name: "Nome",
                table: "Fabricantes",
                type: "varchar(256)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "citext");

            migrationBuilder.AlterColumn<int>(
                name: "Id",
                table: "Fabricantes",
                type: "integer",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "integer")
                .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn)
                .OldAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

            migrationBuilder.AlterColumn<string>(
                name: "Descricao",
                table: "Categorias",
                type: "varchar(256)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "citext");

            migrationBuilder.AlterColumn<int>(
                name: "Id",
                table: "Categorias",
                type: "integer",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "integer")
                .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn)
                .OldAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

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

            migrationBuilder.AddPrimaryKey(
                name: "PK_Modelos",
                table: "Modelos",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Fabricantes",
                table: "Fabricantes",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Categorias",
                table: "Categorias",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Modelos_Categorias_CategoriaId",
                table: "Modelos",
                column: "CategoriaId",
                principalTable: "Categorias",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Modelos_Fabricantes_FabricanteId",
                table: "Modelos",
                column: "FabricanteId",
                principalTable: "Fabricantes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

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

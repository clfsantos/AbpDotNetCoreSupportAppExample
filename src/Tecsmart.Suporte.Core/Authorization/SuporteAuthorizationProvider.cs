using Abp.Authorization;
using Abp.Localization;
using Abp.MultiTenancy;

namespace Tecsmart.Suporte.Authorization
{
    public class SuporteAuthorizationProvider : AuthorizationProvider
    {
        public override void SetPermissions(IPermissionDefinitionContext context)
        {
            context.CreatePermission(PermissionNames.Pages_Chamados, L("Chamados"));
            context.CreatePermission(PermissionNames.Pages_Fila_Atendimento, L("FilaAtendimentos"));
            context.CreatePermission(PermissionNames.Pages_Clientes, L("Clientes"));
            context.CreatePermission(PermissionNames.Pages_Clientes_Omie, L("ClientesOmie"));
            context.CreatePermission(PermissionNames.Pages_Produtos, L("Produtos"));
            context.CreatePermission(PermissionNames.Pages_Produtos_Create, L("ProdutoCreate"));
            context.CreatePermission(PermissionNames.Pages_Produtos_Edit, L("ProdutoEdit"));
            context.CreatePermission(PermissionNames.Pages_Produtos_Delete, L("ProdutoDelete"));
            context.CreatePermission(PermissionNames.Pages_Grupos, L("Grupos"));
            context.CreatePermission(PermissionNames.Pages_Grupos_Create, L("GrupoCreate"));
            context.CreatePermission(PermissionNames.Pages_Grupos_Edit, L("GrupoEdit"));
            context.CreatePermission(PermissionNames.Pages_Grupos_Delete, L("GrupoDelete"));
            context.CreatePermission(PermissionNames.Pages_SubGrupos, L("SubGrupos"));
            context.CreatePermission(PermissionNames.Pages_SubGrupos_Create, L("SubGrupoCreate"));
            context.CreatePermission(PermissionNames.Pages_SubGrupos_Edit, L("SubGrupoEdit"));
            context.CreatePermission(PermissionNames.Pages_SubGrupos_Delete, L("SubGrupoDelete"));
            context.CreatePermission(PermissionNames.Pages_Releases, L("Releases"));
            context.CreatePermission(PermissionNames.Pages_Crachas, L("Crachas"));
            context.CreatePermission(PermissionNames.Pages_Crachas_Suprimentos, L("CrachasSuprimentos"));
            context.CreatePermission(PermissionNames.Pages_Agenda, L("Agenda"));
            context.CreatePermission(PermissionNames.Pages_Equipamentos, L("Equipamentos"));
            context.CreatePermission(PermissionNames.Pages_Fabricantes, L("Fabricantes"));
            context.CreatePermission(PermissionNames.Pages_Fabricantes_Create, L("FabricanteCreate"));
            context.CreatePermission(PermissionNames.Pages_Fabricantes_Edit, L("FabricanteEdit"));
            context.CreatePermission(PermissionNames.Pages_Fabricantes_Delete, L("FabricanteEdit"));
            context.CreatePermission(PermissionNames.Pages_Categorias, L("Categorias"));
            context.CreatePermission(PermissionNames.Pages_Categorias_Create, L("CategoriaCreate"));
            context.CreatePermission(PermissionNames.Pages_Categorias_Edit, L("CategoriaEdit"));
            context.CreatePermission(PermissionNames.Pages_Categorias_Delete, L("CategoriaEdit"));
            context.CreatePermission(PermissionNames.Pages_Notifications_EnviarNotificacao, L("NotificationsEnviar"));
            context.CreatePermission(PermissionNames.Pages_Modelos, L("Modelos"));
            context.CreatePermission(PermissionNames.Pages_Modelos_Create, L("ModeloCreate"));
            context.CreatePermission(PermissionNames.Pages_Modelos_Edit, L("ModeloEdit"));
            context.CreatePermission(PermissionNames.Pages_Modelos_Delete, L("ModeloEdit"));

            context.CreatePermission(PermissionNames.Pages_Users, L("Users"));
            context.CreatePermission(PermissionNames.Pages_Users_View, L("UsersView"));
            context.CreatePermission(PermissionNames.Pages_Users_Create, L("UsersCreate"));
            context.CreatePermission(PermissionNames.Pages_Users_Edit, L("UsersEdit"));
            context.CreatePermission(PermissionNames.Pages_Users_Delete, L("UsersDelete"));
            context.CreatePermission(PermissionNames.Pages_Users_Activation, L("UsersActivation"));
            context.CreatePermission(PermissionNames.Pages_Users_List_Menu, L("UsersList"));
            context.CreatePermission(PermissionNames.Pages_Users_List_Combo, L("UsersListCombo"));
            context.CreatePermission(PermissionNames.Pages_Users_List_Roles, L("UsersListRoles"));
            context.CreatePermission(PermissionNames.Pages_Users_Change_Password, L("UsersChangePassword"));
            context.CreatePermission(PermissionNames.Pages_Roles, L("Roles"));
            context.CreatePermission(PermissionNames.Pages_Tenants, L("Tenants"), multiTenancySides: MultiTenancySides.Host);
        }

        private static ILocalizableString L(string name)
        {
            return new LocalizableString(name, SuporteConsts.LocalizationSourceName);
        }
    }
}

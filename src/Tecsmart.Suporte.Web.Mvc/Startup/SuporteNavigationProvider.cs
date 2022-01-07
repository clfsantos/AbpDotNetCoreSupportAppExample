using Abp.Application.Navigation;
using Abp.Authorization;
using Abp.Localization;
using Tecsmart.Suporte.Authorization;
using Tecsmart.Suporte.Web.Views.Shared.Components.SideBarMenu;

namespace Tecsmart.Suporte.Web.Startup
{
    /// <summary>
    /// This class defines menus for the application.
    /// </summary>
    public class SuporteNavigationProvider : NavigationProvider
    {
        public override void SetNavigation(INavigationProviderContext context)
        {
            context.Manager.MainMenu
                .AddItem(
                    new MenuItemDefinition(
                        PageNames.Home,
                        L("HomePage"),
                        url: "",
                        order: 1,
                        icon: "fas fa-home",
                        requiresAuthentication: true
                    )
                ).AddItem(
                    new MenuItemDefinition(
                        PageNames.Agenda,
                        L("Agenda"),
                        url: "Agenda",
                        icon: "fas fa-calendar-alt",
                        order: 2,
                        permissionDependency: new SimplePermissionDependency(PermissionNames.Pages_Agenda)
                    )
                ).AddItem(
                    new MenuItemDefinition(
                        PageNames.Tenants,
                        L("Tenants"),
                        url: "Tenants",
                        icon: "fas fa-building",
                        permissionDependency: new SimplePermissionDependency(PermissionNames.Pages_Tenants)
                    )
                ).AddItem(
                    new MenuItemDefinition(
                        PageNames.Users,
                        L("Users"),
                        url: "Users",
                        icon: "fas fa-users",
                        order: 9,
                        permissionDependency: new SimplePermissionDependency(PermissionNames.Pages_Users_List_Menu)
                    )
                ).AddItem(
                    new MenuItemDefinition(
                        PageNames.Roles,
                        L("Roles"),
                        url: "Roles",
                        icon: "fas fa-theater-masks",
                        order: 8,
                        permissionDependency: new SimplePermissionDependency(PermissionNames.Pages_Roles)
                            )
                )
                .AddItem( //Cadastros
                   new MenuItemDefinition(
                        "Cadastros",
                        L("Cadastros"),
                        icon: "fas fa-edit",
                        order: 3
                    )
                    .AddItem(
                        new MenuItemDefinition(
                        PageNames.Releases,
                        L("Releases"),
                        url: "Versoes",
                        icon: "fas fa-code-branch",
                        order: 1,
                        permissionDependency: new SimplePermissionDependency(PermissionNames.Pages_Releases)))
                    .AddItem(
                        new MenuItemDefinition(
                        PageNames.Equipamentos,
                        L("Equipamentos"),
                        url: "Equipamentos",
                        icon: "fas fa-fingerprint",
                        order: 2,
                        permissionDependency: new SimplePermissionDependency(PermissionNames.Pages_Equipamentos)))
                     .AddItem(
                        new MenuItemDefinition(
                        PageNames.Modelos,
                        L("Modelos"),
                        url: "Modelos",
                        icon: "fas fa-clone",
                        order: 3,
                        permissionDependency: new SimplePermissionDependency(PermissionNames.Pages_Modelos)))
                    .AddItem(
                        new MenuItemDefinition(
                        PageNames.Fabricantes,
                        L("Fabricantes"),
                        url: "Fabricantes",
                        icon: "fas fa-industry",
                        order: 4,
                        permissionDependency: new SimplePermissionDependency(PermissionNames.Pages_Fabricantes)))
                    .AddItem(
                        new MenuItemDefinition(
                        PageNames.Categorias,
                        L("Categorias"),
                        url: "Categorias",
                        icon: "fas fa-coins",
                        order: 5,
                        permissionDependency: new SimplePermissionDependency(PermissionNames.Pages_Categorias)))
                    .AddItem(
                        new MenuItemDefinition(
                        PageNames.Produtos,
                        L("Produtos"),
                        url: "Produtos",
                        icon: "fas fa-box",
                        order: 6,
                        permissionDependency: new SimplePermissionDependency(PermissionNames.Pages_Produtos)))
                    .AddItem(
                        new MenuItemDefinition(
                        PageNames.Grupos,
                        L("Grupos"),
                        url: "Grupos",
                        icon: "fas fa-object-group",
                        order: 7,
                        permissionDependency: new SimplePermissionDependency(PermissionNames.Pages_Grupos)))
                    .AddItem(
                        new MenuItemDefinition(
                        PageNames.SubGrupos,
                        L("SubGrupos"),
                        url: "SubGrupos",
                        icon: "far fa-object-group",
                        order: 8,
                        permissionDependency: new SimplePermissionDependency(PermissionNames.Pages_SubGrupos)))
                )//Cadastros
                .AddItem( //Suporte
                    new MenuItemDefinition(
                        "Suporte",
                        L("Suporte"),
                        icon: "far fa-life-ring",
                        order: 4,
                        customData: new SideBarMenuCustomData("badge-info", 0)
                    )
                    .AddItem(
                        new MenuItemDefinition(
                        PageNames.FluxoAtendimentos,
                        L("FluxoAtendimentos"),
                        url: "FluxoAtendimentos",
                        icon: "fas fa-exchange-alt",
                        order: 1,
                        permissionDependency: new SimplePermissionDependency(PermissionNames.Pages_Fila_Atendimento)))
                    .AddItem(
                        new MenuItemDefinition(
                        PageNames.FilaAtendimentos,
                        L("FilaAtendimentos"),
                        url: "FilaAtendimentos",
                        icon: "fas fa-list-ul",
                        order: 2,
                        customData: new SideBarMenuCustomData("badge-info", 0),
                        permissionDependency: new SimplePermissionDependency(PermissionNames.Pages_Fila_Atendimento)))
                    .AddItem(
                        new MenuItemDefinition(
                        PageNames.Chamados,
                        L("Chamados"),
                        url: "Chamados",
                        icon: "fas fa-headset",
                        order: 3,
                        permissionDependency: new SimplePermissionDependency(PermissionNames.Pages_Chamados)))
                )//Suporte
                .AddItem(
                    new MenuItemDefinition(
                        PageNames.Clientes,
                        L("Clientes"),
                        url: "Clientes",
                        icon: "fas fa-users",
                        order: 5,
                        permissionDependency: new SimplePermissionDependency(PermissionNames.Pages_Clientes)
                    )
                )
                .AddItem( //Crachás
                    new MenuItemDefinition(
                        PageNames.Crachas,
                        L("Crachas"),
                        url: "Crachas",
                        icon: "fas fa-id-card-alt",
                        order: 6,
                        permissionDependency: new SimplePermissionDependency(PermissionNames.Pages_Crachas)
                    )
                    .AddItem(
                        new MenuItemDefinition(
                        PageNames.Crachas,
                        L("PedidoCracha"),
                        url: "Crachas",
                        icon: "fas fa-id-card-alt",
                        order: 1,
                        permissionDependency: new SimplePermissionDependency(PermissionNames.Pages_Crachas)))
                    .AddItem(
                        new MenuItemDefinition(
                        PageNames.Crachas_Suprimentos,
                        L("CrachasSuprimentos"),
                        url: "Suprimentos",
                        icon: "fas fa-box",
                        order: 2,
                        permissionDependency: new SimplePermissionDependency(PermissionNames.Pages_Crachas_Suprimentos)))
                    .AddItem(
                        new MenuItemDefinition(
                        PageNames.Crachas_Suprimentos_Consumo,
                        L("CrachasSuprimentosConsumo"),
                        url: "Suprimentos/Consumo",
                        icon: "fas fa-toolbox",
                        order: 3,
                        permissionDependency: new SimplePermissionDependency(PermissionNames.Pages_Crachas_Suprimentos)))
                )//Crachás
                .AddItem( //Consultas
                    new MenuItemDefinition(
                        "Consultas",
                        L("Consultas"),
                        icon: "fas fa-search-plus",
                        order: 7,
                        permissionDependency: new SimplePermissionDependency(PermissionNames.Pages_Crachas)
                    )
                    .AddItem(
                        new MenuItemDefinition(
                        PageNames.Chamados_Relatorio,
                        L("ChamadosConsulta"),
                        url: "Chamados/Relatorio",
                        icon: "fas fa-th-list",
                        order: 1,
                        permissionDependency: new SimplePermissionDependency(PermissionNames.Pages_Chamados)))
                    .AddItem(
                        new MenuItemDefinition(
                        PageNames.Assistencias_Relatorio,
                        L("AssistenciasConsulta"),
                        url: "Chamados/RelatorioAssistencia",
                        icon: "fas fa-th-list",
                        order: 2,
                        permissionDependency: new SimplePermissionDependency(PermissionNames.Pages_Chamados)))
                )//Consultas
                ;
        }

        private static ILocalizableString L(string name)
        {
            return new LocalizableString(name, SuporteConsts.LocalizationSourceName);
        }
    }
}

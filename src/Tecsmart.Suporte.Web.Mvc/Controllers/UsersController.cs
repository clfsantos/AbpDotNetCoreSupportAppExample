using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Abp.Application.Services.Dto;
using Abp.AspNetCore.Mvc.Authorization;
using Tecsmart.Suporte.Authorization;
using Tecsmart.Suporte.Controllers;
using Tecsmart.Suporte.Users;
using Tecsmart.Suporte.Web.Models.Users;
using Abp.Web.Models;
using DevExtreme.AspNet.Data.ResponseModel;
using DevExtreme.AspNet.Mvc;
using Microsoft.AspNetCore.Http;
using System.IO;
using System;
using Tecsmart.Suporte.Users.Dto;

namespace Tecsmart.Suporte.Web.Controllers
{
    [AbpMvcAuthorize(PermissionNames.Pages_Users)]
    public class UsersController : SuporteControllerBase
    {
        private readonly IUserAppService _userAppService;

        public UsersController(IUserAppService userAppService)
        {
            _userAppService = userAppService;
        }

        [AbpMvcAuthorize(PermissionNames.Pages_Users_View)]
        public async Task<ActionResult> Index()
        {
            var roles = (await _userAppService.GetRoles()).Items;
            var model = new UserListViewModel
            {
                Roles = roles
            };
            return View(model);
        }

        [AbpMvcAuthorize(PermissionNames.Pages_Users_Edit)]
        public async Task<ActionResult> EditModal(long userId)
        {
            var user = await _userAppService.GetAsync(new EntityDto<long>(userId));
            var roles = (await _userAppService.GetRoles()).Items;
            var model = new EditUserModalViewModel
            {
                User = user,
                Roles = roles
            };
            return PartialView("_EditModal", model);
        }

        [AbpMvcAuthorize(PermissionNames.Pages_Users_Change_Password)]
        public ActionResult ChangePassword()
        {
            return View();
        }

        [AbpMvcAuthorize(PermissionNames.Pages_Users_Change_Password)]
        public ActionResult MudarFoto()
        {
            return View();
        }

        [HttpGet]
        [DontWrapResult]
        [AbpMvcAuthorize(PermissionNames.Pages_Users_List_Combo)]
        public async Task<LoadResult> GetAllUsers(DataSourceLoadOptions loadOptions)
        {
            return await _userAppService.GetAllForLoadResult(loadOptions);
        }

        [HttpPost]
        public async Task<IActionResult> MudarFotoUpload(IFormFile arquivo)
        {
            var filePrefixo = Guid.NewGuid() + "_";
            if (!await UploadArquivo(arquivo, filePrefixo))
            {
                return Json(new { sucesso = false, erros = "Upload Falhou" });
            }
            var foto = new ChangeFotoDto
            {
                CaminhoFoto = filePrefixo + arquivo.FileName
            };
            await _userAppService.ChangeFoto(foto);
            return Json(new { sucesso = true, mensagem = "Foto trocada com sucesso!" });
        }

        private async Task<bool> UploadArquivo(IFormFile arquivo, string filePrefixo)
        {
            if (arquivo.Length <= 0) return false;

            var path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/arquivos/usuarios", filePrefixo + arquivo.FileName);

            if (System.IO.File.Exists(path))
            {
                ModelState.AddModelError(string.Empty, "Já existe um arquivo com este nome!");
                return false;
            }

            using (var stream = new FileStream(path, FileMode.Create))
            {
                await arquivo.CopyToAsync(stream);
            }

            return true;
        }

    }
}

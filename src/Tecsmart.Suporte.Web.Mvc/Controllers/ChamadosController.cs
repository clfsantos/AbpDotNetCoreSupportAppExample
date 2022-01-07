using Abp.Application.Services.Dto;
using Abp.AspNetCore.Mvc.Authorization;
using Abp.Web.Models;
using DevExtreme.AspNet.Data.ResponseModel;
using DevExtreme.AspNet.Mvc;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.IO;
using System.Threading.Tasks;
using Tecsmart.Suporte.Chamados;
using Tecsmart.Suporte.Chamados.Dto;
using Tecsmart.Suporte.Controllers;
using Tecsmart.Suporte.Web.Models.Chamados;

namespace Tecsmart.Suporte.Web.Controllers
{
    [AbpMvcAuthorize]
    public class ChamadosController : SuporteControllerBase
    {
        private readonly IChamadoAppService _chamadoAppService;
        private readonly IFollowupAppService _followupAppService;
        private readonly ITarefaAppService _tarefaAppService;
        private readonly IImplantacaoAppService _implantacaoAppService;
        private readonly IAssistenciaAppService _assistenciaAppService;
        private readonly IAnexoAppService _anexoAppService;
        public ChamadosController(IChamadoAppService chamadoAppService,
                                  IFollowupAppService followupAppService,
                                  ITarefaAppService tarefaAppService,
                                  IImplantacaoAppService implantacaoAppService,
                                  IAssistenciaAppService assistenciaAppService,
                                  IAnexoAppService anexoAppService)
        {
            _chamadoAppService = chamadoAppService;
            _followupAppService = followupAppService;
            _tarefaAppService = tarefaAppService;
            _implantacaoAppService = implantacaoAppService;
            _assistenciaAppService = assistenciaAppService;
            _anexoAppService = anexoAppService;
        }

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Relatorio()
        {
            return View("Relatorio");
        }

        public ActionResult RelatorioAssistencia()
        {
            return View("RelatorioAssistencia");
        }

        [HttpGet]
        [DontWrapResult]
        public async Task<LoadResult> GetAllChamados(DataSourceLoadOptions loadOptions)
        {
            return await _chamadoAppService.GetAllForLoadResult(loadOptions);
        }

        [HttpGet]
        [DontWrapResult]
        public async Task<LoadResult> GetAllChamadosRelatorio(DataSourceLoadOptions loadOptions)
        {
            return await _chamadoAppService.GetAllForRelatorioLoadResult(loadOptions);
        }

        [HttpGet]
        [DontWrapResult]
        public async Task<LoadResult> GetAllAssistenciaRelatorio(DataSourceLoadOptions loadOptions)
        {
            return await _chamadoAppService.GetAllForRelatorioAssistenciaLoadResult(loadOptions);
        }

        [HttpGet]
        [DontWrapResult]
        public async Task<LoadResult> GetAllFollowups(DataSourceLoadOptions loadOptions, int chamadoId)
        {
            return await _followupAppService.GetAllForLoadResult(loadOptions, chamadoId);
        }

        [HttpGet]
        [DontWrapResult]
        public async Task<LoadResult> GetAllTarefas(DataSourceLoadOptions loadOptions, int chamadoId)
        {
            return await _tarefaAppService.GetAllForLoadResult(loadOptions, chamadoId);
        }

        [HttpGet]
        [DontWrapResult]
        public async Task<LoadResult> GetAllEtapas(DataSourceLoadOptions loadOptions, int chamadoId)
        {
            return await _implantacaoAppService.GetAllForLoadResult(loadOptions, chamadoId);
        }

        [HttpGet]
        [DontWrapResult]
        public async Task<LoadResult> GetEtapasAbertasPendentes(DataSourceLoadOptions loadOptions)
        {
            return await _implantacaoAppService.GetEtapasAbertasPendentes(loadOptions);
        }

        [HttpGet]
        [DontWrapResult]
        public async Task<LoadResult> GetEtapasAbertasPendentesGeral(DataSourceLoadOptions loadOptions)
        {
            return await _implantacaoAppService.GetEtapasAbertasPendentesGeral(loadOptions);
        }

        [HttpGet]
        [DontWrapResult]
        public async Task<LoadResult> GetAllAnexos(DataSourceLoadOptions loadOptions, int chamadoId)
        {
            return await _anexoAppService.GetAllForLoadResult(loadOptions, chamadoId);
        }

        [HttpGet]
        [DontWrapResult]
        public async Task<LoadResult> GetAllChamadosDia(DataSourceLoadOptions loadOptions)
        {
            return await _chamadoAppService.GetChamadosDia(loadOptions);
        }

        [HttpGet]
        [DontWrapResult]
        public async Task<LoadResult> GetAllChamadosMes(DataSourceLoadOptions loadOptions)
        {
            return await _chamadoAppService.GetChamadosMes(loadOptions);
        }

        [HttpGet]
        [DontWrapResult]
        public async Task<LoadResult> GetAllChamadosAno(DataSourceLoadOptions loadOptions)
        {
            return await _chamadoAppService.GetChamadosAno(loadOptions);
        }

        [HttpGet]
        [DontWrapResult]
        public async Task<LoadResult> GetChamadosTecnico(DataSourceLoadOptions loadOptions)
        {
            return await _chamadoAppService.GetChamadosTecnico(loadOptions);
        }

        [HttpGet]
        [DontWrapResult]
        public async Task<LoadResult> GetAssistenciasAbertas(DataSourceLoadOptions loadOptions)
        {
            return await _assistenciaAppService.GetAssistenciasAbertas(loadOptions);
        }

        [HttpGet]
        public async Task<PartialViewResult> AssistenciaPartial(int? id)
        {
            GetChamadoForEditOutput getChamadoForEditOutput;

            if (id.HasValue)
            {
                getChamadoForEditOutput = await _chamadoAppService.GetChamadoForEdit(new EntityDto<int> { Id = (int)id });
            }
            else
            {
                getChamadoForEditOutput = new GetChamadoForEditOutput
                {
                    Chamado = new CreateOrEditChamadoDto()
                };
            }

            var viewModel = new CreateOrEditChamadoViewModel()
            {
                Chamado = getChamadoForEditOutput.Chamado,
                Assistencia = await _assistenciaAppService.GetAssistencia(id)
            };

            return PartialView("_AssistenciaView", viewModel);
        }

        public async Task<PartialViewResult> CreateOrEditModal(int? id)
        {
            GetChamadoForEditOutput getChamadoForEditOutput;

            if (id.HasValue)
            {
                getChamadoForEditOutput = await _chamadoAppService.GetChamadoForEdit(new EntityDto<int> { Id = (int)id });
            }
            else
            {
                getChamadoForEditOutput = new GetChamadoForEditOutput
                {
                    Chamado = new CreateOrEditChamadoDto()
                };
            }

            var viewModel = new CreateOrEditChamadoViewModel()
            {
                Chamado = getChamadoForEditOutput.Chamado,
                Assistencia = await _assistenciaAppService.GetAssistencia(id)
            };

            return PartialView("_CadastrarChamado", viewModel);
        }

        public async Task<ActionResult> Editar(int id)
        {
            GetChamadoForEditOutput getChamadoForEditOutput;

            getChamadoForEditOutput = await _chamadoAppService.GetChamadoForEdit(new EntityDto<int> { Id = (int)id });

            var viewModel = new CreateOrEditChamadoViewModel()
            {
                Chamado = getChamadoForEditOutput.Chamado,
                Assistencia = await _assistenciaAppService.GetAssistencia(id)
            };

            return View(viewModel);
        }

        public async Task<PartialViewResult> CreateOrEditModalFollowup(long? id, int chamadoId)
        {
            GetFollowupForEditOutput getFollowupForEditOutput;

            if (id.HasValue)
            {
                getFollowupForEditOutput = await _followupAppService.GetFollowupForEdit(new EntityDto<int> { Id = (int)id });
            }
            else
            {
                getFollowupForEditOutput = new GetFollowupForEditOutput
                {
                    Followup = new CreateOrEditFollowupDto()
                };
            }

            var viewModel = new CreateOrEditFollowupViewModel()
            {
                Followup = getFollowupForEditOutput.Followup
            };

            viewModel.Followup.ChamadoId = chamadoId;

            return PartialView("_CreateOrEditModalFollowup", viewModel);
        }

        public async Task<PartialViewResult> CreateOrEditModalTarefa(long? id, int chamadoId)
        {
            GetTarefaForEditOutput getTarefaForEditOutput;

            if (id.HasValue)
            {
                getTarefaForEditOutput = await _tarefaAppService.GetTarefaForEdit(new EntityDto<int> { Id = (int)id });
            }
            else
            {
                getTarefaForEditOutput = new GetTarefaForEditOutput
                {
                    Tarefa = new CreateOrEditTarefaDto()
                };
            }

            var viewModel = new CreateOrEditTarefaViewModel()
            {
                Tarefa = getTarefaForEditOutput.Tarefa
            };

            viewModel.Tarefa.ChamadoId = chamadoId;

            return PartialView("_CreateOrEditModalTarefa", viewModel);
        }

        public async Task<PartialViewResult> CreateOrEditModalEtapaChamado(long? id, int chamadoId)
        {
            GetEtapaChamadoForEditOutput getEtapaChamadoForEditOutput;

            if (id.HasValue)
            {
                getEtapaChamadoForEditOutput = await _implantacaoAppService.GetEtapaChamadoForEdit(new EntityDto<int> { Id = (int)id });
            }
            else
            {
                getEtapaChamadoForEditOutput = new GetEtapaChamadoForEditOutput
                {
                    EtapaChamado = new CreateOrEditEtapaChamadoDto()
                };
            }

            var viewModel = new CreateOrEditEtapaChamadoViewModel()
            {
                EtapaChamado = getEtapaChamadoForEditOutput.EtapaChamado
            };

            viewModel.EtapaChamado.ChamadoId = chamadoId;

            return PartialView("_CreateOrEditModalImplantacao", viewModel);
        }

        public async Task<PartialViewResult> CreateOrEditModalAssistencia(int? id, int chamadoId)
        {
            GetAssistenciaForEditOutput getAssistenciaForEditOutput;

            if (id.HasValue)
            {
                getAssistenciaForEditOutput = await _assistenciaAppService.GetAssistenciaForEdit(new EntityDto<int> { Id = (int)id });
            }
            else
            {
                getAssistenciaForEditOutput = new GetAssistenciaForEditOutput
                {
                    Assistencia = new CreateOrEditAssistenciaDto()
                };
            }

            var viewModel = new CreateOrEditAssistenciaViewModel()
            {
                Assistencia = getAssistenciaForEditOutput.Assistencia
            };

            viewModel.Assistencia.ChamadoId = chamadoId;

            return PartialView("_CreateOrEditModalAssistencia", viewModel);
        }

        public async Task<PartialViewResult> RecusarEtapaChamado(long? id, int chamadoId)
        {
            GetEtapaChamadoForEditOutput getEtapaChamadoForEditOutput;

            if (id.HasValue)
            {
                getEtapaChamadoForEditOutput = await _implantacaoAppService.GetEtapaChamadoForEdit(new EntityDto<int> { Id = (int)id });
            }
            else
            {
                getEtapaChamadoForEditOutput = new GetEtapaChamadoForEditOutput
                {
                    EtapaChamado = new CreateOrEditEtapaChamadoDto()
                };
            }

            var viewModel = new CreateOrEditEtapaChamadoViewModel()
            {
                EtapaChamado = getEtapaChamadoForEditOutput.EtapaChamado
            };

            viewModel.EtapaChamado.ChamadoId = chamadoId;

            return PartialView("_RecusarEtapaChamadoModal", viewModel);
        }

        public async Task<PartialViewResult> CreateOrEditModalAnexo(int chamadoId)
        {
            GetAnexoForEditOutput getAnexoForEditOutput;

            getAnexoForEditOutput = new GetAnexoForEditOutput
            {
                Anexo = new CreateOrEditAnexoDto()
            };
            
            var viewModel = new CreateOrEditAnexoViewModel()
            {
                Anexo = getAnexoForEditOutput.Anexo
            };

            viewModel.Anexo.ChamadoId = chamadoId;

            return PartialView("_CadastrarModalAnexos", viewModel);
        }

        [HttpPost]
        public async Task<IActionResult> CadastrarAnexoModal(IFormFile arquivo, int chamadoId)
        {
            var filePrefixo = Guid.NewGuid() + "_";
            if (!await UploadArquivo(arquivo, filePrefixo))
            {
                return Json(new { sucesso = false, erros = "Upload Falhou" });
            }
            var anexo = new CreateOrEditAnexoDto();
            anexo.ChamadoId = chamadoId;
            anexo.Nome = arquivo.FileName;
            anexo.Caminho = filePrefixo + arquivo.FileName;
            await _anexoAppService.CreateOrEdit(anexo);
            return Json(new { sucesso = true, mensagem = "Anexo(s) cadastrado(s) com sucesso!" });
        }

        [HttpGet]
        public async Task<IActionResult> DeletarAnexo(int id, string caminho)
        {
            await _anexoAppService.Delete(id);

            var path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/arquivos/chamado", caminho);

            if (System.IO.File.Exists(path))
            {
                System.IO.File.Delete(path);
            }

            return Json(new { sucesso = true, mensagem = "Anexo deletado com sucesso!" });
        }

        private async Task<bool> UploadArquivo(IFormFile arquivo, string filePrefixo)
        {
            if (arquivo.Length <= 0) return false;

            var path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/arquivos/chamado", filePrefixo + arquivo.FileName);

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

        public IActionResult ForceDownload(string link, string output)
        {
            string diretorio = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/arquivos/chamado", link);
            if (System.IO.File.Exists(diretorio))
            {
                var net = new System.Net.WebClient();
                var data = net.DownloadData(diretorio);
                var content = new MemoryStream(data);
                var contentType = "APPLICATION/octet-stream";
                var fileName = output;
                return File(content, contentType, fileName);
            } else
            {
                return Ok();
            }
            
        }

    }
}

using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using TACO_Nutricional.Models.Entidades;
using TACO_Nutricional.Models.Repositorio;
using TACO_Nutricional.Models.ViewModels;

namespace TACO_Nutricional.Controllers
{
    public class ComposicaoAlimentosController : Controller
    {
        private readonly IRepositorioAlimento _repositorioAlimento;
        private readonly ObjetosDaSessao _objetosDaSessao; 
        private readonly IHostingEnvironment _hostingEnvironment;

        public ComposicaoAlimentosController(IRepositorioAlimento repositorioAlimento, ObjetosDaSessao objetosDaSessao, IHostingEnvironment hostingEnvironment)
        {
            _repositorioAlimento = repositorioAlimento;
            _objetosDaSessao = objetosDaSessao;
            _hostingEnvironment = hostingEnvironment;
        }


        public async Task<IActionResult> Index()
        {             
            return View(await _repositorioAlimento.Alimentos());
        }


        public IActionResult MontarRefeicao()
        {
            var ItensRefeicao = _objetosDaSessao.ObterListaRefeicao();
            var Refeicao = new RefeicaoVM { ItensRefeicao = (System.Collections.Generic.List<ItemRefeicaoVM>)ItensRefeicao };
            Refeicao.CalcularTotais();
            return View(Refeicao);
        }


        public IActionResult PesquisarAlimento(string nome)
        {
            return View("Index", _repositorioAlimento.AlimentosPorNome(nome));
        }

        public JsonResult PesquisarAlimentoParaMontarRefeicao(string nome)
        {
            if (nome == null)
                nome = "aba";
            var alimentos = _repositorioAlimento.AlimentosPorNome(nome)
                .Select(a => new { id = a.Id, text = a.Nome});
            return Json(alimentos);
        }


        public IActionResult AdicionarAlimentoNaRefeicao(int id, double porcao)
        {
            var alimento = _repositorioAlimento.AlimentoParaMontarRefeicao(id, porcao);
            var alimentoVM = new ItemRefeicaoVM
            {
                Id = id,
                NomeAlimento = alimento.Nome,
                PorcaoNoPrato = porcao,
                Proteina = alimento.Proteina,
                Carboidrato = alimento.Carboidrato,
                Lipideos = alimento.Lipideos,
                Calorias = alimento.Calorias
            };                       
            _objetosDaSessao.AdicionarNaListaRefeicao(alimentoVM);
            var ItensRefeicaoAtualizados = _objetosDaSessao.ObterListaRefeicao();
            var RefeicaoAtualizada = new RefeicaoVM { ItensRefeicao = (System.Collections.Generic.List<ItemRefeicaoVM>)ItensRefeicaoAtualizados };
            RefeicaoAtualizada.CalcularTotais();
            return PartialView("RefeicaoPartial", RefeicaoAtualizada);
        }


        public IActionResult CadastrarAlimento()
        {
            var listaGrupo =  _repositorioAlimento.GruposAlimentares().Select(g => new { g.Id, g.Nome }).ToList();
            var alimentoVM = new ItemRefeicaoVM
            {
                GruposAlimentaresDD = new SelectList(listaGrupo, "Id", "Nome")
            };
            return View(alimentoVM);
        }

        [HttpPost]
        public IActionResult CadastrarAlimento(ItemRefeicaoVM alimento)
        {

            try
            {
                var alimentoNovo = new Alimento
                {
                    Nome = alimento.NomeAlimento + " *",
                    Calorias = (double)alimento.Calorias,
                    Proteina = (double)alimento.Proteina,
                    Carboidrato = (double)alimento.Carboidrato,
                    Lipideos = (double)alimento.Lipideos,
                    GrupoAlimentarId = alimento.GrupoAlimentarId,
                    CadastradoPorUsuario = true
                };
                _repositorioAlimento.CadastrarAlimento(alimentoNovo);
                return Json(new { isValid = true, Mensagem = "Salvo com sucesso!" });
            }
            catch (Exception)
            {
                return Json(new { isValid = false, Mensagem = "Ops... algo deu errado!" });
            }
            
        }

        [HttpPost]
        public IActionResult DeletarItemdaRefeicao(int id)
        {
            try
            {
                _objetosDaSessao.DeletarItemDaRefeicao(id);
                TempData["Sucesso"] = "Operação efetuada com sucesso!";
                return Json(new { isValid = true, Mensagem = "Salvo com sucesso!" });
            }
            catch (Exception)
            {

                TempData["Erro"] = "Ops! Aconteceu algum problema!";
                return Json(new { isValid = false, Mensagem = "Ops... algo deu errado!" });
            }
            
        }

        public IActionResult GridRefeicao()
        {
            var ItensRefeicao = _objetosDaSessao.ObterListaRefeicao();
            var Refeicao = new RefeicaoVM { ItensRefeicao = (System.Collections.Generic.List<ItemRefeicaoVM>)ItensRefeicao };
            Refeicao.CalcularTotais();
            return PartialView("RefeicaoPartial", Refeicao);
        }

        public IActionResult EditarPorcaoItem(int Id)
        {
            var itemRefeicao = _objetosDaSessao.ObterAlimentoDaListaRefeicao(Id);
            return PartialView(itemRefeicao);
        }

        [HttpPost]
        public IActionResult EditarPorcaoItem(ItemRefeicaoVM itemRefeicao)
        {
            try
            {
                _objetosDaSessao.DeletarItemDaRefeicao(itemRefeicao.Id);
                var alimento = _repositorioAlimento.AlimentoParaMontarRefeicao(itemRefeicao.Id, (double)itemRefeicao.PorcaoNoPrato);
                var alimentoVM = new ItemRefeicaoVM
                {
                    Id = itemRefeicao.Id,
                    NomeAlimento = alimento.Nome,
                    PorcaoNoPrato = itemRefeicao.PorcaoNoPrato,
                    Proteina = alimento.Proteina,
                    Carboidrato = alimento.Carboidrato,
                    Lipideos = alimento.Lipideos,
                    Calorias = alimento.Calorias
                };
                _objetosDaSessao.AdicionarNaListaRefeicao(alimentoVM);
                return Json(new { isValid = true, Mensagem = "Alterado com sucesso!" });
            }
            catch (Exception e)
            {
                return Json(new { isValid = false, Mensagem = e.GetBaseException().Message });
            }
           
        }


        [HttpGet]
        public IActionResult DownloadFile()
        {
            // Since this is just and example, I am using a local file located inside wwwroot
            // Afterwards file is converted into a stream
            var path = Path.Combine(_hostingEnvironment.WebRootPath, "taco_4_edicao.pdf");
            var fs = new FileStream(path, FileMode.Open);

            // Return the file. A byte array can also be used instead of a stream
            return File(fs, "application/octet-stream", "taco_4_edicao.pdf");
        }

    }
}

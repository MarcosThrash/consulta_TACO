using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
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

        public ComposicaoAlimentosController(IRepositorioAlimento repositorioAlimento, ObjetosDaSessao objetosDaSessao)
        {
            _repositorioAlimento = repositorioAlimento;
            _objetosDaSessao = objetosDaSessao;
        }


        public async Task<IActionResult> Index()
        {             
            return View(await _repositorioAlimento.Alimentos());
        }


        public IActionResult MontarRefeicao()
        {
            return View(_objetosDaSessao.ObterListaRefeicao());
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
            var alimentoVM = new AlimentoVM
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
            var lista = _objetosDaSessao.ObterListaRefeicao();
            return PartialView("RefeicaoPartial", lista);
        }


        public IActionResult CadastrarAlimento()
        {
            var listaGrupo =  _repositorioAlimento.GruposAlimentares().Select(g => new { g.Id, g.Nome }).ToList();
            var alimentoVM = new AlimentoVM
            {
                GruposAlimentaresDD = new SelectList(listaGrupo, "Id", "Nome")
            };
            return View(alimentoVM);
        }

        [HttpPost]
        public IActionResult CadastrarAlimento(AlimentoVM alimento)
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

        public IActionResult GridRefeçao()
        {
            return PartialView("RefeicaoPartial", _objetosDaSessao.ObterListaRefeicao());
        }
        
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
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


        public IActionResult Index()
        {             
            return View(_repositorioAlimento.Alimentos());
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
            var alimentoVM = new MontarRefeicaoVM
            {
                Id = id,
                NomeAlimento = alimento.Nome,
                PorcaoNoPrato = porcao,
                Proteina = alimento.Proteina,
                Carboidrato = alimento.Carboidrato,
                Lipideos = alimento.Lipideos,
                Calorias = alimento.Caloria
            };
           
            _objetosDaSessao.AdicionarNaListaRefeicao(alimentoVM);
            return PartialView("RefeicaoPartial", _objetosDaSessao.ObterListaRefeicao());
        }


        public async Task<IActionResult> CadastrarAlimento()
        {
            return View();
        }

        [HttpPost]
        public IActionResult CadastrarAlimento(Alimento alimento)
        {
            _repositorioAlimento.CadastrarAlimento(alimento);
            return Json(new { Mensagem = "Salvo com sucesso!" });
        }

    }
}

using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Linq;
using TACO_Nutricional.Models.ViewModels;

namespace TACO_Nutricional.Models.Repositorio
{
    public class ObjetosDaSessao
    {
        private readonly IHttpContextAccessor _httpContextAccessor;

        public ObjetosDaSessao(IHttpContextAccessor httpContextAccessor)
        {
            _httpContextAccessor = httpContextAccessor;
        }
      
        private void IniciarListaRefeicaoNaSessão()
        {
            if (_httpContextAccessor.HttpContext.Session.GetString("ListaRefeicao") == null)
                _httpContextAccessor.HttpContext.Session.SetString("ListaRefeicao", JsonConvert.SerializeObject(new List<MontarRefeicaoVM>()));
        }

        public IList<MontarRefeicaoVM> ObterListaRefeicao()
        {
            IniciarListaRefeicaoNaSessão();
            return JsonConvert.DeserializeObject<List<MontarRefeicaoVM>>(_httpContextAccessor.HttpContext.Session.GetString("ListaRefeicao"));
        }

        public MontarRefeicaoVM ObterAlimentoDaListaRefeicao(int id) =>
            ObterListaRefeicao().Where(a => a.Id == id).FirstOrDefault();
       
        public void AdicionarNaListaRefeicao(MontarRefeicaoVM alimento)
        {
            var lista = ObterListaRefeicao();
            var alimentoAux = ObterAlimentoDaListaRefeicao(alimento.Id);
            if (alimentoAux == null)
            {
                lista.Add(alimento);
                _httpContextAccessor.HttpContext.Session.SetString("ListaRefeicao", JsonConvert.SerializeObject(lista));
            }                
            else
            {
                alimentoAux.PorcaoNoPrato += alimento.PorcaoNoPrato;
                alimentoAux.Kcal += alimento.Kcal;
                alimentoAux.Proteina += alimento.Proteina;
                alimentoAux.Carboidrato += alimento.Carboidrato;
                alimentoAux.Lipideos += alimento.Lipideos;
                lista.Remove(alimento);
                lista.Add(alimentoAux);
                _httpContextAccessor.HttpContext.Session.SetString("ListaRefeicao", JsonConvert.SerializeObject(lista));
            }
        }


    }
}

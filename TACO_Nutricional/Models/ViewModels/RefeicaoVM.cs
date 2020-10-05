using Microsoft.AspNetCore.Mvc.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TACO_Nutricional.Models.ViewModels
{
    public class RefeicaoVM
    {

        public List<ItemRefeicaoVM> ItensRefeicao { get; set; }

        public double TotalCalorias { get; private set; }

        public double TotalProteinas { get; private set; }

        public double TotalCarboidratos { get; private set; }

        public double TotalLipideos { get; private set; }

        public double TotalPorcao { get; private set; }


        public void CalcularTotais()
       {
            TotalCalorias = Math.Round( ItensRefeicao.Select(i => (double)i.Calorias).Sum(), 0);
            TotalProteinas = Math.Round(ItensRefeicao.Select(i => (double)i.Proteina).Sum(),1);
            TotalCarboidratos = Math.Round(ItensRefeicao.Select(i => (double)i.Carboidrato).Sum(),1);
            TotalLipideos = Math.Round(ItensRefeicao.Select(i => (double)i.Lipideos).Sum(),1);
            TotalPorcao = Math.Round(ItensRefeicao.Select(i => (double)i.PorcaoNoPrato).Sum(),1);
        }

    }
}

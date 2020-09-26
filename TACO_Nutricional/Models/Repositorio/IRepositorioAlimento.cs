using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TACO_Nutricional.Models.Entidades;

namespace TACO_Nutricional.Models.Repositorio
{
    public interface IRepositorioAlimento
    {

        public IEnumerable<Alimento> AlimentosPorNome(string nome);

        public IEnumerable<Alimento> Alimentos();

        public Alimento AlimentoParaMontarRefeicao(int Id, double porcao);

    }
}

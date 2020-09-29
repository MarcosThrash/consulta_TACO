using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TACO_Nutricional.Models.Contexto;
using TACO_Nutricional.Models.Entidades;

namespace TACO_Nutricional.Models.Repositorio
{
    public class RepositorioAlimento : IRepositorioAlimento
    {
        private readonly TacoContexto _context;

        public RepositorioAlimento(TacoContexto context)
        {
            _context = context;
        }

        public Alimento AlimentoParaMontarRefeicao(int Id, double porcao)
        {
            var alimento = _context.Alimentos.Where(a => a.Id == Id).FirstOrDefault();
            var ckal = (Math.Round(alimento.Caloria,0) / 100 * porcao);
            var proteina = (Math.Round(alimento.Proteina,1) / 100 * porcao);
            var carboidrato = (Math.Round(alimento.Carboidrato,1) / 100 * porcao);
            var lipideos = (Math.Round(alimento.Lipideos,1) / 100 * porcao);            
            return new Alimento { Nome = alimento.Nome, Caloria = ckal, Proteina = proteina, Carboidrato = carboidrato, Lipideos = lipideos };             
        }

        public IEnumerable<Alimento> AlimentosPorNome(string nome)
        {            
            return _context.Alimentos.OrderBy(a => a.Nome)
                .Where(a => a.Nome.ToLower().Contains(nome.ToLower()))
                .ToList();
        }

        public IEnumerable<Alimento> Alimentos()
        {
            return _context.Alimentos.OrderBy(a => a.Nome).ToList();
        }

        void IRepositorioAlimento.CadastrarAlimento(Alimento alimento)
        {
            _context.Alimentos.Add(alimento);
            _context.SaveChanges();
        }

        public IEnumerable<GrupoAlimentar> GruposAlimentares()
        {
            return _context.GruposAlimentares.OrderBy(g => g.Nome).ToList();
        }
    }

}


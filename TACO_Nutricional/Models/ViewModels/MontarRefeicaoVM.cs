using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TACO_Nutricional.Models.ViewModels
{
    public class MontarRefeicaoVM
    {

        public int Id { get; set; }

        public string NomeAlimento { get; set; }

        public double PorcaoNoPrato { get; set; }

        public double Calorias { get; set; }

        public double Proteina { get; set; }

        public double Carboidrato { get; set; }

        public double Lipideos { get; set; }

        public override bool Equals(object obj)
        {
            if (obj == null) return false;
            MontarRefeicaoVM aux = obj as MontarRefeicaoVM;
            return (this.Id == aux.Id);
        }

    }
}

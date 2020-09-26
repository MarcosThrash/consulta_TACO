using System.Collections.Generic;

namespace TACO_Nutricional.Models.Entidades
{
    public class GrupoAlimentar
    {
        public int Id { get; set; }

        public string Nome { get; set; }

        public IEnumerable<Alimento> Alimentos {get; set; }

    }
}

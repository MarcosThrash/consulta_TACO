using System.ComponentModel.DataAnnotations.Schema;

namespace TACO_Nutricional.Models.Entidades
{
    public class Alimento
    {
        public int Id { get; set; }

        public string Nome { get; set; }

        public double Umidade { get; set; }

        public double Caloria { get; set; }

        public double Proteina { get; set; }

        public double Lipideos { get; set; }

        public double Colesterol { get; set; }

        public double Carboidrato { get; set; }

        public double FibraAlimentar { get; set; }

        public double Cinzas { get; set; }

        public double Calcio { get; set; }

        public double Magnesio { get; set; }

        public double Manganes { get; set; }

        public double Fosforo { get; set; }

        public double Ferro { get; set; }

        public double Sodio { get; set; }

        public double Potassio { get; set; }

        public double Cobre { get; set; }

        public double Zinco { get; set; }

        public int GrupoAlimentarId { get; set; }

        public bool CadastradoPorUsuario { get; set; }

        public virtual GrupoAlimentar GrupoAlimentar { get; set; }

        [NotMapped]
        public double PorcaoParaMontarREfeicao { get; set; }

    }
}

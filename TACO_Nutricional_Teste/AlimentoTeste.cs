using System;
using System.Collections.Generic;
using System.Text;
using TACO_Nutricional.Models.Entidades;
using Xunit;

namespace TACO_Nutricional_Teste
{
    public class AlimentoTeste
    {

        [Fact]
        [Trait("Alimento","Validando Alimento")]
        public void Alimento_EValido_CamposPrincipaisPreenchidos()
        {
            //Arrange
            var alimento = new Alimento {
                Nome = "Abacate Brasileiro",
                Calorias = 255.20,
                Proteina = 25.8,
                Carboidrato = 45.7,
                Lipideos = 2.8
            };

            //Act
            var valido = alimento.EValido();

            //Assert 
            Assert.True(valido);
        }
    }
}

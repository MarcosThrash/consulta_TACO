using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TACO_Nutricional.Models.Entidades;

namespace TACO_Nutricional.Models.Contexto
{
    public class TacoContexto: DbContext 
    {

        public TacoContexto(DbContextOptions<TacoContexto> options) : base(options)
        {

        }

        public DbSet<GrupoAlimentar> GruposAlimentares { get; set; }

        public DbSet<Alimento> Alimentos { get; set; }

    }
}

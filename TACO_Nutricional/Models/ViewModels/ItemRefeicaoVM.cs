﻿using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace TACO_Nutricional.Models.ViewModels
{
    public class ItemRefeicaoVM
    {

        public int Id { get; set; }

        public string NomeAlimento { get; set; }

        public double? PorcaoNoPrato { get; set; }

        public double? Calorias { get; set; }

        public double? Proteina { get; set; }

        public double? Carboidrato { get; set; }

        public double? Lipideos { get; set; }

        public int GrupoAlimentarId { get; set; }

        public SelectList GruposAlimentaresDD { get; set; }

        public override bool Equals(object obj)
        {
            if (obj == null) return false;
            ItemRefeicaoVM aux = obj as ItemRefeicaoVM;
            return (this.Id == aux.Id);
        }

    }
}

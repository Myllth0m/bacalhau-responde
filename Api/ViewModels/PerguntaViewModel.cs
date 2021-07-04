﻿using System.ComponentModel.DataAnnotations;

namespace Api.ViewModels
{
    public class PerguntaViewModel
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        public string Titulo { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        public string Descricao { get; set; }

        [DataType(DataType.Upload)]
        public string Foto { get; set; }
    }
}
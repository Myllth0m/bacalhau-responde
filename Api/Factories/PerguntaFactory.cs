﻿using Api.ViewModels;
using Domain.Entities;
using System.Collections.Generic;

namespace Api.Factories
{
    public static class PerguntaFactory
    {
        public static Pergunta MapearPergunta(PerguntaViewModel viewModel)
        {
            return new Pergunta(
                viewModel.Id,
                viewModel.Titulo,
                viewModel.Descricao,
                viewModel.Foto);
        }

        public static PerguntaViewModel MapearPerguntaViewModel(Pergunta pergunta)
        {
            return new PerguntaViewModel
            {
                Id = pergunta.Id,
                Titulo = pergunta.Titulo,
                Descricao = pergunta.Descricao,
                Foto = pergunta.Foto
            };
        }

        public static IEnumerable<PerguntaViewModel> MapearListaDePerguntaViewModel(IEnumerable<Pergunta> listaDePerguntas)
        {
            var listaDePerguntaViewModel = new List<PerguntaViewModel>();

            foreach (var pergunta in listaDePerguntas)
                listaDePerguntaViewModel.Add(MapearPerguntaViewModel(pergunta));

            return listaDePerguntaViewModel;
        }
    }
}
using Api.ViewModels;
using Domain.Entities;
using System.Collections.Generic;

namespace Api.Factories
{
    public static class RespostaFactory
    {
        public static Resposta MapearResposta(RespostaViewModel viewModel)
        {
            return new Resposta(
                viewModel.Id,
                viewModel.Descricao,
                viewModel.Foto,
                viewModel.PerguntaId);
        }

        public static RespostaViewModel MapearRespostaViewModel(Resposta resposta)
        {
            return new RespostaViewModel
            {
                Id = resposta.Id,
                Descricao = resposta.Descricao,
                Foto = resposta.Foto,
                PerguntaId = resposta.PerguntaId
            };
        }

        public static IEnumerable<RespostaViewModel> MapearListaDeRespostaViewModel(IEnumerable<Resposta> listaDeRespostas)
        {
            var listaDeRespostaViewModel = new List<RespostaViewModel>();

            foreach (var resposta in listaDeRespostas)
                listaDeRespostaViewModel.Add(MapearRespostaViewModel(resposta));

            return listaDeRespostaViewModel;
        }
    }
}

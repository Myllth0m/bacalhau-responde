using Api.Factories;
using Api.ViewModels;
using Domain.Entities;
using Domain.IRepositories;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Api.Controllers
{
    [Route("api/pergunta")]
    public class PerguntaController : ControllerBase
    {
        private readonly IPerguntaRepository _perguntaRepository;
        public PerguntaController(IPerguntaRepository perguntaRepository)
        {
            _perguntaRepository = perguntaRepository;
        }

        [HttpPost("criar")]
        public async Task<IActionResult> Criar([FromBody] PerguntaViewModel viewModel)
        {
            if (!ModelState.IsValid)
                return BadRequest(new { mensagem = "Preencha os campos obrigatórios" });

            try
            {
                Pergunta pergunta = PerguntaFactory.MapearPergunta(viewModel);

                await _perguntaRepository.Criar(pergunta);

                return Ok(pergunta);
            }
            catch (Exception)
            {
                return BadRequest(new { mensagem = "Não foi possível salvar a pergunta" });
            }
        }

        [HttpPut("alterar")]
        public async Task<IActionResult> Alterar([FromBody] PerguntaViewModel viewModel)
        {
            if (!ModelState.IsValid)
                return BadRequest(new { mensagem = "Preencha os campos obrigatórios" });

            try
            {
                Pergunta pergunta = PerguntaFactory.MapearPergunta(viewModel);

                await _perguntaRepository.Alterar(viewModel.Id, pergunta);

                return Ok(pergunta);
            }
            catch (Exception)
            {
                return BadRequest(new { mensagem = "Não foi possível atualizar a pergunta" });
            }
        }

        [HttpDelete("excluir/{id}")]
        public async Task<IActionResult> Excluir(int id)
        {
            try
            {
                await _perguntaRepository.Excluir(id);

                return Ok(new { mensagem = "Pergunta excluida com sucesso" });
            }
            catch (Exception)
            {
                return BadRequest(new { mensagem = "Não foi possível excluir a pergunta" });
            }
        }

        [HttpGet("buscar-por-id/{id}")]
        public async Task<IActionResult> BuscarPorId(int id)
        {
            Pergunta pergunta = await _perguntaRepository.BuscarPorId(id);

            if (pergunta == null)
                return BadRequest(new { mensagem = "Não existe uma pergunta com esse código" });

            return Ok(PerguntaFactory.MapearPerguntaViewModel(pergunta));
        }

        [HttpGet("listar-por-titulo/{titulo}")]
        public async Task<IActionResult> ListarPorTitulo(string titulo)
        {
            IList<Pergunta> listaDePerguntas = await _perguntaRepository.ListarPorTitulo(titulo);

            if (listaDePerguntas.Count.Equals(0))
                return BadRequest(new { mensagem = "Não existem perguntas com esse título" });

            return Ok(PerguntaFactory.MapearListaDePerguntaViewModel(listaDePerguntas));

        }
        
        [HttpGet("listar-todas")]
        public async Task<IActionResult> Listar()
        {
            IList<Pergunta> listaDePerguntas = await _perguntaRepository.ListarTodas();

            if (listaDePerguntas.Count.Equals(0))
                return BadRequest(new { mensagem = "Ainda não existem perguntas cadastradas" });

            return Ok(PerguntaFactory.MapearListaDePerguntaViewModel(listaDePerguntas));
        }
    }
}

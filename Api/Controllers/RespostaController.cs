using Api.ViewModels;
using Domain.Entities;
using Domain.IRepositories;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace Api.Controllers
{
    [Route("api/resposta")]
    public class RespostaController : ControllerBase
    {
        private readonly IRespostaRepository _respostaRepository;
        public RespostaController(IRespostaRepository respostaRepository)
        {
            _respostaRepository = respostaRepository;
        }

        [HttpPost("criar")]
        public async Task<IActionResult> Criar([FromBody] RespostaViewModel viewModel)
        {
            if (!ModelState.IsValid)
                return BadRequest(new { message = "Preencha os campos obrigatórios" });

            try
            {
                Resposta resposta = RespostaFactory.MapearResposta(viewModel);

                await _respostaRepository.Criar(resposta);

                return Ok(resposta);
            }
            catch (Exception)
            {
                return BadRequest(new { mensagem = "Não foi possível salvar a resposta" });
            }
        }
    }
}

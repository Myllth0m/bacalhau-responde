﻿using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Identity;

namespace BacalhauResponde.Models
{
    public class Pergunta : EntidadeBase
    {
        protected Pergunta() { }
        public Pergunta(
            long id,
            string usuarioId,
            string titulo,
            string descricao,
            string foto)
        {
            Id = id;
            UsuarioId = usuarioId;
            Titulo = titulo;
            Descricao = descricao;
            Foto = foto;
            DataDeCriacao = DateTime.Now.ToShortDateString();
            DataDeAtualizacao = DateTime.Now.ToShortDateString();
        }

        public string UsuarioId { get; private set; }
        public string Descricao { get; private set; }
        public string Foto { get; private set; }
        public string Titulo { get; private set; }
        public IdentityUser Usuario { get; private set; }
        public virtual ICollection<Resposta> Respostas { get; private set; }

        public void AtualizarDados(
            string titulo,
            string descricao,
            string foto)
        {
            Titulo = titulo;
            Descricao = descricao;
            Foto = foto;
            DataDeAtualizacao = DateTime.Now.ToShortDateString();
        }
    }
}

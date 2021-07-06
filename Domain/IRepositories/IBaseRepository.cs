﻿using Domain.Entities;
using System.Threading.Tasks;

namespace Domain.IRepositories
{
    public interface IBaseRepository<T> where T : Base
    {
        Task<T> Criar(T obj);
        Task Excluir(int id);
        Task<T> BuscarPorId(int id);
    }
}

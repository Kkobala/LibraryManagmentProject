using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LMProject.Models;

namespace LMProject.Interfaces
{
    public interface IAuthorRepository
    {
        Task<AuthorsModel> CreateAsync(AuthorsModel authorsModel);
        Task<List<AuthorsModel>> GetAllAsync();
        Task<AuthorsModel?> GetByIdAsync(int id);
    }
}
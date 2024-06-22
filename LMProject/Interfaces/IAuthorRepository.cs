using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LMProject.Models;

namespace LMProject.Interfaces
{
    public interface IAuthorRepository
    {
        Task<Authors> CreateAsync(Authors authorsModel);
        Task<List<Authors>> GetAllAsync();
        Task<Authors?> GetByIdAsync(int id);
    }
}
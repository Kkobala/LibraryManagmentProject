using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LMProject.Helpers
{
    public class QueryObject
    {
        public string? Title { get; set; } = null;
        public string? AuthorName { get; set; } = null;

        public string? SortBy { get; set; } = null;
        public bool IsDescending { get; set; } = false;
    }
}
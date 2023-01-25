using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ToDos.Data;
using ToDos.Models;

namespace ToDos.Pages.Todos
{
    public class IndexModel : PageModel
    {
        private readonly ToDos.Data.TasksContext _context;

        public IndexModel(ToDos.Data.TasksContext context)
        {
            _context = context;
        }

        public IList<Todo> Todo { get;set; } = default!;

        [BindProperty(SupportsGet = true)]
        public string? SearchString { get; set; }


        public async Task OnGetAsync()
        {
            var tasks = from t in _context.Todo select t;

            if (!string.IsNullOrEmpty(SearchString))
            {
                tasks = tasks.Where(s => s.ToDo.Contains(SearchString));
            }

                Todo = await tasks.ToListAsync();
        }

    }
}

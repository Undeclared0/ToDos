using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using ToDos.Data;
using ToDos.Models;

namespace ToDos.Pages.Todos
{
    public class DetailsModel : PageModel
    {
        private readonly ToDos.Data.TasksContext _context;

        public DetailsModel(ToDos.Data.TasksContext context)
        {
            _context = context;
        }
        [BindProperty]
        public Todo Todo { get; set; } = default!; 

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.Todo == null)
            {
                return NotFound();
            }

            var todo = await _context.Todo.FirstOrDefaultAsync(m => m.Id == id);
            if (todo == null)
            {
                return NotFound();
            }
            else 
            {
                Todo = todo;
            }
            return Page();
        }
        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null || _context.Todo == null)
            {
                return NotFound();
            }
            var todo = await _context.Todo.FindAsync(id);

            if (todo != null)
            {
                Todo = todo;
                Todo.IsCompleted= true;
                Todo.Status = "Completed";
                _context.Attach(Todo).State = EntityState.Modified;

                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}

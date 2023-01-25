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
    public class EditModel : PageModel
    {
        private readonly ToDos.Data.TasksContext _context;

        public EditModel(ToDos.Data.TasksContext context)
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

            var todo =  await _context.Todo.FirstOrDefaultAsync(m => m.Id == id);
            
            
            if (todo == null || todo.IsCompleted==true)
            {
                return NotFound();
            }
            Todo = todo;
            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }
            Todo.UpdatedDate = DateTime.Now.ToString("dd/MM/yyyy");
            //Todo.IsCompleted = false;
            _context.Attach(Todo).State = EntityState.Modified;
            
            try
            {

                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TodoExists(Todo.Id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("./Index");
        }

        private bool TodoExists(int id)
        {
          return (_context.Todo?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}

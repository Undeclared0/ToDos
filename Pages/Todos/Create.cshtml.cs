using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using ToDos.Data;
using ToDos.Models;

namespace ToDos.Pages.Todos
{
    public class CreateModel : PageModel
    {
        private readonly ToDos.Data.TasksContext _context;

        public CreateModel(ToDos.Data.TasksContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public Todo Todo { get; set; } = default!;
        

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
          if (!ModelState.IsValid || _context.Todo == null || Todo == null)
            {
                return Page();
            }
            var dateTime = DateTime.Now;

            Todo.UpdatedDate = dateTime.ToString("dd/MM/yyyy");
            Todo.IsCompleted = false;
            Todo.Status = "In Progress";

            _context.Todo.Add(Todo);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}

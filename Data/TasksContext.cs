using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ToDos.Models;

namespace ToDos.Data
{
    public class TasksContext : DbContext
    {
        public TasksContext (DbContextOptions<TasksContext> options)
            : base(options)
        {
        }

        public DbSet<ToDos.Models.Todo> Todo { get; set; } = default!;
    }
}

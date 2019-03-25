using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Todo.Data.Interface;

namespace Todo.Data
{
    public class TodoContext : DbContext, ITodoContext
    {
        public DbSet<Todo.Data.Model.Todo> Todos { get; set; }

        public Task<int> SaveChangesAsync()
        {
            throw new System.NotImplementedException();
        }
    }
}

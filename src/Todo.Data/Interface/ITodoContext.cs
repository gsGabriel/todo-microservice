using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace Todo.Data.Interface
{
    public interface ITodoContext
    {
        DbSet<Todo.Data.Model.Todo> Todos { get; set; }

        Task SaveChangesAsync();
    }
}

using MediatR;
using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Todo.Commands;
using Todo.Data.Interface;

namespace Todo.CommandHandlers
{
    public class RemoveTodoItemCommandHandler : INotificationHandler<RemoveTodoItemCommand>
    {
        private readonly ITodoContext context;

        public RemoveTodoItemCommandHandler(ITodoContext context)
        {
            this.context = context;
        }

        public Task Handle(RemoveTodoItemCommand notification, CancellationToken cancellationToken)
        {
            EntryValidations(notification);
            BusinessValidations(notification);

            var todoToDelete = context.Todos.Single(x => x.Id == notification.Id);
            todoToDelete.DeletedAt = DateTime.Now;

            return context.SaveChangesAsync();
        }

        private void EntryValidations(RemoveTodoItemCommand notification)
        {
            if (notification.Id != Guid.Empty)
                throw new Exception("Id é um campo obrigatório");
        }

        private void BusinessValidations(RemoveTodoItemCommand notification)
        {
            if (context.Todos.Any(x => x.Id == notification.Id && x.DeletedAt.HasValue))
                throw new Exception("Este TodoItem já foi removido");
        }
    }
}

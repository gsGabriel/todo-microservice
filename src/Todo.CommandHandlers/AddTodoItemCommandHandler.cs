using MediatR;
using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Todo.Commands;
using Todo.Data.Interface;

namespace Todo.CommandHandlers
{
    public class AddTodoItemCommandHandler : INotificationHandler<AddTodoItemCommand>
    {
        private readonly ITodoContext context;

        public AddTodoItemCommandHandler(ITodoContext context)
        {
            this.context = context;
        }

        public Task Handle(AddTodoItemCommand notification, CancellationToken cancellationToken)
        {
            EntryValidations(notification);
            BusinessValidations(notification);

            var newTodo = new Todo.Data.Model.Todo
            {
                Id = Guid.NewGuid(),
                Title = notification.Title,
                Description = notification.Description,
                CreatedAt = DateTime.Now
            };

            context.Todos.Add(newTodo);
            return context.SaveChangesAsync();
        }

        private void EntryValidations(AddTodoItemCommand notification)
        {
            if (string.IsNullOrEmpty(notification.Title))
                throw new Exception("Título é um campo obrigatório.");

            if (string.IsNullOrEmpty(notification.Description))
                throw new Exception("Descrição é um campo obrigatório.");
        }

        private void BusinessValidations(AddTodoItemCommand notification)
        {
            if(context.Todos.Any(x => x.Title == notification.Title))
                throw new Exception("Já possui um TodoItem com esse título.");
        }
    }
}

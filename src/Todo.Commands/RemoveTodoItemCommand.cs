using MediatR;
using System;

namespace Todo.Commands
{
    public class RemoveTodoItemCommand : INotification
    {
        public RemoveTodoItemCommand(Guid id)
        {
            Id = id;
        }

        public Guid Id { get; set; }
    }
}

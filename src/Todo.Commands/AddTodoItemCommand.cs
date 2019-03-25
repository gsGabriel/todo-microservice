using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace Todo.Commands
{
    public class AddTodoItemCommand : INotification
    {
        public AddTodoItemCommand(string title, string description)
        {
            Title = title;
            Description = description;
        }

        public string Title { get; }
        public string Description { get; }
    }
}

using MediatR;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Todo.Data.Interface;
using Todo.Queries;
using Todo.Queries.QueryResults;

namespace Todo.QueryHandlers
{
    public class SearchTodoItemsQueryHandler : IRequestHandler<SearchTodoItemsQuery, List<SearchTodoItemsQueryResult>>
    {
        private readonly ITodoContext context;

        public SearchTodoItemsQueryHandler(ITodoContext context)
        {
            this.context = context;
        }

        public Task<List<SearchTodoItemsQueryResult>> Handle(SearchTodoItemsQuery request, CancellationToken cancellationToken)
        {
            var result = context.Todos.Skip(request.Take * request.Offset).Take(request.Take)
                .Select(x => new SearchTodoItemsQueryResult(x.Title, x.Description, x.ReadAt.HasValue));

            return Task.FromResult(result.ToList());
        }
    }
}

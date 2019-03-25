using MediatR;
using System.Collections.Generic;
using Todo.Queries.QueryResults;

namespace Todo.Queries
{
    public class SearchTodoItemsQuery : IRequest<List<SearchTodoItemsQueryResult>>
    {
        public SearchTodoItemsQuery(int take, int offset)
        {
            Take = take;
            Offset = offset;
        }

        public int Take { get; }
        public int Offset { get; }
    }
}

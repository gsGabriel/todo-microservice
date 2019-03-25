namespace Todo.Queries.QueryResults
{
    public class SearchTodoItemsQueryResult
    {
        public SearchTodoItemsQueryResult(string title, string description, bool wasRead)
        {
            Title = title;
            Description = description;
            WasRead = wasRead;
        }

        public string Title { get; }
        public string Description { get; }
        public bool WasRead { get; }
    }
}
